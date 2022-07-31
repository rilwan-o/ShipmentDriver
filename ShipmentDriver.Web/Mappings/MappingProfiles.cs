using AutoMapper;
using ShipmentDriver.Web.Dtos;
using ShipmentDriver.Web.Models;
using ShipmentDriver.Web.ViewModels;

namespace ShipmentDriver.Web.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ShipmentResponseModel, Shipment>();
            CreateMap<Shipment, ShipmentDto>();
            CreateMap<DriverViewModel, Driver>();
        }
    }
}
