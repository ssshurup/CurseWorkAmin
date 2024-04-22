using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для EditLandP.xaml
    /// </summary>
    public partial class EditLandP : Page
    {
        land context;
        public EditLandP(land EditedLand)
        {
            InitializeComponent();
            OwnerCB.ItemsSource = App.DB.owners.ToList();
            context = EditedLand;
            DataContext = context;

        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LandList());
        }
        private void EditBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (context.id == 0)
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
    }
}
