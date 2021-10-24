using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tamagucci
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PerformancePage : ContentPage
    {
        public MainPage mainPage;
        SensorSpeed speed = SensorSpeed.Game;
        public PerformancePage(MainPage newMainPage)
        {
            mainPage = newMainPage;
            BindingContext = this;
            InitializeComponent();
            Accelerometer.Stop();

            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
            
            Accelerometer.Start(speed);

            
        }
        private int t;
        
        void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            var timer = new Timer
            {
                Interval = 1000,
                AutoReset = true,
            };
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            Accelerometer.Stop();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            t += 1;
            int i = 5 - t;

            if (t <= 5)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    GodTxt.Text = i + "";
                    
                });
                
            }
            else
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    GodTxt.Text = "A GOOD PERFORMANCE MORTAL,      THANK YOU";
                });
                mainPage.AddValueBoredom();
                mainPage.isPlayingGame = false;
                Accelerometer.Stop();
            }
            
        }
    }
}