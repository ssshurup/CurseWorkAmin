using CurseWorkAmin.Pages.CallCenterP;
using CurseWorkAmin.Pages.HrPager;
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

namespace CurseWorkAmin.Pages
{
    /// <summary>
    /// Логика взаимодействия для CallCenterManagerP.xaml
    /// </summary>
    public partial class CallCenterManagerP : Page
    {
        public CallCenterManagerP()
        {
            InitializeComponent();
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginP());
        }

        private void RegisterOwner_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterOwnerP());
        }


        private void CreateeOrderBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateOrderP());
        }

     
        private void CreateRentBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateRentP());
        }

        private void landList_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LandList());
        }
    }
}
