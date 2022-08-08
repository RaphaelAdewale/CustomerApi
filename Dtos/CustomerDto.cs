namespace CustomerApi.Dtos
{
    public record CustomerDto
    {
        // creating the Data Transfer Object fields
        public Guid Id { get; init; } // primary key
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime Dob { get; init; }
        public string EmailAddress { get; init; }
    }   
}