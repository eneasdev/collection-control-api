using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Models.InputModels
{
    public class NewBookInputModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleasedYear { get; set; }
        public string Author { get; set; }
    }
}
