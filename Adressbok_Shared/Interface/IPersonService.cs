

namespace Adressbok_Shared.Interface;

public interface IPersonService
{
    public void AddNewContact();

    IServiceResult DeleteContactFromList(string targetEmail);
    public bool ShowAContactFromList(int targetId);
    IServiceResult ShowAllContacts();

}