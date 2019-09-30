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

namespace Dierenpark
{
    /// <summary>
    /// Interaction logic for WindowEchtpaar.xaml
    /// </summary>
    public partial class WindowEchtpaar : Window
    {
        public WindowEchtpaar()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            EchtpaarRow1.Height = new GridLength(0);
        }

        private void Echtpaar_Birth1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Echtpaar_Birth1.SelectedDate == null || Echtpaar_Birth2.SelectedDate == null)
            {
                EchtpaarRow1.Height = new GridLength(0);
            }
            else
            {
                EchtpaarRow1.Height = new GridLength(225);
            }
        }
        private void Echtpaar_Birth2_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Echtpaar_Birth2.SelectedDate == null || Echtpaar_Birth1.SelectedDate == null)
            {
                EchtpaarRow1.Height = new GridLength(0);
            }
            else
            {
                EchtpaarRow1.Height = new GridLength(225);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var age1 = DateTime.Today.Year - ((DateTime)Echtpaar_Birth1.SelectedDate).Date.Year;
            var age2 = DateTime.Today.Year - ((DateTime)Echtpaar_Birth2.SelectedDate).Date.Year;
            if (age1 > 65 && age2 > 65)
            {
                Class1.ListEchtpaar65.Add(age1);
                Class1.ListEchtpaar65.Add(age2);
            }
            else if (age1 > 9 &&  age2 > 9)
            {
                Class1.ListEchtpaar.Add(age1);
                Class1.ListEchtpaar.Add(age2);
            }
            else 
            {
                MessageBox.Show("Er is iemand te jong om te trouwen");
            }
            MainWindow OpenWindow = new MainWindow();
            OpenWindow.Show();
            this.Close();
        }
    }
}
