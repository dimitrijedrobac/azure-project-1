resource "azurerm_mssql_server" "dd-sqlserver" {
  name                           = var.db_name
  location                       = var.location
  resource_group_name            = var.resource_group_name
  version                        = "12.0"
  minimum_tls_version            = "1.2"
  administrator_login           = var.db_username
  administrator_login_password  = var.db_password
}