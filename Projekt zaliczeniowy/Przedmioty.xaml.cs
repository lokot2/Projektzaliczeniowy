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
    /// Logika interakcji dla klasy Przedmioty.xaml
    /// </summary>
    public partial class Przedmioty : Window
    {
        public Przedmioty()
        {
            InitializeComponent();
            dataLoad();
        }
        szkolaEntities _db = new szkolaEntities();

        public static DataGrid datagrid;


        private void dataLoad()
        {
            myGrid.ItemsSource = _db.Przedmiot.ToList();
            datagrid = myGrid;
        }

        private void insertbtn_Click(object sender, RoutedEventArgs e)
        {
            ipage_Przedmioty window_ipage_Przedmioty = new ipage_Przedmioty();
            window_ipage_Przedmioty.ShowDialog();
        }

        private void updatebtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myGrid.SelectedItem as Przedmiot).id;
            UIPage_Przedmioty winndow_UIPage_Przedmioty = new UIPage_Przedmioty(Id);
            winndow_UIPage_Przedmioty.ShowDialog();

        }

        private void deletebtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myGrid.SelectedItem as Przedmiot).id;
            _db.Przedmiot.Remove((from item in _db.Przedmiot
                                  where item.id == Id
                                  select item).Single());
            _db.SaveChanges();
            myGrid.ItemsSource = _db.Przedmiot.ToList();
        }
    }
}

