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
    /// Логика взаимодействия для CreateOrderP.xaml
    /// </summary>
    public partial class CreateOrderP : Page
    {
        orders context;
        public CreateOrderP()
        {
            InitializeComponent();
            DateDP.SelectedDate = DateTime.Now.Date;
            EmployeeCB.ItemsSource = App.DB.users.Where(x => x.roleId == 3).ToList();
            LandCB.ItemsSource = App.DB.land.ToList();
            ServiceCB.ItemsSource = App.DB.services.ToList();
            context = new orders();
            DataContext = context;
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedLand = LandCB.SelectedItem as land;
                context.landId = selectedLand.id;

                var selectedEmp = EmployeeCB.SelectedItem as users;
                context.employeeId = selectedEmp.id;

                var selectedService = ServiceCB.SelectedItem as services;
                context.serviceId = selectedService.id;

                context.dateVisit = DateDP.SelectedDate;
                context.statusId = 1;
                App.DB.orders.Add(context);
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
