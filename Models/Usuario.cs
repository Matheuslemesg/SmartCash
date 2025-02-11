namespace SmartCash.Models
{
    public class Usuario
    {
        public Usuario(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
