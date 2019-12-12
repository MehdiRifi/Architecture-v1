using AutoMapper;
using Core.Interfaces.Repositories;
using Data.Context;
using Data.Context.Auth;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Data.Repositories
{
    public class UserRepository : EFRepository<User>, IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserRepository(
            AppDbContext dbContext,
            UserManager<AppUser> userManager,
            IMapper mapper,
             IHttpContextAccessor httpContextAccessor
            ) : base(dbContext)

        {
            _userManager = userManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> CheckPassword(User user, string password)
        {
            return await _userManager.CheckPasswordAsync(_mapper.Map<AppUser>(user), password);
        }

        public async Task<User> Create(string firstName, string lastName, string email, string userName, string password)
        {
            var appUser = new AppUser { Email = email, UserName = userName };
            var identityResult = await _userManager.CreateAsync(appUser, password);

            if (!identityResult.Succeeded) throw new Exception();

            var user = new User(firstName, lastName, appUser.Id, appUser.UserName);
            await AppDbContext.Users.AddAsync(user);
            await AppDbContext.SaveChangesAsync();
            return user;
        }
        private Task<User> GetByIdentityId(string identityId)
        {
           return  Task.FromResult(_entities.FirstOrDefault(u => u.IdentityId == identityId));
        }
        public async Task<User> FindByName(string userName)
        {
            var appUser = await _userManager.FindByNameAsync(userName);
            return appUser == null ? null : _mapper.Map(appUser, await GetByIdentityId(appUser.Id));
        }

        public Task<User> GetAuthUser()
        {
            var id = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            var user = AppDbContext.Users.FirstOrDefault(u => u.IdentityId == id);
            return Task.FromResult(user);
        }
    }
}
