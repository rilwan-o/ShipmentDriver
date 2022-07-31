using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShipmentDriver.Web.Contracts;
using ShipmentDriver.Web.Dtos;
using ShipmentDriver.Web.Models;
using ShipmentDriver.Web.ViewModels;

namespace ShipmentDriver.Web.Controllers
{
    public class ShipmentController : Controller
    {
        private readonly IShipmentPageServices _shipmentDriverService;
        private readonly IDriverPageServices _driverService;


        public ShipmentController(IShipmentPageServices shipmentDriverService, IDriverPageServices driverService)
        {
            _shipmentDriverService = shipmentDriverService;
            _driverService = driverService;
        }
        public async Task<IActionResult> Index()
        {
            var shipments = await _shipmentDriverService.GetShipments();
            return View(shipments);
        }

        public async Task<IActionResult> Create()
        {            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ShipmentDto shipment)
        {
            if(!ModelState.IsValid) return View(shipment);
            //ModelState.AddModelError("origin", "Origin name is very important");
            ViewBag.dri = await GetDrivers();
            var ship = await _shipmentDriverService.CreateShipment(shipment);
            TempData["success"] = "Shipment created successfuly";
            return RedirectToAction("Index", "Shipment");
        
        }

        public async Task<IActionResult> Edit(string? id)
        {

            if (id == null) return NotFound(id);

            var shipment = await _shipmentDriverService.GetShipment(id);
            if (shipment == null) return NotFound();
            //List<DriverViewModel> dvm = await GetDrivers();
            ViewBag.dri = await GetDrivers();
            return View(shipment);
        }

        private async Task<List<DriverViewModel>> GetDrivers()
        {
            var drivers = await _driverService.GetDrivers();
            List<DriverViewModel> dvm = new List<DriverViewModel>();
            dvm.Add(new DriverViewModel { id = "", firstName = "select ", lastName = "driver" });
            foreach (var item in drivers)
            {
                dvm.Add(item);
            }

            return dvm;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Shipment shipment)
        {
            if (!ModelState.IsValid) return View(shipment);

            await _shipmentDriverService.UpdateShipment(shipment);
            TempData["success"] = "Shipment updated successfuly";
            return RedirectToAction("Index", "Shipment");
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound(id);

            var shipment = await _shipmentDriverService.GetShipment(id);
            if (shipment == null) return NotFound();

            return View(shipment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteById(string? id)
        {
            if (id == null) return NotFound(id);

            var shipment = await _shipmentDriverService.GetShipment(id);
            if (shipment == null) return NotFound();

            await _shipmentDriverService.DeleteShipment(id);
            TempData["success"] = "Shipment removed successfuly";
            return RedirectToAction("Index", "Shipment");
        }

    }
}
