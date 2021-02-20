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

namespace Projekt_zaliczeniowy
{
    /// <summary>
    /// Logika interakcji dla klasy UIPage.xaml
    /// </summary>
    public partial class UIPage : Window
    {
        szkolaEntities _db = new szkolaEntities();
        int Id;
        public UIPage(int student_id)
        {
            InitializeComponent();
            Id = student_id;
            
        }

        private void uButton_Click(object sender, RoutedEventArgs e)
        {
            uczniowie updatestudent = (from item in _db.uczniowie
                                        where item.id == Id
                                        select item).Single();
            updatestudent.imie = answer1.Text;
            updatestudent.płeć = icombobox.Text;
            _db.SaveChanges();
            StudentsPage.datagrid.ItemsSource = _db.uczniowie.ToList();
            this.Hide();
        }
    }
}
