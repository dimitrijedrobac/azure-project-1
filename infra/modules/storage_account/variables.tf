variable "resource_group_name" { type = string }
variable "location"            { type = string }

variable "storage_account_name" {
  type        = string
  description = "3-24 chars, lowercase letters and numbers only, globally unique"
  validation {
    condition     = can(regex("^[a-z0-9]{3,24}$", var.storage_account_name))
    error_message = "Storage account name must be 3-24 characters of lowercase letters and numbers."
  }
}

variable "container_name" {
  type        = string
  default     = "user-images"
  description = "Blob container name for uploaded images"
}
