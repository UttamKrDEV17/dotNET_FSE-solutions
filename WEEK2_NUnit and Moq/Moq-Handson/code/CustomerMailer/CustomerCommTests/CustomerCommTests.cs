using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerCommTests
{
    public class CustomerCommTests
    {
        [Test]
        public void SendMailToCustomer_ShouldReturnTrue_WhenMailIsSent()
        {
            // Arrange
            var mockMailSender = new Mock<IMailSender>();
            mockMailSender.Setup(sender => sender.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                          .Returns(true);

            var customerComm = new CustomerComm(mockMailSender.Object);

            // Act
            bool result = customerComm.SendMailToCustomer();

            // Assert
            Assert.That(result, Is.True);
            mockMailSender.Verify(sender => sender.SendMail("cust123@abc.com", "Some Message"), Times.Once);
        }
    }
}
