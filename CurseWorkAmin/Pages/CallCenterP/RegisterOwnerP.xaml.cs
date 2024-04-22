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
    /// Логика взаимодействия для RegisterOwnerP.xaml
    /// </summary>
    public partial class RegisterOwnerP : Page
    {
        owners context;
        public RegisterOwnerP()
        {
            InitializeComponent();
            context = new owners();
            DataContext = context;
        }
        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.DB.owners.Add(context);
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
