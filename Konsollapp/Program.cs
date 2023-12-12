using Konsollapp_adressbok.Interface;
using Konsollapp_adressbok.Repository;
using Konsollapp_adressbok.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddSingleton<PersonRepository>();
    services.AddSingleton<IPersonService, PersonService>();
    services.AddSingleton<IMenuService, MenuService>();
    services.AddSingleton<IFileService, FileService>();

    
}).Build();

builder.Start();
Console.Clear();

IMenuService menuService = builder.Services.GetRequiredService<IMenuService>();
menuService.ShowMainMenu();