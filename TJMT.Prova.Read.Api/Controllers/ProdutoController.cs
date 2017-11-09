using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TJMT.Prova.Read.Api.Models;

namespace TJMT.Prova.Read.Api.Controllers
{

	[RoutePrefix("produtos")]
	public class ProdutoController : ApiController
	{
		public ProdutoController()
		{

		}

		[HttpGet]
		[Route("")]
		public Task<List<ProdutoDto>> ObterAsync()
		{
			var produtos = new List<ProdutoDto>();

			produtos.Add(new ProdutoDto { AggregateId = Guid.NewGuid(), Codigo = 1, Nome = "Computador", Preco = 12000 });
			produtos.Add(new ProdutoDto { AggregateId = Guid.NewGuid(), Codigo = 2, Nome = "Mesa", Preco = 200 });
			produtos.Add(new ProdutoDto { AggregateId = Guid.NewGuid(), Codigo = 3, Nome = "Headset", Preco = 100 });
			produtos.Add(new ProdutoDto { AggregateId = Guid.NewGuid(), Codigo = 4, Nome = "Notebook", Preco = 5000 });

			return Task.FromResult(produtos);
		}

		[HttpGet]
		[Route("{codigo:int}")]
		public Task<ProdutoDto> ObterPorCodigoAsync(int codigo)
		{
			return Task.FromResult(new ProdutoDto { AggregateId = Guid.NewGuid(), Codigo = 1, Nome = "Computador", Preco = 12000 });
		}
	}

}
