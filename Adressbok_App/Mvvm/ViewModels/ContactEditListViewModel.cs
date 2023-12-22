using Adressbok_App.Mvvm.Models;
using Adressbok_App.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Adressbok_App.Mvvm.ViewModels;

public partial class ContactEditListViewModel : ObservableObject
{
    private readonly IServiceProvider _sp;
    private readonly ContactService _contactService;

    [ObservableProperty]
    private Contact _contactForm = new();

    public ContactEditListViewModel(IServiceProvider sp, ContactService contactService)
    {
        _sp = sp;

       _contactService = contactService;

       ContactForm = _contactService.CurrentContact;

    }

    [RelayCommand]
    private void NavigateToList()
    {
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
    }




    [RelayCommand]
    private void Update()
    {
        _contactService.Update(ContactForm);
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
    }



   
}

