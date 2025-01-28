using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Stocks.DAL.Entities;

namespace Stocks.DAL.Repositories;
public class StockRepository:IStockRepository{
    private readonly IConfiguration _config;
    private readonly string? _connectionString;
    public StockRepository(IConfiguration iconfiguration){
        _config=iconfiguration;
        _connectionString=_config.GetConnectionString("default");
    }
    private IDbConnection GetDbConnection(){
        IDbConnection connection=new MySqlConnection(_connectionString);
        return connection;
    }
    public async Task<IEnumerable<StockEntity>> GetAllStocksAsync(FilterEntity filter){
        var connection=GetDbConnection();
        string sql="select * from Stocks";

        var stocks=await connection.QueryAsync<StockEntity>(sql);
        return stocks;
    }
    public async Task CreateStockAsync(StockEntity stock){
        var connection=GetDbConnection();
        string sql="insert into "
    }
}