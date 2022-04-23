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
    /// 

    public partial class MainWindow : Window
    {
        public int idd = 0;
        public MainWindow()
        {

            ObservableCollection<Book> books = new ObservableCollection<Book>(MyBookCollection.GetMyCollection());
            InitializeComponent();
            BooksList.ItemsSource = books;
            cmbBooks.ItemsSource = Enum.GetValues(typeof(BookFormat));
            int tempid = 0;
            foreach (Book book in (ObservableCollection<Book>)BooksList.ItemsSource)
            {
                if (book.Id > tempid)
                {
                    tempid = book.Id;
                }
            }
            idd = tempid;

        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this record?",
            "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                ((ObservableCollection<Book>)BooksList.ItemsSource).Remove((Book)BooksList.SelectedItem);
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            idd += 1;
            Book temp = new Book(idd);
            temp.IsRead = (bool)IsRead.IsChecked;
            temp.Author = Author.Text;
            if (Year.Text != "") 
            temp.Year = int.Parse(Year.Text);
            temp.Title = Title.Text;
          

            if(temp.Author != "" && temp.Year != null && temp.Title != "")
                ((ObservableCollection<Book>)BooksList.ItemsSource).Add(temp);
        }
    }
}
