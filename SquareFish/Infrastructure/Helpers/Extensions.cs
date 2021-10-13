using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SquareFish.Infrastructure.Helpers
{
    public static partial class Extensions
    {
        public static void UseMigrationRunner(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            MigrationHelper.RunMigrations(scope.ServiceProvider
                .GetRequiredService<ApplicationDbContext>());
        }
    }
}
