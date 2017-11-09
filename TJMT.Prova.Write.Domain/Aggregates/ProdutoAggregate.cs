using System;
using EnjoyCQRS.EventSource;

namespace TJMT.Prova.Write.Domain.Aggregates
{
	/// <summary>
	/// Aggregate de produto
	/// </summary>
	public class ProdutoAggregate : Aggregate
	{
		/// <summary>
		/// Código único do produto
		/// </summary>
		public int Codigo { get; private set; }

		/// <summary>
		/// Nome do produto
		/// </summary>
		public string Nome { get; private set; }

		/// <summary>
		/// Preço do produto
		/// </summary>
		public decimal Preco { get; private set; }

		/// <summary>
		/// Quantidade em estoque
		/// </summary>
		public int Quantidade { get; private set; }

		/// <summary>
		/// Flag para identificar se o produto está excluído
		/// </summary>
		public bool IsExcluido { get; private set; }

		protected override void RegisterEvents()
		{
			SubscribeTo<ProdutoCriado>(e =>
			{
				Id = e.AggregateId;
				Codigo = e.Codigo;
				Nome = e.Nome;
				Preco = e.Preco;
			});

			SubscribeTo<ProdutoAlterado>(e =>
			{
				Nome = e.Nome;
				Preco = e.Preco;
			});

			SubscribeTo<ProdutoExcluido>(e =>
			{
				IsExcluido = true;
			});
		}

		public ProdutoAggregate()
		{

		}

		/// <summary>
		/// Cria produto
		/// </summary>
		/// <param name="id">Id do produto</param>
		/// <param name="codigo">Código do produto</param>
		/// <param name="nome">Nome do produto</param>
		/// <param name="preco">Preço do produto</param>
		/// <param name="quantidade">Quantidade inicial do produto</param>
		public ProdutoAggregate(Guid id, int codigo, string nome, decimal preco, int quantidade)
		{
			if (codigo < 0) throw new ArgumentOutOfRangeException(nameof(codigo));
			if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentNullException(nameof(nome));
			if (nome.Length > 50) throw new NomeNaoDeveUltrapassarCinquentaCaracteresException();
			if (preco < 0M) throw new ArgumentOutOfRangeException(nameof(preco));
			if (preco < 0M) throw new ArgumentOutOfRangeException(nameof(preco));
			if (quantidade < 0) throw new ArgumentOutOfRangeException(nameof(quantidade));

			Emit(new ProdutoCriado(id, DateTime.Now, codigo, nome, preco, quantidade));
		}

		/// <summary>
		/// Altera o produto
		/// </summary>
		/// <param name="nome">Nome do produto</param>
		/// <param name="preco">Preço do produto</param>
		public void Alterar(string nome, decimal preco)
		{
			if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentNullException(nameof(nome));
			if (nome.Length > 50) throw new NomeNaoDeveUltrapassarCinquentaCaracteresException();
			if (preco < 0M) throw new ArgumentOutOfRangeException(nameof(preco));

			Emit(new ProdutoAlterado(Id, nome, preco));
		}

		/// <summary>
		/// Exclui o produto
		/// </summary>
		public void Excluir()
		{
			if (IsExcluido) throw new ProdutoJaExcluidoException();
			Emit(new ProdutoExcluido(Id));
		}
	}
}
