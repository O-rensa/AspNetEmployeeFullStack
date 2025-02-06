migration-name ?= defaultName

migrate:
	@echo "Starting Migration $(migration-name)"
	dotnet ef migrations add $(migration-name) --project ../Employee.Data/Employee.Data.csproj --output-dir Context/Migrations

update:
	@echo "Update Database"
	dotnet ef database update
