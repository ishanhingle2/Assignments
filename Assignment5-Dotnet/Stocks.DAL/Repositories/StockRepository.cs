using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Stocks.DAL.Entities;

namespace Stocks.DAL.Repositories;
public class StockRepository : IStockRepository
{
    private readonly IConfiguration _config;
    private readonly string? _connectionString;
    public StockRepository(IConfiguration iconfiguration)
    {
        _config = iconfiguration;
        _connectionString = _config.GetConnectionString("default");
    }
    private IDbConnection GetDbConnection()
    {
        IDbConnection connection = new MySqlConnection(_connectionString);
        return connection;
    }
    public async Task<IEnumerable<StockEntity>?> GetAllStocksAsync(FilterEntity filter)
    {
        using var connection = GetDbConnection();
        string sql = "SELECT * FROM Stocks WHERE 1=1";
        var parameters = new DynamicParameters();

        if (filter.MinBudget != null)
        {
            sql += " AND Price >= @MinBudget";
            parameters.Add("@MinBudget", filter.MinBudget);
        }

        if (filter.MaxBudget != null)
        {
            sql += " AND Price <= @MaxBudget";
            parameters.Add("@MaxBudget", filter.MaxBudget);
        }

        if (filter.FuelType != null && filter.FuelType.Any())
        {
            sql += " AND FuelType IN @FuelTypes";
            parameters.Add("@FuelTypes", filter.FuelType.Select(f => f.ToString()).ToArray());
        }

        Console.WriteLine(sql);
        var stocks = await connection.QueryAsync<StockEntity>(sql, parameters);
        return stocks;
    }

    public async Task<StockEntity?> CreateStockAsync(StockEntity stock)
    {
        using var connection = GetDbConnection();
        var sql = @"
                INSERT INTO Stocks (MakeName, ModelName, MakeYear, FuelType, Price, Km)
                VALUES (@MakeName, @ModelName, @MakeYear, @FuelType, @Price, @Km);
            ";
        await connection.ExecuteAsync(sql, stock);
        return stock;
    }
    public async Task<StockEntity?> UpdateStockAsync(StockEntity stock)
    {
        var connection = GetDbConnection();
        string sql = @"
        UPDATE Stocks SET
        ModelName=@ModelName,
        MakeName=@MakeName,
        MakeYear=@MakeYear,
        FuelType=@FuelType,
        Price=@Price,
        Km=@Km
        WHERE ProfileId = @ProfileId
        ";
        var affectedRows = await connection.ExecuteAsync(sql, stock);

        if (affectedRows > 0)
        {
            string selectSql = "SELECT * FROM Stocks WHERE ProfileId = @ProfileId";
            var updatedStock = await connection.QuerySingleOrDefaultAsync<StockEntity>(selectSql, new { ProfileId = stock.ProfileId });
            return updatedStock;
        }
        return null;
    }

     public async Task<StockEntity?> GetStockByIdAsync(int id){
        using var connection=GetDbConnection();
         string sql = "Select * FROM Stocks WHERE ProfileId = @ProfileId";
         var stock = await connection.QuerySingleAsync<StockEntity>(sql, new { ProfileId = id });
         return stock;
     }

    public async Task DeleteStockAsync(int id){
        using var connection=GetDbConnection();
        string sql = "DELETE FROM Stocks WHERE ProfileId = @ProfileId";
        await connection.ExecuteAsync(sql, new { ProfileId = id });
    }


}