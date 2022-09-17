namespace API.CoreSystem.Manager.Domain.DTO
{
    public class Person : DeletableEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
