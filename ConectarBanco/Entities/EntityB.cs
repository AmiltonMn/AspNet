namespace Example.Entities;

public class EntityB
{
    // ? Aqui já é definido que é uma primary key, usando Conventions. Da pra estudar sobre isso na documentação
    public int Id { get; set; }
    public required string? Name { get; set; }
    public DateTime? CreationDate { get; set; }

    // ? N-to-One
    // public EntityA? EntityA { get; set; }

    public ICollection<EntityA> EntityAs { get; set; } = [];
}