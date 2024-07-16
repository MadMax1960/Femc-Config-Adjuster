using System.Windows.Controls;
using Femc_Config_Adjuster.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace Femc_Config_Adjuster.Views.Pages
{
	public partial class DashboardPage : Page
	{
        public DashboardPage()
		{
            DataContext = new DashboardViewModel(this); // Set DataContext to ViewModel
			InitializeComponent(); // Ensure InitializeComponent method is called
		}
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Call the ViewModel's method to handle the button press
            var viewModel = DataContext as DashboardViewModel;
            viewModel?.OnSaveButtonPress();
        }
    }
}
