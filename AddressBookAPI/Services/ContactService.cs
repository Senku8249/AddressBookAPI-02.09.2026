using AddressBookAPI.DTOs;
using AddressBookAPI.Mappers;
using AddressBookAPI.Models;
using AutoMapper;

namespace AddressBookAPI.Services
{
    public class ContactService : IContactService
    {
        
        private readonly IMapper _automapper;

        public ContactService(MyMapper mymapper, IMapper automapper)
        {
           
            _automapper = automapper;
        }

        private static List<Contact> contacts = new List<Contact>()
        {
                new Contact() { Id = 1, FirstName = "Jack", LastName = "Jackson", Phone = "111-111-1111", Address = "111 Main Street, Minneapolis, MN 55001", CreditCardNumber = "123456789"},
                new Contact() { Id = 2, FirstName = "John", LastName = "Johnson", Phone = "222-222-2222", Address = "222 Main Street, Minneapolis, MN 55001", CreditCardNumber = "123451234"},
                new Contact() { Id = 3, FirstName = "Mary", LastName = "Erickson", Phone = "333-333-3333", Address = "333 Main Street, Minneapolis, MN 55001", CreditCardNumber = "123456547"}
        };

        public List<ContactDTO> GetAllContacts()
        {
            //return _automapper.ToContactDTOList(contacts);

             return _automapper.Map<List<ContactDTO>>(contacts);
        }

        public ContactDTO GetContactById(int id)
        {
            var contact = contacts.FirstOrDefault(contact => contact.Id == id);

            if (contact != null)
            {
                //return _mymapper.ToContactDTO(contact);

                return _automapper.Map<ContactDTO>(contact); 
            }

            return null;
        }

        public ContactDTO CreateContact(ContactDTO newContact)
        {
            var contact = new Contact();
            contact.Id = newContact.Id;
            contact.FirstName = newContact.FirstName;
            contact.LastName = newContact.LastName;
            contact.Phone = newContact.PhoneNumber;
            contact.Address = newContact.Address;
            contacts.Add(contact);

            //return _mymapper.ToContactDTO(contact);

            return _automapper.Map<ContactDTO>(contact);
        }

        public ContactDTO UpdateContact(ContactDTO updateContact)
        {
            var contact = contacts.FirstOrDefault(contact => contact.Id == updateContact.Id);
            if (contact != null)
            {
                contact.FirstName = updateContact.FirstName;
                contact.LastName = updateContact.LastName;
                contact.Phone = updateContact.PhoneNumber;
                contact.Address = updateContact.Address;

                //return _mymapper.ToContactDTO(contact);

                return _automapper.Map<ContactDTO>(contact);
            }

            return null;
        }

        public bool DeleteContact(int id)
        {
            var contact = contacts.FirstOrDefault(contact => contact.Id == id);
            if (contact == null)
            {
                return false;
            }

            contacts.Remove(contact);
            return true;
        }

    }
}
