
using Adressbok_Shared.Interface;
using Adressbok_Shared.Models;
using Adressbok_Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;


namespace Adressbok_App.Mvvm.ViewModels;

public partial class ContactEditListViewModel : ObservableObject
{
    private readonly IServiceProvider _sp;
    private readonly IContactService _contactService;

    [ObservableProperty]
    private IContact _contactForm = new Contact();

    public ContactEditListViewModel(IServiceProvider sp, IContactService contactService)
    {
        _sp = sp;

       _contactService = contactService;

       ContactForm = _contactService.CurrentContact;

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
    /// Updates a contact and navigates to the contact list view.
    /// </summary>
    [RelayCommand]
    private void Update()
    {
        _contactService.Update(ContactForm);
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
    }



   
}

