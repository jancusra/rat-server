namespace Rat.DataStorage.DataProviders
{
    public partial interface IDataProviderManager
    {
        IDbDataProvider DataProvider { get; }
    }
}
