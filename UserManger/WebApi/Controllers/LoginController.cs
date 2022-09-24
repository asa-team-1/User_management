using Application.Repository.IService;
using Application.Repository.Service;
using Data.AppContext;
using User_management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class LoginController:ControllerBase
    {
        private readonly IJWTAuthenticationManager _jWTManager;
        private readonly MainContext _mainContext;
        private readonly IUserLoginService _userLoginService;
        public LoginController(IJWTAuthenticationManager JWTManager, MainContext mainContext, IUserLoginService userLoginService)
        {
            _jWTManager = JWTManager;
            _mainContext = mainContext;
            _userLoginService = userLoginService;
        }

        [HttpPost]
        public string Login(string mobile,string password)
        {
            var response=_userLoginService.Validate(mobile, password);
            return response;
        }
    }
}
