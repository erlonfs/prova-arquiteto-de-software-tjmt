using EnjoyCQRS.Events;
using System;
using System.Threading.Tasks;
using TJMT.Prova.Infraestucture.EventHandling;
using TJMT.Prova.Infraestucture.Messaging;
using TJMT.Prova.Write.Domain.Aggregates;

namespace TJMT.Prova.AplicationEvents.EventHandler.Produto
{
	public class ProdutoCriadoEventHandler : IInternalEventHandler<ProdutoCriado>
	{
		private readonly IMessageBusPublisher _bus;

		public ProdutoCriadoEventHandler(IMessageBusPublisher bus)
		{
			_bus = bus;
		}

		public async Task ExecuteAsync(Event<ProdutoCriado> e)
		{
			await _bus.PublishAsync(new Events.Produto.ProdutoCriado(e.InnerEvent.AggregateId, 
																	 e.InnerEvent.DataCriacao,
																	 e.InnerEvent.Codigo, 
																	 e.InnerEvent.Nome, 
																	 e.InnerEvent.Preco, 
																	 DateTime.Now));
		}
	}
}
