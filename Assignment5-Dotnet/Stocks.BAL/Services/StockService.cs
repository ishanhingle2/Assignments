using Stocks.DAL.Repositories;
using Stocks.DAL.Entities;
namespace Stocks.BAL.Services;

public class StockService : IStockService
{
    private readonly IStockRepository _stockRepository;

    public StockService(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

    public async Task<IEnumerable<StockEntity>> GetAllStocksAsync(FilterEntity filter)
    {
        // You can add business logic here before/after calling the repository
        return await _stockRepository.GetAllStocksAsync(filter);
    }
}

