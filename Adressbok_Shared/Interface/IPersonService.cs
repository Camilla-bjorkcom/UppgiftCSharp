

namespace Adressbok_Shared.Interface;

public interface IPersonService
{
    /// <summary>
    /// Adds a new contact with user input for contact details, then adds the contact to a contactlist
    /// </summary>
    public void AddNewContact();


    /// <summary>
    /// Deletes a contact from the list based on the provided email address.
    /// </summary>
    /// <param name="targetEmail">Enter the email address of the contact to be deleted.</param>
    /// <returns>An IServiceResult indicating the status of the deletion operation.</returns>
    IServiceResult DeleteContactFromList(string targetEmail);


    /// <summary>
    /// Displays information of all contacts in the list and allows the user to view details for a specific contact.
    /// </summary>
    /// <returns>An IServiceResult indicating the status of the operation.</returns>
    IServiceResult ShowAllContacts();


    /// <summary>
    /// Displays details of a contact from the list based on the provided target ID.
    /// </summary>
    /// <param name="targetId">Enter the ID of the contact to be displayed.</param>
    /// <returns>True if the contact is found and displayed; otherwise, false.</returns>
    public bool ShowAContactFromList(int targetId);
}