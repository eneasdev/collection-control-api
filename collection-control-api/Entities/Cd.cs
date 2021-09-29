namespace collection_control_api.Entities
{
    public class Cd : Item
    {
        public Cd(string title, string singer)
        {
            Title = title;
            AddSinger(singer);
        }

        public string Singer { get; private set; }
        public int SongsNumber { get; private set; }

        public void AddSinger(string name)
        {
            Singer = name;
        }
    }
}
