using EFUpskilling.Entities;
using EFUpskilling.Repositories;

namespace EFUpskilling.Services;

public class PurchaseService : IPurchaseService
{
    private readonly IRepository<Purchase> _repository;
    private readonly IPersistence _persistence;
    private readonly IProductService _productService;

    public PurchaseService(IRepository<Purchase> repository, IPersistence persistence, IProductService productService)
    {
        _repository = repository;
        _persistence = persistence;
        _productService = productService;
    }

    public Purchase CreateNewTransaction(Purchase purchase)
    {
        _persistence.BeginTransaction();
        try
        {
            var newPurchase = _repository.Save(purchase);
            _persistence.SaveChanges();
            
            foreach (var purchaseDetail in newPurchase.PurchaseDetails)
            {
                var product = _productService.GetById(purchaseDetail.ProductId.ToString());
                product.Stock -= purchaseDetail.Qty;
            }
            _persistence.SaveChanges();
            
            _persistence.Commit();

            return newPurchase;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            _persistence.Rollback();
            throw;
        }
    }
}