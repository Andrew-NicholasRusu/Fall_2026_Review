using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Class_Act_2_Lab_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EngineCheckBox_Checked (
            object sender, RoutedEventArgs e)
        {
            EngineCheckBox.Content = "Engine On";

            AudioCheckBox.IsEnabled = true;
            WipersCheckBox.IsEnabled = true;
            AcCheckBox.IsEnabled = true;

            AudioCheckBox.IsChecked = true;
            WipersCheckBox.IsChecked = true;
            AcCheckBox.IsChecked = true;
        }

        private void EngineCheckBox_Indeterminate (
            object sender, RoutedEventArgs e)
        {
            EngineCheckBox.Content = "Ignition";

            AudioCheckBox.IsEnabled = true;
            WipersCheckBox.IsEnabled = true;

            AudioCheckBox.IsChecked = true;
            WipersCheckBox.IsChecked = true;

            AcCheckBox.IsChecked = false;
            AcCheckBox.IsEnabled = false;
        }

        private void EngineCheckBox_Unchecked(
            object sender, RoutedEventArgs e)
        {
            EngineCheckBox.Content = "Engine Off";

            AudioCheckBox.IsChecked = false;
            WipersCheckBox.IsChecked = false;
            AcCheckBox.IsChecked = false;

            AudioCheckBox.IsEnabled = false;
            WipersCheckBox.IsEnabled = false;
            AcCheckBox.IsEnabled = false;

        }
    }
}