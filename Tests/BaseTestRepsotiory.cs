using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class BaseTestRepsotiory
    {
        protected AppDbContext _appDbContext;

        protected AppDbContext DbContext
        {
            get
            {
                if (_appDbContext == null)
                {
                    var options = new DbContextOptionsBuilder<AppDbContext>()
                     .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                     .Options;
                    _appDbContext = new AppDbContext(options);
                }
                return _appDbContext;
            }
        }
    }
}
