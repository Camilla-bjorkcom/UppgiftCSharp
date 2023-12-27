


using Adressbok_Shared.Models;
using Adressbok_Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace Adressbok_App.Mvvm.ViewModels;

public partial class ContactListViewModel : ObservableObject
{

    private readonly ContactService _contactService;

    private readonly IServiceProvider _sp;

    [ObservableProperty]
    private ObservableCollection<Contact> _contactList = [];

    [ObservableProperty]
    private Contact _contact = new();

    public ContactListViewModel(IServiceProvider sp, ContactService contactService)
    {
        _sp = sp;
        _contactService = contactService;

        ContactList = new ObservableCollection<Contact>(_contactService.GetAll());
        _contact = _contactService.CurrentContact;

    }

    

    [RelayCommand] //För att skapa metoder som ska utföra någon form av aktivitet som ska kopplas till en knapptryckning
    public void NavigateToAddPersonToList(Contact contact)
    {
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactAddListViewModel>();

    }




    [RelayCommand]
    private void NavigateToAdd()
    {
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactAddListViewModel>();
    }

    [RelayCommand]
    private void NavigateToDetailsView(Contact contact)
    {
        _contactService.CurrentContact = contact;
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactDetailsViewModel>();
    }
}
