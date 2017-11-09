using System.Threading.Tasks;
using EnjoyCQRS.Events;
using TJMT.Prova.Infraestucture.EventHandling;
using TJMT.Prova.Write.Domain.Aggregates;
using TJMT.Prova.Read.Infraestructure.EF.Contexts.Repository;

namespace TJMT.Prova.Read.EventHandlers.Produto
{
	public class ProdutoCriadoEventHandler : IInternalEventHandler<ProdutoCriado>
	{
		private readonly IProdutoRepository _produtoRepository;

		public ProdutoCriadoEventHandler(IProdutoRepository produtoRepository)
		{
			_produtoRepository = produtoRepository;
		}

		public async Task ExecuteAsync(Event<ProdutoCriado> @event)
		{
			var produto = new Infraestructure.EF.Contexts.Entities.Produto()
			{
				AggregateId = @event.InnerEvent.AggregateId,
				DataCriacao = @event.InnerEvent.DataCriacao,
				Codigo = @event.InnerEvent.Codigo,
				Nome = @event.InnerEvent.Nome,
				Preco = @event.InnerEvent.Preco,
				Quantidade = @event.InnerEvent.Quantidade
			};

			await _produtoRepository.AdicionarAsync(produto);

		}
	}
}
