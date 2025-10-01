# Storage Account
resource "azurerm_storage_account" "ddstorageacct01" {
  name                     = var.storage_account_name
  resource_group_name      = var.resource_group_name
  location                 = var.location
  account_tier             = "Standard"
  account_replication_type = "GRS"

  # keep it simple (no CMK here)
  https_traffic_only_enabled = true
  min_tls_version            = "TLS1_2"
}

# Blob Container for images
# NOTE: use a consistent local name "images"
resource "azurerm_storage_container" "images" {
  name                  = var.container_name
  storage_account_name  = azurerm_storage_account.ddstorageacct01.name
  container_access_type = "private"
}
