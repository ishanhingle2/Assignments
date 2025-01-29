using Stocks.DAL.Repositories;
using Stocks.DAL.Entities;
using Org.BouncyCastle.Asn1;
namespace Stocks.BAL.Services;

public class StockService : IStockService
{
    private readonly IStockRepository _stockRepository;

    public StockService(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

    public async Task<IEnumerable<StockEntity>?> GetAllStocksAsync(FilterEntity filter)
    {
        return await _stockRepository.GetAllStocksAsync(filter);
    }
    public async Task<StockEntity?> CreateStockAsync(StockEntity stock){
        return await _stockRepository.CreateStockAsync(stock);
    }
    public async Task<StockEntity?> UpdateStockAsync(StockEntity stock){
        return await _stockRepository.UpdateStockAsync(stock);
    }
    public async Task<StockEntity?> GetStockByIdAsync(int id){
        return await _stockRepository.GetStockByIdAsync(id);
    }

    public async Task DeleteStockAsync(int id){
        await _stockRepository.DeleteStockAsync(id);
    }
    public bool IsValueForMoney(decimal price,decimal km){
        decimal priceThreshold=200000;
        decimal kmThreshold=10000;
        return (price<priceThreshold && km<kmThreshold);
    }
}

