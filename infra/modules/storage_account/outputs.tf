output "account_name" {
  value = azurerm_storage_account.ddstorageacct01.name
}

output "primary_blob_endpoint" {
  value = azurerm_storage_account.ddstorageacct01.primary_blob_endpoint
}

output "container_name" {
  value = azurerm_storage_container.images.name
}

output "container_id" {
  value = azurerm_storage_container.images.id
}
