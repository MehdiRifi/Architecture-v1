using Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context.Auth
{
    public class AppIdentityDbContextFactory :
        IDesignTimeDbContextFactory<AppIdentityDbContext>
    {
        private static string DataConnectionString => new DatabaseConfiguration().GetDataConnectionString();

        AppIdentityDbContext IDesignTimeDbContextFactory<AppIdentityDbContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppIdentityDbContext>();
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlite(DataConnectionString);
            return new AppIdentityDbContext(optionsBuilder.Options);
        }
    }
}
