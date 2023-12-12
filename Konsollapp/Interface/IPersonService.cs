using Konsollapp_adressbok.Models;

namespace Konsollapp_adressbok.Interface;

public interface IPersonService
{
   public void AddNewContact();
    public void SaveToFile();
    IServiceResult DeleteContactFromList(string targetEmail);
    IServiceResult ShowAContactFromList(int targetId);
    IServiceResult ShowAllContacts();

    IEnumerable<IPerson> GetPersonList();
}