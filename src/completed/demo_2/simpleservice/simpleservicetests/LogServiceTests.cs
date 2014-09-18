using Moq;
using NUnit.Framework;
using SimpleService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleServiceTests
{
    [TestFixture]
    public class LogServiceTests
    {
        ///<summary>
        /// Summary
        ///</summary>
        [Test]
        public void Test_Log_Should_CallLoggers_When_CalledWithErrorMessage()
        {
            // Arrange
            LogService logService = new LogService();
            Mock<ILogger> loggerMock = new Mock<ILogger>();
            loggerMock.Setup(l => l.SupportsLogLevel(It.Is<LogLevel>(level=> level == LogLevel.Error))).Returns(true);
            logService.RegisterLogger(loggerMock.Object);


            // Act
            logService.Log("serious error happened!", LogLevel.Error);

            // Assert
            loggerMock.Verify(m => m.LogMessage("serious error happened!", LogLevel.Error), Times.Once);
        }

        ///<summary>
        /// Summary
        ///</summary>
        [Test]
        public void Test_RegisterLogger_Should_Register_When_CalledWithLogger()
        {
            // Arrange
             LogService logService = new LogService();
             Mock<ILogger> loggerMock = new Mock<ILogger>();
             
            // Act
             logService.RegisterLogger(loggerMock.Object);

            // Assert
             Assert.AreEqual(logService.Loggers[0], loggerMock.Object);
        }


        ///<summary>
        /// Summary
        ///</summary>
        [Test]
        public void Test_Log_Should_NotCallLogger_When_CalledWithNotSupportedLogLevel()
        {
            // Arrange
            LogService logService = new LogService();
            Mock<ILogger> loggerMock = new Mock<ILogger>();
            loggerMock.Setup(l => l.SupportsLogLevel(It.Is<LogLevel>(level=> level == LogLevel.Info))).Returns(true);
            logService.RegisterLogger(loggerMock.Object);


            // Act
            logService.Log("serious error happened!", LogLevel.Error);

            // Assert
            loggerMock.Verify(m => m.LogMessage("serious error happened!", LogLevel.Error), Times.Never);
        }
        

    }
}
