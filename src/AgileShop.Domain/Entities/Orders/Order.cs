using AgileShop.Domain.Enums;

namespace AgileShop.Domain.Entities.Orders;

public class Order : Auditable
{
    public long UserId { get; set; }
    public long DeliverId { get; set; }
    public OrderStatus Status { get; set; }

    // The summ of order details result prices 
    // The money which that user must pay for products
    public double ProductsPrice { get; set; }
    public double DeliveryPrice { get; set; }
    
    // The Payment that user must pay for sale
    // Products price + Deliver price
    public double ResultPrice { get; set; }

    public double Lattitude { get; set; }
    public double Longitude { get; set; }

    public PaymentType Payment { get; set; }
    public bool IsPaid { get; set; }
    public bool IsContracted { get; set; }
    public string Description { get; set; } = String.Empty;
}
