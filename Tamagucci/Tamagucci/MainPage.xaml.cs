using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;

namespace Tamagucci
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
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

        public string TextFromCode { get; set; } = "This text came from code!";

        public MainPage()
        {
            

            BindingContext = this;

            InitializeComponent();

            var timer = new Timer
            {
                Interval = 1000 * 60,
                AutoReset = true,
            };
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            base.OnAppearing();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var creatureDataStore = DependencyService.Get<Interface1<CreatureStats>>();
            MyCreature = await creatureDataStore.ReadItem();
            if (MyCreature == null)
            {
                MyCreature = new CreatureStats { Name = "God" };
                await creatureDataStore.CreateItem(MyCreature);
            }

            
            await creatureDataStore.UpdateItem(MyCreature);
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            MyCreature.Hunger -= .1f;
            MyCreature.Thirst -= .1f;
            MyCreature.Stimulated -= .1f;
            MyCreature.Boredom -= .1f;
            MyCreature.Loneliness -= .1f;
            MyCreature.Tired -= .1f;
        }

        
        private void Button_Clicked(object sender, EventArgs e)
        {
            //shrekImg.Scale = shrekImg.Scale * .8f;
        }

        private void Button_Clicked_Prayer(object sender, EventArgs e)
        {
            TextFromCode = "this is now differend";
        }
        private void Button_Clicked_Feed(object sender, EventArgs e)
        {

        }
        private void Button_Clicked_Show(object sender, EventArgs e)
        {

        }
        private void Button_Clicked_Sacrifice(object sender, EventArgs e)
        {

        }
        private void Button_Clicked_Blood(object sender, EventArgs e)
        {

        }
    }
}
