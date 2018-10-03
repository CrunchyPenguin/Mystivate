using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystivate.Code.Logic
{
    public interface IUserService
    {
        UserModel GetUser();
        string GetUserName();
        int GetUserId();
        string GetEmail();
        void ChangePassword(string oldPass, string newPass);
        void FindUserById(int userId);
        void HashPassword(string password);
    }

}
