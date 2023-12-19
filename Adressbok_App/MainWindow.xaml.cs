using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Adressbok_App;

public partial class MainWindow : Window
{

    //Fields - private
    private readonly ObservableCollection<string> _contactList = [];


    //Properties

    //En konstruktor - dep injection, instanciate objects
    public MainWindow()
    {
        InitializeComponent();
        Input_FirstName.Focus();

        List_Contacts.ItemsSource = _contactList;

    }

    // Metoder
    private void BtnAdd_Click(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Input_FirstName.Text))
        {
            _contactList.Add(Input_FirstName.Text);
            Input_FirstName.Text = string.Empty;

            _contactList.Add(Input_LastName.Text);
            Input_LastName.Text = string.Empty;

            _contactList.Add(Input_Email.Text);
            Input_Email.Text = string.Empty;

            _contactList.Add(Input_PhoneNumber.Text);
            Input_PhoneNumber.Text = string.Empty;

            _contactList.Add(Input_StreetName.Text);
            Input_StreetName.Text = string.Empty;

            _contactList.Add(Input_PostalCode.Text);
            Input_PostalCode.Text = string.Empty;

            _contactList.Add(Input_City.Text);
            Input_City.Text = string.Empty;

            _contactList.Add(Input_Country.Text);
            Input_Country.Text = string.Empty;


        }
        
    }
}