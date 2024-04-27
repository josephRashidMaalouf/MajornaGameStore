using MajornaGameStore.DataAccess.Entities;

namespace MajornaGameStore.Shared.Models;

public class ProductModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public ProductType ProductType { get; set; } = new();
    public Discount Discount { get; set; } = new();
    public string Description { get; set; } = string.Empty;
    public string Languages { get; set; } = string.Empty;

    public string ImageLink { get; set; } =
        "https://static.vecteezy.com/system/resources/previews/005/337/799/non_2x/icon-image-not-found-free-vector.jpg";
    public string PcRequirements { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; } = DateTime.Now;
    public virtual ICollection<Developer> Developers { get; set; } = new List<Developer>();
    public ICollection<Publisher> Publishers { get; set; } = new List<Publisher>();
    public ICollection<Screenshot> Screenshots { get; set; } = new List<Screenshot>();
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();

    public int AgeRating { get; set; }
}