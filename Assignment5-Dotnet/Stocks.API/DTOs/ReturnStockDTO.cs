namespace Stocks.API.DTOs;
using System.ComponentModel.DataAnnotations;
public class ReturnStockDTO{
        public int ProfileId{get;set;}
        public string CarName{get;set;}
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public int MakeYear { get; set; }
        public string FuelType{get;set;}
        public decimal Price { get; set; }
        public string FormattedPrice {get;set;}
        public bool IsValueForMoney{get;set;}
        public decimal Km{get;set;}
}