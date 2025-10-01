variable "app_service_plan_name" {
  description = "The name of the App Service Plan."
  type        = string
  default     = "dd-app-service-plan"
  
}
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
variable "sql_connection_string" {
  description = "The SQL connection string for the backend web app."
  type        = string
  default = "dd-UAMI"
  
}
variable "storage_account_name" {
  description = "The name of the storage account for blob storage."
  type        = string
  default     = "ddstorageacct01"
  
}