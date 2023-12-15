

namespace Adressbok_Shared.Interface;

public interface IPersonService
{
    public void AddNewContact();

    IServiceResult DeleteContactFromList(string targetEmail);
    public void ShowAContactFromList(int targetId);
    IServiceResult ShowAllContacts();

}