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
    /// Logika interakcji dla klasy Nauczyciele.xaml
    /// </summary>
    public partial class Nauczyciele : Window
    {
        public Nauczyciele()
        {
            InitializeComponent();
            dataLoad();
        }

        szkolaEntities _db = new szkolaEntities();

        public static DataGrid datagrid;


        private void dataLoad()
        {
            myGrid.ItemsSource = _db.nauczyciele.ToList();
            datagrid = myGrid;
        }

        private void insertbtn_Click(object sender, RoutedEventArgs e)
        {
            ipage window_ipage = new ipage();
            window_ipage.ShowDialog();
        }

        private void updatebtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myGrid.SelectedItem as nauczyciele).id;
            UIPage winndow_UIPage = new UIPage(Id);
            winndow_UIPage.ShowDialog();

        }

        private void deletebtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myGrid.SelectedItem as nauczyciele).id;
            _db.nauczyciele.Remove((from item in _db.nauczyciele
                                  where item.id == Id
                                  select item).Single());
            _db.SaveChanges();
            myGrid.ItemsSource = _db.nauczyciele.ToList();
        }
    }
}

