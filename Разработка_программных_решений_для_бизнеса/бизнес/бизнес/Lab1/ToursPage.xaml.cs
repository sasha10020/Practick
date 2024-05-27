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
    /// Логика взаимодействия для ToursPage.xaml
    /// </summary>
    public partial class ToursPage : Page
    {
        public ToursPage()
        {
            InitializeComponent();
            

            var allTypes = newHotelEntities.GetContext().Type_Hotel.ToList();
            allTypes.Insert(0, new Type_Hotel
            { Name_type = "Все типы" }
            ) ;

            ComboType.ItemsSource = allTypes;

            CheckActual.IsChecked = true;
            ComboType.SelectedIndex = 0;

            var currentTours = newHotelEntities.GetContext().Tour.ToList();
            LViewTours.ItemsSource = currentTours;

            UpdateTours();

        }

        private void UpdateTours()
        {
            var currentTours = newHotelEntities.GetContext().Tour.ToList();
            var currentType = ComboType.SelectedItem as Type_Hotel;

            if (ComboType.SelectedIndex > 0)
                currentTours = currentTours.Where(p => p.Type_Hotel.Name_type.Contains((ComboType.SelectedItem as Type_Hotel).Name_type)).ToList();
            //currentTours = currentTours.Where(p => p.Type_Hotel.Name_type.Contains(Convert.ToString(ComboType.SelectedItem as Type_Hotel))).ToList();
            currentTours = currentTours.Where(p => p.Name_tour.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            if (CheckActual.IsChecked.Value)
                currentTours = currentTours.Where(p => (bool)p.Is_Actual).ToList();

            LViewTours.ItemsSource = currentTours.OrderBy(p => p.Ticket_count).ToList();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTours();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTours();
        }

        private void CheckActual_Checked(object sender, RoutedEventArgs e)
        {
            UpdateTours();
        }

        private void CheckActual_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateTours();
        }
    }
}
