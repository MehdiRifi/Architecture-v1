
using Core.Interfaces.Repositories;
using Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        private readonly ICarRepository _carRepository;
        public UnitTest1( )
        {
            _carRepository = new CarRepository();
        }
        [TestMethod]
        public void TestMethod1()
        {
            var result = _carRepository.GetYear();
            Assert.IsTrue(result == 2019);
        }
    }
}
