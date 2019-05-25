using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Application.Models.Requests;
using Data.Entities;
using Data.Interfaces;
using Moq;
using NUnit.Framework;
using WebMvc.Controllers;

namespace Integration.Tests.Controllers
{
    [TestFixture]
    public class AuthorizationControllerTests
    {
        private readonly Mock<HttpContextBase> _context = new Mock<HttpContextBase>();
        private readonly Mock<HttpSessionStateBase> _session = new Mock<HttpSessionStateBase>();
        private readonly Mock<IUserRepository> _mockUserRepository = new Mock<IUserRepository>();
        private AuthorizationController _authorizationController;

        [SetUp]
        public void Init()
        {
            _authorizationController = new AuthorizationController(_mockUserRepository.Object);

            _context.Setup(x => x.Session).Returns(_session.Object);
            var requestContext = new RequestContext(_context.Object, new RouteData());
            _authorizationController.ControllerContext =
                new ControllerContext(requestContext, _authorizationController);
        }

        [TearDown]
        public void Cleanup()
        {
        }

        [Test]
        public void SignIn_ValidRequest_ReturnViewResult()
        {
            //Arrange
            const string username = "turtle";
            const string password = "12345";
            User user = null;
            _mockUserRepository.Setup(x => x.SignIn(It.IsAny<string>(), It.IsAny<string>()))
                .Returns<string, string>((u, p) => user = new User
                {
                    UserName = username,
                    Password = password,
                    Email = "turtle@gmail.com",
                    DisplayName = "Turtle"
                });

            //Act
            var result = _authorizationController.SignIn(username, password);

            //Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            Assert.AreEqual(user.UserName, username);
            Assert.AreEqual(user.Password, password);
        }

        [Test]
        public void SignUp_ValidRequest_ReturnViewResult()
        {
            //Arrange
            const string username = "turtle";
            const string email = "turtle@gmail.com";
            const string password = "12345";
            const string displayName = "Turtle";

            _mockUserRepository.Setup(x => x.IsExisted(It.IsAny<string>(), It.IsAny<string>()))
                .Returns<string, string>((e, u) => false);

            _mockUserRepository.Setup(x => x.Add(It.IsAny<User>()))
                .Returns<User>(x => x = new User
                {
                    UserName = username,
                    Password = password,
                    Email = email,
                    DisplayName = displayName
                });

            //Act
            var result = _authorizationController.SignUp(new SignUpRequest
            {
                UserName = username,
                Password = password,
                Email = email,
                DisplayName = displayName
            });

            //Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(result);
        }
    }
}