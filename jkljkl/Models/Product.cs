public class Product
{
    public int Id { get; set; }

    // Non-nullable property
    public string Name { get; set; } = ""; // or another default value

    public decimal Price { get; set; }
}