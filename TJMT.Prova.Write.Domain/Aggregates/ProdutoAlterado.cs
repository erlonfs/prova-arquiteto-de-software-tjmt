using EnjoyCQRS.Events;
using System;

namespace TJMT.Prova.Write.Domain.Aggregates
{
	public class ProdutoAlterado : IDomainEvent
	{
		public Guid AggregateId { get; }
		public string Nome { get; }
		public decimal Preco { get; }

		public ProdutoAlterado(Guid aggregateId, string nome, decimal preco)
		{
			AggregateId = aggregateId;
			Nome = nome;
			Preco = preco;
		}
	}
}
