using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Mystivate.Data;
using Mystivate.Models;

namespace Mystivate.Logic
{
    public class UserService : IUserInfo, IUserSettings
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
            Claim id = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if(id != null)
            {
                return Convert.ToInt32(id.Value);
            }
            else
            {
                return -1;
            }
        }

        public string GetUserName()
        {
            return _accountAccess.GetUsername(GetUserId());
        }

        public void ChangeEmail(string email)
        {
            throw new NotImplementedException();
        }

        public bool NewLogin()
        {
            DateTime? lastlogin = _accountAccess.GetLastLogin(GetUserId());
            if (lastlogin.HasValue)
            {
                if(lastlogin.Value.Date != DateTime.Today)
                {
                    _accountAccess.SetLastLogin(GetUserId(), DateTime.Today);
                    return true;
                }
                return false;
            }
            else
            {
                _accountAccess.SetLastLogin(GetUserId(), DateTime.Today);
                return false;
            }
        }
    }
}
