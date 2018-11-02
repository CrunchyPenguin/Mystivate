using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystivate.Logic
{
    public interface IUserInfo
    {
        UserModel GetUser();
        string GetUserName();
        int GetUserId();
        string GetEmail();
        bool NewLogin();
    }

}
