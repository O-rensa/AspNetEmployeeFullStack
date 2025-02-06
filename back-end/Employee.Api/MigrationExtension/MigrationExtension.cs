using Employee.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Employee.Api.MigrationExtension
{
    public static class MigrationExtension
    {
        public static async Task InitializeMigration(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var contxt = scope.ServiceProvider.GetRequiredService<ProjectContext>();
                await contxt.Database.MigrateAsync();
            }
        }
    }
}
