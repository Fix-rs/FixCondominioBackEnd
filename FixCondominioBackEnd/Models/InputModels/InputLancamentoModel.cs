namespace FixCondominioBackEnd.Models.InputModels
{
    public class InputLancamentoModel
    {
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public Enum.EnumLancamento Lancamento { get; set; }

        public static implicit operator InputLancamentoModel(LancamentosModel lancamentosModel)
        {
            return new InputLancamentoModel()
            {
                Descricao = lancamentosModel.Descricao,
                Valor = lancamentosModel.Valor,
                Lancamento = lancamentosModel.Lancamento
            };
        }
    }
}
