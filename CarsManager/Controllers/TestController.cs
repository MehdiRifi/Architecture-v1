using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsManager.Controllers
{
    [Route("test")]
    public class TestController:BaseController
    {
        private readonly ICarRepository _carRepository;
        public TestController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        [HttpGet]
        public int GetRandomNumber()
        {
            return _carRepository.GetYear();
        }
    }
}
