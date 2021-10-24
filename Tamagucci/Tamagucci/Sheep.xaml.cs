using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tamagucci
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Sheep : ContentPage
    {
        public int ScorePoints;



        public new double Scale()
        {
            Random random = new Random();
            double scale = random.NextDouble();
            scale = scale / 2 + 0.3f;
            return scale;
        }

        public MainPage mainPage;

        public Sheep(MainPage newMainPage)
        {
            mainPage = newMainPage;
            BindingContext = this;
            InitializeComponent();

            

            var timer = new Timer
            {
                Interval = 1000 * 5,
                AutoReset = true,
            };
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Random random = new Random();
            int sheepPicker = random.Next(0,3);
            int speed = random.Next(600, 1000);
            if (sheepPicker == 0)
            {
                if (Sheep1.IsEnabled == false)
                {
                    sheepPicker = 1;
                }
                Sheep1.TranslationX = 0;
                Sheep1.TranslationY = 0;
                Sheep1.Scale = Scale();
                SheepBtn1.TranslationX = 0;
                SheepBtn1.TranslationY = 0;
                SheepBtn1.Scale = Scale() * 5;
            }
            if (sheepPicker == 1)
            {
                if (Sheep2.IsEnabled == false)
                {
                    sheepPicker = 2;
                }
                Sheep2.TranslationX = 0;
                Sheep2.TranslationY = 0;
                Sheep2.Scale = Scale();
                SheepBtn2.TranslationX = 0;
                SheepBtn2.TranslationY = 0;
                SheepBtn2.Scale = Scale() * 5;
            }
            if (sheepPicker == 2)
            {
                if (Sheep3.IsEnabled == false)
                {
                    sheepPicker = 0;
                }
                Sheep3.TranslationX = 0;
                Sheep3.TranslationY = 0;
                Sheep3.Scale = Scale();
                SheepBtn3.TranslationX = 0;
                SheepBtn3.TranslationY = 0;
                SheepBtn3.Scale = Scale() * 5;
            }
            Sheep1.TranslateTo(500, 300, (uint)speed);
            Sheep2.TranslateTo(-500, 300, (uint)speed);
            Sheep3.TranslateTo(500, -500, (uint)speed);
            SheepBtn1.TranslateTo(500, 300, (uint)speed);
            SheepBtn2.TranslateTo(-500, 300, (uint)speed);
            SheepBtn3.TranslateTo(500, -500, (uint)speed);
        }

        private void SheepBtn1_Clicked(object sender, EventArgs e)
        {
            ScorePoints += 1;
            Score.Text = ScorePoints + "/3";
            if (ScorePoints == 3)
            {
                Won();
            }
            Sheep1.IsEnabled = false;
            SheepBtn1.IsEnabled = false;
            Sheep1.IsVisible= false;
            SheepBtn1.IsVisible = false;
        }

        private void SheepBtn2_Clicked(object sender, EventArgs e)
        {
            ScorePoints += 1;
            Score.Text = ScorePoints + "/3";
            if (ScorePoints == 3)
            {
                Won();
            }
            Sheep2.IsEnabled = false;
            SheepBtn2.IsEnabled = false;
            Sheep2.IsVisible = false;
            SheepBtn2.IsVisible = false;
        }

        private void SheepBtn3_Clicked(object sender, EventArgs e)
        {
            ScorePoints += 1;
            Score.Text = ScorePoints + "/3";
            if (ScorePoints == 3)
            {
                Won();
            }
            Sheep3.IsEnabled = false;
            SheepBtn3.IsEnabled = false;
            Sheep3.IsVisible = false;
            SheepBtn3.IsVisible = false;
        }

        private void Won()
        {
            WonImg.IsVisible = true;
            WonTxt.IsVisible = true;

            mainPage.AddValueHunger();
            mainPage.isPlayingGame = false;
        }
    }
}