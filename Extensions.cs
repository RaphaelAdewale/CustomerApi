using CustomerApi.Dtos;
using CustomerApi.Entities;

namespace CustomerApi
{
    public static class Extensions
    {
        public static CustomerDto AsDto(this Customer customer)
        {
            return new CustomerDto{
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Dob = customer.Dob,
                EmailAddress = customer.EmailAddress
            };
        }
    }
}