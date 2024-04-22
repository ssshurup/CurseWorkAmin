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

namespace CurseWorkAmin.Pages.CallCenterP
{
    /// <summary>
    /// Логика взаимодействия для CreateRentP.xaml
    /// </summary>
    public partial class CreateRentP : Page
    {
        rentLand context;
        public CreateRentP()
        {
            InitializeComponent();
            LandCB.ItemsSource = App.DB.land.Where(a => a.ownerId == 1).ToList();
            ClientCB.ItemsSource = App.DB.clients.ToList();
            context = new rentLand();
            DataContext = context;
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(DateEndDP.SelectedDate == DateStartDP.SelectedDate)
                {
                    MessageBox.Show("Дата начала и дата конца аренды не могут совпадать");
                    return;
                }
                else if(DateEndDP.SelectedDate > DateStartDP.SelectedDate)
                {
                    MessageBox.Show("Дата конца аренда не может быть раньше начала");
                    return;
                }
                var selectedLand = LandCB.SelectedItem as land;
                context.idLand = selectedLand.id;

                var selectedClient = ClientCB.SelectedItem as clients;
                context.idClient = selectedClient.id;

                context.dateStard = DateStartDP.SelectedDate;
                context.dateEnd = DateEndDP.SelectedDate;

                App.DB.rentLand.Add(context);
                App.DB.SaveChanges();
                MessageBox.Show("Успешно");
                NavigationService.Navigate(new CallCenterManagerP());
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CallCenterManagerP());

        }
    }
}
