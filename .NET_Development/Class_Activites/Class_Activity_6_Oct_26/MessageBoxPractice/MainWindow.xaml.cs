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

namespace MessageBoxPractice
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

        /* Button 1 */
        private void ShowMessageButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            MessageBox.Show(
                "Welcome to the application!", // message
                "Information", // title
                MessageBoxButton.OK, // button
                MessageBoxImage.Information); // icon
        }

        /* Button 2 */
        private void ShowWarningButton_Click(
            object sender, 
            RoutedEventArgs e)
        {
            MessageBox.Show(
                "Please review your information before continuing.", // message
                "Warning", // title
                MessageBoxButton.OK, // button
                MessageBoxImage.Warning); // icon
        }

        /* Button 3 */
        private void ShowErrorButton_Click(
            object sender, 
            RoutedEventArgs e)
        {
            MessageBox.Show(
                "An unexpected error has occurred while processing", // message
                "Error", // title
                MessageBoxButton.OK, // button
                MessageBoxImage.Error); // icon
        }

        /* Button 4 */
        private void ShowQuestionButton_Click(
            object sender, 
            RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Would you like to continue?",
                "Confirmation",
                MessageBoxButton.YesNo, // buttons
                MessageBoxImage.Question, // icon
                MessageBoxResult.Cancel); // default
            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("You selected Yes.");
            }
            else
            {
                MessageBox.Show("You selected No.");
            }

        }

        /* Button 5 */
        private void ShowAdvancedButton_Click(
            object sender, 
            RoutedEventArgs e)
        {
            MessageBoxResult confirm = MessageBox.Show(
                "Do you want to proceed with this operation?",
                "Advanced Confirmation",
                MessageBoxButton.YesNoCancel, // buttons
                MessageBoxImage.Question, // icon
                MessageBoxResult.Cancel); // default
            if (confirm == MessageBoxResult.Cancel)
            {
                MessageBox.Show("Are you sure you want to exit? Any unsaved changes will be lost. Do you want to continue?",
                "Confirm Exit",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
                if (confirm == MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();
                }
            }
        }
    }
}