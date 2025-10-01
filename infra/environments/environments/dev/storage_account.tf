module "ddstorageacct01" {
  source = "../../modules/storage_account"
    resource_group_name = "rg-learn-Dimitrije-Drobac"
    location            = "West Europe"
    storage_account_name = "ddstorageacct01"
    container_name      = "user-images"
    
}