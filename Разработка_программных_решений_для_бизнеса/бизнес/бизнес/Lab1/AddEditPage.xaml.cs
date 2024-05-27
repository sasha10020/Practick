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

namespace Lab1
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {

        private Hotel currentHotel = new Hotel();
        public AddEditPage(Hotel selectedHotel)
        {
            InitializeComponent();
            if (selectedHotel != null)
                currentHotel = selectedHotel;
            DataContext = selectedHotel;
            ComboCountres.ItemsSource = newHotelEntities.GetContext().Country.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(currentHotel.Name_hotel))
            {
                errors.AppendLine("Укажите название отеля");
            }    
            if (currentHotel.Count_of_stars < 1 || currentHotel.Count_of_stars > 5)
            {
                errors.AppendLine("Количество звезд - от 1 до 5");
            }
            if (currentHotel.Country == null)
            {
                errors.AppendLine("Выберите страну");
            }
            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (currentHotel.id == 0)
                newHotelEntities.GetContext().Hotel.Add(currentHotel);

            try
            {
                newHotelEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ComboCountres_SelectionChanged()
        {

        }
    }
}
