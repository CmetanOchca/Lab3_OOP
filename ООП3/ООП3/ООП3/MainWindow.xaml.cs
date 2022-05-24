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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnUp(object sender, RoutedEventArgs e)
        {


        }

        private void OnRight(object sender, RoutedEventArgs e)
        {
            Holder.Margin = "350,69,0,0"

        }

        private void OnLeft(object sender, RoutedEventArgs e)
        {

        }

        private void OnDown(object sender, RoutedEventArgs e)
        {

        }

        private void OnTake(object sender, RoutedEventArgs e)
        {

        }
    }
}
