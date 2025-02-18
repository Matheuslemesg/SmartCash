namespace SmartCash.DTOs
{
    public class TransacaoDTO 
    {
        public int Tipo { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
    }
}

//No DTO eu vou configurar o que eu quero que minha API receba, ao invés de sempre receber todos os campos. 
//Ex: ID eu não preciso receber pois vou deixar o meu Banco de Dados fazer o autoincremento.