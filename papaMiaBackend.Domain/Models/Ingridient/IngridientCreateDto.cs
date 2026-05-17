using papaMiaBackend.Domain.Entities.Ingridient;

namespace papaMiaBackend.Domain.Models.Ingridient;

public class IngridientCreateDto
{
    public string Name { get; set; } = string.Empty;
    public IngridientType Type { get; set; }
}
