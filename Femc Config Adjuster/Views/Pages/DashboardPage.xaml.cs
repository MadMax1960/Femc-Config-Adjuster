using System.Windows.Controls;
using Femc_Config_Adjuster.ViewModels.Pages;

namespace Femc_Config_Adjuster.Views.Pages;

public partial class DashboardPage : Page
{
	public DashboardPage(DashboardViewModel vm)
	{
		DataContext = vm;
		InitializeComponent();
	}
}
