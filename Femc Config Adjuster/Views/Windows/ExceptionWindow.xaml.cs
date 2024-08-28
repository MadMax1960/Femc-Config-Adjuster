using System.Windows;

namespace Femc_Config_Adjuster.Views.Windows;

/// <summary>
/// Interaction logic for ExceptionWindow.xaml
/// </summary>
public partial class ExceptionWindow : Window
{
    public ExceptionWindow(Exception ex)
    {
        InitializeComponent();
        this.ErrorTitle.Text = ex.Message;
        this.ExceptionTextBox.Text = $"{ex.Message}\n{ex.StackTrace}";
    }
}
