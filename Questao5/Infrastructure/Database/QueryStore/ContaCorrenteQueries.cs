namespace Questao5.Infrastructure.Database.QueryStore
{
	public class ContaCorrenteQueries
	{
		public static string QuerySelectContaCorrenteBase => @"
Select * From ContaCorrente CC
";

		public static string QuerySelectContaCorrentePorId => @$"
{QuerySelectContaCorrenteBase}
Where (CC.IdContaCorrente = @idContaCorrente)
";

		public static string QuerySelectContaCorrentePorIdComMovimento => @$"
{QuerySelectContaCorrenteBase}
Left Join Movimento Mov On Mov.IdContaCorrente = CC.IdContaCorrente
Where (CC.IdContaCorrente = @idContaCorrente)
";
	}
}
