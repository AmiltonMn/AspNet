using Example.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddDbContext<ExampleDbContext>(options => {

    // ? Banco de dados in memory apenas para testes. Trevis usou porque não ta com SQLServer no pc dele.
    // options.UseInMemoryDatabase("my-inmemory-database");

    var connBuilder = new SqlConnectionStringBuilder {
        TrustServerCertificate = true,
        IntegratedSecurity = true,
        DataSource = "localhost",
        InitialCatalog = "MyExampleDatabase",
    };

    options.UseSqlServer(connBuilder.ConnectionString);
});

var provider = services.BuildServiceProvider();

var scope = provider.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<ExampleDbContext>();
context.Database.EnsureCreated();

var obj1 = new EntityA {
    Name = "Aninha",
    CreationDate = DateTime.Now
};

var obj2 = new EntityA {
    Name = "Juninho",
    CreationDate = DateTime.Now
};

var obj3 = new EntityB {
    Name = "Machado",
    CreationDate = DateTime.Now
};

var obj4 = new EntityB {
    Name = "Martelo",
    CreationDate = DateTime.Now
};

obj1.EntityBs.Add(obj3);
obj1.EntityBs.Add(obj4);
obj2.EntityBs.Add(obj4);

context.Add(obj1);
context.Add(obj2);
context.Add(obj3);
context.Add(obj4);
context.SaveChanges();

await context.SaveChangesAsync();

// ? Sem o Include, ele vai mostrar apenas os que foram adicionados recentemente, porque ja foram "Trackeados" pelo framework. para aparecer todos os dados, usar include
foreach (var item in context.EntityAs) {
    Console.WriteLine($"{item.Name} tem:");
    foreach (var tool in item.EntityBs)
        Console.WriteLine($"\t{tool.Name}");
}


// foreach (var item in context.EntityAs)
//     Console.WriteLine(item.Name);

// context.Remove(obj);

// foreach (var item in context.EntityAs)
//     Console.WriteLine(item.Name);

// ? Esse código está fazendo diretamente uma query no nosso banco de dados. Já é tratado o SQLInjection

// var items = context.EntityAs
//     .Where(x => x.Name == "Juninho")
//     .Select(x => x.Id);

// * Ou

// var itemsQuery = 
//     from x in context.EntityAs
//     where x.Name == "Juninho"
//     select x.Id;

