using System;
using System.Device.Gpio;

// See https://github.com/dotnet/iot for System.Device.Gpio source code and help

namespace LedButtonLib
{
    /// <summary>
    /// Control buttons on the LedButton board
    /// </summary>
    public class Button : CustomController
    {
        private const int Sw1Pin = 24;
        private const int Sw2Pin = 23;
        private bool disposed = false;

        public Button() : base() {}
        public Button(GpioDriver driver) : base(driver) {}
        public Button(GpioController controller) : base(controller) {}

        public override void SetupController()
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { _controller.Dispose(); }
            // Free any unmanaged objects here.
            disposed = true;
            base.Dispose(disposing);
        }

        ~Button()
        {
            Dispose(false);
        }
    }
}
