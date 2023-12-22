using Adressbok_App.Mvvm.Models;
using Adressbok_App.Services;
using Adressbok_Shared.Repository;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

