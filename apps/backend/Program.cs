using BackendAPI.Data;
using BackendAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS (code-based)
var allowedOrigin = builder.Configuration["ALLOWED_ORIGIN"]
                   ?? "https://dd-frontend-webapp.azurewebsites.net";
builder.Services.AddCors(o =>
    o.AddPolicy("FrontendOnly", p => p.WithOrigins(allowedOrigin).AllowAnyHeader().AllowAnyMethod())
);

// EF + services
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// If you don't have a real SQL connection yet, temporarily use InMemory to avoid build-time/startup failures:
// builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseInMemoryDatabase("dev"));
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
app.UseCors("FrontendOnly");
app.UseAuthorization();

app.MapControllers();

// Diagnostics (single block)
app.MapGet("/healthz", () => Results.Ok("ok"));
app.MapGet("/__routes", (Microsoft.AspNetCore.Routing.EndpointDataSource eds) =>
{
    var routes = eds.Endpoints
        .OfType<Microsoft.AspNetCore.Routing.RouteEndpoint>()
        .Select(e => e.RoutePattern.RawText);
    return Results.Json(routes);
});


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.EnsureCreated();
}


app.Run();
