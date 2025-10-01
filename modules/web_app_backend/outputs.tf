output "hostname" {
  value = azurerm_linux_web_app.backend.default_hostname
}
output "backend_api_url" {
  value = "https://${azurerm_linux_web_app.backend.default_hostname}"
  
}
