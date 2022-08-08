using CustomerApi.Entities;

namespace CustomerApi.Repositories
{
    public interface ICustomersRepository
    {
        Customer GetCustomer(Guid id);
        IEnumerable<Customer> GetCustomers();
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer); 
        void DeleteCustomer(Guid id);
    }
}