using AutoMapper;
using ShipmentDriver.Web.Contracts;
using ShipmentDriver.Web.Dtos;
using ShipmentDriver.Web.Models;
using ShipmentDriver.Web.ViewModels;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace ShipmentDriver.Web.Services
{
    public class DriverPageServices : IDriverPageServices
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string shipmentDriverBseUrl;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public DriverPageServices(IHttpClientFactory httpClientFactory, IConfiguration configuration, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            shipmentDriverBseUrl = _configuration["ShipmentDriverBaseUrl"];
            _mapper = mapper;
        }
        public async Task<DriverViewModel> CreateDriver(DriverDto driverDto)
        {
            DriverViewModel driver = new DriverViewModel();
            var httpClient = _httpClientFactory.CreateClient();
            var driverString = new StringContent(
                    JsonSerializer.Serialize(driverDto),
                    Encoding.UTF8,
                    Application.Json);

            var httpResponseMessage = await httpClient.PostAsync($"{shipmentDriverBseUrl}/driver",
                driverString);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

                driver = await JsonSerializer.DeserializeAsync<DriverViewModel>(contentStream);

            }

            return driver;
        }

        public async Task DeleteDriver(string id)
        {
            var httpClient = _httpClientFactory.CreateClient();
            using var httpResponseMessage = await httpClient.DeleteAsync($"{shipmentDriverBseUrl}/driver/{id}");
            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public async Task<Driver> GetDriver(string id)
        {
            Driver driver = new Driver();
            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.GetAsync($"{shipmentDriverBseUrl}/driver/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                var dvm = await JsonSerializer.DeserializeAsync<DriverViewModel>(contentStream);
                driver = _mapper.Map<Driver>(dvm);
            }

            return driver;
        }

        public async Task<List<DriverViewModel>> GetDrivers()
        {
            List<DriverViewModel> driverResponse = new List<DriverViewModel>();
            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.GetAsync($"{shipmentDriverBseUrl}/driver/getAll");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                 driverResponse = await JsonSerializer.DeserializeAsync<List<DriverViewModel>>(contentStream);
                
            }

            return driverResponse;
        }

        public async Task UpdateDriver(Driver driver)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var shipmentString = new StringContent(
                    JsonSerializer.Serialize(driver),
                    Encoding.UTF8,
                    Application.Json);

            var httpResponseMessage = await httpClient.PutAsync($"{shipmentDriverBseUrl}/driver/{driver.Id}",
                shipmentString);
            httpResponseMessage.EnsureSuccessStatusCode();
        }
    }
}
