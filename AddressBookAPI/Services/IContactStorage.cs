using AddressBookAPI.Models;
// интерфейс хранилища

namespace AddressBookAPI.Services
{

    public interface IContactStorage
    {
        List<Contact> GetAll();
        Contact? GetById(int id);
        void Add(Contact contact);
        void Delete(int id);
    }
}