using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mystivate.Data;
using Mystivate.Logic;
using Mystivate.Models;

namespace Mystivate.Tests
{
    [TestClass]
    public class SignInServiceTests
    {
        [TestMethod]
        public void RegisterUser_NormalCredentials_True()
        {
            var options = new DbContextOptionsBuilder<Mystivate_dbContext>()
                .UseInMemoryDatabase(databaseName: "RegisterUser_NormalCredentials_True")
                .Options;

            using (var context = new Mystivate_dbContext(options))
            {
                IAccountAccess accountAccess = new AccountAccess(context);

                IRegisterService registerService = new SignInService(null, accountAccess);

                string username = "test";
                string email = "test@test.nl";
                string password = "test123";

                RegisterResult result = registerService.RegisterUser(new RegisterModel
                {
                    Email = email,
                    Username = username,
                    Password = password
                });

                Assert.AreEqual(RegisterResult.Succeeded, result);
            }
        }

        [TestMethod]
        public void RegisterUser_ShortPassword_False()
        {
            var options = new DbContextOptionsBuilder<Mystivate_dbContext>()
                .UseInMemoryDatabase(databaseName: "RegisterUser_ShortPassword_False")
                .Options;

            using (var context = new Mystivate_dbContext(options))
            {
                IAccountAccess accountAccess = new AccountAccess(context);

                IRegisterService registerService = new SignInService(null, accountAccess);

                string username = "test";
                string email = "test@test.nl";
                string password = "tst1";

                RegisterResult result = registerService.RegisterUser(new RegisterModel
                {
                    Email = email,
                    Username = username,
                    Password = password
                });

                Assert.AreEqual(RegisterResult.PasswordShort, result);
            }
        }

        [TestMethod]
        public void RegisterUser_NoPassword_False()
        {
            var options = new DbContextOptionsBuilder<Mystivate_dbContext>()
                .UseInMemoryDatabase(databaseName: "RegisterUser_NoPassword_False")
                .Options;

            using (var context = new Mystivate_dbContext(options))
            {
                IAccountAccess accountAccess = new AccountAccess(context);

                IRegisterService registerService = new SignInService(null, accountAccess);

                string username = "test";
                string email = "test@test.nl";
                string password = "";

                RegisterResult result = registerService.RegisterUser(new RegisterModel
                {
                    Email = email,
                    Username = username,
                    Password = password
                });

                Assert.AreEqual(RegisterResult.PasswordShort, result);
            }
        }

        [TestMethod]
        public void RegisterUser_ShortUsername_False()
        {
            var options = new DbContextOptionsBuilder<Mystivate_dbContext>()
                .UseInMemoryDatabase(databaseName: "RegisterUser_ShortUsername_False")
                .Options;

            using (var context = new Mystivate_dbContext(options))
            {
                IAccountAccess accountAccess = new AccountAccess(context);

                IRegisterService registerService = new SignInService(null, accountAccess);

                string username = "tst";
                string email = "test@test.nl";
                string password = "test123";

                RegisterResult result = registerService.RegisterUser(new RegisterModel
                {
                    Email = email,
                    Username = username,
                    Password = password
                });

                Assert.AreEqual(RegisterResult.UsernameShort, result);
            }
        }

        [TestMethod]
        public void RegisterUser_NoUsername_False()
        {
            var options = new DbContextOptionsBuilder<Mystivate_dbContext>()
                .UseInMemoryDatabase(databaseName: "RegisterUser_NoUsername_False")
                .Options;

            using (var context = new Mystivate_dbContext(options))
            {
                IAccountAccess accountAccess = new AccountAccess(context);

                IRegisterService registerService = new SignInService(null, accountAccess);

                string username = "";
                string email = "test@test.nl";
                string password = "test123";

                RegisterResult result = registerService.RegisterUser(new RegisterModel
                {
                    Email = email,
                    Username = username,
                    Password = password
                });

                Assert.AreEqual(RegisterResult.UsernameShort, result);
            }
        }

        [TestMethod]
        public void RegisterUser_ExistingUsername_False()
        {
            var options = new DbContextOptionsBuilder<Mystivate_dbContext>()
                .UseInMemoryDatabase(databaseName: "RegisterUser_ExistingUsername_False")
                .Options;

            using (var context = new Mystivate_dbContext(options))
            {
                IAccountAccess accountAccess = new AccountAccess(context);

                IRegisterService registerService = new SignInService(null, accountAccess);

                string username = "test";
                string email = "test@test.nl";
                string password = "test123";

                RegisterResult result1 = registerService.RegisterUser(new RegisterModel
                {
                    Email = email,
                    Username = username,
                    Password = password
                });

                Assert.AreEqual(RegisterResult.Succeeded, result1);

                RegisterResult result2 = registerService.RegisterUser(new RegisterModel
                {
                    Email = "test2@test.nl",
                    Username = username,
                    Password = password
                });

                Assert.AreEqual(RegisterResult.UsernameEmailExists, result2);
            }
        }

        [TestMethod]
        public void RegisterUser_ExistingEmail_False()
        {
            var options = new DbContextOptionsBuilder<Mystivate_dbContext>()
                .UseInMemoryDatabase(databaseName: "RegisterUser_ExistingEmail_False")
                .Options;

            using (var context = new Mystivate_dbContext(options))
            {
                IAccountAccess accountAccess = new AccountAccess(context);

                IRegisterService registerService = new SignInService(null, accountAccess);

                string username = "test";
                string email = "test@test.nl";
                string password = "test123";

                RegisterResult result1 = registerService.RegisterUser(new RegisterModel
                {
                    Email = email,
                    Username = username,
                    Password = password
                });

                Assert.AreEqual(RegisterResult.Succeeded, result1);

                RegisterResult result2 = registerService.RegisterUser(new RegisterModel
                {
                    Email = email,
                    Username = "test2",
                    Password = password
                });

                Assert.AreEqual(RegisterResult.UsernameEmailExists, result2);
            }
        }
    }
}
