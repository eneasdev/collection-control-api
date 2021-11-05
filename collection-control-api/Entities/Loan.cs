using System;
using System.Collections.Generic;

namespace collection_control_api.Entities
{
    public class Loan
    {
        public Loan() { }
        public Loan(int itemId, int clientId)
        {
            AddItem(itemId);
            AddClient(clientId);

            CreatedAt = DateTime.Now;
        }

        public int Id { get; set; }
        public int ItemId { get; private set; }
        public int ClientId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime FinishedAt { get; private set; }

        public void AddItem(int id)
        {
            ItemId = id;
        }

        public void AddClient(int id)
        {
            ClientId = id;
        }

        public void Finish()
        {
            FinishedAt = DateTime.Now;
        }
    }
}