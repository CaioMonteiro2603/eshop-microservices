namespace Ordering.Infrastructure.Data.Extensionss
{
    internal class InitialData
    {
        public static IEnumerable<Customer> Customers =>
            new List<Customer>
            {
                Customer.Create(CustomerId.Of(new Guid("a8f5f167-ecf8-4b3b-a6d7-42b7a3b8b405")), "Caio", "cadumontpro@gmail.com"),
                Customer.Create(CustomerId.Of(new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479")), "Loren", "lorenitu@gmail.com")
            };

        public static IEnumerable<Product> Products =>
            new List<Product>
            {
                Product.Create(ProductId.Of(new Guid("d9a8f2a3-5f7b-4b22-86e7-1234567890ab")),"Iphone 15", 500),
                Product.Create(ProductId.Of(new Guid("fe7c4b29-89d4-47c3-945a-abcdef123456")),"Iphone 14", 300),
                Product.Create(ProductId.Of(new Guid("bcd8e9f5-6b1d-4789-a23c-fedcba987654")),"Samsung 10", 400),
                Product.Create(ProductId.Of(new Guid("123e4567-e89b-12d3-a456-426614174000")),"Moto G", 100)
            };

        public static IEnumerable<Order> OrdersWithItems
        {
            get
            {
                var address1 = Address.Of("Mario", "Lorivan", "lorivan@gmail.com", "Centenario", "Brazil", "São Paulo", "12345");
                var address2 = Address.Of("Lourdes", "Maran", "lourdes@gmail.com", "Centenario", "Brazil", "São Paulo", "54256");

                var payment1 = Payment.Of("Caio", "5555555555554444", "18/25", "452", 1);
                var paymen2 = Payment.Of("Lucas", "5555555555554433", "18/24", "401", 2);

                var order1 = Order.Create(
                    OrderId.Of(Guid.NewGuid()),
                    CustomerId.Of(new Guid("a8f5f167-ecf8-4b3b-a6d7-42b7a3b8b405")),
                    OrderName.Of("ORD_1"),
                    shippingAddress: address1,
                    billingAddress: address1, 
                    payment1);

                order1.Add(ProductId.Of(new Guid("d9a8f2a3-5f7b-4b22-86e7-1234567890ab")), 2, 500);
                order1.Add(ProductId.Of(new Guid("123e4567-e89b-12d3-a456-426614174000")), 5, 100);

                var order2 = Order.Create(
                    OrderId.Of(Guid.NewGuid()),
                    CustomerId.Of(new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479")),
                    OrderName.Of("ORD_2"),
                    shippingAddress: address2,
                    billingAddress: address2,
                    paymen2);

                order2.Add(ProductId.Of(new Guid("fe7c4b29-89d4-47c3-945a-abcdef123456")), 4, 300);
                order2.Add(ProductId.Of(new Guid("bcd8e9f5-6b1d-4789-a23c-fedcba987654")), 1, 400);

                return new List<Order> { order1, order2 };

            }
        }
    }

}
