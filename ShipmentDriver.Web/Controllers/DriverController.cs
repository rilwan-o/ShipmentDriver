using Microsoft.AspNetCore.Mvc;
using ShipmentDriver.Web.Contracts;
using ShipmentDriver.Web.Dtos;
using ShipmentDriver.Web.Models;
using ShipmentDriver.Web.ViewModels;

namespace ShipmentDriver.Web.Controllers
{
    public class DriverController : Controller
    {
        private readonly IDriverPageServices _shipmentDriverService;
        private readonly IConfiguration _configuration;
        public DriverController(IDriverPageServices shipmentDriverService, IConfiguration configuration)
        {
            _shipmentDriverService = shipmentDriverService;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            var drivers = await _shipmentDriverService.GetDrivers();
            return View(drivers);
        }
        public IActionResult Create()
        {
            ViewBag.status = GetStatusList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DriverDto driverDto)
        {
            if (!ModelState.IsValid) return View(driverDto);

            var driver = await _shipmentDriverService.CreateDriver(driverDto);
            TempData["success"] = "Driver created successfuly";
            return RedirectToAction("Index", "Driver");

        }

        public async Task<IActionResult> Edit(string? id)
        {

            if (id == null) return NotFound(id);

            var driver = await _shipmentDriverService.GetDriver(id);
            if (driver == null) return NotFound();
            ViewBag.status = GetStatusList();
            return View(driver);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Driver driver)
        {
            if (!ModelState.IsValid) return View(driver);

            await _shipmentDriverService.UpdateDriver(driver);
            TempData["success"] = "Driver updated successfuly";
            return RedirectToAction("Index", "Driver");
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound(id);

            var driver = await _shipmentDriverService.GetDriver(id);
            if (driver == null) return NotFound();

            return View(driver);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteById(string? id)
        {
            if (id == null) return NotFound(id);

            var shipment = await _shipmentDriverService.GetDriver(id);
            if (shipment == null) return NotFound();

            await _shipmentDriverService.DeleteDriver(id);
            TempData["success"] = "Driver removed successfuly";
            return RedirectToAction("Index", "Driver");
        }

        private List<DriverStatus> GetStatusList()
        {
            var statusList = _configuration["DriverStatusList"].Split(',');
            List<DriverStatus> ds = new List<DriverStatus>();
            //ds.Add(new DriverStatus { Id = null, Name = "select status" });
            for (int i = 0; i < statusList.Count(); i++)
            {
                var s = new DriverStatus { Id = i, Name = statusList[i] };
                ds.Add(s);
            }

            return ds;
        }
    }
}
