variable "location" {
  description = "The Azure region where the App Service Plan will be created."
  type        = string
  default     = "West Europe"
  
}
variable "resource_group_name" {
  description = "The name of the resource group in which to create the App Service Plan."
  type        = string
  default     = "rg-learn-Dimitrije-Drobac"
}
variable "kvname" {
  description = "The name of the Key Vault."
  type        = string
  default     = "kv-learn-dimitrije-drobac"
}