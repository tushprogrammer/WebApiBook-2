namespace WebApIBook_2
{
    public class Person : IPerson
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public Person(int id, string name, string lastName, string middleName, string phoneNumber, string address, string description)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            MiddleName = middleName;
            PhoneNumber = phoneNumber;
            Address = address;
            Description = description;
        }

        public Person() { }
    }
}
