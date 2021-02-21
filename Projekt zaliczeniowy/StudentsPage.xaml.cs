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
    /// Logika interakcji dla klasy StudentsPage.xaml
    /// </summary>
    public partial class StudentsPage  : Window
    {

        
        public StudentsPage()
        {
            InitializeComponent();
            dataLoad();
        }

        szkolaEntities _db = new szkolaEntities();

        public static DataGrid datagrid;


        private void dataLoad()
        {
            myGrid.ItemsSource = _db.uczniowie.ToList();
            datagrid = myGrid;
        }

        private void insertbtn_Click(object sender, RoutedEventArgs e)
        {
            ipage window_ipage = new ipage();
            window_ipage.ShowDialog();
        }

        private void updatebtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myGrid.SelectedItem as uczniowie).id;
            UIPage winndow_UIPage = new UIPage(Id);
            winndow_UIPage.ShowDialog();

        }

        private void deletebtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myGrid.SelectedItem as uczniowie).id;
            _db.uczniowie.Remove((from item in _db.uczniowie
                                  where item.id == Id
                                  select item).Single());
            _db.SaveChanges();
            myGrid.ItemsSource = _db.uczniowie.ToList();

        }
    }
}

