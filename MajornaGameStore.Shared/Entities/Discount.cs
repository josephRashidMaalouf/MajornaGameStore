namespace MajornaGameStore.DataAccess.Entities;

public class Discount : EntityBase<int>
{
    public double DiscountPercentage { get; set; }
    public DateTime DiscountStart { get; set; }
    public DateTime DiscountEnd { get; set; }
    public virtual ICollection<Product>? Products { get; set; }
}