
using EFUpskilling.Entities;
using EFUpskilling.Repositories;
using EFUpskilling.Services;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        AppDbContext context = new();
        IRepository<Purchase> repository = new Repository<Purchase>(context);
        IRepository<Product> repositoryProduct = new Repository<Product>(context);
        IPersistence persistence = new DbPersistence(context);
        IProductService productService = new ProductService(repositoryProduct, persistence);
        IPurchaseService purchaseService = new PurchaseService(repository, persistence, productService);

        var purchase = new Purchase
        {
            TransDate = DateTime.Now,
            CustomerId = Guid.Parse("F7DF58F2-DD58-4465-8A1B-08DAF88CF1AB"),
            PurchaseDetails = new List<PurchaseDetail>
            {
                new() { ProductId = Guid.Parse("56D7C6AD-829B-4933-28A7-08DAF889757E"), Qty = 2, },
                new() { ProductId = Guid.Parse("54E89C47-32CC-4E8E-28A8-08DAF889757E"), Qty = 1, },
            }
        };
        
        purchaseService.CreateNewTransaction(purchase);

    }
}


/*/*
         * Microsoft.EntityFrameworkCore
         * Microsoft.EntityFrameworkCore.Tools
         * Microsoft.EntityFrameworkCore.SqlServer
         * Microsoft.EntityFrameworkCore.Design - Digunakan saat menggunakan Dependency Injection
         #1#

        /*
         * ChangeTracker - Entity
         * Added - Penanda saat di insert ke database tapi belum ter-insert
         * Detached - Entity jejaknya di copot
         * Unchanged
         * Modified
         * Deleted
         #1#
        
        using AppDbContext context = new();

        // where clause lambda - bisa mengambil lebih dari satu data

        var customer = context.Customers.FirstOrDefault(customer => customer.CustomerName.ToLower().Equals("andik".ToLower()));
        Console.WriteLine($"Customer: Id: {customer.Id}, Name: {customer.CustomerName}, " +
                          $"MobilePhone: {customer.MobilePhone}, Email: {customer.Email}");

        var customers = context.Customers.ToList();
        
        foreach (var c in customers)
        {
            Console.WriteLine($"Customer: Id: {c.Id}, Name: {c.CustomerName}, " +
                              $"MobilePhone: {c.MobilePhone}, Email: {c.Email}");
        }

        context.Customers.Remove(customer);
        context.SaveChanges();

        // context.Customers.Update(andik);
        // context.SaveChanges();

        // Create
        /*Customer newCustomer = new()
        {
            CustomerName = "Udin",
            Address = "Jl. H. Dahlan",
            MobilePhone = "081234567",
            Email = "udin@gmail.com"
        };
        context.Customers.Add(newCustomer);
        context.SaveChanges();#1#*/
        
           /*var purchase = context.Purchases
            // .Include(purchase => purchase.Customer)
            .Include("Customer")
            // .Include(p => p.PurchaseDetails)
            // .ThenInclude(pd => pd.Product)
            .Include("PurchaseDetails.Product")
            .FirstOrDefault(p => p.Id.Equals(Guid.Parse("269E9174-3BAC-4629-6E01-08DAF88B7767")));
        Console.WriteLine(purchase);*/

        // "SELECT * FROM t_purchase tp
        // JOIN m_customer mc ON = mc.id = t_purchase.customer_id
        // JOIN t_purchase_detail tpd ON tpd.purchase_id = tp.id
        // JOIN m_product mp ON mp.id = tpd.purchase_id"
        
        /*var transaction = context.Database.BeginTransaction();
        try
        {
            var purchase = new Purchase
            {
                TransDate = DateTime.Now,
                // CustomerId = Guid.Parse("D8057C98-B86A-4C6E-EFCF-08DAF7C8F5A7"),
                Customer = new Customer
                {
                    CustomerName = "Abdul",
                    Address = "Jl. Kancil",
                    MobilePhone = "0812313132",
                    Email = "abdul@gmail.com"
                },
                PurchaseDetails = new List<PurchaseDetail>
                {
                    new() { ProductId = Guid.Parse("56D7C6AD-829B-4933-28A7-08DAF889757E"), Qty = 2, },
                    new() { ProductId = Guid.Parse("54E89C47-32CC-4E8E-28A8-08DAF889757E"), Qty = 1, },
                }
            };
            context.Purchases.Add(purchase);
            context.SaveChanges();

            foreach (var purchaseDetail in purchase.PurchaseDetails)
            {
                var product = context.Products.FirstOrDefault(product => product.Id.Equals(purchaseDetail.ProductId));
                if (product != null) product.Stock -= purchaseDetail.Qty;
            }

            context.SaveChanges();
            
            transaction.Commit();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            transaction.Rollback();
            throw;
        }*/