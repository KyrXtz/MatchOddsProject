using MatchOddsProject.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchOddsProject.Migrations
{
    public static class Extensions
    {
        /// <summary>
        /// Apply latest migrations to database.
        /// </summary>
        /// <param name="app"></param>
        public static void DatabaseMigrate(this IApplicationBuilder app)
        {
            try
            {
                using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    context.Database.Migrate();
                }
            }
            catch (SqlException)
            {
                //couldnt connect to database 
                //throw; //disabled for testing purposes
            }
        }
    }
}
