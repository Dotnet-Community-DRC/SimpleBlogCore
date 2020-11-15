using System.Threading.Tasks;
using SimpleBlogCore.Data.Models;

namespace SimpleBlogCore.Service.Interfaces
{
    public interface IManageContact
    {
        Task<ContactModel> GetContactDetailsAsync();

        Task<bool> UpdateContactDetailsAsync(ContactModel contactModel);
    }
}