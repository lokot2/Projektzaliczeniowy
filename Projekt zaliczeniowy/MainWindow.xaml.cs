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

  

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void uczniowie_btn_Click(object sender, RoutedEventArgs e)
        {
            StudentsPage window_StudentsPage = new StudentsPage();
            window_StudentsPage.ShowDialog();
        }

        private void nauczyciele_btn_Click(object sender, RoutedEventArgs e)
        {
            Nauczyciele window_Nauczyciele = new Nauczyciele();
            window_Nauczyciele.ShowDialog();

        }

        private void klasy_btn_Click(object sender, RoutedEventArgs e)
        {
            Klasy window_Klasy = new Klasy();
            window_Klasy.ShowDialog();
        }

        private void przedmioty_btn_Click(object sender, RoutedEventArgs e)
        {
            Przedmioty window_Przedmioty = new Przedmioty();
            window_Przedmioty.ShowDialog();
        }
    }
}
