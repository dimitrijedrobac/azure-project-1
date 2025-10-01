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
variable "db_username" {
    description = "Database username"
    type        = string
    sensitive   = true
}

variable "db_password" {
    description = "Database password"
    type        = string
    sensitive   = true
}
variable "db_name" {
    description = "The name of the SQL database"
    type        = string
    default     = "ddsqldb"
}
