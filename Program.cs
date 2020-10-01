using System;
using System.Threading;
using System.Threading.Tasks;
using System.Device.Gpio;

namespace SimpleButton
{
    class Program
    {   
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            GpioController controller = new GpioController(PinNumberingScheme.Logical);
            var pin = 27;
            var buttonPin = 17;
            
            controller.OpenPin(pin, PinMode.Output);
            controller.OpenPin(buttonPin, PinMode.InputPullUp);            

            try
            {
                while (true)
                {
                    if (controller.Read(buttonPin) == false)
                    {
                        controller.Write(pin, PinValue.High);
                    }
                    else
                    {
                        controller.Write(pin, PinValue.Low);
                    }
                }
            }
            finally
            {
                controller.ClosePin(pin);
            }
        }
    }
}
