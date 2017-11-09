using EnjoyCQRS.Commands;
using EnjoyCQRS.EventSource.Storage;
using System.Threading.Tasks;
using TJMT.Prova.Write.Domain.Aggregates;

namespace TJMT.Prova.Write.Commands.Produto
{
	public class CriarProdutoCommandHandler : ICommandHandler<CriarProdutoCommand>
	{
		private readonly IRepository _repository;

		public CriarProdutoCommandHandler(IRepository repository)
		{
			_repository = repository;
		}

		public async Task ExecuteAsync(CriarProdutoCommand command)
		{
			var produto = new ProdutoAggregate(command.AggregateId, command.Codigo, command.Nome, command.Preco, command.Quantidade);
			await _repository.AddAsync(produto);
		}
	}
}
