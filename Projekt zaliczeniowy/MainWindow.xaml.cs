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

namespace Projekt_zaliczeniowy
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        szkolaEntities _db = new szkolaEntities();

        public static DataGrid datagrid;

        public MainWindow()
        {
            InitializeComponent();
            dataLoad();
        }

        private void dataLoad()
        {
            myGrid.ItemsSource = _db.uczcniowie.ToList();
            datagrid = myGrid;
        }

        private void insertbtn_Click(object sender, RoutedEventArgs e)
        {
            ipage window_ipage = new ipage();
            window_ipage.ShowDialog();
        }

        private void updatebtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myGrid.SelectedItem as uczcniowie).id;
            UIPage winndow_UIPage = new UIPage(Id);
            winndow_UIPage.ShowDialog();

        }

        private void deletebtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myGrid.SelectedItem as uczcniowie).id;
            _db.uczcniowie.Remove((from item in _db.uczcniowie
                                   where item.id == Id
                                   select item).Single());
            _db.SaveChanges();
            myGrid.ItemsSource   = _db.uczcniowie.ToList();
        }
    }
}
