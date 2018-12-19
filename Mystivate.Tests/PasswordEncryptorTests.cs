using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mystivate.Logic;
using Mystivate.Models;

namespace Mystivate.Tests
{
    [TestClass]
    public class PasswordEncryptorTests
    {
        [TestMethod]
        public void CreateTestPassword_LowerCaseOnly_True()
        {
            string password = "testing";
            Assert.IsTrue(CreateTestPassword(password));
        }

        [TestMethod]
        public void CreateTestPassword_UpperCaseOnly_True()
        {
            string password = "TESTING";
            Assert.IsTrue(CreateTestPassword(password));
        }

        [TestMethod]
        public void CreateTestPassword_UpperLowerCase_True()
        {
            string password = "TeStInG";
            Assert.IsTrue(CreateTestPassword(password));
        }

        [TestMethod]
        public void CreateTestPassword_UpperLowerCaseNumbers_True()
        {
            string password = "Testring1234";
            Assert.IsTrue(CreateTestPassword(password));
        }

        [TestMethod]
        public void CreatePassword_TwoOfSame_NotEqual()
        {
            string password = "Testing1234";
            Assert.AreNotEqual(CreatePassword(password), CreatePassword(password));
        }


        private EncryptedPassword CreatePassword(string password)
        {
            return PasswordEncryptor.EncryptPassword(password);
        }

        private bool TestPassword(string password, EncryptedPassword encryptedPassword)
        {
            return PasswordEncryptor.PasswordCorrect(password, encryptedPassword);
        }

        private bool CreateTestPassword(string password)
        {
            EncryptedPassword encryptedPassword = CreatePassword(password);
            return TestPassword(password, encryptedPassword);
        }
    }
}
