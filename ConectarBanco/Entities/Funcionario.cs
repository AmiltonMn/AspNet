namespace Exemplo.Entities;

public class Usuario
{
    // GUID é bom porque é praticamente impossível de repetir os valores, ele é calculado por microssegundos. Pode ter um chance de perder desempenho
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Name { get; set; }

    public ICollection<Usuario> Seguido { get; set;}
    public ICollection<Usuario> Seguidores { get; set;}
}

public class Seguindo 
{
    public Guid Id { get; set;} = Guid.NewGuid();

    public Guid SeguidoId { get; set; }
    public Usuario Seguido { get; set; }

    public Guid SeguidorId { get; set; }
    public Usuario Seguidor { get; set; }
}