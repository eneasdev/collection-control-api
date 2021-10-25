using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Entities
{
    [Table("dvds")]
    public class Dvd : Item
    {
        public Dvd() { }
        public Dvd(string title, string staring)
        {
            Title = title;
            Staring = staring;
        }
        public string Staring { get; private set; }
        public int Duration { get; private set; }

    }
}
