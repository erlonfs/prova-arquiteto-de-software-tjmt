using EnjoyCQRS.Commands;
using System;

namespace TJMT.Prova.Write.Commands.Produto
{
	public class CriarProdutoCommand : Command
	{
		public int Codigo { get; }
		public string Nome { get; }
		public decimal Preco { get; }
		public int Quantidade { get; }

		/// <summary>
		/// Criar produto
		/// </summary>
		/// <param name="aggregateId">Id do produto</param>
		/// <param name="codigo">Código do produto</param>
		/// <param name="nome">Nome do produto</param>
		/// <param name="preco">Preço do produto</param>
		/// <param name="quantidade">Quantidade inicial do produto</param>
		public CriarProdutoCommand(Guid aggregateId, int codigo, string nome, decimal preco, int quantidade) : base(aggregateId)
		{
			Codigo = codigo;
			Nome = nome;
			Preco = preco;
			Quantidade = quantidade;
		}
	}
}
