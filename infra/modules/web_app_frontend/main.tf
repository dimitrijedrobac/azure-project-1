resource "azurerm_linux_web_app" "frontend" {
  name                = "dd-frontend-webapp"
  resource_group_name = var.resource_group_name
  location            = var.location
  service_plan_id     = var.service_plan_id

  site_config {
  application_stack {
    docker_image_name   = "${var.dockerhub_repo}:${var.image_tag}"
    docker_registry_url = "https://index.docker.io"  # <-- include scheme

  }
}
  app_settings = {
    WEBSITES_PORT   = "80"
    BACKEND_API_URL = var.backend_api_url

  }
}
