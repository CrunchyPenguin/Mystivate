using Mystivate.Data;
using Mystivate.Models;
using System;
using System.Collections.Generic;

namespace Mystivate.Tests.MockData
{
    public class AccountAccessMock : IAccountAccess
    {
        private List<User> users = new List<User>();

        public void CreateUserAccount(string username, string email, string passKey, string passSalt)
        {
            users.Add(new User
            {
                Id = 0,
                Username = username,
                Email = email,
                PasswordKey = passKey,
                PasswordSalt = passSalt
            });
        }

        public EncryptedPassword GetEncryptedPassword(int userId)
        {
            throw new NotImplementedException();
        }

        public DateTime? GetLastLogin(int userId)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public int GetUserId(string email)
        {
            throw new NotImplementedException();
        }

        public string GetUsername(int userId)
        {
            throw new NotImplementedException();
        }

        public void SetLastLogin(int userId, DateTime day)
        {
            throw new NotImplementedException();
        }

        public void SetPassword(int userId, string newPassKey, string newPassSalt)
        {
            throw new NotImplementedException();
        }

        public bool UserExists(string email = "", string username = "")
        {
            throw new NotImplementedException();
        }
    }
}
