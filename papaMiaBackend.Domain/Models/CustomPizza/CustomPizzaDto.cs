namespace papaMiaBackend.Domain.Models.CustomPizza;

public class CustomPizzaDto
{
    public int Id { get; set; }
    public int TotalPrice { get; set; }
    public List<int> IngridientIds { get; set; } = [];
}
