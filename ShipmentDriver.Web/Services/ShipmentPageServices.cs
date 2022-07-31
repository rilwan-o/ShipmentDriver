using ShipmentDriver.Web.Contracts;
using ShipmentDriver.Web.Models;
using ShipmentDriver.Web.Dtos;
using System.Text.Json;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using ShipmentDriver.Web.ViewModels;
using AutoMapper;

namespace ShipmentDriver.Web.Services
{

    public class ShipmentPageServices : IShipmentPageServices
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string shipmentDriverBseUrl;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public ShipmentPageServices(IHttpClientFactory httpClientFactory, IConfiguration configuration, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            shipmentDriverBseUrl = _configuration["ShipmentDriverBaseUrl"];
            _mapper = mapper;   
        }
        
        public async Task<Shipment> CreateShipment(ShipmentDto shipmentDto)
        {
            Shipment shipment = new Shipment();
            var httpClient = _httpClientFactory.CreateClient();
            var shipmentString = new StringContent(
                    JsonSerializer.Serialize(shipmentDto),
                    Encoding.UTF8,
                    Application.Json); 

            var httpResponseMessage =await httpClient.PostAsync($"{shipmentDriverBseUrl}/shipment", 
                shipmentString);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

                var shipmentRM = await JsonSerializer.DeserializeAsync<ShipmentResponseModel>(contentStream);
                shipment = _mapper.Map<Shipment>(shipmentRM);

            }

            return shipment;
        }

        public async Task DeleteShipment(string id)
        {
            var httpClient = _httpClientFactory.CreateClient();
            using var httpResponseMessage = await httpClient.DeleteAsync($"{shipmentDriverBseUrl}/shipment/{id}");
            httpResponseMessage.EnsureSuccessStatusCode();
        }
      
        public async Task<Shipment> GetShipment(string id)
        {
            Shipment shipment = new Shipment();
            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.GetAsync($"{shipmentDriverBseUrl}/shipment/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                var shipmentRM = await JsonSerializer.DeserializeAsync<ShipmentResponseModel>(contentStream);
                 shipment = _mapper.Map<Shipment>(shipmentRM);

            }

            return shipment;
        }

        public async Task<List<Shipment>> GetShipments()
        {
            List<Shipment> shipments = new List<Shipment>();
            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.GetAsync($"{shipmentDriverBseUrl}/shipment/getAll");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                var  shipmentResponse = await JsonSerializer.DeserializeAsync<List<ShipmentResponseModel>>(contentStream);
                foreach (var resp in shipmentResponse)
                {
                    var shipment = _mapper.Map<Shipment>(resp);
                    shipments.Add(shipment);
                }
            }

            return shipments;
        }

        public async Task UpdateShipment(Shipment shipment)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var shipmentString = new StringContent(
                    JsonSerializer.Serialize(shipment),
                    Encoding.UTF8,
                    Application.Json);

            var httpResponseMessage = await httpClient.PutAsync($"{shipmentDriverBseUrl}/shipment/{shipment.Id}",
                shipmentString);
            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public async Task<ShipmentStatusUpdateViewModel> PickUp(string ShipmentId, string DriverId)
        {
            ShipmentStatusUpdateViewModel svm = new ShipmentStatusUpdateViewModel();
            var httpClient = _httpClientFactory.CreateClient();
            var shipmentString = new StringContent(
                    JsonSerializer.Serialize(new { ShipmentId , DriverId }),
                    Encoding.UTF8,
                    Application.Json);

            var httpResponseMessage = await httpClient.PostAsync($"{shipmentDriverBseUrl}/shipment/pickup",
                shipmentString);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

                svm = await JsonSerializer.DeserializeAsync<ShipmentStatusUpdateViewModel>(contentStream);
            }

            return svm;
        }

        public async Task<ShipmentStatusUpdateViewModel> Returned(string ShipmentId, string DriverId)
        {
            ShipmentStatusUpdateViewModel svm = new ShipmentStatusUpdateViewModel();
            var httpClient = _httpClientFactory.CreateClient();
            var shipmentString = new StringContent(
                    JsonSerializer.Serialize(new { ShipmentId, DriverId }),
                    Encoding.UTF8,
                    Application.Json);

            var httpResponseMessage = await httpClient.PostAsync($"{shipmentDriverBseUrl}/shipment/return",
                shipmentString);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

                svm = await JsonSerializer.DeserializeAsync<ShipmentStatusUpdateViewModel>(contentStream);
            }

            return svm;
        }
        public async Task<ShipmentStatusUpdateViewModel> Delivered(string ShipmentId, string DriverId)
        {
            ShipmentStatusUpdateViewModel svm = new ShipmentStatusUpdateViewModel();
            var httpClient = _httpClientFactory.CreateClient();
            var shipmentString = new StringContent(
                    JsonSerializer.Serialize(new { ShipmentId, DriverId }),
                    Encoding.UTF8,
                    Application.Json);

            var httpResponseMessage = await httpClient.PostAsync($"{shipmentDriverBseUrl}/shipment/delivered",
                shipmentString);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

                svm = await JsonSerializer.DeserializeAsync<ShipmentStatusUpdateViewModel>(contentStream);
            }

            return svm;
        }

        
    }
}
