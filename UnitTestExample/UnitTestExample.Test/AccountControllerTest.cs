using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Controllers;
using System.Activities;

namespace UnitTestExample.Test
{
    public class AccountControllerTest
    {
        [Test,
            TestCase("abcd1234", false),
            TestCase("irf@uni-corvinus", false),
            TestCase("irf@uni-corvinus.hu", true)
            ]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            //Arrange
            var accountController = new AccountController();
            //Act
            var actualResult = accountController.ValidateEmail(email);
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test,
            TestCase("Abc1", false),
            TestCase("abcdabcd", false),
            TestCase("ABCDABCD", false),
            TestCase("Abc1", false),
            TestCase("Abc1Abc1", true),
            ]
        public void TestValidatePassword(string password, bool expectedResult)
        {
            //Arrange
            var accountController = new AccountController();
            //Act
            var actualResult = accountController.ValidatePassword(password);
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test,
            TestCase("irf@uni-corvinus.hu","Abcd1234"),
            TestCase("irf@uni-corvinus.hu", "Abcd1234456")
            ]
        public void TestRegisterHappyPath(string email, string password)
        {
            //Arrange
            var accountController = new AccountController();
            //Act
            var actualResult = accountController.Register(email, password);
            //Assert
            Assert.AreEqual(email, actualResult.Email);
            Assert.AreEqual(password, actualResult.Password);
            Assert.AreNotEqual(Guid.Empty, actualResult.ID);
        }

        [Test,
            TestCase("irf@uni-corvinus.hu", "Abcd1234"),
            TestCase("irf@uni-corvinus.hu", "ABcd1234"),
            TestCase("irf@uni-corvinus.hu", "Abcde1234"),
            TestCase("irf@uni-corvinus.hu", "Aced1234"),
            TestCase("irf@uni-corvinus.hu", "Abcd12345"),
            TestCase("irf@uni-corvinus.hu", "Abcfd1234"),
            TestCase("irf@uni-corvinus.hu", "Abacd1234"),
            TestCase("irf@uni-corvinus.hu", "Abgcd1234")
            ]
        public void TestRegisterValidateException(string email, string password)
        {
            //Arrange
            var accountController = new AccountController();
            //Act
            try
            {
                var actualResult = accountController.Register(email, password);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOf<ValidationException>(ex);
            }
            //Assert
        }
    }
}
