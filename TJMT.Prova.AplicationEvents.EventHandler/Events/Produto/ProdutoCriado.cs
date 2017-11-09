using System;

namespace TJMT.Prova.AplicationEvents.Events.Produto
{
	public class ProdutoCriado
	{
		public Guid AggregateId { get; }
		public DateTime DataCriacao { get; }
		public int Codigo { get; }
		public string Nome { get; }
		public decimal Preco { get; }

		public DateTime DataExecucao { get; }

		public ProdutoCriado(Guid aggregateId, DateTime dataCriacao, int codigo, string nome, decimal preco, DateTime dataExecucao)
		{
			AggregateId = aggregateId;
			DataCriacao = dataCriacao;
			Codigo = codigo;
			Nome = nome;
			Preco = preco;
			DataExecucao = dataExecucao;
		}
	}
}
