

using Adressbok_Shared.Interface;
using Adressbok_Shared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Adressbok_App.Mvvm.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private IPerson _person;

    public MainViewModel (IPerson person)
    {
        _person = person;
        person = new PersonModel();
        
    }
  
    [ObservableProperty]
    private ObservableCollection<IPerson> _contactList = [];

    [RelayCommand] //För att skapa metoder som ska utföra någon form av aktivitet som ska kopplas till en knapptryckning
    public void AddPersonToList(IPerson person)
    {
      
        if (!string.IsNullOrWhiteSpace(person.FirstName) && !string.IsNullOrWhiteSpace(person.LastName))
        {
            ContactList.Add(person);

            //_contactList.Add(Input_FirstName.Text);
            //Input_FirstName.Text = string.Empty;

            //_contactList.Add(Input_LastName.Text);
            //Input_LastName.Text = string.Empty;

            //_contactList.Add(Input_Email.Text);
            //Input_Email.Text = string.Empty;

            //_contactList.Add(Input_PhoneNumber.Text);
            //Input_PhoneNumber.Text = string.Empty;

            //_contactList.Add(Input_StreetName.Text);
            //Input_StreetName.Text = string.Empty;

            //_contactList.Add(Input_PostalCode.Text);
            //Input_PostalCode.Text = string.Empty;

            //_contactList.Add(Input_City.Text);
            //Input_City.Text = string.Empty;

            //_contactList.Add(Input_Country.Text);
            //Input_Country.Text = string.Empty;
        }
    }
}
