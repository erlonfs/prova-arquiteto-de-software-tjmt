using System.Threading.Tasks;
using EnjoyCQRS.Events;
using TJMT.Prova.Infraestucture.EventHandling;
using TJMT.Prova.Write.Domain.Aggregates;
using TJMT.Prova.Read.Infraestructure.EF.Contexts.Repository;

namespace TJMT.Prova.Read.EventHandlers.Produto
{
	public class ProdutoAlteradoEventHandler : IInternalEventHandler<ProdutoAlterado>
	{
		private readonly IProdutoRepository _produtoRepository;

		public ProdutoAlteradoEventHandler(IProdutoRepository produtoRepository)
		{
			_produtoRepository = produtoRepository;
		}

		public async Task ExecuteAsync(Event<ProdutoAlterado> @event)
		{
			var produto = await _produtoRepository.ObterPorAggregateIdsync(@event.InnerEvent.AggregateId);

			produto.Nome = @event.InnerEvent.Nome;
			produto.Preco = @event.InnerEvent.Preco;
		}
	}
}
