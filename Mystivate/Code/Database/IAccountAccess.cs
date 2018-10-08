using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystivate.Code.Database
{
    public interface IAccountAccess
    {
        User GetUser(int userId);
        void CreateUserAccount(string username, string email, string passKey, string passSalt);
        bool UserExists(string email = "", string username = "");
        void SetPassword(int userId, string newPassKey, string newPassSalt);
        EncryptedPassword GetEncryptedPassword(int userId);
        int GetUserId(string email);
        string GetUsername(int userId);
    }

}
