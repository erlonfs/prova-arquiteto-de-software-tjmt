using FluentAssertions;
using System;
using TJMT.Prova.Write.Domain.Aggregates;
using Xunit;

namespace TJMT.Prova.Write.Domain.Test.Produto
{
	public class ProdutoAggregateTest
	{
		private ProdutoAggregate _aggregate;

		private readonly Guid _id = Guid.NewGuid();
		private readonly int _codigo = 1;
		private readonly string _nome = "Computador";
		private readonly decimal _preco = 12000M;
		private readonly int _quantidade = 10;

		public ProdutoAggregateTest()
		{
			_aggregate = new ProdutoAggregate();
		}

		[Theory]
		[InlineData(-1)]
		[InlineData(0)]
		public void Quando_criar_produto_com_codigo_invalido(int codigo)
		{
			var act = new Action(() => new ProdutoAggregate(_id, codigo, _nome, _preco, _quantidade));
			act.ShouldThrow<ArgumentOutOfRangeException>().And.ParamName.Should().Be("codigo");
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Quando_criar_produto_com_nome_invalido(string nome)
		{
			var act = new Action(() => new ProdutoAggregate(_id, _codigo, nome, _preco, _quantidade));
			act.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("nome");
		}

		[Theory]
		[InlineData("Manuelina Terebentina Capitulina de Jesus Amor Divino")]
		public void Quando_criar_produto_com_nome_maior_do_que_50_caracteres(string nome)
		{
			var act = new Action(() => new ProdutoAggregate(_id, _codigo, nome, _preco, _quantidade));
			act.ShouldThrow<NomeNaoDeveUltrapassarCinquentaCaracteresException>();
		}

		[Theory]
		[InlineData(-1)]
		[InlineData(-0.9)]
		[InlineData(0)]
		public void Quando_criar_produto_com_preco_invalido(decimal preco)
		{
			var act = new Action(() => new ProdutoAggregate(_id, _codigo, _nome, preco, _quantidade));
			act.ShouldThrow<ArgumentOutOfRangeException>().And.ParamName.Should().Be("preco");
		}

		[Theory]
		[InlineData(-1)]
		public void Quando_criar_produto_com_quantidade_inicial_invalida(int quantidade)
		{
			var act = new Action(() => new ProdutoAggregate(_id, _codigo, _nome, _preco, quantidade));
			act.ShouldThrow<ArgumentOutOfRangeException>().And.ParamName.Should().Be("quantidade");
		}


		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Quando_alterar_produto_com_nome_invalido(string nome)
		{
			var act = new Action(() => _aggregate.Alterar(nome, _preco));
			act.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("nome");
		}

		[Theory]
		[InlineData(-1)]
		[InlineData(-0.9)]
		[InlineData(0)]
		public void Quando_alterar_produto_com_preco_invalido(decimal preco)
		{
			var act = new Action(() => _aggregate.Alterar(_nome, preco));
			act.ShouldThrow<ArgumentOutOfRangeException>().And.ParamName.Should().Be("preco");
		}

	}
}
