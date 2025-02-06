migration-name ?= defaultName

migrate:
	@echo "Starting Migration $(migration-name)"
	cd Employee.Api
	dotnet ef migrations add $(migration-name) --project ../Employee.Data/Employee.Data.csproj --output-dir Context/Migrations

