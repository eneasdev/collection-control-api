using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Entities
{
    public class Dvd : Item
    {
        public Dvd() { }
        public Dvd(string title, string staring, int duration)
        {
            Title = title;
            AddStaring(staring);
            AddDuration(duration);
        }
        public string Staring { get; private set; }
        public int Duration { get; private set; }

        public void AddStaring(string staring)
        {
            Staring = staring;
        }

        public void AddDuration(int duration)
        {
            Duration = duration;
        }
    }
}
