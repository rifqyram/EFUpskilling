using EFUpskilling.Entities;

namespace EFUpskilling.Services;

public interface ICustomerService
{
    Customer CreateNewCustomer(Customer customer);
    Customer GetById(string id);
}