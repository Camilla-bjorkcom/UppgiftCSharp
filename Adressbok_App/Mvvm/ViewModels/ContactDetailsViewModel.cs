

using Adressbok_Shared.Models;
using Adressbok_Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Adressbok_App.Mvvm.ViewModels;


public partial class ContactDetailsViewModel : ObservableObject
{
    private readonly IServiceProvider _sp;
    private readonly ContactService _contactService;

    [ObservableProperty]
    private Contact _contact = new Contact(); 

   
   

    public ContactDetailsViewModel(IServiceProvider sp, ContactService contactService)
    {
        _sp = sp;
        _contactService = contactService;
        Contact = _contactService.CurrentContact;
    }

   
    [RelayCommand]
    public void NavigateToEdit(Contact contact)
    {
        _contactService.CurrentContact = contact;
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactEditListViewModel>();
    }

    [RelayCommand]
    private void NavigateToList(Contact contact)
    {
        _contactService.CurrentContact = contact;
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
    }


    [RelayCommand]
    public void NavigateToRemoveContactFromList()
    {
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactRemoveListViewModel>();

    }
}

