using System.Threading.Tasks;

namespace TJMT.Prova.Infraestucture.Messaging
{
	/// <summary>
	/// Responsável por realizar a publicação de Mensagens para o Message Broker.
	/// </summary>
	public interface IMessageBusPublisher
	{
		Task PublishAsync<TMessage>(TMessage message);
	}
}
