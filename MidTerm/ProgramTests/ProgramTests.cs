using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieApp;
using NUnit.Framework;
using Xunit;
using Assert = NUnit.Framework.Assert;
using TheoryAttribute = NUnit.Framework.TheoryAttribute;

namespace MovieAppUnitTests
{
    [TestClass]
    public class MovieDBTests
    {
        [Theory]
        [InlineData("Brandon Brewer", "bbrewer", "password", "Brandon Brewer")]
        public void AskForCredential_IsUser_ReturnsTrue(string userName, string userLogin, string password, string expected)
        {
            UserDB users = new UserDB();
            UserCredentials u = new UserCredentials(userName, userLogin, password);
            MovieDB movies = new MovieDB();
            users.AddUser(u);

            string result = Program.AskForCredential(movies, users);
            
            Assert.AreEqual(expected, result);
        }


        [Theory]
        [InlineData("Brandon Brewer", "bbrewer", "password", "Not Found")]
        public void AskForCredential_IsUser_ReturnsFalse(string userName, string userLogin, string password, string expected)
        {
            UserDB users = new UserDB();
            UserCredentials u = new UserCredentials(userName, userLogin, password);
            MovieDB movies = new MovieDB();
            users.AddUser(u);

            string result = Program.AskForCredential(movies, users);

            Assert.AreNotEqual(expected, result);
        }



        [Test]
        public void ReturnsTrue()
        {
            Assert.IsTrue(true);
        }
    }
}
