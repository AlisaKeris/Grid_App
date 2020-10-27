using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Grid_App
{
    public partial class MainPage : ContentPage
    {
        private int player;
        private BoxView[,] box2= new BoxView[3,3];
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
            lblk = new Label() { Text = " ", TextColor = Color.FromRgb(50, 200, 50) };
            lblp = new Label() { Text = " ", TextColor = Color.FromRgb(0, 0, 0) };
            grid = new Grid();
            btn = new Button()
            {
                Text = "Новая игра",
                TextColor = Color.FromRgb(255, 255, 255),
                BorderWidth = 5,
                FontSize = 20,
                BackgroundColor = Color.FromRgb(50, 200, 50)
            };

            for (int i = 0; i < 4; i++)
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
                    var tap = new TapGestureRecognizer();
                    box.GestureRecognizers.Add(tap);
                    tap.Tapped += Tap_Tapped1;
                    btn.Clicked += new EventHandler(Btn_Clicked1) ;
                    grid.Children.Add(btn, 4, 0);
                    grid.Children.Add(lblk, 4, 1);
                    grid.Children.Add(lblp, 4, 2);

                }
            }
            Content = grid;
        }

        private void Btn_Clicked1(object sender, EventArgs e)
        {
            newgame();
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            Random rnd = new Random();
            player = rnd.Next(0, 2);
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
            checkwin();
        }
        private void checkwin()
        {
            if (box2[0,0].Color == box2[0,1].Color && box2[0,1].Color == box2[1, 2].Color)
            {
                if (box2[0,0].Color != Color.FromRgb(255, 255, 255)) {
                    lblp.Text = "Вы победили!";
                    return;
                }
            }
            if (box2[1, 0].Color == box2[1, 1].Color && box2[1, 1].Color == box2[1, 2].Color)
            {
                if (box2[1, 0].Color != Color.FromRgb(255, 255, 255))
                {
                    lblp.Text = "Вы победили!";
                }

            }
            if (box2[2, 0].Color == box2[2, 1].Color && box2[2, 1].Color == box2[2, 2].Color)
            {
                if (box2[2, 0].Color != Color.FromRgb(255, 255, 255))
                {
                    lblp.Text = "Вы победили!";
                }

            }
            if (box2[0, 0].Color == box2[1, 0].Color && box2[1, 0].Color == box2[2, 0].Color)
            {
                if (box2[0, 0].Color != Color.FromRgb(255, 255, 255))
                {
                    lblp.Text = "Вы победили!";
                }

            }
            if (box2[0, 1].Color == box2[1, 1].Color && box2[1, 1].Color == box2[2, 1].Color)
            {
                if (box2[0, 1].Color != Color.FromRgb(255, 255, 255))
                {
                    lblp.Text = "Вы победили!";
                }

            }
            if (box2[0, 2].Color == box2[1, 2].Color && box2[1, 2].Color == box2[2, 2].Color)
            {
                if (box2[0, 2].Color != Color.FromRgb(255, 255, 255))
                {
                    lblp.Text = "Вы победили!";
                }
            }
                
            if (box2[0, 0].Color == box2[1, 1].Color && box2[1, 1].Color == box2[2, 2].Color)
            {
                if (box2[0, 0].Color != Color.FromRgb(255, 255, 255))
                {
                    lblp.Text = "Вы победили!";
                }

            }
            if (box2[2, 2].Color == box2[1, 1].Color && box2[1, 1].Color == box2[0, 2].Color)
            {
                if (box2[2, 0].Color != Color.FromRgb(255, 255, 255))
                {
                    lblp.Text = "Вы победили!";
                }

            }
        }
    }
}
