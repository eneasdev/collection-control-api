using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace collection_control_api.Entities
{
    public abstract class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleasedYear { get; set; }
    }
}
