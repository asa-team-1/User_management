using System.CodeDom.Compiler;
using Application.Repository.IService;
using Application.Repository.Service;
using Data.AppContext;
using Domain.IRepo;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    public class RegisterController : Controller
    {
        string s;
        private readonly IUserRepo _userRepo;
        private readonly MainContext _mainContext;
        private readonly IUserRegisterService _userRegister;

        public RegisterController(IUserRepo userRepo, MainContext mainContext, IUserRegisterService userRegister)
        {
            _userRepo = userRepo;
            _mainContext = mainContext;
            _userRegister = userRegister;
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<string> Index(string name,string familyName,string mobile, string password)
        {

            await _userRegister.RegisterAsync(name, familyName, mobile, password);
            return _userRegister.SetCode(mobile);

        }
    }
}
