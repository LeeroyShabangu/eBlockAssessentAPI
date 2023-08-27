using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eBlockAssessent.Data;
using eBlockAssessent.Models;
using eBlockAssessent.Services;

namespace eBlockAssessent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactService _contactService;

        public ContactsController(ContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetContacts()
        {
            return await _contactService.GetContactsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var contact = await _contactService.GetContactAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return contact;
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> AddContact(Contact contact)
        {
            await _contactService.AddContactAsync(contact);
            return CreatedAtAction(nameof(GetContact), new { id = contact.Id }, contact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, Contact contact)
        {
            if (!await _contactService.UpdateContactAsync(id, contact))
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            if (!await _contactService.DeleteContactAsync(id))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
