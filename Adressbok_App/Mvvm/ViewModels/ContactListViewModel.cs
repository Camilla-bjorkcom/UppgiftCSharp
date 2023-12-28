


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

    private readonly ContactService _contactService;

    private readonly IServiceProvider _sp;

    [ObservableProperty]
    private ObservableCollection<IContact> _contactList = [];

    [ObservableProperty]
    private IContact _contact = new Contact();

    public ContactListViewModel(IServiceProvider sp, ContactService contactService)
    {
        _sp = sp;
        _contactService = contactService;

        ContactList = new ObservableCollection<IContact>(_contactService.GetAll());
        _contact = _contactService.CurrentContact;

    }

    

    [RelayCommand] //För att skapa metoder som ska utföra någon form av aktivitet som ska kopplas till en knapptryckning
    public void NavigateToAddPersonToList(IContact contact)
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
    private void NavigateToDetailsView(IContact contact)
    {
        _contactService.CurrentContact = contact;
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactDetailsViewModel>();
    }
}
