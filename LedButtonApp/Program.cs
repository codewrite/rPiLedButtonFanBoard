using System;
using System.Device.Gpio;
using CommandLine;
using LedButtonLib;

// Options using: https://github.com/commandlineparser/commandline
// Start with https://github.com/commandlineparser/commandline/wiki/Getting-Started

namespace LedButtonApp
{
    class Program
    {
        public class Options
        {
            [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
            public bool Verbose { get; set; }
            [Option("redled", HelpText = "Set Red LED on or off")]
            public int? RedLed { get; set; }
            [Option("greenled", HelpText = "Set Green LED on or off")]
            public int? GreenLed { get; set; }
            [Option("ledCycle", HelpText = "Test LEDs until stopped")]
            public bool ledCycle { get; set; }
            [Option("buttonTest", HelpText = "Test button pressed code")]
            public bool buttonTest { get; set; }
        }

        private static readonly LedBoard _ledBoard = new LedBoard();

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed<Options>(o =>
                   {
                       if (o.RedLed != null)
                       {
                           _ledBoard.SetRedLed(o.RedLed != 0);
                       }
                       if (o.GreenLed != null)
                       {
                           _ledBoard.SetGreenLed(o.GreenLed != 0);
                       }
                       if (o.ledCycle)
                       {
                           _ledBoard.LedCycleTest();
                       }
                       if (o.buttonTest)
                       {
                       }
                   });
        }

    }
}

