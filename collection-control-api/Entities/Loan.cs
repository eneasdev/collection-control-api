using System;
using System.Collections.Generic;

namespace collection_control_api.Entities
{
    public class Loan
    {
        public Loan() { }
        public Loan(List<Item> item, Client client)
        {
            Item = item;
            Client = client;

            CreatedAt = DateTime.Now;
        }

        public int Id { get; set; }
        public List<Item> Item { get; private set; }
        public Client Client { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime FinishedAt { get; private set; }

    }
}