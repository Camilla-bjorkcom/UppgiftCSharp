

using Adressbok_Shared.Interface;
using Adressbok_Shared.Models;
using Adressbok_Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Adressbok_App.Mvvm.ViewModels;


public partial class ContactDetailsViewModel : ObservableObject
{
    private readonly IServiceProvider _sp;
    private readonly IContactService _contactService;

    [ObservableProperty]
    private IContact _contact = new Contact(); 

   
   

    public ContactDetailsViewModel(IServiceProvider sp, IContactService contactService)
    {
        _sp = sp;
        _contactService = contactService;
        Contact = _contactService.CurrentContact;
    }


    /// <summary>
    /// Navigates to the edit view for a specific contact.
    /// </summary>
    /// <param name="contact">The contact to be edited.</param>
    [RelayCommand]
    public void NavigateToEdit(IContact contact)
    {
        _contactService.CurrentContact = contact;
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactEditListViewModel>();
    }

    /// <summary>
    /// Navigates to the contact list view for a specific contact.
    /// </summary>
    /// <param name="contact">The contact to navigate to the list for.</param>
    [RelayCommand]
    private void NavigateToList(IContact contact)
    {
        _contactService.CurrentContact = contact;
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
    }

    /// <summary>
    /// Navigates to the remove contact view.
    /// </summary>
    [RelayCommand]
    public void NavigateToRemoveContactFromList()
    {
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactRemoveListViewModel>();

    }
}

