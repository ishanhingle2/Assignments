namespace Stocks.API.DTOs;
using System.ComponentModel.DataAnnotations;
public class ReturnStockDTO{
        [Required]
        public int ProfileId{get;set;}
        [Required]
        [MaxLength(200)]
        public string CarName{get;set;}
        [Required]
        [MaxLength(100)]
        public string MakeName { get; set; }
        [Required]
        [MaxLength(100)]
        public string ModelName { get; set; }
        [Required]
        [Range(1990,2025)]
        public int MakeYear { get; set; }
        [Required]
        public string FuelType{get;set;}
        [Required]
        [Range(0,double.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        [StringLength(50,MinimumLength =7)]
        public string FormattedPrice {get;set;}
        [Required]
        public bool IsValueForMoney{get;set;}
        [Required]
        [Range(0,double.MaxValue)]
        public decimal Km{get;set;}
}