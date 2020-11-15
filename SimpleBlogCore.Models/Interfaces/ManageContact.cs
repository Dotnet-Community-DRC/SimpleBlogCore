using System.Threading.Tasks;
using SimpleBlogCore.Data;
using SimpleBlogCore.Data.Models;
using SimpleBlogCore.Service.Repository;

namespace SimpleBlogCore.Service.Interfaces
{
    public class ManageContact : IManageContact
    {
        private readonly AppDbContext _context;

        public ManageContact(AppDbContext context)
        {
            _context = context;
        }

        public Task<ContactModel> GetContactDetailsAsync() =>
            new Contact(_context).GetContactDetailsAsync();

        public Task<bool> UpdateContactDetailsAsync(ContactModel contactModel) =>
             new Contact(_context).UpdateContactDetailsAsync(contactModel);
    }
}