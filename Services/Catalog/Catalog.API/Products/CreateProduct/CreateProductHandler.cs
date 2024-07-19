namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category, string Description, string ImagemFile, decimal Price) 
    : ICommand<CreateProductResult>; 
public record CreateProductResult(Guid Id);
internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        // create Product entity from command object

        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImagemFile,
            Price = command.Price,
        };

        // save the database
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        // return CreateProuctResult result 

        return new CreateProductResult(product.Id); 
    }
}
