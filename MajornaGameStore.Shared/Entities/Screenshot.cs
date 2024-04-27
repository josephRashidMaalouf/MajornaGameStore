namespace MajornaGameStore.DataAccess.Entities;

public class Screenshot : EntityBase<int>
{
    public string Path { get; set; }
    public int ProductId { get; set; }
}