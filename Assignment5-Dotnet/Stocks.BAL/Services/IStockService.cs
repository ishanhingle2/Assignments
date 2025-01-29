using Stocks.DAL.Entities;

namespace Stocks.BAL.Services
{
    public interface IStockService
    {
        Task<IEnumerable<StockEntity>?> GetAllStocksAsync(FilterEntity filter);
        Task<StockEntity?> CreateStockAsync(StockEntity stock);
        Task<StockEntity?> UpdateStockAsync(StockEntity stock);
        Task<StockEntity?> GetStockByIdAsync(int id);
        Task DeleteStockAsync(int id);
        bool IsValueForMoney(decimal price,decimal km);
    }
}