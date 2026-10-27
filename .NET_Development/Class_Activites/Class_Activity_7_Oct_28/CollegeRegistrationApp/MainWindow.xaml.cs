using System.ComponentModel;
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

namespace CollegeRegistrationApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _studentName = string.Empty;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string StudentName
        {
            get => _studentName;
            set
            {
                if (_studentName != value)
                {
                    _studentName = value;
                    OnPropertyChanged(nameof(StudentName));
                    OnPropertyChanged(nameof(WelcomeMessage));
                }
            }
        }

        public string WelcomeMessage
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_studentName))
                    return "Welcome!";
                return $"Welcome, {_studentName.Trim()}!";
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            UpdateRegistrationStatusUI();
            UpdateCourseSummary();
            UpdateSummaryServices();
        }

        private void TextBox_FullName(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_StudentID(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_EmailAddress(object sender, TextChangedEventArgs e)
        {

        }

        private void RadioButton_Intro_To_Programming(object sender, RoutedEventArgs e)
        {
            UpdateCourseSummary();
        }

        private void RadioButton_Web_Development(object sender, RoutedEventArgs e)
        {
            UpdateCourseSummary();
        }

        private void RadioButton_Database_Fundamentals(object sender, RoutedEventArgs e)
        {
            UpdateCourseSummary();
        }

        private void RegistrationStatus_Changed(object sender, RoutedEventArgs e)
        {
            UpdateRegistrationStatusUI();
            UpdateSummaryServices();
        }

        private void OptionalService_Changed(object sender, RoutedEventArgs e)
        {
            UpdateSummaryServices();
        }

        private int GetSelectedCourseFee()
        {
            if (rbWebDev != null && rbWebDev.IsChecked == true)
                return 150;
            if (rbDbFund != null && rbDbFund.IsChecked == true)
                return 180;
            return 120; // Introduction to Programming
        }

        private string GetSelectedCourseName()
        {
            if (rbWebDev != null && rbWebDev.IsChecked == true)
                return "Web Development";
            if (rbDbFund != null && rbDbFund.IsChecked == true)
                return "Database Fundamentals";
            return "Introduction to Programming";
        }

        private int GetOptionalServicesFee()
        {
            if (chkRegistrationStatus != null && chkRegistrationStatus.IsChecked == false)
                return 0;

            int fee = 0;
            if (chkPrintedMaterials != null && chkPrintedMaterials.IsChecked == true)
                fee += 25;
            if (chkParkingPermit != null && chkParkingPermit.IsChecked == true)
                fee += 40;
            if (chkCertificate != null && chkCertificate.IsChecked == true)
                fee += 15;
            return fee;
        }

        public void UpdateCourseSummary()
        {
            if (txtSummaryCourse == null || txtSummaryCourseFee == null)
                return;

            txtSummaryCourse.Text = GetSelectedCourseName();
            txtSummaryCourseFee.Text = $"${GetSelectedCourseFee()}";
            UpdateSummaryTotal();
        }

        public void UpdateSummaryServices()
        {
            if (pnlSummaryServices == null || txtSummaryNoServices == null)
                return;

            bool servicesEnabled = chkRegistrationStatus?.IsChecked != false;
            bool hasAnyService = false;

            if (servicesEnabled && chkPrintedMaterials != null && chkPrintedMaterials.IsChecked == true)
            {
                if (rowSummaryPrintedMaterials != null) rowSummaryPrintedMaterials.Visibility = Visibility.Visible;
                hasAnyService = true;
            }
            else
            {
                if (rowSummaryPrintedMaterials != null) rowSummaryPrintedMaterials.Visibility = Visibility.Collapsed;
            }

            if (servicesEnabled && chkParkingPermit != null && chkParkingPermit.IsChecked == true)
            {
                if (rowSummaryParkingPermit != null) rowSummaryParkingPermit.Visibility = Visibility.Visible;
                hasAnyService = true;
            }
            else
            {
                if (rowSummaryParkingPermit != null) rowSummaryParkingPermit.Visibility = Visibility.Collapsed;
            }

            if (servicesEnabled && chkCertificate != null && chkCertificate.IsChecked == true)
            {
                if (rowSummaryCertificate != null) rowSummaryCertificate.Visibility = Visibility.Visible;
                hasAnyService = true;
            }
            else
            {
                if (rowSummaryCertificate != null) rowSummaryCertificate.Visibility = Visibility.Collapsed;
            }

            txtSummaryNoServices.Visibility = hasAnyService ? Visibility.Collapsed : Visibility.Visible;
            UpdateSummaryTotal();
        }

        public void UpdateSummaryTotal()
        {
            if (txtSummaryTotalFee == null)
                return;

            int total = GetSelectedCourseFee() + GetOptionalServicesFee();
            txtSummaryTotalFee.Text = $"${total}";
        }

        private void UpdateRegistrationStatusUI()
        {
            if (chkRegistrationStatus == null || pnlOptionalServices == null || txtStatusDescription == null)
                return;

            if (chkRegistrationStatus.IsChecked == true)
            {
                // Ready to Confirm (Checked)
                chkRegistrationStatus.Content = "Ready to Confirm (Checked)";
                pnlOptionalServices.IsEnabled = true;
                txtStatusDescription.Text = "Optional services are enabled, and registration can be confirmed (if all required information is valid).";
                txtStatusDescription.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2E7D32"));
            }
            else if (chkRegistrationStatus.IsChecked == null)
            {
                // In Progress (Indeterminate)
                chkRegistrationStatus.Content = "In Progress (Indeterminate)";
                pnlOptionalServices.IsEnabled = true;
                txtStatusDescription.Text = "Optional services are enabled, but registration cannot yet be confirmed.";
                txtStatusDescription.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E65100"));
            }
            else
            {
                // Not Started (Unchecked)
                chkRegistrationStatus.Content = "Not Started (Unchecked)";
                pnlOptionalServices.IsEnabled = false;
                txtStatusDescription.Text = "Optional services are disabled and registration cannot be confirmed.";
                txtStatusDescription.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#757575"));
            }
        }

        private void btnCalculateTotal_Click(object sender, RoutedEventArgs e)
        {
            UpdateCourseSummary();
            UpdateSummaryServices();
            UpdateSummaryTotal();
        }

        private void btnConfirmRegistration_Click(object sender, RoutedEventArgs e)
        {
            var errors = new System.Collections.Generic.List<string>();

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
                errors.Add("• Student full name is required.");

            if (string.IsNullOrWhiteSpace(txtStudentID.Text))
                errors.Add("• Student ID is required.");

            if (string.IsNullOrWhiteSpace(txtEmailAddress.Text))
                errors.Add("• Email address is required.");

            bool isCourseSelected = (rbIntroProg != null && rbIntroProg.IsChecked == true) ||
                                    (rbWebDev != null && rbWebDev.IsChecked == true) ||
                                    (rbDbFund != null && rbDbFund.IsChecked == true);

            if (!isCourseSelected)
                errors.Add("• A course must be selected.");

            if (chkRegistrationStatus.IsChecked != true)
                errors.Add("• Registration Status must be set to 'Ready to Confirm'.");

            if (errors.Count > 0)
            {
                string errorMessage = "Please correct the following errors before confirming registration:\n\n" +
                                      string.Join("\n", errors);
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int totalFee = GetSelectedCourseFee() + GetOptionalServicesFee();
            string courseName = GetSelectedCourseName();
            string studentName = txtFullName.Text.Trim();

            string confirmPrompt = "Are you sure you want to confirm this registration?\n\n" +
                                  $"Student: {studentName}\n" +
                                  $"Course: {courseName}\n" +
                                  $"Total Fee: ${totalFee}";

            MessageBoxResult result = MessageBox.Show(confirmPrompt, "Confirm Registration", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                string successMessage = "Registration Confirmed!\n\n" +
                                       $"Student: {studentName}\n" +
                                       $"Course: {courseName}\n" +
                                       $"Total Fee: ${totalFee}";

                MessageBox.Show(successMessage, "Registration Successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnClearForm_Click(object sender, RoutedEventArgs e)
        {
            // Reset input fields
            txtFullName.Text = string.Empty;
            StudentName = string.Empty;
            txtStudentID.Text = string.Empty;
            txtEmailAddress.Text = string.Empty;

            // Reset course selection to default (Introduction to Programming)
            if (rbIntroProg != null)
                rbIntroProg.IsChecked = true;

            // Reset optional services
            if (chkPrintedMaterials != null)
                chkPrintedMaterials.IsChecked = false;
            if (chkParkingPermit != null)
                chkParkingPermit.IsChecked = false;
            if (chkCertificate != null)
                chkCertificate.IsChecked = false;

            // Reset registration status to Not Started
            if (chkRegistrationStatus != null)
                chkRegistrationStatus.IsChecked = false;

            UpdateRegistrationStatusUI();
            UpdateCourseSummary();
            UpdateSummaryServices();
        }
    }
}