using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Application.Repository.IService;
using Data.AppContext;
using Domain.Entity;
using Application.Repository.Service;
using Data.Repo;
using Domain.IRepo;

namespace Application.Repository.Service
{

    public class UserRegisterService:IUserRegisterService
    {
        private static int _verificationNumber = 0;
        private static DateTime _codeTimer = DateTime.Now;
        private readonly IUserRepo _userRepository;
        private readonly MainContext _mainContext;

        public UserRegisterService( IUserRepo userRepository, MainContext mainContext)
        {
            _userRepository = userRepository;
            _mainContext = mainContext;
        }

        public async Task<string> RegisterAsync(string name,string lastName, string mobile, string password)
        {
            var passwordHash=HashCreate(password);
            if (UserExist(mobile))
            {
                return "User Exist";
            }
            await _userRepository.Add(name,lastName,mobile,passwordHash);
            return "Successfully Registered";
        }

        public string SetCode(string Mobile)
        {

            DateTime now = DateTime.Now;

            var res = (now - _codeTimer).TotalSeconds;
            if (res > 20 || _verificationNumber == 0)
            {
                _codeTimer = DateTime.Now;
                Random rnd = new Random();
                _verificationNumber = rnd.Next(10000, 99999);
            }
            return _verificationNumber.ToString();
        }

        public string HashCreate(string password)
        {
            var sha = SHA256.Create();
            var as8bytearray = Encoding.UTF8.GetBytes(password);
            var hashedpass = sha.ComputeHash(as8bytearray);
            string passwordHash = Convert.ToBase64String(hashedpass);
            return passwordHash;
        }

        public bool UserExist(string mobile)
        {
            var tmpusr = _mainContext.Users.FirstOrDefault(c => c.PhoneNumber == mobile);
            if (tmpusr != null)
            {
                return true;
            }
            return false;
        }
    }
}
