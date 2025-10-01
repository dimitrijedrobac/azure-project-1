# Derive hostnames from app names (no cross-module dependency)
locals {
  backend_name          = "dd-backend-webapp"
  frontend_name         = "dd-frontend-webapp"

  backend_default_host  = "${local.backend_name}.azurewebsites.net"
  frontend_default_host = "${local.frontend_name}.azurewebsites.net"
}


# Shared App Service Plan (Linux)

module "app-service-plan" {
  source                 = "../../infra/modules/app_service_plan"
  resource_group_name    = "rg-learn-Dimitrije-Drobac"
  location               = "West Europe"
  app_service_plan_name  = "dd-app-service-plan"


  sql_connection_string  = "dd-UAMI"
  storage_account_name   = "ddstorageacct01"
}


# Backend Web App (.NET 8)

module "web_app_backend" {
  source                = "../../infra/modules/web_app_backend"
  resource_group_name   = "rg-learn-Dimitrije-Drobac"
  location              = "West Europe"
  service_plan_id       = module.app-service-plan.id


  app_name              = local.backend_name


  frontend_hostname     = "https://${local.frontend_default_host}"


  sql_connection_string = "dd-UAMI"
  storage_account_name  = "ddstorageacct01"
}


# Frontend Web App (Docker Hub image)

module "web_app_frontend" {
  source                = "../../infra/modules/web_app_frontend"
  resource_group_name   = "rg-learn-Dimitrije-Drobac"
  location              = "West Europe"
  service_plan_id       = module.app-service-plan.id

  app_name              = local.frontend_name

  backend_api_url       = "https://${local.backend_default_host}"


  dockerhub_repo        = "dimitrijedrobac/dimitrije.drobac"
  image_tag             = "v2"

  sql_connection_string = "dd-UAMI"
  storage_account_name  = "ddstorageacct01"
}
