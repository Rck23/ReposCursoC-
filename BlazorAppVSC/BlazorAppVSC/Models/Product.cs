namespace BlazorAppVSC; 

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public decimal? Price { get; set; }
    public string Description { get; set; } = "";
    public int CategoryId { get; set; }
    public Category Category { get; set; } = new Category();
    public string[] Images { get; set; } = new string[0];
    public string Image { get; set; } = "";
}