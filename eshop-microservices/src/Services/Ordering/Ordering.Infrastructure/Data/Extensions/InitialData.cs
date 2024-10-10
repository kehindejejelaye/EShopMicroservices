namespace Ordering.Infrastructure.Data.Extensions;
public class InitialData
{
    public static IEnumerable<Customer> Customers => new List<Customer>
    {
        Customer.Create(CustomerId.Of(new Guid("154EF8B9-68F5-4F90-AA05-2844FABEC48C")), "Mehmet", "mehmet@gmail.com"),
        Customer.Create(CustomerId.Of(new Guid("E6BA772A-C7DD-4B31-B077-7D9281F951D7")), "John", "john@gmail.com")
    };

    public static IEnumerable<Product> Products => new List<Product>
    {
        Product.Create(ProductId.Of(new Guid("69CB6234-8DA0-4194-980B-616B96AE15B1")), "IPhone X", 500),
        Product.Create(ProductId.Of(new Guid("9A51E6E4-5EA6-42ED-9E3F-5D9B18AAF3C3")), "Samsung 10", 400),
        Product.Create(ProductId.Of(new Guid("C296B390-955B-491C-874D-5B18FB5E6D9E")), "Huawei Plus", 650),
        Product.Create(ProductId.Of(new Guid("DFA8A983-BB82-4C1F-A116-55CEB9BA94C1")), "Xiaomi Mi", 450)
    };

    public static IEnumerable<Order> OrdersWithItems
    {
        get
        {
            var address1 = Address.Of("Mehmet", "Ozkaya", "mehmet@gmail.com", "Bahcelievler No 4", "Turkey", "Istanbul", "38050");
            var address2 = Address.Of("JOhn", "Doe", "john@gmail.com", "Broadway No 1", "England", "Nottingham", "08050");

            var payment1 = Payment.Of("Mehmet", "555-555-5555", "12/28", "355", 1);
            var payment2 = Payment.Of("John", "222-555-2323", "06/30", "222", 2);

            var order1 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("154EF8B9-68F5-4F90-AA05-2844FABEC48C")),
                OrderName.Of("Order 1"),
                shippingAddress: address1,
                billingAddress: address1,
                payment1);
            order1.Add(ProductId.Of(new Guid("69CB6234-8DA0-4194-980B-616B96AE15B1")), 2, 500);
            order1.Add(ProductId.Of(new Guid("9A51E6E4-5EA6-42ED-9E3F-5D9B18AAF3C3")), 1, 400);

            var order2 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("E6BA772A-C7DD-4B31-B077-7D9281F951D7")),
                OrderName.Of("Order 2"),
                shippingAddress: address2,
                billingAddress: address2,
                payment2);
            order2.Add(ProductId.Of(new Guid("C296B390-955B-491C-874D-5B18FB5E6D9E")), 1, 650);
            order2.Add(ProductId.Of(new Guid("DFA8A983-BB82-4C1F-A116-55CEB9BA94C1")), 2, 450);

            return new List<Order> { order1, order2 };
        }
    }
}
