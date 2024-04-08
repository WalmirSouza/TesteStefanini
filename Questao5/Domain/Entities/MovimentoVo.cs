namespace Questao5.Domain.Entities
{
	public class MovimentoVo
	{
		public String IdMovimento { get; }
		public String IdContaCorrente { get; }
		public DateTime DataMovimento { get; }
		public char TipoMovimento { get; }
		public decimal Valor { get; }

		public MovimentoVo(Movimento movimento)
		{
			IdMovimento = movimento.IdMovimento;
			IdContaCorrente = movimento.IdContaCorrente;
			DataMovimento = movimento.DataMovimento;
			TipoMovimento = movimento.TipoMovimento;
			Valor = movimento.Valor;
		}
	}
}
