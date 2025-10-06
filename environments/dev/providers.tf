terraform {
  required_version = ">= 1.6.0"
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 4.46.0"
    }
  }
}

provider "azurerm" {
  features {    
    key_vault {
      purge_soft_delete_on_destroy    = true
      recover_soft_deleted_key_vaults = true
    }
  }

  # You already set/verified subscription via CLI; this just avoids auto-registration
  resource_provider_registrations = "none"

  # (Optional but fine to keep)
  use_cli        = true
  subscription_id = "777e574a-ed35-408e-8ddb-147537615158"
  tenant_id       = "68a00411-fc49-4771-bd0e-fad4d8208e87"
}
