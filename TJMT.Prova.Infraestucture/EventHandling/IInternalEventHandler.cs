using EnjoyCQRS.Events;

namespace TJMT.Prova.Infraestucture.EventHandling
{
    public interface IInternalEventHandler<TEvent> : IEventHandler<Event<TEvent>>
        where TEvent : IDomainEvent
    {
    }
}