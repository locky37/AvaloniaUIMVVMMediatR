using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaApplicationMVVM.Views;

public partial class MyCheckBoxControl : UserControl
{
    public MyCheckBoxControl()
    {
        InitializeComponent();
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}