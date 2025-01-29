using AutoMapper;
using Stocks.API.DTOs;
using Stocks.DAL.Entities;
using Stocks.DAL.Enums;


namespace Stocks.API.Handler;
public class StockAutoMapperHandler:Profile{
    public StockAutoMapperHandler(){
        CreateMap<CreateStockDTO,StockEntity>()
        .ForMember(dest=>dest.ProfileId,opt=>opt.Ignore());

        CreateMap<UpdateStockDTO,StockEntity>();

        CreateMap<StockEntity,ReturnStockDTO>()
        .ForMember(dest=>dest.CarName,opt=>opt.MapFrom(src=>$"{src.MakeYear} {src.MakeName} {src.ModelName}"))
        .ForMember(dest=>dest.FormattedPrice,opt=>opt.MapFrom(src=>$"{src.Price/100000} Lakh"))
        .ForMember(dest=>dest.IsValueForMoney,opt=>opt.MapFrom(src => false));
    }
}