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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        static string connectionString = "data source=LIZA\\MSSQLSERVER_2;initial catalog=AmonikLast;integrated security=True;MultipleActiveResultSets=True";
        SqlConnection cnn = new SqlConnection(connectionString);
        bool refreshDG = false;
        string emailAdmin = "";
        public AdminPage(string email)
        {
            InitializeComponent();
            cnn.Open();
            AdminGrid.ItemsSource = AmonikLastEntities.GetContext().Users.ToList();
            emailAdmin = email;
            UpdateUsers();
        }


        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddUserPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (AdminGrid.SelectedItems.Count == 1)
            {
                string userEmail = ((DataRowView)AdminGrid.SelectedItems[0]).Row["Email"].ToString();
                refreshDG = true;
                NavigationService.Navigate(new ChangeRole(userEmail, AdminGrid));
            }
            else
                MessageBox.Show("Select 1 person!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            //NavigationService.Navigate(new ChangeRole());
        }

        private void UpdateUsers()
        {
            List<AmonikItog.Users> currentUser = new List<AmonikItog.Users>();
            var currentOffice = OfficeComboBox.SelectedItem as Users;

            if (OfficeComboBox.SelectedIndex > 0)
                currentUser = AppData.db.Users.Where(p => p.Title == OfficeComboBox.SelectedItem).ToList();

            AdminGrid.ItemsSource = currentUser;


            if (OfficeComboBox.SelectedIndex == 0)
            {
                AdminGrid.ItemsSource = FindAllUsersInfo().AsDataView();
            }
            //else
            //{
            //    UserGrid.ItemsSource = FindByOfficesUsersInfo(OfficeComboBox.SelectedItem.ToString()).AsDataView();
            //}
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            OfficeComboBox.ItemsSource = FillingCb("All Offices");
            OfficeComboBox.SelectedIndex = 0;
        }


        public DataTable FindAllUsersInfo()
        {
            DataTable dt_Users = new DataTable();

            SqlCommand sqlCommand = cnn.CreateCommand();
            sqlCommand.CommandText = "select FirstName, LastName, datediff(year, Birthdate, getdate()) as Age, Role_user, Email, Title, case when Active = 0 then 'red' when Role_user = 'Administrator' then 'green' else 'white' end as User_Color from Users";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dt_Users);

            return dt_Users;
        }

        public List<string> FillingCb(string FirstItem)
        {
            DataTable dt_Offices = new DataTable();
            List<string> offices = new List<string>() { FirstItem };

            SqlCommand sqlCommand = cnn.CreateCommand();
            sqlCommand.CommandText = "select distinct Title from Users";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dt_Offices);

            for (int i = 0; i < dt_Offices.Rows.Count; i++)
                offices.Add(dt_Offices.Rows[i][0].ToString());

            return offices;
        }

        private void Page_IsVisibleChanged_1(object sender, DependencyPropertyChangedEventArgs e)
        {
            AmonikLastEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            AdminGrid.ItemsSource = AmonikLastEntities.GetContext().Users.ToList();
            UpdateUsers();
        }

        private void OfficeComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            UpdateUsers();
        }

        private void ButtonColor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBlock email = AdminGrid.Columns[EmailColumn.DisplayIndex].GetCellContent(AdminGrid.Items[AdminGrid.SelectedIndex]) as TextBlock;

                if (email.Text == emailAdmin)
                {
                    MessageBox.Show("Администратор не может быть заблокирован!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                SqlCommand cmd = cnn.CreateCommand();
                cmd.Parameters.AddWithValue("@em", email.Text);
                cmd.CommandText = "Update Users Set Active = case when Active = 0 then 1 else 0 end Where Email = @em";
                cmd.ExecuteNonQuery();
                

            }
            catch
            {
                MessageBox.Show("Выберите пользователя!");
            }


            AmonikLastEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            AdminGrid.ItemsSource = AmonikLastEntities.GetContext().Users.ToList();

            UpdateUsers();
        }


        private void AdminGrid_GotFocus(object sender, RoutedEventArgs e)
        {
            if (refreshDG)
            {
                refreshDG = false;
                UpdateUsers();
            }
        }

        private void AdminGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
