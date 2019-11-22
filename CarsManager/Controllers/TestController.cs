using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CarsManager.Controllers
{
    [Route("test")]
    public class TestController : BaseController
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
