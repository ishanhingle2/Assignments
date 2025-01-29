using AutoMapper;
using Org.BouncyCastle.Crypto.Agreement.Srp;
using Stocks.API.DTOs;
using Stocks.DAL.Entities;
using Stocks.DAL.Enums;
using ZstdSharp.Unsafe;

public class AutoMapperHandler:Profile{
    public AutoMapperHandler(){
        CreateMap<QueryDTO,FilterEntity>()
        .ForMember(dest => dest.MinBudget, opt => opt.MapFrom(
            src => src.Budget != null && src.Budget.Contains('-') ? 
            int.Parse(src.Budget.Split(new char[]{'-'})[0])*100000 : (int?)null
        ))
        .ForMember(dest => dest.MaxBudget, opt => opt.MapFrom(
            src => src.Budget != null && src.Budget.Contains('-') ? 
            int.Parse(src.Budget.Split(new char[]{'-'})[1])*100000 : (int?)null
        ))
        .ForMember(dest=>dest.FuelType,opt=>opt.MapFrom(src=>src.FuelType != null ?
         GetFuelFilters(src.FuelType) : null
         ));

        CreateMap<CreateStockDTO,StockEntity>()
        .ForMember(dest=>dest.ProfileId,opt=>opt.Ignore());

        CreateMap<UpdateStockDTO,StockEntity>();

        CreateMap<StockEntity,ReturnStockDTO>()
        .ForMember(dest=>dest.CarName,opt=>opt.MapFrom(src=>$"{src.MakeYear} {src.MakeName} {src.ModelName}"))
        .ForMember(dest=>dest.FormattedPrice,opt=>opt.MapFrom(src=>$"{src.Price/100000} Lakh"))
        .ForMember(dest=>dest.IsValueForMoney,opt=>opt.MapFrom(src => false));
    }
    //function to map ?fuelType='1+2+3.. to fuel filter enum
    private List<FuelFilterTypeEnum> GetFuelFilters(string fuelType){
        string []queryArray=fuelType.Split('+');
        List<FuelFilterTypeEnum> FuelFilterList=new List<FuelFilterTypeEnum>();
        FuelFilterTypeEnum[] filterTypeArray = (FuelFilterTypeEnum[])Enum.GetValues(typeof(FuelFilterTypeEnum));
        foreach(string integerFuelType in queryArray){
            FuelFilterTypeEnum type = filterTypeArray[int.Parse(integerFuelType) - 1];
            FuelFilterList.Add(type);
        }

        return FuelFilterList;
    }
}


