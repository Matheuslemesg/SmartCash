namespace SmartCash.Models
{
    public class Categoria {
        public Categoria(string descricao){
            Descricao = descricao;
            // Vem aqui a new list de transacoes
        }

        public int Id { get; set; }
        public string Descricao { get; set; }

        // public ICollection<Transacao> Transacoes { get; set; }

    }
}
