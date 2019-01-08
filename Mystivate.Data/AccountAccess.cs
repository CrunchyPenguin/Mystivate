using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mystivate.Models;

namespace Mystivate.Data
{
    public class AccountAccess : IAccountAccess
    {
        private readonly Mystivate_dbContext _dbContext;
        public AccountAccess(Mystivate_dbContext db)
        {
            _dbContext = db;
        }

        public bool CreateUserAccount(string username, string email, string passKey, string passSalt)
        {
            if (!_dbContext.Database.IsInMemory())
            {
                using (var connection = _dbContext.Database.GetDbConnection())
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
                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
            else
            {
                if (!UserExists(email, username))
                {
                    _dbContext.Users.Add(new User
                    {
                        Username = username,
                        Email = email,
                        PasswordKey = passKey,
                        PasswordSalt = passSalt
                    });
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public EncryptedPassword GetEncryptedPassword(int userId)
        {
            User user = _dbContext.Users.SingleOrDefault(u => u.Id == userId);
            return new EncryptedPassword
            {
                PasswordKey = user.PasswordKey,
                PasswordSalt = user.PasswordSalt
            };
        }

        public DateTime? GetLastLogin(int userId)
        {
            return _dbContext.Users.SingleOrDefault(u => u.Id == userId).LastLogin;
        }

        public User GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public int GetUserId(string email)
        {
            return _dbContext.Users.SingleOrDefault(u => u.Email == email).Id;
        }

        public string GetUsername(int userId)
        {
            return _dbContext.Users.SingleOrDefault(u => u.Id == userId).Username;
        }

        public void SetLastLogin(int userId, DateTime day)
        {
            _dbContext.Users.SingleOrDefault(u => u.Id == userId).LastLogin = day;
            _dbContext.SaveChanges();
        }

        public void SetPassword(int userId, string newPassKey, string newPassSalt)
        {
            User user = _dbContext.Users.SingleOrDefault(u => u.Id == userId);
            user.PasswordKey = newPassKey;
            user.PasswordSalt = newPassSalt;
            _dbContext.Users.Update(user);
        }

        public bool UserExists(string email = "", string username = "")
        {
            if (_dbContext.Users.Any(u => (u.Email == email) || (u.Username == username)))
            {
                return true;
            }
            return false;
        }
    }
}
