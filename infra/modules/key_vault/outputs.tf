output "kv-kv_vault_uri" {
  value       = azurerm_key_vault.ddkeyvault.vault_uri
  description = "The URI of the Key Vault."
  
}