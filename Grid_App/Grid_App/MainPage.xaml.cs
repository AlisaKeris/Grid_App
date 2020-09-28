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
        int player = 1; 
        Label lblk, lblp;
        Grid grid;
        BoxView box;
        Button btn;
        public MainPage()
        {
            AbsoluteLayout absoluteLayout = new AbsoluteLayout();
            lblk = new Label() { Text = " ", TextColor = Color.FromRgb(0, 0, 0) };
            AbsoluteLayout.SetLayoutBounds(lbl, new Rectangle(50, 60, 50, 100));
            lblp = new Label() { Text = "Красный ходит первый", TextColor = Color.FromRgb(0, 0, 0) };
            AbsoluteLayout.SetLayoutBounds(lbl, new Rectangle(50, 10, 50, 200));
            grid = new Grid();
            AbsoluteLayout.SetLayoutBounds(grid, new Rectangle(150, 40, 200, 200));
            btn = new Button()
            {
                Text = "Новая игра",
                TextColor = Color.FromRgb(255, 255, 255),
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
                    box = new BoxView { Color = Color.FromRgb(255, 255, 255) };
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
            BoxView box = sender as BoxView;
            if (box.Color == Color.FromRgb(255, 255, 255)) 
            {

               switch (player) 
                {
                    case 1: //если ходит красный, меняется цвет ячейки, ход переходит к синиму и меняется значение переменной 
                        box.Color = Color.FromRgb(255, 0, 0); 
                        player = 0;
                        lblp.Text = "Ходит синий";
                        break;
                    case 0: //и наоборот если ходит синий
                        box.Color = Color.FromRgb(0, 0, 255);
                        player = 1;
                        lblp.Text = "Ходит красный";
                        break;
                }

            }
            else //если ячейка не белая, значит она уже занята 
            {
                lblk.Text = "Эта клетка уже занята!";
            }
        }
    }
}