using Stocks.BAL.Services;
using Moq;
using Stocks.DAL.Repositories;
using Stocks.DAL.Entities;
using Xunit.Sdk;
using Stocks.DAL.Enums;
using FluentAssertions;
using System.Threading.Tasks;
namespace Stocks.Tests;

public class StockServicesTests
{   
    private readonly StockService _stockService;
    private readonly Mock<IStockRepository> _stockRepositoryMock;
    public StockServicesTests(){
        _stockRepositoryMock = new Mock<IStockRepository>();
        _stockService=new StockService(_stockRepositoryMock.Object);
    }
    [Fact]
    public void IsValueForMoney_WithValueForMoney_ReturnsTrue()
    {
       decimal price=100000;
       decimal km=500;
       bool res=_stockService.IsValueForMoney(price,km);
       Assert.True(res);
    }
    [Fact]
    public void IsValueForMoney_WithNotValueForMoney_ReturnsFalse()
    {
       decimal price=600000;
       decimal km=50000;
       bool res=_stockService.IsValueForMoney(price,km);
       Assert.False(res);
    }
    [Fact]
    public async Task GetAllStocksAsync_WithStocksAvailble_ReturnsStock(){
        IEnumerable<StockEntity> expectedStocks=new List<StockEntity>{
            new StockEntity { ProfileId = 1, MakeName = "Toyota", ModelName = "Innova",
            MakeYear = 2020, FuelType = FuelFilterTypeEnum.Diesel, Price = 1200000, Km = 40000 },
            new StockEntity { ProfileId = 2, MakeName = "Honda", ModelName = "City",
            MakeYear = 2019, FuelType = FuelFilterTypeEnum.Petrol, Price = 900000, Km = 30000 }
        };
        FilterEntity filter=new FilterEntity();
        _stockRepositoryMock.Setup(repo=>repo.GetAllStocksAsync(filter)).ReturnsAsync(expectedStocks);

        var result= await _stockService.GetAllStocksAsync(filter);
        result.Should().BeEquivalentTo(
            expectedStocks
        );
        
        
    }
}