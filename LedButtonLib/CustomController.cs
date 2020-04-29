using System;
using System.Device.Gpio;

// See https://github.com/dotnet/iot for System.Device.Gpio source code and help

namespace LedButtonLib
{
    /// <summary>
    /// Base class for controllers
    /// </summary>
    public abstract class CustomController : IDisposable
    {
        protected GpioController _controller;
        private bool disposed = false;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CustomController()
        {
            _controller = new GpioController();
            SetupController();
        }

        /// <summary>
        /// Constructor with custom GPIO driver
        /// </summary>
        /// <param name="driver">GPIO Driver</param>
        public CustomController(GpioDriver driver)
        {
            _controller = new GpioController(PinNumberingScheme.Logical, driver);
            SetupController();
        }

        /// <summary>
        /// Constructor with supplied GPIO controller
        /// </summary>
        /// <param name="controller">GPIO controller to use</param>
        public CustomController(GpioController controller)
        {
            _controller = controller;
            SetupController();
        }

        public abstract void SetupController();

        // Standard Dispose Pattern: https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);     
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return; 
      
            if (disposing)
            {
                _controller.Dispose();
            }
      
            // Free any unmanaged objects here.

            disposed = true;
        }

        ~CustomController()
        {
            Dispose(false);
        }
    }
}
