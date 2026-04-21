namespace papaMiaBackend.Domain.Models.Banner;
public class BannerDto
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public int Sort { get; set; } = 0;
}
