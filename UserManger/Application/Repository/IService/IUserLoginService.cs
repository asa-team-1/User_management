using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using User_management.Repository;

namespace Application.Repository.IService
{
    public interface IUserLoginService
    {
        public bool VerifyPass(string password, string hashedpassword);

        public Token GenerateJWTToken(User usr);

        public string Validate(string mobile,string password);
    }
}
