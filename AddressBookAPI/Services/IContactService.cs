using AddressBookAPI.DTOs;
using AddressBookAPI.Models;

namespace AddressBookAPI.Services
{
    public interface IContactService
    {
        ContactDTO CreateContact(ContactDTO newContact);
        bool DeleteContact(int id);
        List<ContactDTO> GetAllContacts();
        ContactDTO GetContactById(int id);
        ContactDTO UpdateContact(ContactDTO updateContact);
    }
}
