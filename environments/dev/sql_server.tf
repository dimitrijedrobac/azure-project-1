module "sql_server" {
  source = "../../infra/modules/sql_server"
    resource_group_name = "rg-learn-Dimitrije-Drobac"
    location            = "North Europe"
    db_name             = "dd-sqlserverv1"
    db_username         = "ddadmin"
    db_password         = "Ddpaswword123!"
}