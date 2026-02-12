
namespace Catalog.API.Products.GetProductByCategory
{
    // public record GetProductByCategoryRequest(string Category);
    public record GetProductByCategoryResponse(IEnumerable<Product> product);
    public class GetProoductByCatgoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}",
                async (string category, ISender sender) =>
                {
                    var result = await sender.Send(new GetProductByCategoryQuery(category));
                    var response = result.Adapt<GetProductByCategoryResponse>();
                    return Results.Ok(response);
                })
                .WithName("GetProductByCategory")
                .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
                .WithSummary("Get Product By Category")
                .WithDescription("Get Product By Category");
        }
    }   
}
