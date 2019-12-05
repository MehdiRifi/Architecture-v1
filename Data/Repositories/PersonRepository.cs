using Core.Interfaces.Repositories;
using Data.Context;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class PersonRepository : EFRepository<Person>, IPersonRepository
    {
        public PersonRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
