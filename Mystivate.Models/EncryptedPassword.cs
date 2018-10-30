using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystivate.Models
{
    public class EncryptedPassword
    {
        public string PasswordKey { get; set; }
        public string PasswordSalt { get; set; }
    }
}
