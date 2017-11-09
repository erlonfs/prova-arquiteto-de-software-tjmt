using EnjoyCQRS.EventSource;
using EnjoyCQRS.MessageBus;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using TJMT.Prova.Write.Api.Models;
using TJMT.Prova.Write.Commands.Produto;

namespace TJMT.Prova.Write.Api.Controllers
{
	[RoutePrefix("produto")]
	public class ProdutoController : ApiController
	{
		private readonly ICommandDispatcher _dispatcher;
		private readonly IUnitOfWork _unitOfWork;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dispatcher"></param>
		/// <param name="unitOfWork"></param>
		public ProdutoController(ICommandDispatcher dispatcher, IUnitOfWork unitOfWork)
		{
			_dispatcher = dispatcher;
			_unitOfWork = unitOfWork;
		}

		/// <summary>
		/// Cria produto
		/// </summary>
		/// <param name="dto">Dados do produto</param>
		/// <returns></returns>
		[HttpPost]
		[Route("")]
		public async Task<Guid> CriarAsync(CriarProdutoDto dto)
		{
			var produtoId = Guid.NewGuid();
			var command = new CriarProdutoCommand(produtoId, dto.Codigo, dto.Nome, dto.Preco, dto.Quantidade);

			await _dispatcher.DispatchAsync(command);
			await _unitOfWork.CommitAsync();

			return produtoId;
		}

		/// <summary>
		/// Altera produto
		/// </summary>
		/// <param name="aggregateId">Id do produto</param>
		/// <param name="dto">Dados do produto</param>
		/// <returns></returns>
		[HttpPut]
		[Route("{aggregateId:guid}")]
		public async Task<Guid> AlterarAsync(Guid aggregateId, AlterarProdutoDto dto)
		{
			var command = new AlterarProdutoCommand(aggregateId, dto.Nome, dto.Preco);

			await _dispatcher.DispatchAsync(command);
			await _unitOfWork.CommitAsync();

			return aggregateId;

		}
	}

}
