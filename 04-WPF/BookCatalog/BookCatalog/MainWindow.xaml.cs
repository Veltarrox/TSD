using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BookCatalog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            ObservableCollection<Book> books = new ObservableCollection<Book>(MyBookCollection.GetMyCollection());
            InitializeComponent();
            BooksList.ItemsSource = books;
            cmbBooks.ItemsSource = Enum.GetValues(typeof(BookFormat));
            
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            ((ObservableCollection<Book>)BooksList.ItemsSource).Remove((Book)BooksList.SelectedItem);
        }
    }
}
