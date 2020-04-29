using System;
using System.Device.Gpio;

// See https://github.com/dotnet/iot for System.Device.Gpio source code and help

namespace LedButtonLib
{
    /// <summary>
    /// Control LEDs on the LedButton board
    /// </summary>
    public class Led : CustomController
    {
        private const int RedLedPin = 17;
        private const int GreenLedPin = 27;
        private bool disposed = false;

        public Led() : base() {}
        public Led(GpioDriver driver) : base(driver) {}
        public Led(GpioController controller) : base(controller) {}

        public override void SetupController()
        {
            _controller.OpenPin(RedLedPin, PinMode.Output);
            _controller.OpenPin(GreenLedPin, PinMode.Output);
        }

        /// <summary>
        /// Turn the red LED on or off
        /// </summary>
        /// <param name="on">true to turn on, false to turn off</param>
        public void SetRed(bool on)
        {
            _controller.Write(RedLedPin, on ? PinValue.High : PinValue.Low);
        }

        /// <summary>
        /// Turn the green LED on or off
        /// </summary>
        /// <param name="on">true to turn on, false to turn off</param>
        public void SetGreen(bool on)
        {
            _controller.Write(GreenLedPin, on ? PinValue.High : PinValue.Low);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { _controller.Dispose(); }
            // Free any unmanaged objects here.
            disposed = true;
            base.Dispose(disposing);
        }

        ~Led()
        {
            Dispose(false);
        }
    }
}
