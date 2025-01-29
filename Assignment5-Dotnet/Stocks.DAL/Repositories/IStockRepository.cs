using System.Collections.Generic;
using System.Threading.Tasks;
using Stocks.DAL.Entities;
using Stocks.DAL.Enums;

namespace Stocks.DAL.Repositories
{
    public interface IStockRepository
    {
        Task<IEnumerable<StockEntity>?> GetAllStocksAsync(FilterEntity filter);
        //Task<StockEntity> GetStockByIdAsync(int id);
        Task<StockEntity?> CreateStockAsync(StockEntity stock);
        Task<StockEntity?> UpdateStockAsync(StockEntity stock);
        Task<StockEntity?> GetStockByIdAsync(int id);
        Task DeleteStockAsync(int id);
    }
}