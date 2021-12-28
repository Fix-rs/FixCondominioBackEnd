namespace FixCondominioBackEnd.Models
{
    public class LancamentosModel
    {
        public int ID { get; set; }
        public string Descricao { get; set;} = string.Empty;
        public decimal Valor { get; set;}
        public Enum.EnumLancamento  Lancamento { get; set; }
        public DateTime DataAlteracao { get; set; }

    }
}
