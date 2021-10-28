using System.Collections.Generic;

namespace collection_control_api.Entities
{
    public class Client
    {
        public Client() { }
        public Client(string name)
        {
            AddName(name);
        }

        public int Id { get; set; }
        public string Name { get; private set; }
        public List<Loan> Loan { get; private set; }

        public void AddName(string name)
        {
            Name = name;
        }
    }
}