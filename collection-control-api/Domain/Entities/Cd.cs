using System.ComponentModel.DataAnnotations.Schema;

namespace collection_control_api.Entities
{
    public class Cd : Item
    {
        public Cd() { }
        public Cd(string title, string singer, int songsNumber)
        {
            Title = title;
            AddSinger(singer);
            AddSongsNumber(songsNumber);
        }

        public string Singer { get; private set; }
        public int SongsNumber { get; private set; }

        public void AddSinger(string singer)
        {
            Singer = singer;
        }

        public void AddSongsNumber(int songsNumber)
        {
            SongsNumber = songsNumber;
        }
    }
}
