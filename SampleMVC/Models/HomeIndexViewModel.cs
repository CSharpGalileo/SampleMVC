using AdventureWorksNS.Data;

namespace SampleMVC.Models
{
    public record HomeIndexViewModel
    (
        int VisitorCount,
        IList<ProductCategory> Categories,
        IList<Product> Products
    );
}
