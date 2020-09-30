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
        Label lblk, lblp;
        Grid grid;
        BoxView box;
        Button btn;
        public MainPage()
        {
            newgame();
        }
        public void newgame()
        {
            AbsoluteLayout absoluteLayout = new AbsoluteLayout();
            lblk = new Label() { Text = " ", TextColor = Color.FromRgb(50, 200, 50) };
            AbsoluteLayout.SetLayoutBounds(lblk, new Rectangle(50, 40, 50, 100));
            lblp = new Label() { Text = " ", TextColor = Color.FromRgb(0, 0, 0) };
            AbsoluteLayout.SetLayoutBounds(lblp, new Rectangle(50, 10, 50, 200));
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
                    absoluteLayout.Children.Add(lblk);
                    absoluteLayout.Children.Add(lblp);
                    var tap = new TapGestureRecognizer();
                    box.GestureRecognizers.Add(tap);
                    tap.Tapped += Tap_Tapped;
                    btn.Clicked += new EventHandler(Btn_Clicked1) ;

                }
            }
            Content = absoluteLayout;
        }

        private void Btn_Clicked1(object sender, EventArgs e)
        {
            newgame();
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int player = rnd.Next(0, 2);
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
            else
            {
                lblk.Text = "Эта клетка уже занята!";
            }
        }
    }
}