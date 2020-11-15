using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleBlogCore.Data;
using SimpleBlogCore.Data.Models;

namespace SimpleBlogCore.Service.Repository
{
    public class Contact
    {
        private readonly AppDbContext _context;

        public Contact(AppDbContext context)
        {
            _context = context;
        }

        public Task<ContactModel> GetContactDetailsAsync()
        {
            return _context.Contact.FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateContactDetailsAsync(ContactModel contactModel)
        {
            var contact = await _context.Contact.FirstOrDefaultAsync();

            if (contact != null)
            {
                try
                {
                    contact.PageTitle = contactModel.PageTitle;
                    contact.Title = contactModel.Title;
                    contact.Details = contactModel.Details;
                    contact.ShowContactForm = contactModel.ShowContactForm;

                    await _context.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
    }
}