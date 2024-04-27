using MajornaGameStore.DataAccess.Entities;

namespace MajornaGameStore.Shared.Dtos;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int ProductTypeId { get; set; }
    public int DiscountId { get; set; } = 1;
    public string Description { get; set; }
    public string Languages { get; set; }
    public string ImageLink { get; set; }
    public string PcRequirements { get; set; }
    public DateTime ReleaseDate { get; set; }
    public ICollection<int> DeveloperIds { get; set; }
    public ICollection<int> PublisherIds { get; set; }
    public ICollection<int> ScreenshotIds { get; set; }
    public ICollection<int> TagIds { get; set; }
    public ICollection<int> ReviewIds { get; set; }

    public int AgeRating { get; set; }
}