using collection_control_api.Models;
using System;
using System.Collections.Generic;

namespace collection_control_api.Entities
{
    public abstract class Item
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Amount { get; private set; }
        public List<Lend> Lends { get; private set; }

        public virtual void AddName(string name)
        {
            Name = name;
        }

        public virtual void AddDescription(string description)
        {
            Description = description;
        }

        public virtual void AddAmount(int amount)
        {
            Amount = amount;
        }

        public virtual void Lend(NewLendInputModel lendInputModel)
        {
            if (lendInputModel == null) Lends = new List<Lend>();

            Lends.Add(new Lend(lendInputModel));
        }

    }
}
