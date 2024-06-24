using CRUD_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Repository.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();

        Task<int> AddUser(User user);

        Task<User> GetUserById(int id);
        Task<bool> UpdateUser(User user);

        Task<bool> DeleteUser(int id);
    }
}
