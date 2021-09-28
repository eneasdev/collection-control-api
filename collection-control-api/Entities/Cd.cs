using collection_control_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Entities
{
    public class Cd : Item
    {
        

        public override void AddName(string name)
        {
            base.AddName(name);
        }

        public override void AddDescription(string description)
        {
            base.AddDescription(description);
        }

        public override void AddAmount(int amount)
        {
            base.AddAmount(amount);
        }

        public override void Lend(NewLendInputModel lendInputModel)
        {
            base.Lend(lendInputModel);
        }
    }
}
