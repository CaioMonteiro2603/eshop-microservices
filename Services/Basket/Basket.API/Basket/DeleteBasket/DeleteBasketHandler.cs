namespace Basket.API.Basket.DeleteBasket; 

public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>; 
public record DeleteBasketResult(bool IsSuccess);

public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketCommandValidator()
    {
        RuleFor(s => s.UserName).NotEmpty().WithMessage("UserName is required!"); 
    }
}
public class DeleteBasketHandler : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        //TODO: delete basket from db and cache
        //sesion.Delete<product>(command.ID)

        return new DeleteBasketResult(true); 
    }
}
