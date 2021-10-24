using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tamagucci
{
    public partial class App : Application
    {
        public App()
        {
            DependencyService.RegisterSingleton<Interface1<CreatureStats>>(new LocalCreatureStore());

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            var sleepTime = Preferences.Get("SleepTime", DateTime.Now);
            var wakeTime = DateTime.Now;

            TimeSpan timeAsleep = wakeTime - sleepTime;
        }

        protected override void OnSleep()
        {
            var sleepTime = DateTime.Now;
            Preferences.Set("SleepTime", sleepTime);
        }

        protected override void OnResume()
        {
            var sleepTime = Preferences.Get("SleepTime", DateTime.Now);
            var wakeTime = DateTime.Now;

            TimeSpan timeAsleep = wakeTime - sleepTime;

            Preferences.Set("TimeAsleep", timeAsleep.TotalHours);
        }
    }
}
