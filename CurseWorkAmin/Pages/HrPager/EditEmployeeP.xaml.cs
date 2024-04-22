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
    /// Логика взаимодействия для EditEmployeeP.xaml
    /// </summary>
    public partial class EditEmployeeP : Page
    {
        users context;
        public EditEmployeeP( users employee)
        {
            InitializeComponent();
            PostCB.ItemsSource = App.DB.role.ToList();
            context = employee;
            DataContext = context;
        }
        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeeP());
        }
        private void EditBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (context.id == 0)
                    App.DB.users.Add(context);
                App.DB.SaveChanges();
                MessageBox.Show("Успешно");
                NavigationService.Navigate(new HrManagerP());
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
