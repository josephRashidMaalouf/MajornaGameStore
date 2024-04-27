using System.Text.Json.Serialization;

namespace MajornaGameStore.DataAccess.Entities;

public class Tag : EntityBase<int>
{
    public string Name { get; set; }

    [JsonIgnore]
    public virtual ICollection<Product> Products { get; set; }

}