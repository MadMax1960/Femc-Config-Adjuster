using Femc_Config_Adjuster.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace Femc_Config_Adjuster.Views.Pages
{
	public partial class DashboardPage : INavigableView<DashboardViewModel>
	{
		public DashboardViewModel ViewModel { get; }

		public DashboardPage(DashboardViewModel viewModel)
		{
			ViewModel = viewModel;
			DataContext = this;

			InitializeComponent();
		}
	}
}
