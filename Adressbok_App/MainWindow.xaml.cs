using Adressbok_App.Mvvm.ViewModels;
using System.Windows;

namespace Adressbok_App;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;

    }

   
}