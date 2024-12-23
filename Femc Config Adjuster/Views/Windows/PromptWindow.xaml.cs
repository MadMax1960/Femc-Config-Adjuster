using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Controls;

namespace Femc_Config_Adjuster.Views.Windows;

/// <summary>
/// Interaction logic for PromptWindow.xaml
/// </summary>
public partial class PromptWindow : FluentWindow
{
	public bool Result { get; private set; }

	public PromptWindow(string title = "Update Available", string content = "A new version of the application is available. Would you like to update?", string windowTitle = "FEMC Config Update")
	{
		InitializeComponent();
		this.Title = windowTitle;
		this.TitleBar.Title = windowTitle;
		this.PromptTitle.Text = title;
		this.PromptContent.Text = content;
		Result = false; // Default result to false (No)
	}

	private async void YesButton_Click(object sender, RoutedEventArgs e)
	{
		Result = true;

		// Hide buttons and show the progress bar
		YesButton.IsEnabled = false;
		NoButton.IsEnabled = false;
		UpdateProgressBar.Visibility = Visibility.Visible;

		// Simulate update progress
		await RunUpdateAsync();

		// Close the window
		Close();
	}

	private void NoButton_Click(object sender, RoutedEventArgs e)
	{
		Result = false; // User chose "No"
		Close();
	}

	private async Task RunUpdateAsync()
	{
		// Update the progress bar during the update process
		for (int i = 0; i <= 100; i += 10)
		{
			UpdateProgressBar.Value = i;
			await Task.Delay(200); // Simulate some work
		}
	}

	/// <summary>
	/// Method to update the progress bar incrementally.
	/// </summary>
	public void UpdateProgress(double progress)
	{
		Dispatcher.Invoke(() =>
		{
			UpdateProgressBar.Value = progress;
		});
	}
}
