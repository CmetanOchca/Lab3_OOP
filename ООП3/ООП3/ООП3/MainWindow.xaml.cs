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
        DoubleAnimation buttonAnimation = new DoubleAnimation();
        private int countPositionX = 0;
        private int countPositionY = 0;
        private float speedAnimation = 0.1f;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnUp(object sender, RoutedEventArgs e)
        {
            if (countPositionY < 10)
            {
                countPositionY++;
                buttonAnimation.From = Line.ActualHeight;
                buttonAnimation.By = -10;
                buttonAnimation.Duration = TimeSpan.FromSeconds(speedAnimation);
                Line.BeginAnimation(Button.HeightProperty, buttonAnimation);
                ThicknessAnimation thicknessAnimation = new ThicknessAnimation()
                {
                    From = new Thickness(Magnet.Margin.Left, Magnet.Margin.Top, Magnet.Margin.Right, Magnet.Margin.Bottom),
                    To = new Thickness(Magnet.Margin.Left, Magnet.Margin.Top - 10, Magnet.Margin.Right, Magnet.Margin.Bottom),
                    Duration = TimeSpan.FromSeconds(speedAnimation),
                };
                Magnet.BeginAnimation(MarginProperty, thicknessAnimation);
            }
        }


        private void OnRight(object sender, RoutedEventArgs e)
        {
            if (countPositionX < 5)
            {
                countPositionX++;
                //buttonAnimation.From = Holder.ActualWidth;
                //buttonAnimation.By = 35;
                //buttonAnimation.Duration = TimeSpan.FromSeconds(speedAnimation);
                //Holder.BeginAnimation(Button.WidthProperty, buttonAnimation);
                Holder.SetValue(Canvas.LeftProperty, Convert.ToDouble(Holder.GetValue(LeftProperty)) + 35.0);
            }
        }

        private void OnLeft(object sender, RoutedEventArgs e)
        {
            if (countPositionX > 0)
            {
                countPositionX--;
                //buttonAnimation.From = Holder.ActualWidth;
                //buttonAnimation.By = -35;
                //buttonAnimation.Duration = TimeSpan.FromSeconds(speedAnimation);
                //Holder.BeginAnimation(Button.WidthProperty, buttonAnimation);
                Holder.SetValue(Canvas.LeftProperty, Convert.ToDouble(Holder.GetValue(LeftProperty)) - 35.0);
            }
        }

        private void OnDown(object sender, RoutedEventArgs e)
        {
            if (countPositionY > -10)
            {
                countPositionY--;
                buttonAnimation.From = Line.ActualHeight;
                buttonAnimation.By = 10;
                buttonAnimation.Duration = TimeSpan.FromSeconds(speedAnimation);
                Line.BeginAnimation(Button.HeightProperty, buttonAnimation);
                ThicknessAnimation thicknessAnimation = new ThicknessAnimation()
                {
                    From = new Thickness(Magnet.Margin.Left, Magnet.Margin.Top, Magnet.Margin.Right, Magnet.Margin.Bottom),
                    To = new Thickness(Magnet.Margin.Left, Magnet.Margin.Top + 10, Magnet.Margin.Right, Magnet.Margin.Bottom),
                    Duration = TimeSpan.FromSeconds(speedAnimation),
                };
                Magnet.BeginAnimation(MarginProperty, thicknessAnimation);
            }
        }

        private void OnTake(object sender, RoutedEventArgs e)
        {

        }
    }
}
