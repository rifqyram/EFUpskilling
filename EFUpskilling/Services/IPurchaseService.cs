using EFUpskilling.Entities;

namespace EFUpskilling.Services;

public interface IPurchaseService
{
    Purchase CreateNewTransaction(Purchase purchase);
}