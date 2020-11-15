using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleBlogCore.Data.Models;
using SimpleBlogCore.Service;
using SimpleBlogCore.Service.Google;
using SimpleBlogCore.Service.Interfaces;
using SimpleBlogCore.Web.Models.ViewModels;

namespace SimpleBlogCore.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IManageContact _manageContact;
        private readonly IManageSettings _manageSettings;

        public ContactController(IManageContact manageContact, IManageSettings manageSettings)
        {
            _manageContact = manageContact;
            _manageSettings = manageSettings;
        }

        [HttpGet]
        [Route("api/contact")]
        public Task<ContactModel> Get()
        {
            return _manageContact.GetContactDetailsAsync();
        }

        [HttpPost]
        [Route("api/contact")]
        public async Task<bool?> Post(ContactModel contactModel)
        {
            try
            {
                var updated = await _manageContact.UpdateContactDetailsAsync(contactModel);
                if (updated)
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return null;
            }
        }

        [HttpPost]
        [Route("api/contactform")]
        public async Task<bool?> PostForm(ContactFormModel contactFormModel)
        {
            try
            {
                var settings = await _manageSettings.GetSettingsAsync();
                var reCaptcha = new ReCaptcha();
                if (!reCaptcha.Validate(contactFormModel.ReCaptcha, settings.ReCaptchaSecretKey))
                {
                    return false;
                }

                await new EmailSender(_manageSettings)
                    .SendContactFormEmailAsync(contactFormModel.SenderName, contactFormModel.SenderEmail, contactFormModel.SenderPhone, contactFormModel.SenderMessage);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}