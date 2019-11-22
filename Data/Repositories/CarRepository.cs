using Core.Interfaces.Repositories;

namespace Data.Repositories
{
    class CarRepository : ICarRepository
    {
        public int GetYear()
        {
            return 2019;
        }
    }
}
