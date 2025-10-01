resource "azurerm_mssql_database" "example" {
  name         = var.sqldb_name
  server_id    = var.server_id
  collation    = "SQL_Latin1_General_CP1_CI_AS"
  max_size_gb  = var.max_size_gb
  sku_name     = var.sku_name

}