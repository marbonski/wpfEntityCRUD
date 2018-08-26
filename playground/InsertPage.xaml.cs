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

namespace entityCRUD
{
    /// <summary>
    /// Logika interakcji dla klasy InsertPage.xaml
    /// </summary>
    public partial class InsertPage : Window
    {
        dbCRUDEntities _db = new dbCRUDEntities();
        public InsertPage()
        {
            InitializeComponent();
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            member newMember = new member()
            {
                name = nameTextBox.Text,
                gender = genderComboBox.Text
            };

            _db.members.Add(newMember);
            _db.SaveChanges();
            MainWindow.dataGrid.ItemsSource = _db.members.ToList();
            this.Hide();

        }
    }
}
