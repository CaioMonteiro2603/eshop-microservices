namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductCommand(Guid Id, string Name, List<string> Category, string Description, string ImagemFile, decimal Price)
    : ICommand<UpdateProductResult>;

public record UpdateProductResult(bool IsSucess);

internal class UpdateProductCommandHandler(IDocumentSession session, ILogger<UpdateProductCommandHandler> logger) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("UpdateProductHandler.Handle called with {@Command}", command);

        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
        
        if(product is null)
        {
            throw new ProductNotFoundException(); 
        }

        product.Name = command.Name;
        product.Category = command.Category;
        product.Description = command.Description;  
        product.ImageFile = command.ImagemFile;
        product.Price = command.Price;

        session.Update(product);
        await session.SaveChangesAsync(cancellationToken);

        return new UpdateProductResult(true); 
    }
}

