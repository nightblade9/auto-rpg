using AutoRpg.Cryptographer;
using AutoRpg.DatabaseMediator;
using AutoRpg.Authentication.Controllers;
using Moq;
using NUnit.Framework;
using static AutoRpg.Authentication.Controllers.AuthenticationController;

namespace AutoRpg.Authentication.Tests.Controllers
{
    [TestFixture]
    public class AuthenticationControllerTests
    {
        [Test]
        public void PostReturnsFalseIfUserIsntInDatabase()
        {
            // Arrange
            var mediator = new Mock<IDatabaseMediator>();

            // Checking if username exists? Yes it does.
            mediator.Setup(m => m.ExecuteScalar<int>(It.IsAny<string>(), It.IsAny<object>())).Returns(0);

            // Act
            var controller = new AuthenticationController(mediator.Object);
            var actual = controller.Post(new CredentialsDto("user name doesn't matter because of mocks", "ditto for password"));

            // Assert
            Assert.That(actual.Value, Is.False);
            mediator.VerifyAll();
        }

        [Test]
        public void PostReturnsFalseIfUserExistsButPasswordsDontMatch()
        {
            // Arrange
            var plaintextPassword = "password"; // randomly chosen and guaranteed to be strong!
            var hashedPassword = PasswordHasher.HashPassword(plaintextPassword);
            var mediator = new Mock<IDatabaseMediator>();

            // Checking if username exists? Yes it does.
            mediator.Setup(m => m.ExecuteScalar<int>(It.IsAny<string>(), It.IsAny<object>())).Returns(1);
            // When selecting password, get back the hash
            mediator.Setup(m => m.ExecuteScalar<string>(It.IsAny<string>(), It.IsAny<object>())).Returns(hashedPassword);

            // Act
            var controller = new AuthenticationController(mediator.Object);
            var actual = controller.Post(new CredentialsDto("user name doesn't matter because of mocks", "wrong password"));

            // Assert
            Assert.That(actual.Value, Is.False);
            mediator.VerifyAll();
        }

        [Test]
        public void PostReturnsTrueIfUserExistsAndPasswordMatchesDatabase()
        {
            // Arrange
            var plaintextPassword = "password"; // randomly chosen and guaranteed to be strong!
            var hashedPassword = PasswordHasher.HashPassword(plaintextPassword);
            var mediator = new Mock<IDatabaseMediator>();

            // Checking if username exists? Yes it does.
            mediator.Setup(m => m.ExecuteScalar<int>(It.IsAny<string>(), It.IsAny<object>())).Returns(1);
            // When selecting password, get back the hash
            mediator.Setup(m => m.ExecuteScalar<string>(It.IsAny<string>(), It.IsAny<object>())).Returns(hashedPassword);

            // Act
            var controller = new AuthenticationController(mediator.Object);
            var actual = controller.Post(new CredentialsDto("user name doesn't matter because of mocks", plaintextPassword));

            // Assert
            Assert.That(actual.Value, Is.True);
            mediator.VerifyAll();
        }
    }
}
