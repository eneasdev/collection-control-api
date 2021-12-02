using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Models.InputModels.Dvd
{
    public class NewDvdInputModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleasedYear { get; set; }
        public string Staring { get; set; }
        public int Duration { get; set; }
    }
}
