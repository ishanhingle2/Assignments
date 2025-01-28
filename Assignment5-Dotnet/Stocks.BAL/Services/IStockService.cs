using Stocks.DAL.Entities;

namespace Stocks.BAL.Services
{
    public interface IStockService
    {
        Task<IEnumerable<StockEntity>> GetAllStocksAsync(FilterEntity filter);
        // Additional methods for business logic
    }
}