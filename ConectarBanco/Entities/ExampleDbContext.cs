using Exemplo.Entities;
using Microsoft.EntityFrameworkCore;

namespace Example.Entities;

public class ExampleDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<EntityA> EntityAs { get; set; }
    public DbSet<EntityB> EntityAsB { get; set;}
    public DbSet<Usuario> Usuarios{ get; set; }

    protected override void OnModelCreating(ModelBuilder builder) { 

        // ? Configuração One-to-One
        // builder.Entity<EntityA>()
        //     .HasOne(e => e.EntityB) // A entidade A tem uma entidade B 
        //     .WithOne(e => e.EntityA) // Essa entidade B Tem uma entidade A
        //     .HasForeignKey<EntityB>() // O A que tem a posse do B
        //     .OnDelete(DeleteBehavior.Cascade);

        // ? Configuração N-to-One
        // builder.Entity<EntityA>()
        //     .HasMany(e => e.EntityBs) // A entidade A tem várias entidades B
        //     .WithOne(e => e.EntityA) // Essa entidade B Tem uma entidade A
        //     .HasForeignKey("EntityAId") // O A que tem a posse do B
        //     .OnDelete(DeleteBehavior.Cascade);

        // ? Configuração N-to-N
        builder.Entity<EntityA>()
            .HasMany(e => e.EntityBs) // A entidade A tem uma várias entidades B
            .WithMany(e => e.EntityAs); // Essa entidade B Tem várias entidades A

        builder.Entity<Usuario>()
            .HasMany(e => e.Seguidores)
            .WithMany(e => e.Seguido);
    }

    // Podemos mudar convenções. Convenções são padrões para alguns tipos e atributos de tabelas, como o ID. Qualquer dúvida, ver nas docs

    // protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    // {
    //     base.ConfigureConventions(configurationBuilder);
    // }
}