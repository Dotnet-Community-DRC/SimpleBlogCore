using System.Threading.Tasks;
using SimpleBlogCore.Data.Models;

namespace SimpleBlogCore.Service.Interfaces
{
    public interface IManageSettings
    {
        Task<SettingsModel> GetSettingsAsync();

        Task<bool> UpdateSettingsAsync(SettingsModel settingsModel);
    }
}