using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using Stocks.DAL.Enums;

namespace Stocks.DAL.Entities
{
    public class StockEntity
    {
        public int ProfileId { get; set; }
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
        public FuelFilterTypeEnum FuelType{get;set;}
        [Required]
        [Range(0,double.MaxValue)]
        public decimal Price { get; set; }
    }
}