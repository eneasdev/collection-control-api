using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Models.InputModels.Book
{
    public class UpdateBookInputModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
