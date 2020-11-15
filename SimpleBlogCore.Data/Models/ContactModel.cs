using System.ComponentModel.DataAnnotations;

namespace SimpleBlogCore.Data.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string PageTitle { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public bool ShowContactForm { get; set; }
    }
}