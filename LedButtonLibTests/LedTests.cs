using System.Device.Gpio;
using LedButtonLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;

namespace LedButtonLibTests
{
    // TODO: https://www.c-sharpcorner.com/article/moq-unit-test-net-core-app-using-mock-object/
    // and google "Moq abstract class"

    [TestClass]
    public class LedTests
    {
        [DataTestMethod]
        [DataRow("SetRed", 17, false)]
        [DataRow("SetRed", 17, true)]
        [DataRow("SetGreen", 27, false)]
        [DataRow("SetGreen", 27, true)]
        public void SetLed_ShouldCall_DriverWriteMethod(string method, int pin, bool on)
        {
            // Given I have created a mock Gpio driver
            var mockDriver = new Mock<GpioDriver>();

            // And I have mocked the methods to write to a pin
            mockDriver.Protected().Setup<bool>("IsPinModeSupported", ItExpr.IsAny<int>(), ItExpr.IsAny<PinMode>()).Returns(true);
            mockDriver.Protected().Setup<PinMode>("GetPinMode", ItExpr.IsAny<int>()).Returns(PinMode.Output);

            // And created a mock Led
            var led = new Led(mockDriver.Object);

            // When I call the controller - e.g. led.SetRed(true)
            typeof(Led).GetMethod(method).Invoke(led, new object[] { on });

            // Then I expect the pin to be written to
            mockDriver.Protected().Verify("Write", Times.Once(), ItExpr.Is<int>(p => p == pin), ItExpr.Is<PinValue>(m => m == (on ? PinValue.High : PinValue.Low)));
        }

    }
}
