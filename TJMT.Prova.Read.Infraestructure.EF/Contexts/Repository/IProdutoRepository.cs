using System;
using System.Threading.Tasks;
using TJMT.Prova.Read.Infraestructure.EF.Contexts.Entities;

namespace TJMT.Prova.Read.Infraestructure.EF.Contexts.Repository
{
	public interface IProdutoRepository
    {
		Task AdicionarAsync(Produto produto);
		Task<Produto> ObterPorIdAsync(int id);
		Task<Produto> ObterPorAggregateIdsync(Guid aggregateId);
		Task<Produto> ObterPorCodigoAsync(int codigo);
	}
}
