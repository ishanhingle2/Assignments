using AutoMapper;
using Stocks.API.DTOs;
using Stocks.DAL.Entities;
using Stocks.DAL.Enums;
namespace Stocks.API.Handler;
public class FilterAutoMapperHandler:Profile{
    public FilterAutoMapperHandler(){
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


