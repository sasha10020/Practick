using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace AmonikItog.Pages
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        static string connectionString = "data source=LIZA\\MSSQLSERVER_2;initial catalog=AmonikLast;integrated security=True;MultipleActiveResultSets=True";
        SqlConnection cnn = new SqlConnection(connectionString);
        public Login()
        {
            InitializeComponent();
            cnn.Open();
        }



        private void Login_button_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(TBUsername.Text) || string.IsNullOrEmpty(PBPassword.Password))
            {
                MessageBox.Show("Введите логин и пароль!");
                return;
            }


            using (var db = new AmonikLastEntities())
            {
                var user = db.Users
                    .AsNoTracking()
                    .FirstOrDefault(u => u.Email == TBUsername.Text && u.Password_p == PBPassword.Password);
                if (user.Active == false)
                {
                    Login_button.IsEnabled = false;
                    MessageBox.Show("Пользователь заблокирован");
                }
                else
                {
                    if (user == null)
                    {
                        MessageBox.Show("Пользователь с такими данными не найден!");
                        return;
                    }

                    else
                    {
                        MessageBox.Show("Пользователь успешно найден!");
                    }

                    switch (user.Role_user)
                    {
                        case "Administrator":
                            //NavigationWindow ad = new NavigationWindow();
                            //ad.Content = new AdminPage();
                            //this.Close();
                            //ad.Show();
                            NavigationService?.Navigate(new AdminPage(TBUsername.Text));
                            break;
                        case "User":
                            //NavigationWindow us = new NavigationWindow();
                            //us.Content = new UserPage(TBUsername.Text);
                            //this.Close();
                            //us.Show();
                            NavigationService?.Navigate(new UserPage(TBUsername.Text));
                            break;
                    }


                    if (SavePasswordCheckBox.IsChecked == true)
                    {

                        var us = db.Users
                        .AsNoTracking()
                        .FirstOrDefault(c => c.Email == TBUsername.Text);

                        SqlCommand cmd = cnn.CreateCommand();

                        cmd.CommandText = @"Update Users Set Chek = 1 where Chek = 0 and Email = '" + TBUsername.Text + "'";
                        SqlDataReader day = cmd.ExecuteReader();
                    }



                    //int click = 0;
                    //if (PBPassword.Password == ) // проверяем пароль так или другими способами
                    //{
                    //    //что-то делаем
                    //}
                    //else if (click >= 2) // лимит превышен
                    //{
                    //    textBox1.Enabled = false; //блокируем текстбокс
                    //}
                }
            }

        }

        private void SavePasswordCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (SavePasswordCheckBox.IsChecked == true)
            {
                CheckList.Visibility = Visibility.Visible;
                List<string> check = new List<string>();
                SqlCommand ccc = cnn.CreateCommand();
                ccc.CommandText = @"select Email from Users where Chek = 1 ";
                SqlDataReader prov = ccc.ExecuteReader();
                check.Clear();
                while (prov.Read())
                    CheckList.Items.Add(String.Format("{0}", prov.GetValue(0).ToString()).Trim());
                prov.Close();

            }

            //SqlCommand cmd = cnn.CreateCommand();
            //cmd.CommandText = @"select Email From Users Where Chek = 1";
            //SqlDataReader r = cmd.ExecuteReader();
            //while (r.Read())
            //{
            //    CheckList.Items.Add(r.GetValue(0).ToString());
            //}

        }

        private void CheckList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = @"select Email, Password_p from Users where Email = '" + CheckList.SelectedItem + "'";
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                TBUsername.Text = r.GetValue(0).ToString();
                PBPassword.Password = r.GetValue(1).ToString();
            }

            CheckList.Visibility = Visibility.Hidden;

        }

    }
}
