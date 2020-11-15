using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleBlogCore.Data;
using SimpleBlogCore.Data.Models;
using SimpleBlogCore.Web.Helpers;

namespace SimpleBlogCore.Service.Repository
{
    public class Settings
    {
        private readonly AppDbContext _context;
        private readonly IDataEncryptionHelper _encryptionHelper;

        public Settings(AppDbContext context, IDataEncryptionHelper encryptionHelper)
        {
            _context = context;
            _encryptionHelper = encryptionHelper;
        }

        public async Task<SettingsModel> GetSettingsAsync()
        {
            var settings = await _context.Settings.FirstOrDefaultAsync();
            var settingsModel = new SettingsModel()
            {
                PhoneNumber = settings.PhoneNumber,
                ShowPhone = settings.ShowPhone,
                NoticeText = settings.NoticeText,
                ShowNotice = settings.ShowNotice,
                EnableNoticeMarquee = settings.EnableNoticeMarquee,
                MainThemeColor = settings.MainThemeColor,
                LinkedIn = settings.LinkedIn,
                Twitter = settings.Twitter,
                Facebook = settings.Facebook,
                GitHub = settings.GitHub,
                Twitch = settings.Twitch,
                YouTube = settings.YouTube,
                GoogleAnalyticsID = settings.GoogleAnalyticsID,
                SendGridKey = _encryptionHelper.Decrypt(settings.SendGridKey),
                EmailAddress = settings.EmailAddress,
                ReCaptchaKey = _encryptionHelper.Decrypt(settings.ReCaptchaKey),
                ReCaptchaSecretKey = _encryptionHelper.Decrypt(settings.ReCaptchaSecretKey)
            };

            return settingsModel;
        }

        public async Task<bool> UpdateSettingsAsync(SettingsModel settingsModel)
        {
            var settings = await _context.Settings.FirstOrDefaultAsync();
            if (settings != null)
            {
                try
                {
                    settings.PhoneNumber = settingsModel.PhoneNumber;
                    settings.ShowPhone = settingsModel.ShowPhone;
                    settings.NoticeText = settingsModel.NoticeText;
                    settings.ShowNotice = settingsModel.ShowNotice;
                    settings.EnableNoticeMarquee = settingsModel.EnableNoticeMarquee;
                    settings.MainThemeColor = settingsModel.MainThemeColor;
                    settings.LinkedIn = settingsModel.LinkedIn;
                    settings.Twitter = settingsModel.Twitter;
                    settings.Facebook = settingsModel.Facebook;
                    settings.GitHub = settingsModel.GitHub;
                    settings.Twitch = settingsModel.Twitch;
                    settings.YouTube = settingsModel.YouTube;
                    settings.GoogleAnalyticsID = settingsModel.GoogleAnalyticsID;
                    settings.SendGridKey = _encryptionHelper.Encrypt(settingsModel.SendGridKey);
                    settings.EmailAddress = settingsModel.EmailAddress;
                    settings.ReCaptchaKey = _encryptionHelper.Encrypt(settingsModel.ReCaptchaKey);
                    settings.ReCaptchaSecretKey = _encryptionHelper.Encrypt(settingsModel.ReCaptchaSecretKey);

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