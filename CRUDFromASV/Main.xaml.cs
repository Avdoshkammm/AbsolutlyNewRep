using CRUDFromASV.Models;
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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main(User user)
        {
            InitializeComponent();
            using (SportStoreRememberContext db = new SportStoreRememberContext())
            {
                if(user != null)
                {
                    MessageBox.Show($"{user.RoleNavigation.Name}: {user.Surname} {user.Name}. \r\t");
                    statusUser.Text = user.RoleNavigation.Name;
                }
                else
                {
                    MessageBox.Show("guest");
                    statusUser.Text = "Гость";
                }

                productlistView.ItemsSource = db.Products.ToList();
            }
        }


        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            new AddWindow(null).ShowDialog();
        }

        private void EditProduct_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Product p = (sender as ListView).SelectedItem as Product;
            new AddWindow(p).ShowDialog();
        }
    }
}
