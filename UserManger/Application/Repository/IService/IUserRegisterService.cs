using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Application.Repository.IService
{
    public interface IUserRegisterService
    {
        public Task<string> RegisterAsync(string name, string lastName, string mobile,string password);

        public string SetCode(string Mobile);
    }
}
