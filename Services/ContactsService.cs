using eBlockAssessent.Data;
using eBlockAssessent.Models;
using Microsoft.EntityFrameworkCore;

namespace eBlockAssessent.Services
{
    public class ContactService
    {
        private readonly ContactDbContext _context;

        public ContactService(ContactDbContext context)
        {
            _context = context;
        }

        public async Task<List<Contact>> GetContactsAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetContactAsync(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task<Contact> AddContactAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<bool> UpdateContactAsync(int id, Contact contact)
        {
            if (id != contact.Id)
            {
                return false;
            }

            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteContactAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return false;
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
