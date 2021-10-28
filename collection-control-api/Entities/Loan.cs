using System;
using System.Collections.Generic;

namespace collection_control_api.Entities
{
    public class Loan
    {
        public Loan() { }
        public Loan(Item item, Client client)
        {
            AddItem(item);
            AddClient(client);

            CreatedAt = DateTime.Now;
        }

        public int Id { get; set; }
        public List<Item> Item { get; private set; }
        public Client Client { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime FinishedAt { get; private set; }

        public void AddItem(Item item)
        {
            Item.Add(item);
        }

        public void AddClient(Client client)
        {
            Client = client;
        }

        public void Finish()
        {
            FinishedAt = DateTime.Now;
        }
    }
}