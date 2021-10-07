namespace collection_control_api.Entities
{
    public abstract class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public Loan Loan { get; set; }
    }
}
