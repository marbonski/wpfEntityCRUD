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

namespace entityCRUD
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        dbCRUDEntities _db = new dbCRUDEntities();
        public static DataGrid dataGrid;
        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        public void Load()
        {
            myDataGrid.ItemsSource = _db.members.ToList();
            dataGrid = myDataGrid;
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            InsertPage Ipage = new InsertPage();
            Ipage.ShowDialog();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as member).id;
            UpdatePage Upage = new UpdatePage(id);
            Upage.ShowDialog();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as member).id;
            var deleteMember = _db.members.Where(m => m.id == id).Single();
            _db.members.Remove(deleteMember);
            _db.SaveChanges();
            myDataGrid.ItemsSource = _db.members.ToList();
        }
    }
}
