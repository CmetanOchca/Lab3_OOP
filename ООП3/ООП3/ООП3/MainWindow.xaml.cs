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
        int countPositionX = 0;
        int countPositionY = 0;
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
                buttonAnimation.Duration = TimeSpan.FromSeconds(0);
                Line.BeginAnimation(Button.HeightProperty, buttonAnimation);
                ThicknessAnimation thicknessAnimation = new ThicknessAnimation()
                {
                    From = new Thickness(Magnet.Margin.Left, Magnet.Margin.Top, Magnet.Margin.Right, Magnet.Margin.Bottom),
                    To = new Thickness(Magnet.Margin.Left, Magnet.Margin.Top - 10, Magnet.Margin.Right, Magnet.Margin.Bottom),
                    Duration = TimeSpan.FromSeconds(0),
                };
                Magnet.BeginAnimation(MarginProperty, thicknessAnimation);
            }
        }


        private void OnRight(object sender, RoutedEventArgs e)
        {
            if (countPositionX < 10)
            {
                countPositionX++;
                buttonAnimation.From = Holder.ActualWidth;
                buttonAnimation.By = 35;
                buttonAnimation.Duration = TimeSpan.FromSeconds(0);
                Holder.BeginAnimation(Button.WidthProperty, buttonAnimation);
            }
        }

        private void OnLeft(object sender, RoutedEventArgs e)
        {
            buttonAnimation.From = Holder.ActualWidth;
            buttonAnimation.By = -35;
            buttonAnimation.Duration = TimeSpan.FromSeconds(0);
            Holder.BeginAnimation(Button.WidthProperty, buttonAnimation);
            if (countPositionX>0) { countPositionX--; }
        }

        private void OnDown(object sender, RoutedEventArgs e)
        {
            if (countPositionY > -10)
            {
                countPositionY--;
                buttonAnimation.From = Line.ActualHeight;
                buttonAnimation.By = 10;
                buttonAnimation.Duration = TimeSpan.FromSeconds(0);
                Line.BeginAnimation(Button.HeightProperty, buttonAnimation);
                ThicknessAnimation thicknessAnimation = new ThicknessAnimation()
                {
                    From = new Thickness(Magnet.Margin.Left, Magnet.Margin.Top, Magnet.Margin.Right, Magnet.Margin.Bottom),
                    To = new Thickness(Magnet.Margin.Left, Magnet.Margin.Top + 10, Magnet.Margin.Right, Magnet.Margin.Bottom),
                    Duration = TimeSpan.FromSeconds(0),
                };
                Magnet.BeginAnimation(MarginProperty, thicknessAnimation);
            }
        }

        private void OnTake(object sender, RoutedEventArgs e)
        {

        }
    }
}
