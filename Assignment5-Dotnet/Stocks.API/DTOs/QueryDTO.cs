using System.ComponentModel.DataAnnotations;
using Stocks.DAL.Enums;

namespace Stocks.API.DTOs;
public class QueryDTO{
    [RegularExpression("^[1-9]|1[0-9]|2[0-1]-([1-9]|1[0-9]|2[0-1])$",ErrorMessage ="Invalid Query"),]
    public string? Budget {get;set;}
    [RegularExpression("^[1-6](/+[1-6]){0,5}$")]
    public string ?FuelType{get;set;}
}