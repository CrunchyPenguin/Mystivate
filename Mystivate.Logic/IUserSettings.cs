using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystivate.Logic
{
    public interface IUserSettings
    {
        void ChangePassword(string oldPass, string newPass);
        void ChangeEmail(string email);
    }

}
