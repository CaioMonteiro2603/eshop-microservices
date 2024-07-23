using Marten.Schema;

namespace Catalog.API.Data;

//applying a seed

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync())
        {
            return;
        }

        //marten upsert will cater for existing records

        session.Store<Product>(GetPreConfigureProducts()); 
        await session.SaveChangesAsync();
    }

    private static IEnumerable<Product> GetPreConfigureProducts() => new List<Product>()
    {
        new Product()
        {
                    Id = new Guid("d83f030c-12ef-4a85-bf45-2f2c3c492e9f"),
                    Name = "IPhone X",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-1.png",
                    Price = 950.00M,
                    Category = new List<string> {"Smart Phone" }
        },
        new Product()
        {
                    Id = new Guid("a2b8d5f0-c3f8-47d9-9627-0c0a15bde48a"),
                    Name = "IPhone X",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-1.png",
                    Price = 800.00M,
                    Category = new List<string> {"Smart Phone" }
        },
        new Product()
        {
                    Id = new Guid("12e4b78f-9a1c-467a-94b6-08c8ad3c6f99"),
                    Name = "IPhone X",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-1.png",
                    Price = 957.00M,
                    Category = new List<string> {"Smart Phone" }
        },
        new Product()
        {
                    Id = new Guid("f7d92208-4f2d-46e8-9cb1-02a8f1a7d50c"),
                    Name = "IPhone X",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-1.png",
                    Price = 960.00M,
                    Category = new List<string> {"Smart Phone" }
        },
        new Product()
        {
                    Id = new Guid("7cfbf123-d71f-495b-bc7e-b3f7e54a2e6d"),
                    Name = "IPhone X",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-1.png",
                    Price = 150.00M,
                    Category = new List<string> {"Smart Phone" }
        },
        new Product()
        {
                    Id = new Guid("583b57c5-e237-4c79-9a1f-d450a5c0e218"),
                    Name = "IPhone X",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-1.png",
                    Price = 870.00M,
                    Category = new List<string> {"Smart Phone" }
        },
        new Product()
        {
                    Id = new Guid("5e3190de-8c78-437d-88e1-9a746f8d4015"),
                    Name = "IPhone X",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-1.png",
                    Price = 550.00M,
                    Category = new List<string> {"Smart Phone" }
        },
    };
}
