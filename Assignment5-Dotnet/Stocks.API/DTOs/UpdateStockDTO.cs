using System.ComponentModel.DataAnnotations;
namespace Stocks.API.DTOs;
public class UpdateStockDTO{
        [Required]
        public int ProfileId{get;set;}
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
        public String FuelType{get;set;}
        [Required]
        [Range(0,double.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        [Range(0,double.MaxValue)]
        public decimal Km{get;set;}
}