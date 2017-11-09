using EnjoyCQRS.Commands;
using EnjoyCQRS.EventSource.Storage;
using System.Threading.Tasks;
using TJMT.Prova.Write.Domain.Aggregates;

namespace TJMT.Prova.Write.Commands.Produto
{
	public class AlterarProdutoCommandHandler : ICommandHandler<AlterarProdutoCommand>
	{
		private readonly IRepository _repository;

		public AlterarProdutoCommandHandler(IRepository repository)
		{
			_repository = repository;
		}

		public async Task ExecuteAsync(AlterarProdutoCommand command)
		{
			var produto = await _repository.GetByIdAsync<ProdutoAggregate>(command.AggregateId);
			await _repository.AddAsync(produto);
		}
	}
}
