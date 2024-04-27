using System.ComponentModel.DataAnnotations;

namespace MajornaGameStore.DataAccess.Entities;

public class Review : EntityBase<int>
{
    public float Rating { get; set; }
    [Range(1.0, 5.0)]
    public string Comment { get; set; } = string.Empty;

    public string UserId { get; set; }
    public int ProductId { get; set; }
    
    
}