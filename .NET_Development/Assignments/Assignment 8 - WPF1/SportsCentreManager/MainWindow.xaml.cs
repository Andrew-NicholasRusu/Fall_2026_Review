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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SportsCentreManager
{

    public partial class MainWindow : Window
    {
        // region Part E.2: Bound Code-Behind Property
        public string WelcomeMessage { get; set; } = "Healthier People. Stronger Communities.";

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            InitializeDefaults();
        }


        private void InitializeDefaults()
        {
            if (lblSummaryMembership != null)
                lblSummaryMembership.Text = "Basic";

            if (lblSummaryFacility != null)
                lblSummaryFacility.Text = "—";

            if (txtSummaryServices != null)
                txtSummaryServices.Text = "None";

            UpdateRegistrationStatus();
        }

        // region Part B: Membership & Facility Selection Event Handlers

        /// <summary>
        /// Updates the registration summary when a membership package is selected.
        /// </summary>
        private void Membership_Checked(object sender, RoutedEventArgs e)
        {
            if (lblSummaryMembership == null) return;

            if (rbBasic != null && rbBasic.IsChecked == true)
                lblSummaryMembership.Text = "Basic";
            else if (rbStandard != null && rbStandard.IsChecked == true)
                lblSummaryMembership.Text = "Standard";
            else if (rbPremium != null && rbPremium.IsChecked == true)
                lblSummaryMembership.Text = "Premium";
        }


        private void Facility_Checked(object sender, RoutedEventArgs e)
        {
            if (lblSummaryFacility == null) return;

            if (rbGym != null && rbGym.IsChecked == true)
                lblSummaryFacility.Text = "Gym";
            else if (rbPool != null && rbPool.IsChecked == true)
                lblSummaryFacility.Text = "Swimming Pool";
            else if (rbCourt != null && rbCourt.IsChecked == true)
                lblSummaryFacility.Text = "Basketball Court";
        }

        // Part C: Optional Services & Three-State CheckBox Event Handlers


        private void RegistrationStatus_Click(object sender, RoutedEventArgs e)
        {
            UpdateRegistrationStatus();
        }

        /// <summary>
        /// Updates optional service control states and label text according to the three states:
        /// 1. Unchecked (false) - Not Started: Optional services disabled and unchecked.
        /// 2. Indeterminate (null) - In Progress: Optional services enabled; confirmation cannot be made.
        /// 3. Checked (true) - Ready to Confirm: Optional services enabled; confirmation permitted.
        /// </summary>
        private void UpdateRegistrationStatus()
        {
            if (chkStatus == null || chkTraining == null || chkLocker == null || chkClasses == null)
                return;

            if (chkStatus.IsChecked == false)
            {
                // State 1: Unchecked — Not Started
                chkStatus.Content = "Registration Status: Not Started";

                // Optional services are disabled and unchecked
                chkTraining.IsEnabled = false;
                chkTraining.IsChecked = false;

                chkLocker.IsEnabled = false;
                chkLocker.IsChecked = false;

                chkClasses.IsEnabled = false;
                chkClasses.IsChecked = false;

                UpdateOptionalServicesSummary();
            }
            else if (chkStatus.IsChecked == null)
            {
                // State 2: Indeterminate — In Progress
                chkStatus.Content = "Registration Status: In Progress";

                // Optional services are enabled
                chkTraining.IsEnabled = true;
                chkLocker.IsEnabled = true;
                chkClasses.IsEnabled = true;
            }
            else // chkStatus.IsChecked == true
            {
                // State 3: Checked — Ready to Confirm
                chkStatus.Content = "Registration Status: Ready to Confirm";

                // Optional services are enabled
                chkTraining.IsEnabled = true;
                chkLocker.IsEnabled = true;
                chkClasses.IsEnabled = true;
            }
        }

        /// <summary>
        /// Handles when an optional service checkbox is checked or unchecked.
        /// </summary>
        private void OptionalService_Click(object sender, RoutedEventArgs e)
        {
            UpdateOptionalServicesSummary();
        }

        /// <summary>
        /// Updates the registration summary list of optional services.
        /// </summary>
        private void UpdateOptionalServicesSummary()
        {
            if (txtSummaryServices == null) return;

            List<string> selectedServices = new List<string>();

            if (chkTraining != null && chkTraining.IsChecked == true)
                selectedServices.Add("Personal Training");

            if (chkLocker != null && chkLocker.IsChecked == true)
                selectedServices.Add("Locker Rental");

            if (chkClasses != null && chkClasses.IsChecked == true)
                selectedServices.Add("Group Fitness Classes");

            if (selectedServices.Count > 0)
            {
                txtSummaryServices.Text = string.Join(", ", selectedServices);
            }
            else
            {
                txtSummaryServices.Text = "None";
            }
        }

        // Part D: Event Handling & Action Buttons

        /// <summary>
        /// Calculates the total monthly fee based on membership and selected optional services.
        /// </summary>
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            decimal totalFee = CalculateTotalFee();
            if (lblSummaryFee != null)
            {
                lblSummaryFee.Text = totalFee.ToString("C");
            }
        }

        /// <summary>
        /// Helper method to compute the total monthly fee.
        /// </summary>
        private decimal CalculateTotalFee()
        {
            decimal fee = 0m;

            // Membership packages
            if (rbBasic != null && rbBasic.IsChecked == true)
                fee += 30m;
            else if (rbStandard != null && rbStandard.IsChecked == true)
                fee += 50m;
            else if (rbPremium != null && rbPremium.IsChecked == true)
                fee += 80m;

            // Optional services (only count if checkboxes are enabled & checked)
            if (chkTraining != null && chkTraining.IsEnabled && chkTraining.IsChecked == true)
                fee += 40m;

            if (chkLocker != null && chkLocker.IsEnabled && chkLocker.IsChecked == true)
                fee += 10m;

            if (chkClasses != null && chkClasses.IsEnabled && chkClasses.IsChecked == true)
                fee += 20m;

            return fee;
        }

        /// <summary>
        /// Validates member registration inputs and displays confirmation or error message.
        /// </summary>
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            List<string> errors = new List<string>();

            // 1. Verify name, email, and phone are not empty
            if (string.IsNullOrWhiteSpace(txtName?.Text))
                errors.Add("• Member's full name is required.");

            if (string.IsNullOrWhiteSpace(txtEmail?.Text))
                errors.Add("• Email address is required.");

            if (string.IsNullOrWhiteSpace(txtPhone?.Text))
                errors.Add("• Phone number is required.");

            // 2. Verify membership is selected
            bool hasMembership = (rbBasic?.IsChecked == true) ||
                                 (rbStandard?.IsChecked == true) ||
                                 (rbPremium?.IsChecked == true);
            if (!hasMembership)
                errors.Add("• A membership package must be selected.");

            // 3. Verify facility is selected
            bool hasFacility = (rbGym?.IsChecked == true) ||
                               (rbPool?.IsChecked == true) ||
                               (rbCourt?.IsChecked == true);
            if (!hasFacility)
                errors.Add("• A preferred facility must be selected.");

            // 4. Verify registration status is Ready to Confirm (Checked)
            if (chkStatus?.IsChecked != true)
            {
                errors.Add("• Registration status must be set to 'Ready to Confirm'.");
            }

            // If any validation failed, show error message
            if (errors.Count > 0)
            {
                string errorMessage = "Please correct the following errors before confirming:\n\n" +
                                     string.Join("\n", errors);
                MessageBox.Show(errorMessage, "Registration Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Determine selections for confirmation display
            string membership = rbBasic?.IsChecked == true ? "Basic ($30/month)" :
                                rbStandard?.IsChecked == true ? "Standard ($50/month)" : "Premium ($80/month)";

            string facility = rbGym?.IsChecked == true ? "Gym" :
                              rbPool?.IsChecked == true ? "Swimming Pool" : "Basketball Court";

            string memberName = txtName?.Text.Trim() ?? string.Empty;
            string email = txtEmail?.Text.Trim() ?? string.Empty;
            string phone = txtPhone?.Text.Trim() ?? string.Empty;

            string services = txtSummaryServices?.Text ?? "None";
            decimal totalFee = CalculateTotalFee();

            // Update fee label in summary
            if (lblSummaryFee != null)
                lblSummaryFee.Text = totalFee.ToString("C");

            // Display successful confirmation message
            string confirmationMessage = "Registration Confirmed Successfully!\n\n" +
                                        $"Member Name: {memberName}\n" +
                                        $"Email: {email}\n" +
                                        $"Phone: {phone}\n" +
                                        $"Membership: {membership}\n" +
                                        $"Facility: {facility}\n" +
                                        $"Optional Services: {services}\n" +
                                        $"Total Monthly Fee: {totalFee:C}";

            MessageBox.Show(confirmationMessage, "Registration Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Resets all form fields and summaries to their default initial states.
        /// </summary>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            // Clear textboxes
            if (txtName != null) txtName.Text = string.Empty;
            if (txtEmail != null) txtEmail.Text = string.Empty;
            if (txtPhone != null) txtPhone.Text = string.Empty;

            // Restore default membership selection (Basic)
            if (rbBasic != null) rbBasic.IsChecked = true;
            if (rbStandard != null) rbStandard.IsChecked = false;
            if (rbPremium != null) rbPremium.IsChecked = false;

            // Reset facility selection
            if (rbGym != null) rbGym.IsChecked = false;
            if (rbPool != null) rbPool.IsChecked = false;
            if (rbCourt != null) rbCourt.IsChecked = false;

            // Return registration status to Not Started
            if (chkStatus != null) chkStatus.IsChecked = false;
            UpdateRegistrationStatus();

            // Reset registration summary displays
            // lblSummaryName is bound to txtName.Text; leave the binding intact.
            if (lblSummaryMembership != null) lblSummaryMembership.Text = "Basic";
            if (lblSummaryFacility != null) lblSummaryFacility.Text = "—";
            if (txtSummaryServices != null) txtSummaryServices.Text = "None";
            if (lblSummaryFee != null) lblSummaryFee.Text = "$0.00";
        }
    }
}