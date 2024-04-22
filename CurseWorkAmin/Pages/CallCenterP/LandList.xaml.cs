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
    /// Логика взаимодействия для LandList.xaml
    /// </summary>
    public partial class LandList : Page
    {
        public LandList()
        {
            InitializeComponent();
            LandListDG.ItemsSource = App.DB.land.ToList();

        }

        private void RegisterLandBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterLandP());
        }

        private void EditLandBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedLand = LandListDG.SelectedItem as land;
            if (selectedLand != null)
            {
                NavigationService.Navigate(new EditLandP(selectedLand));
            }
            else MessageBox.Show("Выберите что-то");
        }

        private void DropEmpBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedLand = LandListDG.SelectedItem as land;
            if (selectedLand != null)
            {
                App.DB.land.Remove(selectedLand);
                LandListDG.ItemsSource = App.DB.land.ToList();
            }
            else MessageBox.Show("Выберите что-то");
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CallCenterManagerP());
        }
    }
}
