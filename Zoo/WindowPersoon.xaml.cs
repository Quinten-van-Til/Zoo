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
    /// Interaction logic for WindowPersoon.xaml
    /// </summary>
    public partial class WindowPersoon : Window
    {
        public WindowPersoon()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            PersoonRow1.Height = new GridLength(0);
        }

        private void Persoon_Birth_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Persoon_Birth.SelectedDate == null)
            {
                PersoonRow1.Height = new GridLength(0);
            }
            else
            {
                PersoonRow1.Height = new GridLength(225);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var age = DateTime.Today.Year - ((DateTime)Persoon_Birth.SelectedDate).Date.Year;
            if(age > 65 )
            {
                Class1.List65.Add(age);
            }
            else if (age > 9)
            {
                Class1.ListPersoon.Add(age);
            }
            else if(age > 2)
            {
                Class1.Listkind.Add(age);
            }
            MainWindow OpenWindow = new MainWindow();
            OpenWindow.Show();
            this.Close();
        }
    }
}
