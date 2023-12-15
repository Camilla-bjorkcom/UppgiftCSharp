
using Adressbok_Shared.Interface;
using Adressbok_Shared.Repository;
using Adressbok_Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddSingleton<PersonRepository>();
    services.AddSingleton<IMenuService, MenuService>();
    services.AddSingleton<IFileService, FileService>();
    services.AddSingleton<IPersonService, PersonService>();

}).Build();

builder.Start();
Console.Clear();

IMenuService menuService = builder.Services.GetRequiredService<IMenuService>();
menuService.ShowMainMenu();