using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AvaloniaForm.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Message.Text = "Button Pressed";
    }
}