using EnjoyCQRS.Events;
using System;

namespace TJMT.Prova.Write.Domain.Aggregates
{
	public class ProdutoExcluido : IDomainEvent
	{
		public Guid AggregateId { get; }
		public ProdutoExcluido(Guid aggregateId) { AggregateId = aggregateId; }
	}
}
