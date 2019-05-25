using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Data.Entities;
using Data.Interfaces;
using Moq;
using NUnit.Framework;
using WebMvc.Controllers;

namespace Unit.Tests.Models
{
    [TestFixture]
    public class AuthorizationRequestModelTests
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

    }
}