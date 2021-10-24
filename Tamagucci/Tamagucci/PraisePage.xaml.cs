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
    public partial class PraisePage : ContentPage
    {
        private int randomPicker;
        private int score;
        private bool prayer1Active;
        private bool prayer2Active;
        private bool prayer3Active;
        private bool prayer4Active;
        private bool isPicking;

        public MainPage mainPage;

        public PraisePage(MainPage newMainPage)
        {
            mainPage = newMainPage;
            BindingContext = this;
            InitializeComponent();

            var timer = new Timer
            {
                Interval = 1000 * 1.5f,
                AutoReset = true,
            };
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            prayer1Active = false;
            prayer2Active = false;
            prayer3Active = false;
            prayer4Active = false;
            ButtonClickable();
            Random random = new Random();
            randomPicker = random.Next(0, 4);
            if (randomPicker == 0)
            {
                Prayer1.TranslationY = -500;
            }
            if (randomPicker == 1)
            {
                Prayer2.TranslationY = -500;
            }
            if (randomPicker == 2)
            {
                Prayer3.TranslationY = -500;
            }
            if (randomPicker == 3)
            {
                Prayer4.TranslationY = -500;
            }
            Prayer1.TranslateTo(10, 400, 1500);
            Prayer2.TranslateTo(10, 400, 1500);
            Prayer3.TranslateTo(10, 400, 1500);
            Prayer4.TranslateTo(10, 400, 1500);
            
        }

        async void ButtonClickable()
        {
            if (isPicking)
            {
                return;
            }
            isPicking = true;
            await Task.Delay(1000);
            if (randomPicker == 0)
            {
                prayer1Active = true;
            }
            if (randomPicker == 1)
            {
                prayer2Active = true;
            }
            if (randomPicker == 2)
            {
                prayer3Active = true;
            }
            if (randomPicker == 3)
            {
                prayer4Active = true;
            }
            isPicking = false;

        }

        private void Prayer1_Clicked(object sender, EventArgs e)
        {
            if (prayer1Active)
            {
                score += 1;
            }
            else
            {
                score -= 1;
            }
            Score.Text = score + "/10";
            prayer1Active = false;
            if (score >= 10)
            {
                Won();
            }
        }

        private void Prayer2_Clicked(object sender, EventArgs e)
        {
            if (prayer2Active)
            {
                score += 1;
            }
            else
            {
                score -= 1;
            }
            Score.Text = score + "/10";
            prayer2Active = false;
            if (score >= 10)
            {
                Won();
            }
        }

        private void Prayer3_Clicked(object sender, EventArgs e)
        {
            if (prayer3Active)
            {
                score += 1;
            }
            else
            {
                score -= 1;
            }
            Score.Text = score + "/10";
            if (score >= 10)
            {
                Won();
            }
            prayer3Active = false;
        }

        private void Prayer4_Clicked(object sender, EventArgs e)
        {
            if (prayer4Active)
            {
                score += 1;

            }
            else
            {
                score -= 1;
            }
            Score.Text = score + "/10";
            if (score >= 10)
            {
                Won();
            }
            prayer4Active = false;
        }

        private void Won()
        {
            WonImgPrayer.IsVisible = true;
            WonTxtPrayer.IsVisible = true;

            mainPage.AddValueLoneliness();
            mainPage.isPlayingGame = false;
        }
    }
}