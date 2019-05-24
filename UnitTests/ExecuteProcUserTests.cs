using System;
using System.Web.Script.Serialization;
using NUnit.Framework;
using Topic.Data.Repositories;
using Topic.Models;

namespace UnitTests
{
    [TestFixture]
    public class ExecuteProcUserTests
    {
        [TestCase("turtle", "12345", "turtle@gmail.com", "turtle")]
        public void Create_User_Test(string username, string password, string email, string displayName)
        {
            var user = new UserRepository();

            user.Add(new User
            {
                Email = email,
                UserName = username,
                Password = password,
                DisplayName = displayName
            });

            Assert.IsNotNull(user);
        }

        [TestCase(1)]
        public void Get_UserById_Test(int id)
        {
            var user = new UserRepository();

            var result = user.FindById(id);

            var json = new JavaScriptSerializer();

            Console.WriteLine(json.Serialize(result));

            Assert.IsNotNull(result);
        }
    }
}