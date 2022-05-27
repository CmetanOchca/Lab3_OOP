using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ООП3
{ 
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int countPositionX = 0;
        private int countPositionY = 0;
        private float speedAnimation = 0;
        private bool TakeCargo = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnUp(object sender, RoutedEventArgs e)
        {
            if (countPositionY < 10)
            {
                countPositionY++;
                Line.SetValue(HeightProperty, Convert.ToDouble(Line.GetValue(HeightProperty)) - 10.0);
                //ThicknessAnimation thicknessAnimation = new ThicknessAnimation()
                //{
                //    From = new Thickness(Magnet.Margin.Left, Magnet.Margin.Top, Magnet.Margin.Right, Magnet.Margin.Bottom),
                //    To = new Thickness(Magnet.Margin.Left, Magnet.Margin.Top - 10, Magnet.Margin.Right, Magnet.Margin.Bottom),
                //    Duration = TimeSpan.FromSeconds(speedAnimation),
                //};
                //Magnet.BeginAnimation(MarginProperty, thicknessAnimation);
                if (TakeCargo) Cargo.SetValue(Canvas.TopProperty, Convert.ToDouble(Cargo.GetValue(Canvas.TopProperty)) - 10.0);
            }
        }

        private void OnRight(object sender, RoutedEventArgs e)
        {
            if ((TakeCargo) && (countPositionY == -10)) { }
            else
            {
                if (countPositionX < 5)
                {
                    countPositionX++;
                    Holder.SetValue(Canvas.LeftProperty, Convert.ToDouble(Holder.GetValue(LeftProperty)) + 35.0);
                    if (TakeCargo) Cargo.SetValue(Canvas.LeftProperty, Convert.ToDouble(Cargo.GetValue(Canvas.LeftProperty)) + 35.0);
                }
            }
        }

        private void OnLeft(object sender, RoutedEventArgs e)
        {
            if ((TakeCargo) && (countPositionY == -10)) { }
            else
            {
                if (countPositionX > 0)
                {
                    countPositionX--;
                    Holder.SetValue(Canvas.LeftProperty, Convert.ToDouble(Holder.GetValue(LeftProperty)) - 35.0);
                    if (TakeCargo) Cargo.SetValue(Canvas.LeftProperty, Convert.ToDouble(Cargo.GetValue(Canvas.LeftProperty)) - 35.0);
                }
            }
        }

        private void OnDown(object sender, RoutedEventArgs e)
        {
            if (countPositionY > -10)
            {
                countPositionY--;
                Line.SetValue(HeightProperty, Convert.ToDouble(Line.GetValue(HeightProperty)) + 10.0);
                //ThicknessAnimation thicknessAnimation = new ThicknessAnimation()
                //{
                //    From = new Thickness(Magnet.Margin.Left, Magnet.Margin.Top, Magnet.Margin.Right, Magnet.Margin.Bottom),
                //    To = new Thickness(Magnet.Margin.Left, Magnet.Margin.Top + 10, Magnet.Margin.Right, Magnet.Margin.Bottom),
                //    Duration = TimeSpan.FromSeconds(speedAnimation),
                //};
                //Magnet.BeginAnimation(MarginProperty, thicknessAnimation);
                if (TakeCargo) Cargo.SetValue(Canvas.TopProperty, Convert.ToDouble(Cargo.GetValue(Canvas.TopProperty)) + 10.0);
            }
        }

        private void OnTake(object sender, RoutedEventArgs e)
        {
            double HolderX = Convert.ToDouble(Holder.GetValue(LeftProperty));
            double CargoX = Convert.ToDouble(Cargo.GetValue(LeftProperty));
            if ((HolderX == CargoX) && (countPositionY == -10) && (!TakeCargo))
            {
                TakeCargo = true;
                Take.Background = Brushes.Red;

            }
            else if ((countPositionY == -10) && (TakeCargo)) 
            { 
                TakeCargo = false; 
                Take.Background = Brushes.White; 
            }
        }
    }
}
