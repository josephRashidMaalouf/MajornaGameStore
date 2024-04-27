using System.Formats.Asn1;

namespace MajornaGameStore.DataAccess.Entities;

public class Product : EntityBase<int>
{
    public string Name { get; set; }
    public double  Price { get; set; }
    public int ProductTypeId { get; set; }
    public int DiscountId { get; set; } = 1;
    public string Description { get; set; }
    public string Languages { get; set; }
    public string ImageLink { get; set; }
    public string PcRequirements { get; set; }
    public DateTime ReleaseDate { get; set; }
    public virtual ICollection<Developer> Developers { get; set; }
    public ICollection<Publisher> Publishers { get; set; }
    public ICollection<Screenshot> Screenshots { get; set; }
    public ICollection<Tag> Tags { get; set; }
    public ICollection<Review> Reviews { get; set; }

    public int AgeRating { get; set; }
}