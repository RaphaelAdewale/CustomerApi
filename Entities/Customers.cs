namespace CustomerApi.Entities
{
    public record Customer
    {
        // creating the fields
        public Guid Id { get; init; } // primary key
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime Dob { get; init; }
        public string EmailAddress { get; init; }
    }   
}