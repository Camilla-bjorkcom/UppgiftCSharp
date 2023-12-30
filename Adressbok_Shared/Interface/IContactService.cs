namespace Adressbok_Shared.Interface
{
    public interface IContactService
    {
        public IContact CurrentContact { get; set; }

        /// <summary>
        /// Adds a contact to the collection if the required information (FirstName and Email) is not empty.
        /// </summary>
        /// <param name="contact">The contact of type IContact to be added.</param>
        /// <returns>True if the contact is added successfully; otherwise, false.</returns>
        bool Add(IContact contact);

        /// <summary>
        /// Retrieves all contacts from a data source and returns them as an IEnumerable<IContact>.
        /// </summary>
        /// <returns>An IEnumerable<IContact> containing all contacts; null if retrieval fails.</returns>
        IEnumerable<IContact> GetAll();

        /// <summary>
        /// Removes a contact from the collection based on the provided email address.
        /// </summary>
        /// <param name="email">The email address of the contact to be removed.</param>
        /// <returns>True if the contact is successfully removed; otherwise, false.</returns>
        bool Remove(string email);

        /// <summary>
        /// Saves the contact collection to a file.
        /// </summary>
        /// <returns>True if the save operation is successful; otherwise, false.</returns>
        bool SaveToFile();

        /// <summary>
        /// Updates a contact in the collection based on the provided contact information.
        /// </summary>
        /// <param name="contact">The contact with updated information.</param>
        /// <returns>True if the update operation is successful; otherwise, false.</returns>
        bool Update(IContact contact);

    }
}