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

namespace CurseWorkAmin.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginP.xaml
    /// </summary>
    public partial class LoginP : Page
    {
        users context;
        public LoginP()
        {
            InitializeComponent();
            context = new users();
            DataContext = context;
        }
        private void LogBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var loggedUser = App.DB.users.Where(a => a.login == context.login && a.password == context.password);
                if (loggedUser.Any())
                {
                    App.LoggedUser = loggedUser.First();
                    if (App.LoggedUser.roleId == 1) NavigationService.Navigate(new HrManagerP());
                    else if (App.LoggedUser.roleId == 2) NavigationService.Navigate(new CallCenterManagerP());
                    else if (App.LoggedUser.roleId == 3) NavigationService.Navigate(new WorkerP());
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
