

using Adressbok_Shared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace Adressbok_App.Mvvm.ViewModels;

public partial class MainViewModel : ObservableObject
{ 


    [ObservableProperty]
    private ObservableCollection<Contact> _contactList = [];

    [ObservableProperty]
    private ObservableObject _currentViewModel;


    private readonly IServiceProvider _sp;

    /// <summary>
    /// ViewModel class managing the main application view and navigation.
    /// </summary>
    /// <param name="sp">The service provider for dependency injection.</param>
    public MainViewModel(IServiceProvider sp)
    {
        _sp = sp;
        CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
    }


}    
