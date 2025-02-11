namespace SmartCash.Models
{
    public class Transacao
    {
        public Transacao (int tipo, string descricao, double valor)
        {
            Tipo = tipo;
            Descricao = descricao;
            Valor = valor;
        }
        
        public int Id { get; set; }
        public int Tipo { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public long CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
