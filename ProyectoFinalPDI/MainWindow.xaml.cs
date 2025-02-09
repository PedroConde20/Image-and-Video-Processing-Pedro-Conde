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

namespace ProyectoFinalPDI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.Visibility = Visibility.Hidden;
            this.Closing += (s, e) => (this.DataContext as IDisposable).Dispose();
            Hide();
            Form1 form = new Form1();
            form.ShowDialog();
            Close();
        }
        public MainWindow(bool doNotMakeInvisible)
        {
            InitializeComponent();
        }

        private void btnIrACamara_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Form1 form = new Form1();
            form.ShowDialog();
            Close();
        }
    }
}
