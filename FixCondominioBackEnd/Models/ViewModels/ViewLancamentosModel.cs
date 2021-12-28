namespace FixCondominioBackEnd.Models.ViewModels
{
    public class ViewLancamentosModel
    {
        public long ID { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public Enum.EnumLancamento Lancamento { get; set; }

        public static implicit operator ViewLancamentosModel(LancamentosModel lancamentosModel)
        {
            return new ViewLancamentosModel()
            {
                ID = lancamentosModel.ID,
                Descricao = lancamentosModel.Descricao,
                Valor = lancamentosModel.Valor,
                Lancamento = lancamentosModel.Lancamento
            };
        }
    }
}
