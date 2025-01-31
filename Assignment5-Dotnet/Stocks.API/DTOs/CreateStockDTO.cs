using System.ComponentModel.DataAnnotations;
using Stocks.DAL.Enums;
namespace Stocks.API.DTOs;
public class CreateStockDTO{
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
        [EnumDataType(typeof(FuelFilterTypeEnum))]
        public String FuelType{get;set;}
        [Required]
        [Range(0,double.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        [Range(0,double.MaxValue)]
        public decimal Km{get;set;}
}