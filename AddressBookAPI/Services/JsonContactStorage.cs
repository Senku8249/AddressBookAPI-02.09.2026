using global::AddressBookAPI.Models;
using System.Text.Json;

namespace AddressBookAPI.Services
{
    
    
        public class JsonContactStorage : IContactStorage
        {
            private const string FilePath = "contacts.json";

            public List<Contact> GetAll()
            {
                if (!File.Exists(FilePath))
                    return new List<Contact>();

                var json = File.ReadAllText(FilePath);

                if (string.IsNullOrWhiteSpace(json))
                    return new List<Contact>();

                return JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
            }

            public Contact? GetById(int id)
            {
                var contacts = GetAll();
                return contacts.FirstOrDefault(c => c.Id == id);
            }

            public void Add(Contact contact)
            {
                var contacts = GetAll();

                // если Id не задан — назначаем следующий
                if (contact.Id == 0)
                    contact.Id = contacts.Count == 0 ? 1 : contacts.Max(c => c.Id) + 1;

                contacts.Add(contact);
                SaveAll(contacts);
            }

            public void Delete(int id)
            {
                var contacts = GetAll();

                var contact = contacts.FirstOrDefault(c => c.Id == id);
                if (contact == null) return;

                contacts.Remove(contact);
                SaveAll(contacts);
            }

            private void SaveAll(List<Contact> contacts)
            {
                var json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(FilePath, json);
            }
        }
    }


