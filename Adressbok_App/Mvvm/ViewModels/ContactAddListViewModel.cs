
using Adressbok_Shared.Interface;
using Adressbok_Shared.Models;
using Adressbok_Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// ViewModel class handling the addition and navigation of contacts in the application.
/// </summary>
namespace Adressbok_App.Mvvm.ViewModels;

public partial class ContactAddListViewModel : ObservableObject
{
    private readonly IServiceProvider _sp;
    private readonly IContactService _contactService;

    public ContactAddListViewModel(IServiceProvider sp, IContactService contactService)
    {
        _sp = sp;
        _contactService = contactService;
    }

    /// <summary>
    /// Navigates to the contact list view.
    /// </summary>
    [RelayCommand]
    private void NavigateToList()
    {
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
    }

    /// <summary>
    /// Contact form for adding new contacts.
    /// </summary>
    [ObservableProperty]
    private IContact _contactForm = new Contact();

    /// <summary>
    /// Adds a contact and navigates to the contact list view.
    /// </summary>
    [RelayCommand]
    private void Add()
    {
        _contactService.Add(ContactForm);

        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
    }
}
