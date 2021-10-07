namespace collection_control_api.Entities
{
    public class Client
    {
        public Client(string nome)
        {
            Nome = nome;
        }

        public int Id { get; set; }
        public string Nome { get; private set; }
    }
}