using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tamagucci
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BloodPage : ContentPage
    {
        private int total;
        public MainPage mainPage;
        public BloodPage(MainPage newMainPage)
        {
            mainPage = newMainPage;
            BindingContext = this;
            InitializeComponent();
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            //right leg
            Leg1.IsVisible = false;
            total += 1;

            if (total >= 4)
            {
                Won();
            }
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            //leftleg
            Leg2.IsVisible = false;
            total += 1;

            if (total >= 4)
            {
                Won();
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //rightArm
            Arm1.IsVisible = false;
            total += 1;

            if (total >= 4)
            {
                Won();
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            //leftArm
            Arm2.IsVisible = false;
            total += 1;

            if (total >= 4)
            {
                Won();
            }
        }

        private void Won()
        {
            WonIMG.IsVisible = true;
            WonTXT.IsVisible = true;
            mainPage.isPlayingGame = false;
            mainPage.AddValueThirst();
        }
    }
}