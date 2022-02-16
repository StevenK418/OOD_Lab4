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

namespace WPF_DB_Test1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NORTHWNDEntities db = new NORTHWNDEntities();

        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnQuery_Click(object sender, RoutedEventArgs e)
        {
            var query = from c in db.Customers
                select c.CompanyName;
            lbxCustomerEx1.ItemsSource = query.ToList();
        }

        private void btnQueryEx2_Click(object sender, RoutedEventArgs e)
        {
            var query = from c in db.Customers
                select c;
            lbxCustomerEx2.ItemsSource = query.ToList();
        }

        private void btnQueryEx3_Click(object sender, RoutedEventArgs e)
        {
            var query = from o in db.Orders
                where o.Customer.City.Equals("London")
                      || o.Customer.City.Equals("Paris")
                      || o.Customer.City.Equals("USA")
                orderby o.Customer.CompanyName
                select new
                {
                    CustomerName = o.Customer.CompanyName,
                    City = o.Customer.City,
                    Address = o.ShipAddress
                };

            //Show the retrieved data in the listbox
            lbxCustomerEx3.ItemsSource = query.ToList();
        }

        private void btnQueryEx4_Click(object sender, RoutedEventArgs e)
        {
            var query = from p in db.Products
                                            where p.Category.CategoryName.Equals("Beverages")
                                            orderby p.ProductID descending 
                                            select new
                                            {
                                                p.ProductID,
                                                p.ProductName,
                                                p.Category.CategoryName,
                                                p.UnitPrice
                                            };

            //Show the retrieved data in the listbox
            lbxCustomerEx4.ItemsSource = query.ToList();
        }
    }
}
