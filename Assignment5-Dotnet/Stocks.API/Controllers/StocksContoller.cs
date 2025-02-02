using Microsoft.AspNetCore.Mvc;
using Stocks.API.DTOs;
using Stocks.BAL.Services;
using AutoMapper;
using Stocks.DAL.Entities;
using Org.BouncyCastle.Asn1;
namespace Stocks.API.Controllers;

[ApiController]
[Route("[Controller]")]
public class StocksController : ControllerBase
{
    private readonly IStockService _stockService;
    private readonly IMapper _mapper;
    public StocksController(IStockService stockService,IMapper mapper1)
    {
        _stockService = stockService;
        _mapper=mapper1;
    }
    [HttpGet]
    public async Task<ActionResult> Get([FromQuery] QueryDTO queryParams)
    {
        FilterEntity filter=_mapper.Map<FilterEntity>(queryParams);
        var stocks = await _stockService.GetAllStocksAsync(filter);
        if(stocks==null) return NotFound("No Products Found");
        IEnumerable<ReturnStockDTO> res=_mapper.Map<IEnumerable<ReturnStockDTO>>(stocks);
        foreach(var stock in res){
            stock.IsValueForMoney=_stockService.IsValueForMoney(stock.Price,stock.Km);
        }
        return Ok(res);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id){
        StockEntity? stock=await _stockService.GetStockByIdAsync(id);
        if (stock == null) return NotFound("Could Not Found Stock with this Id");
        return Ok(stock);
    }
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateStockDTO stockBody){
        StockEntity stock=_mapper.Map<StockEntity>(stockBody);
        var createdStock=await _stockService.CreateStockAsync(stock);
        return Ok(createdStock);
    }
    [HttpPut]
    public async Task<ActionResult> Put([FromBody] UpdateStockDTO stockBody){
        StockEntity stock=_mapper.Map<StockEntity>(stockBody);
        var updatedStock=await _stockService.UpdateStockAsync(stock);
        if (updatedStock == null) return NotFound("Could Not Found Stock with this Id");
        return Ok(updatedStock);
    }
    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] int id){
        await _stockService.DeleteStockAsync(id);
        return Ok("Stock Deleted Successfully");
    }
}
