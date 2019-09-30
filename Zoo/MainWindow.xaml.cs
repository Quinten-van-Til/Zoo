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

namespace Dierenpark
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int Personen;
        int Kinderen;
        int Gepensioneerden;
        int Echtparen;
        int EchtparenGepensioneerd;
        public void Variables()
        {
            Personen = Class1.ListPersoon.Count;
            Kinderen = Class1.Listkind.Count;
            Gepensioneerden = Class1.List65.Count;
            Echtparen = (Class1.ListEchtpaar.Count / 2);
            EchtparenGepensioneerd = (Class1.ListEchtpaar65.Count / 2);
        }

        public void Labels()
        {
            Variables();
            int prijs = (Personen * 30) + (Kinderen * 11) + (Gepensioneerden * 26) + (Echtparen * 61) + (EchtparenGepensioneerd * 65);
            int Total = Personen + Kinderen + Gepensioneerden + Echtparen + EchtparenGepensioneerd;

            Prijs_Aantal.Content = prijs.ToString("C2");

            if (Total == 0)
                MainRow1.Height = new GridLength(0);
            else
            {
                MainRow1.Height = new GridLength(225);
                if (Personen > 0)
                {
                    Persoon_Txt.Visibility = Visibility.Visible;
                    Persoon_Aantal.Visibility = Visibility.Visible;
                    Persoon_Aantal.Content = Personen;
                }
                if (Kinderen > 0)
                {
                    Kind_Txt.Visibility = Visibility.Visible;
                    Kind_Aantal.Visibility = Visibility.Visible;
                    Kind_Aantal.Content = Kinderen;
                }
                if (Gepensioneerden > 0)
                {
                    Persoon65_Txt.Visibility = Visibility.Visible;
                    Persoon65_Aantal.Visibility = Visibility.Visible;
                    Persoon65_Aantal.Content = Gepensioneerden;
                }
                if (Echtparen > 0)
                {
                    Echtpaar_Txt.Visibility = Visibility.Visible;
                    Echtpaar_Aantal.Visibility = Visibility.Visible;
                    Echtpaar_Aantal.Content = Echtparen;
                }
                if (EchtparenGepensioneerd > 0)
                {
                    Echtpaar65_Txt.Visibility = Visibility.Visible;
                    Echtpaar65_Aantal.Visibility = Visibility.Visible;
                    Echtpaar65_Aantal.Content = EchtparenGepensioneerd;
                }
            }
        }
            public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            Labels();
        }

        private void Button_Click_Persoon(object sender, RoutedEventArgs e)
        {
            WindowPersoon OpenWindow = new WindowPersoon();
            OpenWindow.Show();
            this.Close();
        }

        private void Button_Click_Echtpaar(object sender, RoutedEventArgs e)
        {
            WindowEchtpaar OpenWindow = new WindowEchtpaar();
            OpenWindow.Show();
            this.Close();
        }

        private void Afrekenen_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bedankt voor uw aankoop!");

            Class1.ListPersoon.Clear();
            Class1.Listkind.Clear();
            Class1.List65.Clear();
            Class1.ListEchtpaar.Clear();
            Class1.ListEchtpaar65.Clear();

            Labels();
        }
    }
}
