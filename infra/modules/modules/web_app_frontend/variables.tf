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
variable "service_plan_id" {
  description = "ID of the App Service Plan for the backend"
  type        = string
}

variable "image_tag" {
  description = "The Docker image tag to deploy"
  type        = string
  default     = "v1"
  
}
variable "dockerhub_repo" {
  description = "The Docker Hub repository for the frontend image"
  type        = string
  default     = "dimitrijedrobac/dimitrije.drobac"
  
}
variable "backend_api_url" {
  description = "The public URL of the backend API"
  type        = string
}
variable "app_name" { type = string }

