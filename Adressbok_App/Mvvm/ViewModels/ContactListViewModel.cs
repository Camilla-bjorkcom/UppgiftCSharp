


using Adressbok_Shared.Interface;
using Adressbok_Shared.Models;
using Adressbok_Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace Adressbok_App.Mvvm.ViewModels;

public partial class ContactListViewModel : ObservableObject
{

    private readonly IContactService _contactService;

    private readonly IServiceProvider _sp;

    [ObservableProperty]
    private ObservableCollection<IContact> _contactList = [];

    [ObservableProperty]
    private IContact _contact = new Contact();


    /// <summary>
    /// ViewModel class managing the contact list view and navigation in the application.
    /// </summary>
    /// <param name="sp">The service provider for dependency injection.</param>
    /// <param name="contactService">The contact service for handling contact-related operations.</param>
    public ContactListViewModel(IServiceProvider sp, IContactService contactService)
    {
        _sp = sp;
        _contactService = contactService;

        var result = _contactService.GetAll();
        if (result != null)
        {
            ContactList = new ObservableCollection<IContact>(result);
        }
       
        _contact = _contactService.CurrentContact;

    }


    /// <summary>
    /// Navigates to the add contact view for a specific contact.
    /// </summary>
    /// <param name="contact">The contact to be added.</param>
    [RelayCommand]
    public void NavigateToAddPersonToList(IContact contact)
    {
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactAddListViewModel>();

    }

    /// <summary>
    /// Navigates to the add contact view.
    /// </summary>
    [RelayCommand]
    private void NavigateToAdd()
    {
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactAddListViewModel>();
    }

    /// <summary>
    /// Navigates to the details view for a specific contact.
    /// </summary>
    /// <param name="contact">The contact to view details for.</param>
    [RelayCommand]
    private void NavigateToDetailsView(IContact contact)
    {
        _contactService.CurrentContact = contact;
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactDetailsViewModel>();
    }
}
