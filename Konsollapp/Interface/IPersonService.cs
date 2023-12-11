using Konsollapp_adressbok.Models;

namespace Konsollapp_adressbok.Interface;

public interface IPersonService
{
    IServiceResult AddNewContact();
    IServiceResult DeleteContactFromList(string targetEmail);
    IServiceResult ShowAContactFromList(int targetId);
    IServiceResult ShowAllContacts();
    IServiceResult AddPersonToList(IPerson person);
}