using System;
using System.Threading.Tasks;
using SimpleBlogCore.Data;
using SimpleBlogCore.Data.Models;
using SimpleBlogCore.Service.Repository;
using SimpleBlogCore.Web.Helpers;

namespace SimpleBlogCore.Service.Interfaces
{
    public class ManageSettings : IManageSettings
    {
        private readonly AppDbContext _context;
        private readonly IDataEncryptionHelper _encryptHelper;

        public ManageSettings(AppDbContext context, IDataEncryptionHelper encryptHelper)
        {
            _context = context;
            _encryptHelper = encryptHelper;
        }

        public Task<SettingsModel> GetSettingsAsync() =>
            new Settings(_context, _encryptHelper).GetSettingsAsync();

        public Task<bool> UpdateSettingsAsync(SettingsModel settingsModel) =>
            new Settings(_context, _encryptHelper).UpdateSettingsAsync(settingsModel);
    }
}