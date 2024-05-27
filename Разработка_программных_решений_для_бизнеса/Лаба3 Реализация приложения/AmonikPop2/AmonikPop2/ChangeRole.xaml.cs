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

namespace AmonikPop2
{
    /// <summary>
    /// Логика взаимодействия для ChangeRole.xaml
    /// </summary>
    public partial class ChangeRole : Page
    {
        static string connectionString = "data source=LIZA\\MSSQLSERVER_2;initial catalog=Session1_01_Berezka;integrated security=True;MultipleActiveResultSets=True";
        SqlConnection cnn = new SqlConnection(connectionString);

        public ChangeRole()
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
        }

        
        private void CancelB_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();

        }

        private void ApplyB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(EmailTB.Text) || string.IsNullOrEmpty(FirstNametb.Text) || string.IsNullOrEmpty(LastNametb.Text) || string.IsNullOrEmpty(Convert.ToString(ComboOffice.SelectedItem)))
                {
                    MessageBox.Show("Введите данные");
                    return;
                }

                using (var db = new Session1_01_BerezkaEntities())
                {
                    var user = db.Users
                        .AsNoTracking()
                        .FirstOrDefault(u => u.Email == EmailTB.Text && u.FirstName == FirstNametb.Text && u.LastName == LastNametb.Text && u.Title == ComboOffice.Text);

                    if (user == null)
                    {
                        MessageBox.Show("Введите корректные данные");
                        return;
                    }


                    if (UserCheckBox.IsChecked == true)
                    {


                        var us = db.Users
                          .AsNoTracking()
                          .FirstOrDefault(c => c.Email == EmailTB.Text);

                        SqlCommand cmd = cnn.CreateCommand();

                        cmd.CommandText = @"Update Users Set Role_user = 'User' where Role_user = 'Administrator' and Email = '" + EmailTB.Text + "'";
                        SqlDataReader day = cmd.ExecuteReader();

                    

                    }

                    if (AdminChecBox.IsChecked == true)
                    {

                        var uss = db.Users
                          .AsNoTracking()
                          .FirstOrDefault(c => c.Email == EmailTB.Text);


                        SqlCommand cmd = cnn.CreateCommand();

                        cmd.CommandText = @"Update Users Set Role_user = 'Administrator' where Role_user = 'User' and Email = '" + EmailTB.Text + "'";
                        SqlDataReader day = cmd.ExecuteReader();


                    }


                }

                MessageBox.Show("Данные обновлены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }   

        } 

    }

}

       
    

