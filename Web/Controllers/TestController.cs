using Core.Interfaces.Repositories;
using Data.Configuration;
using Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace CarsManager.Controllers
{
    [Route("test")]
    public class TestController : BaseController
    {
        private readonly AppDbContext _dbContext;
        public TestController(AppDbContext  dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public int GetRandomNumber()
        {
            var x =new DatabaseConfiguration();
            var y = x.GetDataConnectionString();
            return 2020;
        }
    }
}
