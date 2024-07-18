using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category, string Description, string ImagemFile, decimal Price) 
    : ICommand<CreateProductResult>; 
public record CreateProductResult(Guid id);
internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
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

        // return CreateProuctResult result 

        return new CreateProductResult(Guid.NewGuid());

        throw new NotImplementedException();
    }
}
