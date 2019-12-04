using Core.Interfaces.Repositories;

namespace Data.Repositories
{
    public class CarRepository : ICarRepository
    {
        public int GetYear()
        {
            return 2019;
        }
    }
}
