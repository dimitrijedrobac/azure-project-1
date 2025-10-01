module "sql_database" {
  source = "../../infra/modules/sql_database"
    sqldb_name          = "dd-sqldbv1"
    max_size_gb        = 2
    sku_name           = "S0"
    server_id          = module.sql_server.server_id
}