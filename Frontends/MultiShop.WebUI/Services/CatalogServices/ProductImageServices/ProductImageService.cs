using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;
using System.Text.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly HttpClient _httpClient;
        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductImageDto>("productimages", createProductImageDto);
        }
        public async Task DeleteProductImageAsync(string id)
        {
            await _httpClient.DeleteAsync("productimages?id=" + id);
        }
        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productimages/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
            return values;
        }
        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var responseMessage = await _httpClient.GetAsync("productimages");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductImageDto>>(jsonData);
            return values;
        }
        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductImageDto>("productimages", updateProductImageDto);
        }

        public async Task<GetByIdProductImageDto> GetByProductIdProductImageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"productimages/ProductImagesByProductId/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine("API Response: " + responseContent); // Yanıtı kontrol etme

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                try
                {
                    var values = System.Text.Json.JsonSerializer.Deserialize<GetByIdProductImageDto>(responseContent, options);
                    return values;
                }
                catch (System.Text.Json.JsonException ex)
                {
                    Console.WriteLine($"JSON deserialization error: {ex.Message}");
                    return null;
                }
            }
            else
            {
                Console.WriteLine($"API Error: {responseMessage.StatusCode}");
                return null;
            }
        }
    }
}
