variable "sqldb_name" {
  description = "The name of the SQL database"
  type        = string
  default     = "ddsqldb"
  
}
variable "server_id" {
  description = "The ID of the SQL server where the database will be created"
  type        = string
  
}
variable "max_size_gb" {
  description = "The maximum size of the SQL database in GB"
  type        = number
  default     = 2
  
}
variable "sku_name" {
  description = "The SKU name for the SQL database"
  type        = string
  default     = "S0"
  
}