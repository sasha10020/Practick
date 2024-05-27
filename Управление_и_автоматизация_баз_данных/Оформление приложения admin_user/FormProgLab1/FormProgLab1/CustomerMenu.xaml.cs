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
using System.Runtime.InteropServices;
using System.Windows.Threading;

namespace FormProgLab1
{
    /// <summary>
    /// Логика взаимодействия для CustomerMenu.xaml
    /// </summary>
    public partial class CustomerMenu : Page
    {
        //private DispatcherTimer _timer;
        
        public CustomerMenu()
        {
            InitializeComponent();
            //_timer = new DispatcherTimer();
            //_timer.Interval = new TimeSpan(0, 0, 0, 3);
            //_timer.Tick += IdleTick;
            //_timer.Start();
        }

        //private void IdleTick(object sender, EventArgs e)
        //{
        //    var idle = GetIdle();
        //    if (idle.Seconds >= 10)
        //    {
        //        NavigationService?.Navigate(new AuthPage());
        //    }
        //}


        private void B1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Page2());
        }

        private void B2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AuthPage());
        }

        private void B3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Menu());
        }

      

        

    }
}
