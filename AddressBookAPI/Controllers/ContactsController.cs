using AddressBookAPI.DTOs;
using AddressBookAPI.Models;
using AddressBookAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AddressBookAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult AllContacts()
        {
            return Ok(_contactService.GetAllContacts());
        }

        [HttpGet("{id}")]
        public IActionResult ContactById(int id)
        {
            var contact = _contactService.GetContactById(id);
            if (contact == null)
            {
                return BadRequest("Can not find this contact");
            }
            return Ok(contact);
        }

        [HttpPost]
        public IActionResult CreateContact([FromBody] ContactDTO newContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var contact = _contactService.CreateContact(newContact);

            if (contact == null)
            {
                return BadRequest("Can not find this contact to create");
            }

            return Ok(contact);
        }

        [HttpPut]
        public IActionResult UpdateContact([FromBody] ContactDTO updateContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var contact = _contactService.UpdateContact(updateContact);
            if (contact == null)
            {
                return BadRequest("Can not find this contact to update");
            }

            return Ok(contact);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var result = _contactService.DeleteContact(id);
            if (result == false)
            {
                return BadRequest("Can not find this contact to delete");
            }

            return Ok("The contact has been deleted");
        }
    }
}
