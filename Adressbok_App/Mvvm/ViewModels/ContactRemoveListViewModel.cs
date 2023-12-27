
using Adressbok_Shared.Models;
using Adressbok_Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;


namespace Adressbok_App.Mvvm.ViewModels;

public partial class ContactRemoveListViewModel : ObservableObject
{
    private readonly IServiceProvider _sp;
    private readonly ContactService _contactService;

    public string Input_Email { get; set; } = null!;

    public ContactRemoveListViewModel(IServiceProvider sp, ContactService contactService)
    {
        _sp = sp;

        _contactService = contactService;

        _contactForm = _contactService.CurrentContact;
    }


    [ObservableProperty]
    private Contact _contactForm = new();


    [RelayCommand]
    private void RemoveContact(string email)
    {
        _contactService.Remove(email);
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
    }

    [RelayCommand]
    private void NavigateToList()
    {
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
    }


}


