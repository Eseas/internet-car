using Microsoft.IoT.Lightning.Providers;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Devices;
using Windows.Devices.Pwm;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Lesson_201
{
    /// <summary>
    /// The application main page.  Because we are running headless we will not see anything
    /// even though it is begin generated at runtime.  This acts as the main entry point for the 
    /// application functionality.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // which GPIO pin do we want to use to control the LED light
        //const int GPIOToUse = 18;
        //const int GPIOToUse = 24;
        //private PwmPin _pin24;
        private PwmPin _pin18;

        // The class which wraps our LED.
        InternetLed internetLed;

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += OnLoaded;
            //Test();
        }

        // This method will be called by the application framework when the page is first loaded.
        //protected override async void OnNavigatedTo(NavigationEventArgs navArgs)
        //{
        //    Debug.WriteLine("MainPage::OnNavigatedTo");
            
        //    try
        //    {
        //        //// Create a new InternetLed object
        //        //internetLed = new InternetLed(GPIOToUse);

        //        //// Initialize it for use
        //        //internetLed.InitalizeLed();

        //        //// Now have it make the web API call and get the led blink delay


        //        //while (true)
        //        //{
        //        //    //int blinkDelay = await internetLed.GetBlinkDelayFromWeb();
        //        //    //internetLed.Blink();

        //        //    // LAST WORKING (INDEX)
        //        //    internetLed.GetThrottleFromWeb();
        //        //    internetLed.Drive();
        //        //    await Task.Delay(100);
        //        //    // End

        //        //}

        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e.Message);
        //    }
        //}
        
        private async void Test()
        {
            //if (Microsoft.IoT.Lightning.Providers.LightningProvider.IsLightningEnabled)
            //{
            //    // Do something with the Lightning providers
            //}
        }





        private async void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            if (LightningProvider.IsLightningEnabled)
            {
                LowLevelDevicesController.DefaultProvider = LightningProvider.GetAggregateProvider();

                var pwmControllers = await PwmController.GetControllersAsync(LightningPwmProvider.GetPwmProvider());
                var pwmController = pwmControllers[1]; // the on-device controller
                pwmController.SetDesiredFrequency(50); // try to match 50Hz

                //_pin24 = pwmController.OpenPin(24);
                //_pin24.SetActiveDutyCyclePercentage(.95);
                //_pin24.Start();

                internetLed = new InternetLed();
                //internetLed.InitalizeLed();

                while (true)
                {
                    //int blinkDelay = await internetLed.GetBlinkDelayFromWeb();
                    //internetLed.Blink();
                    await internetLed.GetThrottleFromWeb();

                    double test = internetLed.getThrottle() / 100.0;

                    _pin18 = pwmController.OpenPin(18);
                    _pin18.SetActiveDutyCyclePercentage(internetLed.getThrottle() / 100.0);
                    _pin18.Start();

                    // LAST WORKING (INDEX)
                    
                    //internetLed.Drive();
                    await Task.Delay(100);
                    // End

                }
            }

            //var gpioController = await GpioController.GetDefaultAsync();
            //if (gpioController == null)
            //{
            //    StatusMessage.Text = "There is no GPIO controller on this device.";
            //    return;
            //}
            //_pin22 = gpioController.OpenPin(22);
            //_pin22.SetDriveMode(GpioPinDriveMode.Output);
            //_pin22.Write(GpioPinValue.Low);
        }
    }
}