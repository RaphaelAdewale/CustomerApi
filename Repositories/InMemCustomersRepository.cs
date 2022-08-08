using System;
using System.Linq;
using CustomerApi.Entities;

namespace CustomerApi.Repositories
{
    public class InMemCustomersRepository : ICustomersRepository
    {
        private readonly List<Customer> customers = new()
        {
            new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = "Raphael",
                LastName = "Adewale",
                Dob = DateTime.Parse("1994-09-16"),
                EmailAddress = "raphael.adewale@stanbicibtc.com"
            },
            new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = "Chinyere",
                LastName = "Okoye",
                Dob = DateTime.Parse("1997-08-12"),
                EmailAddress = "chinyere.okoye@stanbicibtc.com"
            },
            new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = "Ngozi",
                LastName = "Ezenwa",
                Dob = DateTime.Parse("1998-10-11"),
                EmailAddress = "ngozi.ezenwa@stanbicibtc.com"
            },
            new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = "Ikechukwu",
                LastName = "Onyia",
                Dob = DateTime.Parse("1995-11-10"),
                EmailAddress = "ikechukwu.onyia@stanbicibtc.com"
            },
            new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = "Olisa",
                LastName = "Obi",
                Dob = DateTime.Parse("1992-02-05"),
                EmailAddress = "olisa.obi@stanbicibtc.com"
            }
        };

        public IEnumerable<Customer> GetCustomers()
        {
            return customers;
        }

        public Customer GetCustomer(Guid id)
        {
            return customers.Where(customer => customer.Id == id).SingleOrDefault();
        }

        public void CreateCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            var index = customers.FindIndex(existingCustomer => existingCustomer.Id == customer.Id);
            customers[index] = customer;
        }

        public void DeleteCustomer(Guid id)
        {
            var index = customers.FindIndex(existingCustomer => existingCustomer.Id == id);
            customers.RemoveAt(index);
        }
    }
}