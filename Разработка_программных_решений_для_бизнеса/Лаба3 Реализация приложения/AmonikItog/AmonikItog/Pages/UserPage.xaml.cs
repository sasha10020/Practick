using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
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
using System.Windows.Threading;

namespace AmonikItog.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        static string connectionString = "data source=LIZA\\MSSQLSERVER_2;initial catalog=AmonikLast;integrated security=True;MultipleActiveResultSets=True";
        SqlConnection cnn = new SqlConnection(connectionString);

        public string emailUser;
        public int id;
        DispatcherTimer timer = new DispatcherTimer();

        private int seconds = 0;
        private int minuts = 0;
        private int hours = 0;
        public UserPage(string email)
        {
            InitializeComponent();
            emailUser = email;

            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = @"SELECT FirstName FROM Users WHERE Email = '" + email + "'";
            var one = cmd.ExecuteReader();
            while (one.Read()) { hiLable.Content = "Hi " + one[0].ToString() + ", Welcome to AMONIC Airlines."; }
            //cnn.Close();
            ///////////
            //cnn.Open();
            SqlCommand cmd_id = cnn.CreateCommand();
            cmd_id.CommandText = @"SELECT Id FROM Users WHERE Email = '" + emailUser + "'";
            var _id = cmd_id.ExecuteReader();
            while (_id.Read()) { id = Convert.ToInt32(_id[0]); }
            //cnn.Close();
            ///////////
            //cnn.Open();
            SqlCommand cmd_un = cnn.CreateCommand();
            cmd_un.CommandText = $@"Select Count(Unsuccessful_logout) From SessionTime Where Id = {id} and Unsuccessful_logout != 'Null'";
            var two = cmd_un.ExecuteReader();
            while (two.Read()) { CrashesLable.Content = $"Number of crashes: {two[0]}"; }
            //cnn.Close();
        }

        private void timerTiker(object sender, EventArgs e)
        {
            seconds++;
            if (seconds == 60)
            {
                seconds = 0;
                minuts++;
            }
            if (minuts == 60)
            {
                minuts = 0;
                hours++;
            }
            TimerLable.Content = $"{hours.ToString()}:{minuts.ToString()}:{seconds.ToString()}";
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            TimeSpan time = new TimeSpan(hours, minuts, seconds);
            TimeSpan logout_time = new TimeSpan(Convert.ToInt32(DateTime.Now.ToString("HH")), Convert.ToInt32(DateTime.Now.ToString("mm")), Convert.ToInt32(DateTime.Now.ToString("ss")));
            TimeSpan login_time = logout_time - time;

            StringBuilder err = new StringBuilder();
            try
            {
                //cnn.Open();
                SqlCommand cmd2 = cnn.CreateCommand();
                cmd2.CommandText = @"Insert into SessionTime values(@Id,@Date_login,@Login_time,@Logout_time,@Time_spent,@Unsuccessful_logout)";
                cmd2.Parameters.AddWithValue("@Id", id);
                cmd2.Parameters.AddWithValue("@Date_login", DateTime.Today);
                cmd2.Parameters.AddWithValue("@Login_time", login_time);
                cmd2.Parameters.AddWithValue("@Logout_time", logout_time);
                cmd2.Parameters.AddWithValue("@Time_spent", time);
                cmd2.Parameters.AddWithValue("@Unsuccessful_logout", DBNull.Value);
                cmd2.ExecuteNonQuery();
                //cnn.Close();

                NavigationService.Navigate(new Login());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ShutDownButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            TimeSpan time = new TimeSpan(hours, minuts, seconds);
            TimeSpan logout_time = new TimeSpan(Convert.ToInt32(DateTime.Now.ToString("HH")), Convert.ToInt32(DateTime.Now.ToString("mm")), Convert.ToInt32(DateTime.Now.ToString("ss")));
            TimeSpan login_time = logout_time - time;

            StringBuilder err = new StringBuilder();
            try
            {
                //cnn.Open();
                SqlCommand cmd2 = cnn.CreateCommand();
                cmd2.CommandText = @"Insert into SessionTime values(@Id,@Date_login,@Login_time,NULL,NULL,@Unsuccessful_logout)";
                cmd2.Parameters.AddWithValue("@Id", id);
                cmd2.Parameters.AddWithValue("@Date_login", DateTime.Today);
                cmd2.Parameters.AddWithValue("@Login_time", login_time);
                cmd2.Parameters.AddWithValue("@Unsuccessful_logout", "Power outage");
                cmd2.ExecuteNonQuery();
                //cnn.Close();

                NavigationService.Navigate(new Login());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public DataTable FindUserTime()
        {
            DataTable dt_User = new DataTable();
            dt_User.Columns.Add("Date", System.Type.GetType("System.String"));

            SqlCommand sqlCommand = cnn.CreateCommand();
            sqlCommand.CommandText = @"select Date_login, convert(nvarchar, Login_time, 108) as Login_time, case when Logout_time is null then '**' else convert(nvarchar, Logout_time, 108) end as Logout_time,  case when Time_spent is null then '**' else convert(nvarchar, Time_spent, 108) end as Time_spent, Unsuccessful_logout, case when Unsuccessful_logout = 'Power outage' then 'red' else 'white' end as Color from SessionTime where Id = '" + id + "'";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dt_User);

            for (int i = 0; i < dt_User.Rows.Count; i++)
                dt_User.Rows[i][0] = dt_User.Rows[i][0].ToString().Replace(" 0:00:00", "").Replace('.', '/');

            return dt_User;
        }

        private void Page_ToolTipClosing(object sender, ToolTipEventArgs e)
        {
            TimeSpan time = new TimeSpan(hours, minuts, seconds);
            TimeSpan logout_time = new TimeSpan(Convert.ToInt32(DateTime.Now.ToString("HH")), Convert.ToInt32(DateTime.Now.ToString("mm")), Convert.ToInt32(DateTime.Now.ToString("ss")));
            TimeSpan login_time = logout_time - time;

            try
            {
                //cnn.Open();
                SqlCommand cmd2 = cnn.CreateCommand();
                cmd2.CommandText = @"Insert into SessionTime values(@Id,@Date_login,@Login_time,NULL,NULL,@Unsuccessful_logout)";
                cmd2.Parameters.AddWithValue("@Id", id);
                cmd2.Parameters.AddWithValue("@Date_login", DateTime.Today);
                cmd2.Parameters.AddWithValue("@Login_time", login_time);
                cmd2.Parameters.AddWithValue("@Unsuccessful_logout", "Power outage");
                cmd2.ExecuteNonQuery();
                //cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Page_Loaded_1(object sender, RoutedEventArgs e)
        {
            UserGrid.ItemsSource = FindUserTime().AsDataView();

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timerTiker;
            timer.Start();
        }
    }
}
