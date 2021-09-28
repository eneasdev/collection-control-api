using collection_control_api.Entities;
using collection_control_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Interfaces
{
    public interface IItemRepository
    {
        void AddItem(Item item);
    }
}
