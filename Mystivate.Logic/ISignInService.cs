using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystivate.Logic
{
    public interface ISignInService
    {
        Task<SignInResult> SignIn(string email, string password);
        RegisterResult RegisterUser(RegisterModel user);
        Task SignOut();

    }

}
