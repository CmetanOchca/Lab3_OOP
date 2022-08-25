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
        private float speedAnimation = 0;
        private bool TakeCargo = false;
        private double MoveX = 35.0;
        private double MoveY = 10.0;
        public double HolderX;
        public double HolderY;
        public double CargoY;
        public double MagnetY;
        public double SliderY;
        public double BeamX;
        public double HolderHeight;
        public double HolderWidth;
        public double CargoHeight;
        public double SliderHeight;
        public double MagnetHeight;
        public double BeamWidth;


        public MainWindow()
        {
            InitializeComponent();
            HolderY = Convert.ToDouble(Holder.GetValue(TopProperty));
            HolderX = Convert.ToDouble(Holder.GetValue(LeftProperty));
            CargoY = Convert.ToDouble(Cargo.GetValue(TopProperty));
            MagnetY = Convert.ToDouble(Magnet.GetValue(TopProperty));
            SliderY = Convert.ToDouble(Slider.GetValue(TopProperty));
            BeamX = Convert.ToDouble(Beam.GetValue(LeftProperty));
            HolderHeight = Convert.ToDouble(Holder.GetValue(HeightProperty));
            HolderWidth = Convert.ToDouble(Holder.GetValue(WidthProperty));
            CargoHeight = Convert.ToDouble(Cargo.GetValue(HeightProperty));
            MagnetHeight = Convert.ToDouble(Magnet.GetValue(HeightProperty));
            SliderHeight = Convert.ToDouble(Slider.GetValue(HeightProperty));
            BeamWidth = Convert.ToDouble(Beam.GetValue(WidthProperty));
        }

        private void OnUp(object sender, RoutedEventArgs e)
        {
            if ((SliderY + SliderHeight + MagnetHeight) < MagnetY)
            {
                SliderY = SliderY + MoveY;
                HolderY = HolderY - MoveY;
                Line.SetValue(HeightProperty, Convert.ToDouble(Line.GetValue(HeightProperty)) - MoveY);
                ThicknessAnimation thicknessAnimation = new ThicknessAnimation()
                {
                    From = new Thickness(Magnet.Margin.Left, Magnet.Margin.Top, Magnet.Margin.Right, Magnet.Margin.Bottom),
                    To = new Thickness(Magnet.Margin.Left, Magnet.Margin.Top - MoveY, Magnet.Margin.Right, Magnet.Margin.Bottom),
                    Duration = TimeSpan.FromSeconds(speedAnimation),
                };
                Magnet.BeginAnimation(MarginProperty, thicknessAnimation);
                if (TakeCargo) Cargo.SetValue(Canvas.TopProperty, Convert.ToDouble(Cargo.GetValue(Canvas.TopProperty)) - MoveY);
            }
        }

        private void OnRight(object sender, RoutedEventArgs e)
        {
            if ((TakeCargo) && ((HolderY + HolderHeight) == (CargoY))) { }
            else
            {
                if ((HolderX + 2 * HolderWidth) < (BeamX + BeamWidth))
                {
                    HolderX = HolderX + MoveX;
                    Holder.SetValue(Canvas.LeftProperty, Convert.ToDouble(Holder.GetValue(LeftProperty)) + MoveX);
                    if (TakeCargo) Cargo.SetValue(Canvas.LeftProperty, Convert.ToDouble(Cargo.GetValue(Canvas.LeftProperty)) + MoveX);
                }
            }
        }

        private void OnLeft(object sender, RoutedEventArgs e)
        {
            if ((TakeCargo) && ((HolderY + HolderHeight) == (CargoY))) { }
            else
            {
                if ((HolderX) > (BeamX + HolderWidth))
                {
                    HolderX = HolderX - MoveX;
                    Holder.SetValue(Canvas.LeftProperty, Convert.ToDouble(Holder.GetValue(LeftProperty)) - MoveX);
                    if (TakeCargo) Cargo.SetValue(Canvas.LeftProperty, Convert.ToDouble(Cargo.GetValue(Canvas.LeftProperty)) - MoveX);
                }
            }
        }

        private void OnDown(object sender, RoutedEventArgs e)
        {
            if ((HolderY + HolderHeight) != (CargoY))
            {
                HolderY = HolderY + MoveY;
                SliderY = SliderY - MoveY;
                Line.SetValue(HeightProperty, Convert.ToDouble(Line.GetValue(HeightProperty)) + MoveY);
                ThicknessAnimation thicknessAnimation = new ThicknessAnimation()
                {
                    From = new Thickness(Magnet.Margin.Left, Magnet.Margin.Top, Magnet.Margin.Right, Magnet.Margin.Bottom),
                    To = new Thickness(Magnet.Margin.Left, Magnet.Margin.Top + MoveY, Magnet.Margin.Right, Magnet.Margin.Bottom),
                    Duration = TimeSpan.FromSeconds(speedAnimation),
                };
                Magnet.BeginAnimation(MarginProperty, thicknessAnimation);
                if (TakeCargo) Cargo.SetValue(Canvas.TopProperty, Convert.ToDouble(Cargo.GetValue(Canvas.TopProperty)) + MoveY);
            }
        }

        private void OnTake(object sender, RoutedEventArgs e)
        {
            double HolderX = Convert.ToDouble(Holder.GetValue(LeftProperty));
            double CargoX = Convert.ToDouble(Cargo.GetValue(LeftProperty));
            if ((HolderX == CargoX) && ((HolderY + HolderHeight) == (CargoY)) && (!TakeCargo))
            {
                TakeCargo = true;
                Take.Background = Brushes.Red;

            }
            else if (((HolderY + HolderHeight) == (CargoY)) && (TakeCargo))
            {
                TakeCargo = false;
                Take.Background = Brushes.White;
            }
        }
    }
}