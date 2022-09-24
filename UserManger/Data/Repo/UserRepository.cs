using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Data.AppContext;
using Domain.Entity;
using Domain.IRepo;
using Microsoft.EntityFrameworkCore;

namespace Data.Repo
{
    public class UserRepository : IUserRepo
    {
        private readonly MainContext _mainContext;
        public UserRepository(MainContext mainContext)
        {
            _mainContext = mainContext;
        }

        public async Task<bool> Add(string name, string lastName, string phoneNumber, string password, bool isActive = true, int level = 0)
        {
            User user = new User
            {
                Name = name,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Password = password,
                IsActive = isActive,
                Level = level
            };
            await _mainContext.Users.AddAsync(user);
            await _mainContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remove(int id)
        {
            var check = _mainContext.Users.First(c => c.Id == id);

            check.IsDeleted = true;
            await _mainContext.SaveChangesAsync();
            return true;

        }

        public async Task<bool> Update(int id, string name, string lastName, string password)
        {
            var check = _mainContext.Users.First(c => c.Id == id);
            if (check != null)
            {
                check.Name = name;
                check.LastName = lastName;
                check.Password = password;
                await _mainContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public IEnumerable<User> GetAll()
        {
            var users = _mainContext.Users;
            return users.ToList();
        }

        public User? GetByMobile(string mobile)
        {
            var check = _mainContext.Users.First(c => c.
                PhoneNumber == mobile);

            return check;


        }
    }
}
