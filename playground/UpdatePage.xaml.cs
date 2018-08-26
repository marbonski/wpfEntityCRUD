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
    /// Logika interakcji dla klasy UpdatePage.xaml
    /// </summary>
    public partial class UpdatePage : Window
    {
        dbCRUDEntities _db = new dbCRUDEntities();
        int Id;

        public UpdatePage(int memberID)
        {
            InitializeComponent();
            Id = memberID;
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            member updateMember = (from m in _db.members
                                  where m.id == Id
                                  select m).Single();
            updateMember.name = nameTextBox.Text;
            updateMember.gender = genderComboBox.Text;
            _db.SaveChanges();
            MainWindow.dataGrid.ItemsSource = _db.members.ToList();
            this.Hide();
        }
    }
}
