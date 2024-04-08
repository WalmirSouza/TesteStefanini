using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.QueryStore;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Database
{
	public class ContaCorrenteRepository
	{
		private readonly DatabaseConfig databaseConfig;

		public ContaCorrenteRepository(DatabaseConfig databaseConfig)
		{
			this.databaseConfig = databaseConfig;
		}

		public ContaCorrente ObterPorId(Guid idContaCorrente)
		{
			using var connection = new SqliteConnection(databaseConfig.Name);
			return connection.QuerySingle<ContaCorrente>(ContaCorrenteQueries.QuerySelectContaCorrentePorId, new { idContaCorrente });
		}


		public ContaCorrente ObterPorIdComMovimentos(Guid idContaCorrente)
		{
			var dapperMapper = new DapperMapper();
			using var connection = new SqliteConnection(databaseConfig.Name);

			connection.Query<ContaCorrente, Movimento, ContaCorrente>(
				sql: ContaCorrenteQueries.QuerySelectContaCorrentePorIdComMovimento,
				map: Mapeamento,
				param: new { idContaCorrente },
				splitOn: "IdMovimento"
			);

			return dapperMapper.GetObjects<ContaCorrente>().SingleOrDefault();

			ContaCorrente Mapeamento(ContaCorrente contaCorrente, Movimento movimento)
			{
				contaCorrente = dapperMapper.Get(contaCorrente.IdContaCorrente, contaCorrente);
				movimento = dapperMapper.Get(movimento.IdMovimento, movimento);

				contaCorrente.Adicionar(movimento);
				return contaCorrente;
			}
		}

	}
}
