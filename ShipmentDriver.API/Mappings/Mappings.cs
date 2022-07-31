using AutoMapper;
using ShipmentDriver.API.Dtos;
using ShipmentDriver.API.ViewModels;
using ShipmentDriver.Data.Models;

namespace ShipmentDriver.API.Mappings
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Driver, DriverViewModel>();
            CreateMap<DriverDto, Driver>();
            CreateMap<DriverViewModel, Driver>();
            CreateMap<ShipmentDto, Shipment>();



        }
    }
}
