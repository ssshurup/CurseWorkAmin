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

namespace CurseWorkAmin.Pages.WorkerPages
{
    /// <summary>
    /// Логика взаимодействия для WorkPage.xaml
    /// </summary>
    public partial class WorkPage : Page
    {
        public WorkPage()
        {
            InitializeComponent();
            OrderListDG.ItemsSource = App.DB.orders.Where(a => a.employeeId == App.LoggedUser.id).ToList();
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WorkerP());
        }

        private void NextStatusBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = OrderListDG.SelectedItem as orders;
            if (selectedOrder != null && selectedOrder.statusId != 4)
            {
                selectedOrder.statusId++;
                App.DB.SaveChanges();
                MessageBox.Show("Успешно");
                OrderListDG.ItemsSource = App.DB.orders.Where(a => a.employeeId == App.LoggedUser.id).ToList();
            }
            else
            {
                MessageBox.Show("Заказ не выбран или уже выполнен");
            }
        }
    }
}
