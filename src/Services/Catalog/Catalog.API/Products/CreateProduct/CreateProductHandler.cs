
namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name,  List<string> Category, string Description, decimal Price, string ImageFile) 
        : ICommand<CreateProductResult>;
   
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler(IDocumentSession session) 
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = command.Name,
                Description = command.Description,
                Price = command.Price,
                Category = command.Category,
                ImageFile = command.ImageFile
            };

            // save to database
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            return new CreateProductResult(product.Id);
        }
    }
}
