# Backend Web App (ASP.NET Core)
resource "azurerm_linux_web_app" "backend" {
  name                = "dd-backend-webapp"
  resource_group_name = var.resource_group_name
  location            = var.location

  # Attach to the existing service plan
  service_plan_id     = var.service_plan_id

    site_config {
    cors {
      allowed_origins        = [var.frontend_hostname]
      support_credentials    = false
    }
    http2_enabled            = true
    minimum_tls_version        = "1.2"
    use_32_bit_worker          = false
    ftps_state                 = "Disabled"
    application_stack { dotnet_version = "8.0" }
  }
  client_certificate_enabled = false
  client_certificate_mode    = "Optional"  # or remove entirely
  https_only            = true

  app_settings = {
    "ASPNETCORE_ENVIRONMENT"      = "Production"
    "ConnectionStrings__DefaultConnection" = var.sql_connection_string
    "BlobStorage__AccountName"             = var.storage_account_name
    ALLOWED_ORIGIN         = "https://dd-frontend-webapp.azurewebsites.net"  }
}