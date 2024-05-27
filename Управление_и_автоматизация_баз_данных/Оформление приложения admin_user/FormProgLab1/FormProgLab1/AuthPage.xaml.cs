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

namespace FormProgLab1
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void B_Enter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(logTB.Text) || string.IsNullOrEmpty(Pass.Password))
            {
                MessageBox.Show("Введите логин и пароль!");
                return;
            }
          
            using (var db = new user_1Entities1())
            {
                var user = db.UserS
                    .AsNoTracking()
                    .FirstOrDefault(u => u.login == logTB.Text && u.password == Pass.Password);
                 
                if (user == null)
                {
                    MessageBox.Show("Пользователь с такими данными не найден!");
                    return;
                }

                MessageBox.Show("Пользователь успешно найден!");

                switch(user.role)
                {
                    case "admin":
                        NavigationService?.Navigate(new DirectorMenu());
                        break;
                    case "user":
                        NavigationService?.Navigate(new CustomerMenu());
                        break;
                }

            }
        }

        private void B_registration_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Page2());
        }
    }
}
