namespace CategoryService;



public class CategoryService: ICategoryService
{
    private readonly HttpClient _client;

    private readonly JsonSerializerOptions options; 

    public CategoryService(HttpClient client)
    {
        _client = client; 
        options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};   
    }

    public async Task<List<Category>?> Get(){
        var response = await _client.GetAsync("v1/categories");

        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content); 
        }

        return JsonSerializer.DeserializeAsync<List<Category>>(content, options);
    }
}


public interface ICategoryService{
    Task<List<Category>?> Get();
}