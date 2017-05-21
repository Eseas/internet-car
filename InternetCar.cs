using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace Lesson_201
{
    class InternetCar
    {
        private GpioController gpioController;
        private GpioPin ledControlGpioPin;
        
        private int throttle;

        public InternetCar(int pin)
        {
            gpioController = GpioController.GetDefault();

            ledControlGpioPin = gpioController.OpenPin(pin);
            ledControlGpioPin.SetDriveMode(GpioPinDriveMode.Output);


        }


        //    public void InitalizeLed()
        //    {
        //        // Now setup the LedControlPin
        //        gpio = GpioController.GetDefault();

        //        ledControlGPIOPin = gpio.OpenPin(ledControlPin);
        //        ledControlGPIOPin.SetDriveMode(GpioPinDriveMode.Output);

        //        // Get the current pin value
        //        GpioPinValue startingValue = LedControlGPIOPin.Read();
        //        _LedState = (startingValue == GpioPinValue.Low) ? eLedState.On : eLedState.Off;
        //    }

        //    // A public property for interacting with the LED from code.
        //    public eLedState LedState
        //    {
        //        get { return _LedState; }
        //        set
        //        {
        //            Debug.WriteLine("InternetLed::LedState::set " + value.ToString());
        //            if (LedControlGPIOPin != null)
        //            {
        //                GpioPinValue newValue = (value == eLedState.On ? GpioPinValue.High : GpioPinValue.Low);
        //                LedControlGPIOPin.Write(newValue);
        //                _LedState = value;
        //            }
        //        }
        //    }

        //    // Change the state of the led from on to off or off to on
        //    public void Blink()
        //    {
        //        if (LedState == eLedState.On)
        //        {
        //            LedState = eLedState.Off;
        //        }
        //        else
        //        {
        //            LedState = eLedState.On;
        //        }
        //    }


        //    // This will call an exposed web API at the indicated URL
        //    // the API will return a string value to use as the blink delay.
        //    const string WebAPIURL = "http://192.168.1.64:8080/rest/blinker";
        //    //const string WebAPIURL = "http://adafruitsample.azurewebsites.net/TimeApi";
        //    public async Task<int> GetBlinkDelayFromWeb()
        //    {
        //        Debug.WriteLine("InternetLed::MakeWebApiCall");

        //        string responseString = "No response";

        //        try
        //        {
        //            using (HttpClient client = new HttpClient())
        //            {
        //                // Make the call
        //                responseString = await client.GetStringAsync(WebAPIURL);

        //                // Let us know what the returned string was
        //                Debug.WriteLine(String.Format("Response string: [{0}]", responseString));
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            Debug.WriteLine(e.Message);
        //        }

        //        int delay;

        //        if (!int.TryParse(responseString, out delay))
        //        {
        //            delay = DefaultBlinkDelay;
        //        }

        //        // return the blink delay
        //        return delay;
        //    }

    }

}