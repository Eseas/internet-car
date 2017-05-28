using Microsoft.IoT.Lightning.Providers;
using System;
using System.Threading.Tasks;
using Windows.Devices;
using Windows.Devices.Pwm;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Lesson_201
{
    public sealed partial class MainPage : Page
    {
        private PwmPin _pin18;
        
        InternetLed internetLed;

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += OnLoaded;
        }
        
        private async void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            if (LightningProvider.IsLightningEnabled)
            {
                LowLevelDevicesController.DefaultProvider = LightningProvider.GetAggregateProvider();

                var pwmControllers = await PwmController.GetControllersAsync(LightningPwmProvider.GetPwmProvider());
                var pwmController = pwmControllers[1]; // the on-device controller
                pwmController.SetDesiredFrequency(50); // try to match 50Hz
                

                internetLed = new InternetLed();

                _pin18 = pwmController.OpenPin(18);

                while (true)
                {
                    await internetLed.GetThrottleFromWeb();

                    double test = internetLed.getThrottle() / 100.0;
                    
                    _pin18.SetActiveDutyCyclePercentage(internetLed.getThrottle() / 100.0);
                    _pin18.Start();
                    
                    
                    await Task.Delay(200);
                }
            }            
        }
    }
}