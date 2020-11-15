using SimpleBlogCore.Data.Models;

namespace SimpleBlogCore.Data
{
    public class SeedContact
    {
        public static void Initialize(AppDbContext context)
        {
            var contact = new ContactModel()
            {
                PageTitle = "Contact Me",
                Title = "Contact",
                Details = "",
                ShowContactForm = true
            };

            context.Contact.Add(contact);
            context.SaveChanges();
        }
    }
}