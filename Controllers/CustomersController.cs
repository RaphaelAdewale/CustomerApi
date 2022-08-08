using CustomerApi.Dtos;
using CustomerApi.Entities;
using CustomerApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersRepository repository;

        public CustomersController(ICustomersRepository repository)
        {
            this.repository = repository;
        }

        
        // GET /customers
        [HttpGet] 
        public IEnumerable<CustomerDto> GetCustomers()
        {
            var customers = repository.GetCustomers().Select(customer => customer.AsDto());
            return customers;
        }   

        // GET /customers/{id}
        [HttpGet("{id}")]
        public ActionResult<CustomerDto> GetCustomer(Guid id)
        {
            var customer = repository.GetCustomer(id);

            if (customer is null)
            {
                return NotFound();
            }

            return customer.AsDto();
        }

        // POST /customers/{id}
        [HttpPost]
        public ActionResult<CustomerDto> CreateCustomer(CreateCustomerDto customerDto)
        {
            Customer customer = new()
            {
                Id = Guid.NewGuid(),
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Dob = customerDto.Dob,
                EmailAddress = customerDto.EmailAddress
            };

            repository.CreateCustomer(customer);

            return CreatedAtAction(nameof(GetCustomer), new {id = customer.Id }, customer.AsDto());
        }

        // PUT /Customer/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(Guid id, UpdateCustomerDto customerDto)
        {
            var existingCustomer = repository.GetCustomer(id);
            if (existingCustomer is null)
            {
                return NotFound();
            }

            Customer updatedCustomer = existingCustomer with
            {
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Dob = customerDto.Dob,
                EmailAddress = customerDto.EmailAddress
            };

            repository.UpdateCustomer(updatedCustomer);

            return NoContent();

        }

        //DELETE /customers/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(Guid id)
        {
            var existingCustomer = repository.GetCustomer(id);
            
            if (existingCustomer is null)
            {
                return NotFound();
            }

            repository.DeleteCustomer(id);

            return NoContent();
        }
    }
}