namespace API.CoreSystem.Manager.Domain.Entities
{
    public class Person : DeletableEntity
    {
        public Person(string? name, string? lastName, string? nationality, string? zipCode, string? state, string? city, string? address, string? email, string? phone, string? federalId)
        {
            Name = name;
            LastName = lastName;
            Nationality = nationality;
            ZipCode = zipCode;
            State = state;
            City = city;
            Address = address;
            Email = email;
            Phone = phone;
            FederalId = federalId;
        }

        public Person()
        {

        }

        public string? Name { get; private set; }
        public string? LastName { get; private set; }
        public string? Nationality { get; private set; }
        public string? ZipCode { get; private set; }
        public string? State { get; private set; }
        public string? City { get; private set; }
        public string? Address { get; private set; }
        public string? Email { get; private set; }
        public string? Phone { get; private set; }
        public string? FederalId { get; private set; }
    }
}
