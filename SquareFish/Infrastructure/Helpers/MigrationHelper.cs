using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquareFish.Infrastructure.Helpers
{
    public class MigrationHelper
    {
        public static void RunMigrations(DbContext context)
        {
            context.Database.Migrate();
        }
    }
}
