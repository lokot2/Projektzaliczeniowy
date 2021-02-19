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
    /// Logika interakcji dla klasy ipage.xaml
    /// </summary>
    public partial class ipage : Window
    {
        szkolaEntities _db = new szkolaEntities();

        public ipage()
        {
            InitializeComponent();
        }
        private void iButton_Click(object sender, RoutedEventArgs e)
        {
            uczcniowie newStudent = new uczcniowie()
            {
                imie = answer1.Text,
                płeć = icombobox.Text
            };

            _db.uczcniowie.Add(newStudent);
            _db.SaveChanges();
            MainWindow.datagrid.ItemsSource = _db.uczcniowie.ToList();
            this.Hide();
        }
    }
}
