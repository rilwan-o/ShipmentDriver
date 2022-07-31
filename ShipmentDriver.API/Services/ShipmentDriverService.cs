using AutoMapper;
using ShipmentDriver.API.Dtos;
using ShipmentDriver.API.ViewModels;
using ShipmentDriver.Data.Contracts;
using ShipmentDriver.Data.Data;
using ShipmentDriver.Data.Models;

namespace ShipmentDriver.API.Services
{
    public class ShipmentDriverService : IShipmentDriverService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public ShipmentDriverService(IUnitOfWork repository, IMapper mapper, IConfiguration config)
        {
            _repository = repository;
            _mapper = mapper;
            _config = config;
        }

        public List<Shipment> GetShipments()
        {
            return _repository.Shipment.FindByCondition(d => d.DeletedAt == null).ToList();
        }

        public Shipment GetShipment(string id)
        {
            return _repository.Shipment.GetById(d => d.Id.ToString() == id && d.DeletedAt == null);

        }

        public Shipment CreateShipment(ShipmentDto shipmentDto)
        {
            Shipment shipment = _mapper.Map<Shipment>(shipmentDto);
            shipment.Status = (int)ShipmentStatus.init;
            shipment.CreatedAt = DateTime.Now;
            _repository.Shipment.Create(shipment);
            _repository.Save();

            return shipment;
        }

        public void UpdateShipment(Shipment shipment)
        {
            shipment.UpdatedAt = DateTime.Now;
            _repository.Shipment.Update(shipment);
            _repository.Save();
        }

        public void DeleteShipment(string id)
        {
            var shipment = _repository.Shipment.GetById(d => d.Id.ToString() == id && d.DeletedAt == null);
            shipment.DeletedAt = DateTime.Now;
            _repository.Shipment.Update(shipment);
            _repository.Save();

        }

        public List<Driver> GetDrivers()
        {
            return _repository.Driver.FindByCondition(d => d.DeletedAt == null).ToList();
        }

        public Driver GetDriver(string id)
        {
            return _repository.Driver.GetById(d => d.Id.ToString() == id && d.DeletedAt == null);
        }

        public Driver CreateDriver(DriverDto driverDto)
        {
            Driver driver = _mapper.Map<Driver>(driverDto);
            driver.CreatedAt = DateTime.Now;
            _repository.Driver.Create(driver);
            _repository.Save();

            return driver;
        }

        public void UpdateDriver(Driver driver)
        {
            driver.UpdatedAt = DateTime.Now;
            _repository.Driver.Update(driver);
            _repository.Save();

        }

        public void DeleteDriver(string id)
        {
            var driver = _repository.Driver.GetById(d => d.Id.ToString() == id);
            driver.DeletedAt = DateTime.Now;
            _repository.Driver.Update(driver);
            _repository.Save();

        }

        public ShipmentStatusUpdateViewModel PickUp(string ShipmentId, string DriverId)
        {
            var eitherExist = ExistenceCheck(ShipmentId, DriverId);
            if(!eitherExist.IsSuccess) return eitherExist;

            _repository.Shipment.PickUp(ShipmentId, DriverId);
            _repository.Save();

            return eitherExist;
        }

        public ShipmentStatusUpdateViewModel Delivered(string ShipmentId, string DriverId)
        {
            var eitherExist = ExistenceCheck(ShipmentId, DriverId);
            if (!eitherExist.IsSuccess) return eitherExist;

            _repository.Shipment.Delivered(ShipmentId, DriverId);
            _repository.Save();

            return eitherExist;
        }

        public ShipmentStatusUpdateViewModel Returned(string ShipmentId, string DriverId)
        {
            var eitherExist = ExistenceCheck(ShipmentId, DriverId);
            if (!eitherExist.IsSuccess) return eitherExist;

            _repository.Shipment.Returned(ShipmentId, DriverId);
            _repository.Save();

            return eitherExist;
        }

        private ShipmentStatusUpdateViewModel ExistenceCheck(string ShipmentId, string DriverId)
        {
            ShipmentStatusUpdateViewModel resp = new ShipmentStatusUpdateViewModel();

            var shipment = _repository.Shipment.GetById(d => d.Id.ToString() == ShipmentId && d.DeletedAt == null);
            var status = shipment is null;
            resp.IsSuccess = !status;

            if (status) 
            {
                resp.Message = _config["ShipmentNotFound"];
                return resp;
            }
            var driver = _repository.Driver.GetById(d => d.Id.ToString() == DriverId && d.DeletedAt == null);
            status = driver is null;
            resp.IsSuccess = !status;
            if (status)
            {
                resp.Message = _config["DriverNotFound"];
                return resp;
            }

            resp.Message = _config["Succss"];
            return resp;
        }
    }
}
