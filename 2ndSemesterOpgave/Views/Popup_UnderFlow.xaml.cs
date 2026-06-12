using _2ndSemesterOpgave.Class;
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
    /// Interaction logic for Popup_UnderFlow.xaml
    /// </summary>
    public partial class Popup_UnderFlow : Window
    {
        private int _flowId;
        public Popup_UnderFlow(int flowId)
        {
            InitializeComponent();
            _flowId = flowId;
        }
        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : Popup_UnderFlow                       ║
        // ║  METODE      : GemUnderFlow_Click()                  ║
        // ║  BESKRIVELSE : tager tekst fra titel og content      ║
        // ║                og laver UnderFlow med CRUD_UnderFlow ║
        // ╚══════════════════════════════════════════════════════╝
        private void GemUnderFlow_Click(object sender, RoutedEventArgs e)
        {
            string title = UnderFlowTitelBox.Text;
            string content = UnderFlowDescriptionBox.Text;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(content))
            {
                MessageBox.Show("Udfyld alle felter.");
                return;
            }

            CRUD_UnderFlow.Add(title, content, _flowId);
            Close();
        }
    }
}
