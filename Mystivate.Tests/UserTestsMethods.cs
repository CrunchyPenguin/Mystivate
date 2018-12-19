using Mystivate.Data;
using Mystivate.Logic;
using Mystivate.Models;
using System.Linq;

namespace Mystivate.Tests
{
    public class UserTestsMethods
    {
        public static bool RegisterUser(IAccountAccess accountAccess, string username, string email, string password)
        {
            EncryptedPassword encryptedPassword = PasswordEncryptor.EncryptPassword(password);
            return accountAccess.CreateUserAccount(username, email, encryptedPassword.PasswordKey, encryptedPassword.PasswordSalt);
        }

        public static int GetUserId(IAccountAccess accountAccess, string email)
        {
            return accountAccess.GetUserId(email);
        }

        public static EncryptedPassword GetPassword(IAccountAccess accountAccess, string email)
        {
            int userId = accountAccess.GetUserId(email);
            return accountAccess.GetEncryptedPassword(userId);
        }

        public static bool UserRegistered(Mystivate_dbContext context, string username, string email)
        {
            return context.Users.SingleOrDefault(u => u.Username == username && u.Email == email) != null;
        }
    }
}
