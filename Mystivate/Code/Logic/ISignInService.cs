using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystivate.Code.Logic
{
    public interface ISignInService
    {
        Task<bool> SignIn(string email, string password);
        void CreateUser(UserModel userModel);
        Task SignOut();
        bool IsSignedIn();

    }

}
