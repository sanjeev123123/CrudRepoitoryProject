using CRUD_Repository.Data;
using CRUD_Repository.Models;
using CRUD_Repository.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Repository.Repository.Classes
{
    public class UserClass : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserClass(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var user = _dbContext.Users.ToList();
            return user;
        }

        public async Task<int> AddUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            _dbContext.SaveChanges();
            return user.UserId;

        }

        public async Task<User> GetUserById(int id)
        {
            var usr = _dbContext.Users.Where(x => x.UserId == id).FirstOrDefault();
            return usr;
        }

        public async Task<bool> UpdateUser(User usr)
        {
            bool status = false;
            if (usr != null)
            {
                _dbContext.Users.Update(usr);
                await _dbContext.SaveChangesAsync();
                status = true;
            }
            return status;
        }

        public async Task<bool> DeleteUser(int id)
        {
            bool status = false;
            if (id!=0)
            {
                var usr = _dbContext.Users.Where(x=>x.UserId==id).FirstOrDefault();
                if (usr!=null)
                {
                    _dbContext.Users.Remove(usr);
                    await _dbContext.SaveChangesAsync();
                    status= true;
                }
            }
            return status;

        }
    }
}
