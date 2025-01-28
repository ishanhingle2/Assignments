using Microsoft.AspNetCore.Mvc;
using Stocks.API.DTOs;
using Stocks.DAL.Repositories;
using Stocks.BAL.Services;
using AutoMapper;
using Stocks.DAL.Entities;
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
        return Ok(stocks);
    }
}
