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
    /// Логика взаимодействия для RegisterLandP.xaml
    /// </summary>
    public partial class RegisterLandP : Page
    {
        land context;
        public RegisterLandP()
        {
            InitializeComponent();
            OwnerCB.ItemsSource = App.DB.owners.ToList();
            context = new land();   
            DataContext = context;
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedOwner = OwnerCB.SelectedItem as owners;
                context.ownerId = selectedOwner.id;
                App.DB.land.Add(context);
                App.DB.SaveChanges();
                MessageBox.Show("Успешно");
                NavigationService.Navigate(new LandList());
            }
            catch
            {
                MessageBox.Show("Ошибка");

            }
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LandList());

        }
    }
}
