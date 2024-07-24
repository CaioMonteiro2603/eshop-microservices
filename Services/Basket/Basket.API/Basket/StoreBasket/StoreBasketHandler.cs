namespace Basket.API.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;

public record StoreBasketResult(string UserName); 

public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(s => s.Cart).NotNull().WithMessage("Cart cannot be null!");
        RuleFor(s => s.Cart.UserName).NotNull().WithMessage("UserName is required!");
    }
}

public class StoreBasketCommandHandler : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        ShoppingCart cart = command.Cart;

        //TODO: store basket in db (use marten upsert - if exist = update, if not = insert)
        //TODO: update cache

        return new StoreBasketResult("swn"); 
    }
}
