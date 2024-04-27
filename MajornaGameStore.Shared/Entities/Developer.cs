using System.Text.Json.Serialization;

namespace MajornaGameStore.DataAccess.Entities;

public class Developer : EntityBase<int>
{
    public string Name { get; set; }
    [JsonIgnore]
    public virtual ICollection<Product> Products { get; set; }

}