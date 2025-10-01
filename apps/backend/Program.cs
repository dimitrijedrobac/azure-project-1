var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS (if using in code)
var allowedOrigin = builder.Configuration["ALLOWED_ORIGIN"]
                   ?? "https://dd-frontend-webapp.azurewebsites.net";
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendOnly", p =>
        p.WithOrigins(allowedOrigin)
         .AllowAnyHeader()
         .AllowAnyMethod());
});

// DbContext + services
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(connectionString));
builder.Services.AddSingleton<BlobStorageService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("FrontendOnly");  // if using CORS in code
app.UseAuthorization();
app.MapControllers();

// TEMP diagnostics:
app.MapGet("/healthz", () => Results.Ok("ok"));
app.MapGet("/__routes", (Microsoft.AspNetCore.Routing.EndpointDataSource eds) =>
{
    var routes = eds.Endpoints
        .OfType<Microsoft.AspNetCore.Routing.RouteEndpoint>()
        .Select(e => new { e.RoutePattern.RawText, e.Metadata, e.Order });
    return Results.Json(routes);
});

// Liveness
app.MapGet("/healthz", () => Results.Ok("ok"));

// Dump all discovered routes
app.MapGet("/__routes", (Microsoft.AspNetCore.Routing.EndpointDataSource eds) =>
{
    var routes = eds.Endpoints
        .OfType<Microsoft.AspNetCore.Routing.RouteEndpoint>()
        .Select(e => e.RoutePattern.RawText);
    return Results.Json(routes);
});


app.Run();
