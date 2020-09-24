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
        Label lbl;
        Grid grid;
        BoxView box;
        Button btn;
        public MainPage()
        {
            AbsoluteLayout absoluteLayout = new AbsoluteLayout();
            lbl = new Label() { Text = " ", TextColor = Color.FromRgb(50, 200, 50) };
            AbsoluteLayout.SetLayoutBounds(lbl, new Rectangle(50, 40, 50, 100));
            grid = new Grid();
            AbsoluteLayout.SetLayoutBounds(grid, new Rectangle(150, 40, 200, 200));
            btn = new Button()
            {
                Text = "Новая игра",
                TextColor = Color.White,
                BorderWidth = 5,
                FontSize = 20,
                BackgroundColor = Color.FromRgb(50, 200, 50)
            };
            AbsoluteLayout.SetLayoutBounds(btn, new Rectangle(60, 300, 150, 50));
            for (int i = 0; i < 3; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    box = new BoxView { Color = Color.White };
                    grid.Children.Add(box, i, j);
                    absoluteLayout.Children.Add(btn);
                    absoluteLayout.Children.Add(grid);
                    absoluteLayout.Children.Add(lbl);
                    var tap = new TapGestureRecognizer();
                    box.GestureRecognizers.Add(tap);
                    tap.Tapped += Tap_Tapped1;
                    btn.Clicked += Btn_Clicked;

                }
            }
            Content = absoluteLayout;
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            grid.Children.Clear();
        }

        private void Tap_Tapped1(object sender, EventArgs e)
        {
            lbl.Text = " ";
            BoxView box = sender as BoxView;
            if (box.Color == Color.White)
            {
                box.Color = Color.FromRgb(200, 50, 50);

            }
            else
            {
                lbl.Text = "Эта клетка уже занята!";
            }
        }
    }
}