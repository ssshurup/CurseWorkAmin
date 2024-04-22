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

namespace CurseWorkAmin.Pages.HrPager
{
    /// <summary>
    /// Логика взаимодействия для EmployeeP.xaml
    /// </summary>
    public partial class EmployeeP : Page
    {
        public EmployeeP()
        {
            InitializeComponent();
            EmployeeListDG.ItemsSource = App.DB.users.ToList();
        }

        private void EditEmpBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = EmployeeListDG.SelectedItem as users;
            if (selectedEmployee != null)
            {
                NavigationService.Navigate(new EditEmployeeP(selectedEmployee));
            }
            else MessageBox.Show("Выберите что-то");
        }

        private void DropEmpBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = EmployeeListDG.SelectedItem as users;
            if (selectedEmployee != null)
            {
                App.DB.users.Remove(selectedEmployee);
                App.DB.SaveChanges();
                MessageBox.Show("Успешно");
                EmployeeListDG.ItemsSource = App.DB.users.ToList();
            }
            else MessageBox.Show("Выберите что-то");
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HrManagerP());
        }

        private void AddEmpBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEmployeeP());
        }
    }
}
