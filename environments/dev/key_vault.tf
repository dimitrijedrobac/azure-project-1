module "key_vault" {
  source              = "../../infra/modules/key_vault"
  kvname             = "kv-learn-drobac"
  location            = "West Europe"
  resource_group_name = "rg-learn-Dimitrije-Drobac"
  
}