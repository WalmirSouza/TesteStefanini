using Microsoft.AspNetCore.Mvc;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database;

namespace Questao5.Infrastructure.Services.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ContaCorrenteController : ControllerBase
	{
		private readonly ContaCorrenteRepository _contaCorrenteRepository;
		public ContaCorrenteController(ContaCorrenteRepository contaCorrenteRepository)
		{
			_contaCorrenteRepository = contaCorrenteRepository;
		}

		[HttpGet(Name = "GetSaldo")]
		public decimal GetSaldo(Guid idContaCorrente)
		{
			var contaCorrente = _contaCorrenteRepository.ObterPorIdComMovimentos(idContaCorrente);
			return contaCorrente.CalcularSaldo();
		}

		[HttpGet("extrato", Name = "GetExtrato")]
		public IEnumerable<MovimentoVo> GetExtrato(Guid idContaCorrente)
		{
			var contaCorrente = _contaCorrenteRepository.ObterPorIdComMovimentos(idContaCorrente);
			return contaCorrente.Movimentacao.ToArray();
		}
	}
}