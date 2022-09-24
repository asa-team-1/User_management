using System.Security.Cryptography;
using System.Text;
using Application.Repository.IService;
using Data.AppContext;
using Domain.Entity;
using Domain.IRepo;
using User_management.Repository;

namespace Application.Repository.Service
{
    public class UserLoginService : IUserLoginService
    {
        private readonly MainContext _mainContext;
        private readonly IJWTAuthenticationManager _jWTManager;
        private readonly IUserRepo _userRepo;

        public UserLoginService(MainContext mainContext, IJWTAuthenticationManager jWtManager, IUserRepo userRepo)
        {
            _mainContext = mainContext;
            _jWTManager = jWtManager;
            _userRepo = userRepo;
        }

        public Token GenerateJWTToken(User usr)
        {
            var token = _jWTManager.Authenticate(usr);
            return token;
        }

        public string Validate(string mobile, string password)
        {
            if (UserExist(mobile))
            {
                var usr = _userRepo.GetByMobile(mobile);
                if(VerifyPass(password,usr.Password))
                {
                    var jwttoken = GenerateJWTToken(usr);
                    usr.RefreshToken = jwttoken.RefreshToken;
                    usr.RefreshTokenExpiryTime = DateTime.Now.AddDays(1);
                    _mainContext.SaveChangesAsync();
                    return jwttoken.token + "\n" + jwttoken.RefreshToken;
                }
                else
                {
                    return "Wrong Password ! ";
                }
            }
            else
            {
                return "User Not Exist";
            }
        }

        public bool VerifyPass(string password, string hashedpassword)
        {
            var sha = SHA256.Create();
            var as8bytearray = Encoding.UTF8.GetBytes(password);
            var hashedpass = sha.ComputeHash(as8bytearray);
            password = Convert.ToBase64String(hashedpass);
            return password == hashedpassword;
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
