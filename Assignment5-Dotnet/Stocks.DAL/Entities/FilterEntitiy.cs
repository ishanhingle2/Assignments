using System.ComponentModel.DataAnnotations;
using Stocks.DAL.Enums;
namespace Stocks.DAL.Entities;
public class FilterEntity{
    [Range(1,21)]
    public int ?MinBudget{get;set;}
    [Range(1,21)]
    public int ?MaxBudget{get;set;}
    public List<FuelFilterTypeEnum>? FilterType {get;set;}
}