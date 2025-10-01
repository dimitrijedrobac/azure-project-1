resource "azurerm_service_plan" "dd_app_service_plan" {
  name                = "dd-app_service_plan"
  resource_group_name = var.resource_group_name
  location            = var.location
  os_type             = "Linux"
  sku_name            = "B2"
  worker_count = 2

}
