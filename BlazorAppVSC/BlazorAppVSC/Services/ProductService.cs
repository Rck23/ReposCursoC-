namespace BlazorAppVSC;

public class ProductService : IProductService
{
    private readonly HttpClient client;
    private readonly JsonSerializerOptions options;

    public ProductService(HttpClient http, JsonSerializerOptions optionsJson)
    {
        JsonSerializerOptions { PropertyNameCaseInsensitive = true};
        client = http;
    }

    public async Task<List<Category>?> Get()
    {
        var response = await _client.GetAsync("v1/products");

        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }

        return JsonSerializer.DeserializeAsync<List<Category>>(content, options);
    }

    public async Task Add(Product product)
    {
        var response = await client.PostAsync("v1/products", JsonContent.Create(product));

        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
    }

    public async Task Delete(int productId)
    {
        var response = await client.DeleteAsync($"v1/products/{productId}");

        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
    }

    public async Task<Product?> Get(int productId)
    {
        var response = await _client.GetAsync($"v1/products/{productId}");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode) throw new ApplicationException(content);
        return JsonSerializer.Deserialize<Product>(content, _serializer);
    }

public async Task Update(Product product)
    {
        var response = await _client.PutAsync($"v1/products/{product.Id}", JsonContent.Create(product));
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode) throw new ApplicationException(content);
    }
}


public interface IProductService
{ Task<List<Product>?> Get();
    Task<Product?> Get(int productId);
    Task Add(Product product);
    Task Update(Product product);
    Task Delete(int productId);

}