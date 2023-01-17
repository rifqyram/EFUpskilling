using EFUpskilling.Entities;

namespace EFUpskilling.Services;

public interface IProductService
{
    Product CreateNewProduct(Product product);
    Product GetById(string id);
}