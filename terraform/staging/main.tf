provider "aws" {
  region  = "eu-west-2"
  version = "~> 2.0"
}
data "aws_caller_identity" "current" {}
data "aws_region" "current" {}

locals {
  application_name = "academy-api"
   parameter_store = "arn:aws:ssm:${data.aws_region.current.name}:${data.aws_caller_identity.current.account_id}:parameter"
}


data "aws_iam_role" "ec2_container_service_role" {
  name = "ecsServiceRole"
}

data "aws_iam_role" "ecs_task_execution_role" {
  name = "ecsTaskExecutionRole"
}

terraform {
  backend "s3" {
    bucket  = "terraform-state-academy-production" # Contains staging DB
    encrypt = true
    region  = "eu-west-2"
    key     = services/academy-api/state
  }
}

#module "development" {
#  # Delete as appropriate:
#  source                      = "github.com/LBHackney-IT/aws-hackney-components-per-service-terraform.git//modules/environment/backend/fargate"
#  # source = "github.com/LBHackney-IT/aws-hackney-components-per-service-terraform.git//modules/environment/backend/ec2"
#  cluster_name                = "staging-apis"
#  ecr_name                    = hackney/academy-api
#  environment_name            = "staging"
#  application_name            = local.application_name
#  security_group_name         = back end security group name # Replace with your security group name, WITHOUT SPECIFYING environment. Usually the SG has the name of your API
#  vpc_name                    = "vpc-staging-apis"
#  host_port                   = port # Replace with the port to use for your api / app
#  port                        = port # Replace with the port to use for your api / app
#  desired_number_of_ec2_nodes = number of nodes # Variable will only be used if EC2 is required. Do not remove it.
#  lb_prefix                   = "nlb-staging-apis"
#  ecs_execution_role          = data.aws_iam_role.ecs_task_execution_role.arn
#  lb_iam_role_arn             = data.aws_iam_role.ec2_container_service_role.arn
#  task_definition_environment_variables = {
#    ASPNETCORE_ENVIRONMENT = "staging"
#  }
#  task_definition_environment_variable_count = number # This number needs to reflect the number of environment variables provided
#  cost_code = your project's cost code
#  task_definition_secrets      = {}
#  task_definition_secret_count = number # This number needs to reflect the number of environment variables provided
#}
