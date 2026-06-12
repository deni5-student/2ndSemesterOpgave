using _2ndSemesterOpgave.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _2ndSemesterOpgave.Views
{
    /// <summary>
    /// Interaction logic for Popup_Flow.xaml
    /// </summary>
    public partial class Popup_Flow : Window
    {
        public Popup_Flow()
        {
            InitializeComponent();
        }

        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : Popup_Flow                            ║
        // ║  METODE      : Gem_Click()                           ║
        // ║  BESKRIVELSE : tager tekst fra titel og content      ║
        // ║                og laver Flow med CRUD_Flow           ║
        // ╚══════════════════════════════════════════════════════╝
        private void Gem_Click(object sender, RoutedEventArgs e)
        {
            string title = FlowTitelBox.Text;
            string content = FlowDescriptionBox.Text;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(content))
            {
                MessageBox.Show("Udfyld alle felter.");
                return;
            }

            CRUD_Flow.Add(title, content, 1);
            Close();
        }
    }
}
