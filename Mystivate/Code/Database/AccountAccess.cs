using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mystivate.Models;

namespace Mystivate.Code.Database
{
    public class AccountAccess : IAccountAccess
    {
        private readonly Mystivate_dbContext _db;
        public AccountAccess(Mystivate_dbContext db)
        {
            _db = db;
        }

        public void CreateUserAccount(string username, string email, string passKey, string passSalt)
        {
            using (var connection = _db.Database.GetDbConnection())
            {
                try
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "usp_CreateUser";
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@Email";
                    parameter.Value = email;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@Username";
                    parameter.Value = username;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@PasswordKey";
                    parameter.Value = passKey;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@PasswordSalt";
                    parameter.Value = passSalt;
                    command.Parameters.Add(parameter);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public EncryptedPassword GetEncryptedPassword(int userId)
        {
            User user = _db.Users.Where(u => u.Id == userId).First();
            return new EncryptedPassword
            {
                PasswordKey = user.PasswordKey,
                PasswordSalt = user.PasswordSalt
            };
        }

        public User GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public int GetUserId(string email)
        {
            return _db.Users.Where(u => u.Email == email).First().Id;
        }

        public string GetUsername(int userId)
        {
            return _db.Users.Where(u => u.Id == userId).First().Username;
        }

        public void SetPassword(int userId, string newPassKey, string newPassSalt)
        {
            User user = _db.Users.Where(u => u.Id == userId).First();
            user.PasswordKey = newPassKey;
            user.PasswordSalt = newPassSalt;
            _db.Users.Update(user);
        }

        public bool UserExists(string email = "", string username = "")
        {
            if (email != "" && username == "")
            {
                if (_db.Users.Where(u => u.Email == email).Count() != 0)
                {
                    return true;
                }
            }
            else if (username != "" && email == "")
            {
                if (_db.Users.Where(u => u.Username == username).Count() != 0)
                {
                    return true;
                }
            }
            else if(username != "" && email != "")
            {
                if (_db.Users.Where(u => (u.Email == email) && (u.Username == username)).Count() != 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
