using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
   public interface IUserRepository:IRepository<User>
    {
        Task<User> Create(string firstName, string lastName, string email, string userName, string password);
        Task<User> FindByName(string userName);
        Task<bool> CheckPassword(User user, string password);
        Task<User> GetAuthUser();
    }
}
