using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
    /// Логика взаимодействия для AddEmployeeP.xaml
    /// </summary>
    public partial class AddEmployeeP : Page
    {
        users context;
        public AddEmployeeP()
        {

            InitializeComponent();
            PostCB.ItemsSource = App.DB.role.ToList();
            context = new users();
            DataContext = context;
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedPost = PostCB.SelectedItem as role;
                context.roleId = selectedPost.id;
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

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeeP()) ;
        }
    }
}
