namespace collection_control_api.Entities
{
    public class Cd : Item
    {
        public Cd() { }
        public Cd(string title, string singer)
        {
            Title = title;
            Singer = singer;

            ItemType = Type.Cd;
        }

        public string Singer { get; private set; }
        public int SongsNumber { get; private set; }
    }
}
