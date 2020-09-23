using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Grid_App
{
    public partial class MainPage : ContentPage
    {
        Grid grid;
        BoxView box;
        Button btn;
        public MainPage()
        {
            AbsoluteLayout absoluteLayout = new AbsoluteLayout();
            grid = new Grid();
            btn = new Button() {
                Text = "Новая игра",
                TextColor = Color.White,
                BorderWidth = 5,
                FontSize = 20,
                BackgroundColor = Color.Blue,
            };
            
            for (int i = 0; i < 3; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    box= new BoxView { Color = Color.White };
                    grid.Children.Add(box, i, j);
                    
                    var tap = new TapGestureRecognizer();
                    box.GestureRecognizers.Add(tap);
                    tap.Tapped += Tap_Tapped;
                    btn.Clicked += Btn_Clicked;
                }
            }
            Content = absoluteLayout;
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            box.Color = Color.FromRgb(200, 50, 50);
        }
    }
}
