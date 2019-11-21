using Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

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
