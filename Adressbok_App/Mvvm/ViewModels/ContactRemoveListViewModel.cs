
using Adressbok_Shared.Interface;
using Adressbok_Shared.Models;
using Adressbok_Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;


namespace Adressbok_App.Mvvm.ViewModels;

public partial class ContactRemoveListViewModel : ObservableObject
{
    private readonly IServiceProvider _sp;
    private readonly IContactService _contactService;

    public string Input_Email { get; set; } = null!;


    /// <summary>
    /// ViewModel class managing the contact removal view and navigation in the application.
    /// </summary>
    /// <param name="sp">The service provider for dependency injection.</param>
    /// <param name="contactService">The contact service for handling contact-related operations.</param>
    public ContactRemoveListViewModel(IServiceProvider sp, IContactService contactService)
    {
        _sp = sp;

        _contactService = contactService;

        _contactForm = _contactService.CurrentContact;
    }

    /// <summary>
    /// Observable property for storing the contact to be removed.
    /// </summary>
    [ObservableProperty]
    private IContact _contactForm = new Contact();


    /// <summary>
    /// Removes a contact based on the provided email and navigates to the contact list view.
    /// </summary>
    /// <param name="email">The email of the contact to be removed.</param>
    [RelayCommand]
    private void RemoveContact(string email)
    {
        _contactService.Remove(email);
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
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


}


