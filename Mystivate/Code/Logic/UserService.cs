using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Mystivate.Code.Database;
using Mystivate.Models;

namespace Mystivate.Code.Logic
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAccountAccess _accountAccess;

        public UserService(IHttpContextAccessor httpContextAccessor, IAccountAccess accountAccess)
        {
            _httpContextAccessor = httpContextAccessor;
            _accountAccess = accountAccess;
        }

        public void ChangePassword(string oldPass, string newPass)
        {
            throw new NotImplementedException();
        }

        public UserModel GetUser()
        {
            throw new NotImplementedException();
        }

        public string GetEmail()
        {
            throw new NotImplementedException();
        }

        public int GetUserId()
        {
            var identity = (ClaimsIdentity)_httpContextAccessor.HttpContext.User.Identity;
            int id = Convert.ToInt32(identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            return id;
        }

        public string GetUserName()
        {
            return _accountAccess.GetUsername(GetUserId());
        }
    }
}
