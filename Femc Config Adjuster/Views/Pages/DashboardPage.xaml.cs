using System.Windows.Controls;
using Femc_Config_Adjuster.ViewModels.Pages;

namespace Femc_Config_Adjuster.Views.Pages
{
	public partial class DashboardPage : Page
	{
        public DashboardPage()
		{
            DataContext = new DashboardViewModel(this); // Set DataContext to ViewModel
			InitializeComponent(); // Ensure InitializeComponent method is called
		}

    }
}
