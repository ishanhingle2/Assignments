using System.Collections.Generic;
using System.Threading.Tasks;
using Stocks.DAL.Entities;
using Stocks.DAL.Enums;

namespace Stocks.DAL.Repositories
{
    public interface IStockRepository
    {
        Task<IEnumerable<StockEntity>> GetAllStocksAsync(FilterEntity filter);
        // Task<StockEntity> GetStockByIdAsync(int id);
        // Task AddStockAsync(StockEntity stock);
        // Task UpdateStockAsync(StockEntity stock);
        // Task DeleteStockAsync(int id);
    }
}