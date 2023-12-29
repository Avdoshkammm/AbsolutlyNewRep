using CRUDFromASV.Models;
using Microsoft.EntityFrameworkCore;
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
using System.Windows.Shapes;

namespace CRUDFromASV
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            using(SportStoreRememberContext db = new SportStoreRememberContext())
            {
                User user = db.Users.Where(u => u.Login == loginBox.Text && u.Password == passwordBox.Password).Include(u => u.RoleNavigation).FirstOrDefault() as User;
                if (user != null) 
                {
                    Main main = new Main(user);
                    main.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Fuck you!");
                }
            }
        }

        private void guestButton_Click(object sender, RoutedEventArgs e)
        {
            Main main = new Main(null);
            main.Show();
            this.Close();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
