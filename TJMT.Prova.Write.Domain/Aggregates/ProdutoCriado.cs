using EnjoyCQRS.Events;
using System;

namespace TJMT.Prova.Write.Domain.Aggregates
{
	public class ProdutoCriado : IDomainEvent
	{
		public Guid AggregateId { get; }
		public DateTime DataCriacao { get; }
		public int Codigo { get; }
		public string Nome { get; }
		public decimal Preco { get; }
		public int Quantidade { get; }

		public ProdutoCriado(Guid aggregateId, DateTime dataCriacao, int codigo, string nome, decimal preco, int quantidade)
		{
			AggregateId = aggregateId;
			DataCriacao = dataCriacao;
			Codigo = codigo;
			Nome = nome;
			Preco = preco;
			Quantidade = quantidade;
		}
	}
}
