namespace Questao5.Domain.Entities
{
	public class ContaCorrente
	{
		private readonly List<Movimento> _movimentos;

		public String IdContaCorrente { get; set; }
		public int Numero { get; set; }
		public string Nome { get; set; }
		public bool Ativo { get; set; }

		public IEnumerable<MovimentoVo> Movimentacao => _movimentos.OrderBy(x => x.DataMovimento).Select(x => new MovimentoVo(x));

		public ContaCorrente()
		{
			IdContaCorrente = Guid.NewGuid().ToString();
			_movimentos = new List<Movimento>();
		}

		public void Adicionar(Movimento movimento)
		{
			movimento.ContaCorrente = this;
			_movimentos.Add(movimento);
		}

		public decimal CalcularSaldo()
		{
			return _movimentos.Where(x => x.Tipo == TipoMov.Credito).Sum(x => x.Valor)
				- _movimentos.Where(x => x.Tipo == TipoMov.Debito).Sum(x => x.Valor);
		}
	}
}