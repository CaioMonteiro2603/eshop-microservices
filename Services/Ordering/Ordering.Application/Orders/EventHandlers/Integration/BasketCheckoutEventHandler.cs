using BuildingBlocks.Messaging.Events;
using MassTransit;
using Ordering.Application.Orders.Commands.CreateOrder;

namespace Ordering.Application.Orders.EventHandlers.Integration;

public class BasketCheckoutEventHandler(ISender sender, ILogger<BasketCheckoutEventHandler> logger)
    : IConsumer<BasketCheckoutEvent>
{
    //this methods will be provide to loggin incoming events
    public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
    {
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name); 

        var command = MapToCreateOrderCommand(context.Message);
        await sender.Send(command); 
    }

    private CreateOrderCommand MapToCreateOrderCommand(BasketCheckoutEvent message)
    {
        //Create full order withg incoming event data 
        var addressDto = new AddressDto(message.FirstName, message.LastName, message.EmailAddress,
            message.AddressLine, message.Country, message.State, message.ZipCode);
        var paymentDto = new PaymentDto(message.CardName, message.CardNumber, message.Expiration, message.CVV, message.PaymentMethod);
        var orderId = Guid.NewGuid();

        var orderDto = new OrderDto(
            Id: orderId,
            CustomerId: message.CustomerId,
            OrderName: message.UserName,
            ShippingAddress: addressDto,
            BillingAddress: addressDto,
            Payment: paymentDto,
            Status: OrderStatus.Pending,
            OrderItems:
            [
                 new OrderItemDto(orderId, new Guid("b2f735c7-3c5e-45e1-9bc4-cb9e2b19e2f4"), 2, 150),
                 new OrderItemDto(orderId , new Guid("c3a12c6e-8470-4ae4-b8b5-4b0c67c4855b"), 3, 200)
            ]); 
        
        return new CreateOrderCommand(orderDto);
    }
}
