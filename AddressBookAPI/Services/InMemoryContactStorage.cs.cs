using AddressBookAPI.Models;
using AddressBookAPI.Services;

public class InMemoryContactStorage : IContactStorage
{
    private readonly List<Contact> _contacts = new()
    {
        new Contact { Id = 1, FirstName = "Jack", LastName = "Jackson", Phone = "111-111-1111", Address = "111 Main Street", CreditCardNumber = "123456789"},
        new Contact { Id = 2, FirstName = "John", LastName = "Johnson", Phone = "222-222-2222", Address = "222 Main Street", CreditCardNumber = "123451234"}
    };

    public List<Contact> GetAll() => _contacts;

    public Contact? GetById(int id) =>
        _contacts.FirstOrDefault(c => c.Id == id);

    public void Add(Contact contact) =>
        _contacts.Add(contact);

    public void Delete(int id)
    {
        var contact = GetById(id);
        if (contact != null)
            _contacts.Remove(contact);
    }
}



Реализовать хранение контактов. Через интерфейс и подлкючить через програм cs. 
    Реализовать сторедж сервис с работой с файлами json на жестком диске*