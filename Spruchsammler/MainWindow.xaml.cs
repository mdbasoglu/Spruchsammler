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
using System.IO;


namespace Spruchsammler
{
    public partial class MainWindow : Window
    {
        private SpruchListeDatei _datei;
        private List<Spruch> _sprüche;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _datei = new SpruchListeDatei("../../../Sprüche.txt");
            _sprüche = _datei.Laden();
            lbxSprüche.ItemsSource = _sprüche;
            btnSpeichern.IsEnabled = false;
            btnLöschen.IsEnabled = false;
        }
        private void BtnSpeichern_Click(object sender, RoutedEventArgs e)
        {
            string text = tbxSpruchtext.Text;
            string autor = tbxAutor.Text;
            Spruch spruch = new Spruch(text, autor);
            _sprüche.Add(spruch);
            lbxSprüche.Items.Refresh();
            tbxSpruchtext.Text = "";
            tbxAutor.Text = "";
        }
        private void BtnLöschen_Click(object sender, RoutedEventArgs e)
        {
            Spruch spruch = (Spruch)lbxSprüche.SelectedItem;
            _sprüche.Remove(spruch);
            lbxSprüche.Items.Refresh();
        }
        private void Tbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxSpruchtext.Text != "" && tbxAutor.Text != "")
            {
                btnSpeichern.IsEnabled = true;
            }
            else
            {
                btnSpeichern.IsEnabled = false;
            }
        }
        private void LbxSprüche_SelectionChanged(object sender,
        SelectionChangedEventArgs e)
        {
            if (lbxSprüche.SelectedItem != null)
            {
                btnLöschen.IsEnabled = true;
            }
            else
            {
                btnLöschen.IsEnabled = false;
            }
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            _datei.Speichern(_sprüche);
        }
    }
}