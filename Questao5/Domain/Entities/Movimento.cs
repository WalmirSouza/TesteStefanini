namespace Questao5.Domain.Entities
{
	public class Movimento
	{
		public String IdMovimento { get; set; }

		internal ContaCorrente ContaCorrente { get; set; }

		public String IdContaCorrente => ContaCorrente.IdContaCorrente;

		public DateTime DataMovimento { get; set; }

		public TipoMov Tipo { get; set; }

		public char TipoMovimento
		{
			get => Tipo.ToString().First();
			set => Tipo = (value == 'C') ? TipoMov.Credito : TipoMov.Debito;
		}

		public decimal Valor { get; set; }
	}
}
