namespace Example.Entities;

public class EntityA
{
    public int Id { get; set; }
    public required string? Name { get; set; }
    public DateTime? CreationDate { get; set; }

    // N-to-One
    // public ICollection<EntityB> EntityBs { get; set; } = [];

    public ICollection<EntityB> EntityBs { get; set; } = [];
}