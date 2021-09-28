using collection_control_api.Interfaces;
using collection_control_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Entities
{
    public class Cd : Item
    {
        private readonly IItemRepository _itemRepository;
        public Cd(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public Cd()
        {

        }
        public override void Create(NewItemInputModel itemInputModel)
        {
            var newCd = new Cd();
            newCd.AddName(itemInputModel.Name);
            newCd.AddDescription(itemInputModel.Description);
            _itemRepository.AddItem(newCd);
        }
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
