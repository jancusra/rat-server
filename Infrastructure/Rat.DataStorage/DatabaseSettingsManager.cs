using Rat.Domain.Infrastructure;

namespace Rat.DataStorage
{
    public partial class DatabaseSettingsManager
    {
        private static string _settingsJsonFilePath = @"\App_Data\databaseSettings.json";

        public static DatabaseSettings GetSettings()
        {
            return CommonSettingsManager.GetSettings<DatabaseSettings>(_settingsJsonFilePath);
        }
    }
}
