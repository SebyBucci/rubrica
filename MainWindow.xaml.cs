using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace bucci.sebastian._4i.rubricaUnoAMolti
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Persone persone;
        Contatti contatti;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                persone = new Persone("Persone.csv");
                dgPersone.ItemsSource = persone;

                contatti = new("Contatti.csv");

                statusbar.Text = $"Ho letto dal file" +
                        $"{persone.Count} persone, e" +
                        $"{contatti.Count} contatti";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void adOgniRiga(object sender, DataGridRowEventArgs e)
        {
            Persona p = e.Row.Item as Persona;
            if (p != null)
            {
                if (p.IdPersona == 1)
                {
                    e.Row.Background = Brushes.Red;
                    e.Row.Foreground = Brushes.White;
                }
            }
        }

        private void dgDati_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Persona p = e.AddedItems[0] as Persona;

            if (p != null)
            {
                statusbar.Text = $"Hai selezionato {p.Nome} {p.Cognome}";

                Contatti contattiFiltrati = new();

                foreach (var item in contatti)
                    if (item.idPersona == p.IdPersona)
                        contattiFiltrati.Add(item);

                dgContatti.ItemsSource = contattiFiltrati;

            }
        }

        private void dgContatti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { }

    }
}