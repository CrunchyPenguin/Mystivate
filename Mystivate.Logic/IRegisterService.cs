﻿using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystivate.Logic
{
    public interface IRegisterService
    {
        RegisterResult RegisterUser(RegisterModel user);

    }

}
