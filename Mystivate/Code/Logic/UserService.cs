using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Mystivate.Models;

namespace Mystivate.Code.Logic
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void ChangePassword(string oldPass, string newPass)
        {
            throw new NotImplementedException();
        }

        public void FindUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public string GetEmail()
        {
            throw new NotImplementedException();
        }

        public UserModel GetUser()
        {
            throw new NotImplementedException();
        }

        public int GetUserId()
        {
            throw new NotImplementedException();
        }

        public string GetUserName()
        {
            return _httpContextAccessor.HttpContext.User.Identity.Name;
        }

        public void HashPassword(string password)
        {
            throw new NotImplementedException();
        }
    }
}
