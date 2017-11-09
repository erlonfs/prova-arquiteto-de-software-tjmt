using EnjoyCQRS.Events;
using System;
using System.Threading.Tasks;
using TJMT.Prova.Infraestucture.EventHandling;
using TJMT.Prova.Infraestucture.Messaging;
using TJMT.Prova.Write.Domain.Aggregates;

namespace TJMT.Prova.AplicationEvents.EventHandler.Produto
{
	public class ProdutoAlteradoEventHandler : IInternalEventHandler<ProdutoAlterado>
	{
		private readonly IMessageBusPublisher _bus;

		public ProdutoAlteradoEventHandler(IMessageBusPublisher bus)
		{
			_bus = bus;
		}

		public async Task ExecuteAsync(Event<ProdutoAlterado> e)
		{
			await _bus.PublishAsync(new Events.Produto.ProdutoAlterado(e.InnerEvent.AggregateId,
																	   e.InnerEvent.Nome,
																	   e.InnerEvent.Preco,
																	   DateTime.Now));
		}
	}
}
