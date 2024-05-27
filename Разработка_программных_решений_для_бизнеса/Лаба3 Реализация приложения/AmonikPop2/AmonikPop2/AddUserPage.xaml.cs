using System;
using System.Collections.Generic;
using System.Data;
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

namespace AmonikPop2
{
    /// <summary>
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        private Users _currentUser = new Users();
        static string connectionString = "data source=LIZA\\MSSQLSERVER_2;initial catalog=Session1_01_Berezka;integrated security=True;MultipleActiveResultSets=True";
        SqlConnection cnn = new SqlConnection(connectionString);
        
        public AddUserPage()
        { 
            InitializeComponent();
            cnn.Open();

          
            DataTable title = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "select distinct Title from Users";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(title);

            for (int i = 0; i < title.Rows.Count; i++)
            {
                ComboOfficeB.Items.Add(title.Rows[i]["Title"]);
            }

            DataBirth.Text = DateTime.Today.ToString();


        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {


            //SqlCommand cmd = cnn.CreateCommand();

            //cmd.CommandText = @"Insert into Users (Role_user, Email, Password_p, FirstName, LastName, Title, Birthdate, Active, Chek)
            //values (User, '" + Usertb.Text + "', '" + PasswordB.Password + "', '" + FirstNameTB.Text + "', '" + LastNameTB.Text + "', '" + Office.Text + "', '" + DataBirth.SelectedDate + "',  1, 0)";

            StringBuilder err = new StringBuilder();
            DateTime date = (DateTime)DataBirth.SelectedDate;
            var age = DateTime.Now.Year - date.Year;
            if (DateTime.Now.DayOfYear < date.DayOfYear) age--;

            try
            {
                if (age > 18)
                {
                    
                    SqlCommand cmd = cnn.CreateCommand();
                    cmd.CommandText = "Insert into Users (Role_user,Email,Password_p,FirstName,LastName,Title,Birthdate,Active, Chek)values(@ru,@em,@pu,@fn,@ln,@tl,@bd,@av, @ch)";
                    cmd.Parameters.AddWithValue("@ru", "User");
                    cmd.Parameters.AddWithValue("@em", Usertb.Text);
                    cmd.Parameters.AddWithValue("@pu", PasswordB.Password);
                    cmd.Parameters.AddWithValue("@fn", FirstNameTB.Text);
                    cmd.Parameters.AddWithValue("@ln", LastNameTB.Text);
                    cmd.Parameters.AddWithValue("@tl", Convert.ToString(ComboOfficeB.SelectedItem));
                    cmd.Parameters.AddWithValue("@bd", (DateTime)DataBirth.SelectedDate);
                    cmd.Parameters.AddWithValue("@av", true);
                    cmd.Parameters.AddWithValue("@ch", false);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Информация была сохранена!");
                    NavigationService.Navigate(new AdminPage());
                }
                else { MessageBox.Show("Пользователь не может быть такого возраста!"); return; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
