using EnjoyCQRS.Commands;
using System;

namespace TJMT.Prova.Write.Commands.Produto
{
	public class AlterarProdutoCommand : Command
	{
		public string Nome { get; }
		public decimal Preco { get; }

		/// <summary>
		/// Altera o produto
		/// </summary>
		/// <param name="aggregateId">Id do produto</param>
		/// <param name="nome">Nome do produto</param>
		/// <param name="preco">Preço do produto</param>
		public AlterarProdutoCommand(Guid aggregateId, string nome, decimal preco) : base(aggregateId)
		{
			Nome = nome;
			Preco = preco;
		}
	}
}
