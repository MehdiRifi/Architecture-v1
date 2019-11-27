using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Data.Configuration
{
    public class DbContextFactory :
        IDesignTimeDbContextFactory<AppDbContext>
    {
        private static string DataConnectionString => new DatabaseConfiguration().GetDataConnectionString();

        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseSqlite(DataConnectionString);
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
