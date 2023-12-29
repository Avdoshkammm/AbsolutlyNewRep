using CRUDFromASV.Models;
using System.Text;
using System.Windows;

namespace CRUDFromASV
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow(Product product)
        {
            InitializeComponent();
            this.Title = "Добавление товара";
            Product? currentProduct;

            if(product != null) 
            {
                currentProduct = product;
                this.Title = "Редактирование товара";
                DataContext = currentProduct;
            }
        }

        private void saveProductButtonClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(nameBox.Text))
                errors.AppendLine("Укажите название");
            if (string.IsNullOrWhiteSpace(descriptionBox.Text))
                errors.AppendLine("Укажите описание");
            if (string.IsNullOrWhiteSpace(costBox.Text))
                errors.AppendLine("Укажите цену");

            //
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            using (SportStoreRememberContext db = new SportStoreRememberContext())
            {

                try
                {
                    Product product = new Product()
                    {
                        Name = nameBox.Text,
                        Description = descriptionBox.Text,
                        Cost = Convert.ToDecimal(costBox.Text),
                    };


                    if (product.Cost < 0)
                    {
                        MessageBox.Show("Цена должна быть положительной!");
                        return;
                    }

                    db.Products.Add(product);

                    db.SaveChanges();

                    MessageBox.Show("Продукт успешно добавлен!");
                    this.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.ToString());
                }


            }
        }
    }
}