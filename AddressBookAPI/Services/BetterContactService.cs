using AddressBookAPI.DTOs;
using AddressBookAPI.Models;
using AutoMapper;

namespace AddressBookAPI.Services
{
    public class BetterContactService : IContactService
    {

        private readonly IMapper _mapper;
        private readonly List<Contact> _contacts = new();

        public BetterContactService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<ContactDTO> GetAllContacts() =>
            _mapper.Map<List<ContactDTO>>(_contacts);

        public ContactDTO GetContactById(int id) =>
            _mapper.Map<ContactDTO>(_contacts.FirstOrDefault(c => c.Id == id));

        public ContactDTO CreateContact(ContactDTO dto)
        {
            var contact = _mapper.Map<Contact>(dto);
            _contacts.Add(contact);
            return _mapper.Map<ContactDTO>(contact);
        }

        public ContactDTO UpdateContact(ContactDTO dto)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == dto.Id);
            if (contact == null) return null;

            _mapper.Map(dto, contact);
            return _mapper.Map<ContactDTO>(contact);
        }

        public bool DeleteContact(int id)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == id);
            return contact != null && _contacts.Remove(contact);
        }
        /* public ContactDTO CreateContact(ContactDTO newContact)
         {
             throw new NotImplementedException();
         }

         public bool DeleteContact(int id)
         {
             throw new NotImplementedException();
         }

         public List<ContactDTO> GetAllContacts()
         {
             throw new NotImplementedException();
         }

         public ContactDTO GetContactById(int id)
         {
             throw new NotImplementedException();
         }

         public ContactDTO UpdateContact(ContactDTO updateContact)
         {
             throw new NotImplementedException();
         }*/
    }
}
