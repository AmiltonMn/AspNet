namespace Server.Source.Entities.Orders;

public class FinalOrder
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public required ApplicationUser Client { get; set; }

    public required string DeliveryAddress { get; set; }

    public required ICollection<Order> Orders { get; set; }

    public required float Value { get; set; }
}