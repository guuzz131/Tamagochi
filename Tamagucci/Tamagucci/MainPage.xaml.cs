using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Timers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Tamagucci
{
    public partial class MainPage : ContentPage
    {
        public bool isPlayingGame;

        public MainPage mainPage;

        public CreatureStats MyCreature { get; set; } = new CreatureStats
        {
            Name = "God",
            UserName = "Guus",
            Hunger = 1f,
            Thirst = 1f,
            Loneliness = 1f,
            Boredom = 1f,
            Stimulated = 1f,
            Tired = 1f,
        };

        public string TextFromCode { get; set; } = "";

        public MainPage()
        {
            mainPage = this;

            BindingContext = this;

            InitializeComponent();

            var timer = new Timer
            {
                Interval = 1000 * 2,
                AutoReset = true,
            };
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            OnStartup();
        }

        private void OnStartup()
        {
            var creatureDataStore = DependencyService.Get<Interface1<CreatureStats>>();
            MyCreature = creatureDataStore.ReadItem();
            if (MyCreature == null)
            {
                MyCreature = new CreatureStats { Name = "God" };
                creatureDataStore.CreateItem(MyCreature);
            }

            double timeAsleep = Preferences.Get("TimeAsleep", (double)0);

            MyCreature.Loneliness = 1;
            MyCreature.Hunger = 1;
            MyCreature.Boredom = 1;
            MyCreature.Thirst = 1;
            MyCreature.Tired = 1;
            MyCreature.Stimulated = 1;

            /*
            MyCreature.Loneliness -= (float)timeAsleep * .1f;
            MyCreature.Hunger -= (float)timeAsleep * .1f;
            MyCreature.Boredom -= (float)timeAsleep * .1f;
            MyCreature.Thirst -= (float)timeAsleep * .1f;
            MyCreature.Tired += (float)timeAsleep * .1f;
            MyCreature.Stimulated -= (float)timeAsleep * .1f;*/

            if (MyCreature.Hunger < 0)
            {
                MyCreature.Hunger = 0;
            }
            if (MyCreature.Thirst < 0)
            {
                MyCreature.Thirst = 0;
            }
            if (MyCreature.Stimulated < 0)
            {
                MyCreature.Stimulated = 0;
            }
            if (MyCreature.Boredom < 0)
            {
                MyCreature.Boredom = 0;
            }
            if (MyCreature.Loneliness < 0)
            {
                MyCreature.Loneliness = 0;
            }
            if (MyCreature.Tired < 0)
            {
                MyCreature.Tired = 0;
            }
            creatureDataStore.UpdateItem(MyCreature);
            UpdateText();
            //LonelinessXMALtxt.Text = MyCreature.LonelinessText;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!isPlayingGame)
            {
                var creatureDataStore = DependencyService.Get<Interface1<CreatureStats>>();

                MyCreature.Hunger -= .1f;
                if (MyCreature.Hunger < 0)
                {
                    MyCreature.Hunger = 0;
                }
                MyCreature.Thirst -= .1f;
                if (MyCreature.Thirst < 0)
                {
                    MyCreature.Thirst = 0;
                }
                MyCreature.Stimulated -= .1f;
                if (MyCreature.Stimulated < 0)
                {
                    MyCreature.Stimulated = 0;
                }
                MyCreature.Boredom -= .1f;
                if (MyCreature.Boredom < 0)
                {
                    MyCreature.Boredom = 0;
                }
                MyCreature.Loneliness -= .1f;
                if (MyCreature.Loneliness < 0)
                {
                    MyCreature.Loneliness = 0;
                }
                MyCreature.Tired -= .1f;
                if (MyCreature.Tired < 0)
                {
                    MyCreature.Tired = 0;
                }

                UpdateText();
                creatureDataStore.UpdateItem(MyCreature);

                
            }
        }

        
        private void Button_Clicked(object sender, EventArgs e)
        {
            //shrekImg.Scale = shrekImg.Scale * .8f;
        }

        private void Button_Clicked_Prayer(object sender, EventArgs e)
        {
            /*MyCreature.Loneliness += .1f;
            var creatureDataStore = DependencyService.Get<Interface1<CreatureStats>>();
            creatureDataStore.UpdateItem(MyCreature);
            UpdateText();*/
            isPlayingGame = true;
            Navigation.PushAsync(new PraisePage(mainPage));
            
        }
        private void Button_Clicked_Feed(object sender, EventArgs e)
        {
            isPlayingGame = true;
            Navigation.PushAsync(new Sheep(mainPage));
        }
        private void Button_Clicked_Show(object sender, EventArgs e)
        {
            isPlayingGame = true;
            Navigation.PushAsync(new PerformancePage(mainPage));
        }
        private void Button_Clicked_Sacrifice(object sender, EventArgs e)
        {
            MyCreature.Stimulated -= .2f;
            if (MyCreature.Stimulated > 1)
            {
                MyCreature.Stimulated = 1;
            }
            var creatureDataStore = DependencyService.Get<Interface1<CreatureStats>>();
            creatureDataStore.UpdateItem(MyCreature);
            UpdateText();
        }
        private void Button_Clicked_Blood(object sender, EventArgs e)
        {
            isPlayingGame = true;
            Navigation.PushAsync(new BloodPage(mainPage));
        }

        void UpdateText()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                LonelinessXMALtxt.Text = MyCreature.LonelinessText;
                HungerXMALtxt.Text = MyCreature.HungerText;
                ThirstXMALtxt.Text = MyCreature.ThirstText;
                StimulatedXMALtxt.Text = MyCreature.StimulatedText;
                BoredomXMALtxt.Text = MyCreature.BoredomText;
                TiredXMALtxt.Text = MyCreature.TiredText;
            });

            float i = (MyCreature.Hunger + MyCreature.Thirst + MyCreature.Stimulated + MyCreature.Tired + MyCreature.Boredom + MyCreature.Loneliness) / 6 * -1 + 1;
            Clouds.FadeTo(i, 1000);
            if (Clouds.Opacity >= 1)
            {
                DefeatIMG.IsVisible = true;
                DefeatTXT.IsVisible = true;
                Retry.IsVisible = true;
            }

            
        }

        public void AddValueHunger()
        {
            MyCreature.Hunger += .8f;
            if (MyCreature.Hunger > 1)
            {
                MyCreature.Hunger = 1;
            }
            HungerXMALtxt.Text = MyCreature.HungerText;
            var creatureDataStore = DependencyService.Get<Interface1<CreatureStats>>();
            creatureDataStore.UpdateItem(MyCreature);
            UpdateText();
        }
        public void AddValueLoneliness()
        {
            MyCreature.Loneliness += .8f;
            if (MyCreature.Loneliness > 1)
            {
                MyCreature.Loneliness = 1;
            }
            LonelinessXMALtxt.Text = MyCreature.LonelinessText;
            var creatureDataStore = DependencyService.Get<Interface1<CreatureStats>>();
            creatureDataStore.UpdateItem(MyCreature);
            UpdateText();
        }
        public void AddValueBoredom()
        {
            MyCreature.Boredom += .8f;
            if (MyCreature.Boredom > 1)
            {
                MyCreature.Boredom = 1;
            }
            BoredomXMALtxt.Text = MyCreature.BoredomText;
            var creatureDataStore = DependencyService.Get<Interface1<CreatureStats>>();
            creatureDataStore.UpdateItem(MyCreature);
            UpdateText();
        }
        public void AddValueThirst()
        {
            MyCreature.Thirst += .8f;
            if (MyCreature.Thirst > 1)
            {
                MyCreature.Thirst = 1;
            }
            ThirstXMALtxt.Text = MyCreature.ThirstText;
            var creatureDataStore = DependencyService.Get<Interface1<CreatureStats>>();
            creatureDataStore.UpdateItem(MyCreature);

            UpdateText();
        }

        private void Retry_Clicked(object sender, EventArgs e)
        {
            MyCreature.Loneliness = 1;
            MyCreature.Hunger = 1;
            MyCreature.Boredom = 1;
            MyCreature.Thirst = 1;
            MyCreature.Tired = 1;
            MyCreature.Stimulated = 1;

            DefeatIMG.IsVisible = false;
            DefeatTXT.IsVisible = false;
            Retry.IsVisible = false;
        }
    }
}
