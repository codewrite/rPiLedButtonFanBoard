using System.Device.Gpio;
using System.Threading;
using LedButtonLib;

namespace LedButtonApp
{
    public class LedBoard
    {
        private readonly GpioController _gpioController = new GpioController();
        private readonly Led _led;

        public LedBoard() => _led = new Led(_gpioController);
        
        public void SetRedLed(bool on) => _led.SetRed(on);
        public void SetGreenLed(bool on) => _led.SetRed(on);

        public void LedCycleTest()
        {
            int num = 0;
            while (true)
            {
                _led.SetGreen((num & 1) != 0);
                _led.SetRed((num & 2) != 0);
                if (++num > 3) num = 0;
                Thread.Sleep(125);
            }
        }

    }
}