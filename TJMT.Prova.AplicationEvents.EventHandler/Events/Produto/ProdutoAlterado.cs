using System;

namespace TJMT.Prova.AplicationEvents.Events.Produto
{
	public class ProdutoAlterado
	{
		public Guid AggregateId { get; }
		public string Nome { get; }
		public decimal Preco { get; }

		public DateTime DataExecucao { get; }

		public ProdutoAlterado(Guid aggregateId, string nome, decimal preco, DateTime dataExecucao)
		{
			AggregateId = aggregateId;
			Nome = nome;
			Preco = preco;
			DataExecucao = dataExecucao;
		}
	}
}
