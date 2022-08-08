using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Dtos
{
    public record UpdateCustomerDto
    {
        // fields that will be created by the POST action
        [Required]
        public string FirstName { get; init; }
        [Required]
        public string LastName { get; init; }
        [Required]
        public DateTime Dob { get; init; }
        [Required]
        public string EmailAddress { get; init; }
    }
}