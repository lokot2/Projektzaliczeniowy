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
    /// Logika interakcji dla klasy Klasy.xaml
    /// </summary>
    public partial class Klasy : Window
    {
        public Klasy()
        {
            InitializeComponent();
            dataLoad();
        }
        szkolaEntities _db = new szkolaEntities();

        public static DataGrid datagrid;


        private void dataLoad()
        {
            myGrid.ItemsSource = _db.Klasa.ToList();
            datagrid = myGrid;
        }

        private void insertbtn_Click(object sender, RoutedEventArgs e)
        {
            ipage_Klasy window_ipage_Klasy = new ipage_Klasy();
            window_ipage_Klasy.ShowDialog();
        }

        private void updatebtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myGrid.SelectedItem as Klasa).id;
            UIPage_Klasy winndow_UIPage_Klasy = new UIPage_Klasy(Id);
            winndow_UIPage_Klasy.ShowDialog();

        }

        private void deletebtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myGrid.SelectedItem as Klasa).id;
            _db.Klasa.Remove((from item in _db.Klasa
                                  where item.id == Id
                                  select item).Single());
            _db.SaveChanges();
            myGrid.ItemsSource = _db.Klasa.ToList();
        }
    }
}

