

using Adressbok_App.Mvvm.ViewModels;
using Adressbok_App.Mvvm.Views;
using Adressbok_Shared.Models;
using Adressbok_Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace Adressbok_App;

//Motsvarar vår program.cs
public partial class App : Application
{
    private static IHost? builder;

    public App()
    {
        builder = Host.CreateDefaultBuilder()
            .ConfigureServices (services =>
            {
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<MainWindow>();
               
                services.AddTransient<Contact>();
                services.AddSingleton<ContactService>();

                services.AddTransient<ContactListViewModel>();
                services.AddTransient<ContactListView>();

                services.AddTransient<ContactAddListViewModel>();
                services.AddTransient<ContactAddView>();

                services.AddTransient<EditContactView>();
                services.AddTransient<ContactEditListViewModel>();

                services.AddTransient<RemoveContactWEmail>();
                services.AddTransient<ContactRemoveListViewModel>();

                services.AddTransient<FileService>();

                services.AddTransient<ContactDetailsViewModel>();
                services.AddTransient<ContactDetailsView>();
            })
            .Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        builder!.Start();

        var mainWindow = builder!.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}
