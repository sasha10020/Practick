using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Логика взаимодействия для ChangeRole.xaml
    /// </summary>
    public partial class ChangeRole : Page
    {
        private Users _currentUser = new Users();
        static string connectionString = "data source=LIZA\\MSSQLSERVER_2;initial catalog=AmonikLast;integrated security=True;MultipleActiveResultSets=True";
        SqlConnection cnn = new SqlConnection(connectionString);
        List<string> user = new List<string>();
        DataGrid dg_Users = new DataGrid();
        public ChangeRole(string userEmail, DataGrid dg)
        {
            InitializeComponent();
            DataTable title = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "select distinct Title from Users";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(title);

            for (int i = 0; i < title.Rows.Count; i++)
            {
                ComboOffice.Items.Add(title.Rows[i]["Title"]);
            }

            DataContext = _currentUser;
            //ComboOffice.ItemsSource = title;
            user.Add(userEmail);
            dg_Users = dg;
        }


        private void CancelB_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();

        }

        private void ApplyB_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                //cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "Update Users Set Role_user = @ru, FirstName = @fn, LastName = @ln, Title = @tl Where Email = @em";
                cmd.Parameters.AddWithValue("@ru", (bool)UserCheckBox.IsChecked ? "User" : "Administrator");
                cmd.Parameters.AddWithValue("@fn", FirstNametb.Text);
                cmd.Parameters.AddWithValue("@ln", LastNametb.Text);
                cmd.Parameters.AddWithValue("@tl", Convert.ToString(ComboOffice.SelectedItem));
                cmd.Parameters.AddWithValue("@em", EmailTB.Text);
                cmd.ExecuteNonQuery();
                //cnn.Close();

                MessageBox.Show("Chenched was saved!");
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


            //    try
            //    {
            //        if (string.IsNullOrEmpty(EmailTB.Text) || string.IsNullOrEmpty(FirstNametb.Text) || string.IsNullOrEmpty(LastNametb.Text) || string.IsNullOrEmpty(Convert.ToString(ComboOffice.SelectedItem)))
            //        {
            //            MessageBox.Show("Введите данные");
            //            return;
            //        }

            //        using (var db = new AmonikLastEntities())
            //        {
            //            var user = db.Users
            //                .AsNoTracking()
            //                .FirstOrDefault(u => u.Email == EmailTB.Text && u.FirstName == FirstNametb.Text && u.LastName == LastNametb.Text && u.Title == ComboOffice.Text);

            //            if (user == null)
            //            {
            //                MessageBox.Show("Введите корректные данные");
            //                return;
            //            }


            //            if (UserCheckBox.IsChecked == true)
            //            {


            //                var us = db.Users
            //                  .AsNoTracking()
            //                  .FirstOrDefault(c => c.Email == EmailTB.Text);

            //                SqlCommand cmd = cnn.CreateCommand();

            //                cmd.CommandText = @"Update Users Set Role_user = 'User' where Role_user = 'Administrator' and Email = '" + EmailTB.Text + "'";
            //                SqlDataReader day = cmd.ExecuteReader();



            //            }

            //            if (AdminChecBox.IsChecked == true)
            //            {

            //                var uss = db.Users
            //                  .AsNoTracking()
            //                  .FirstOrDefault(c => c.Email == EmailTB.Text);


            //                SqlCommand cmd = cnn.CreateCommand();

            //                cmd.CommandText = @"Update Users Set Role_user = 'Administrator' where Role_user = 'User' and Email = '" + EmailTB.Text + "'";
            //                SqlDataReader day = cmd.ExecuteReader();


            //            }


            //        }

            //        MessageBox.Show("Данные обновлены");

            //        NavigationService.GoBack();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message.ToString());
            //    }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt_User = new DataTable();

            SqlCommand sqlCommand = cnn.CreateCommand();
            sqlCommand.CommandText = "select FirstName, LastName, Title, Role_user from Users where Email = '" + user[0] + "'";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dt_User);

            for (int i = 0; i < dt_User.Columns.Count; i++)
                user.Add(dt_User.Rows[0][i].ToString());

            for (int i = 0; i < user.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        EmailTB.Text = user[i];
                        break;
                    case 1:
                        FirstNametb.Text = user[i];
                        break;
                    case 2:
                        LastNametb.Text = user[i];
                        break;
                    case 4:
                        if (user[4] == "User")
                            UserCheckBox.IsChecked = true;
                        else
                            AdminChecBox.IsChecked = true;
                        break;
                }
            }

            for (int i = 0; i < ComboOffice.Items.Count; i++)
                if (ComboOffice.Items[i].ToString() == user[3])
                    ComboOffice.SelectedIndex = i;
        }
    }
}
