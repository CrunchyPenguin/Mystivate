using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mystivate.Models;
using Mystivate.Logic;
using Mystivate.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Mystivate.Tests
{
    [TestClass]
    public class AccountAccessTests
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
                string username = "test";
                string email = "test@test.nl";
                string password = "test123";

                Assert.IsTrue(UserTestsMethods.RegisterUser(accountAccess, username, email, password));

                Assert.IsTrue(UserTestsMethods.UserRegistered(context, username, email));
            }
        }

        [TestMethod]
        public void RegisterUser_TwoSameUsername_False()
        {
            var options = new DbContextOptionsBuilder<Mystivate_dbContext>()
                .UseInMemoryDatabase(databaseName: "RegisterUser_TwoSameUsername_False")
                .Options;

            using (var context = new Mystivate_dbContext(options))
            {
                IAccountAccess accountAccess = new AccountAccess(context);
                string username = "test";
                string email = "test@test.nl";
                string password = "test123";

                Assert.IsTrue(UserTestsMethods.RegisterUser(accountAccess, username, email, password));

                string email2 = "test2@test.nl";
                Assert.IsFalse(UserTestsMethods.RegisterUser(accountAccess, username, email2, password));
            }
        }

        [TestMethod]
        public void RegisterUser_TwoSameEmail_False()
        {
            var options = new DbContextOptionsBuilder<Mystivate_dbContext>()
                .UseInMemoryDatabase(databaseName: "RegisterUser_TwoSameEmail_False")
                .Options;

            using (var context = new Mystivate_dbContext(options))
            {
                IAccountAccess accountAccess = new AccountAccess(context);
                string username = "test";
                string email = "test@test.nl";
                string password = "test123";

                Assert.IsTrue(UserTestsMethods.RegisterUser(accountAccess, username, email, password));

                string username2 = "test2";
                Assert.IsFalse(UserTestsMethods.RegisterUser(accountAccess, username2, email, password));
            }
        }

        [TestMethod]
        public void RegisterUser_TwoSameUsernameEmail_False()
        {
            var options = new DbContextOptionsBuilder<Mystivate_dbContext>()
                .UseInMemoryDatabase(databaseName: "RegisterUser_TwoSameUsernameEmail_False")
                .Options;

            using (var context = new Mystivate_dbContext(options))
            {
                IAccountAccess accountAccess = new AccountAccess(context);
                string username = "test";
                string email = "test@test.nl";
                string password = "test123";

                Assert.IsTrue(UserTestsMethods.RegisterUser(accountAccess, username, email, password));

                Assert.IsFalse(UserTestsMethods.RegisterUser(accountAccess, username, email, password));
            }
        }

        [TestMethod]
        public void LoginUser_CorrectCredentials_True()
        {
            var options = new DbContextOptionsBuilder<Mystivate_dbContext>()
                .UseInMemoryDatabase(databaseName: "LoginUser_CorrectCredentials_True")
                .Options;

            using (var context = new Mystivate_dbContext(options))
            {
                IAccountAccess accountAccess = new AccountAccess(context);

                string username = "Ruben";
                string email = "test@test.nl";
                string password = "test123";
                Assert.IsTrue(UserTestsMethods.RegisterUser(accountAccess, username, email, password));

                EncryptedPassword encryptedPasswordDB = UserTestsMethods.GetPassword(accountAccess, email);

                Assert.IsTrue(PasswordEncryptor.PasswordCorrect(password, encryptedPasswordDB));
            }
        }

        [TestMethod]
        public void LoginUser_IncorrectCredentials_False()
        {
            var options = new DbContextOptionsBuilder<Mystivate_dbContext>()
                .UseInMemoryDatabase(databaseName: "LoginUser_InCorrectCredentials_False")
                .Options;

            using (var context = new Mystivate_dbContext(options))
            {
                IAccountAccess accountAccess = new AccountAccess(context);

                string username = "Ruben";
                string email = "test@test.nl";
                string password = "test123";
                Assert.IsTrue(UserTestsMethods.RegisterUser(accountAccess, username, email, password));

                EncryptedPassword encryptedPasswordDB = UserTestsMethods.GetPassword(accountAccess, email);

                string loginPassword = "wrongPassword";
                Assert.IsFalse(PasswordEncryptor.PasswordCorrect(loginPassword, encryptedPasswordDB));
            }
        }
    }
}
