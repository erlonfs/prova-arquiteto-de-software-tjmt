using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TJMT.Prova.Read.Infraestructure.EF.Contexts.Entities;

namespace TJMT.Prova.Read.Infraestructure.EF.Contexts.Repository
{
	public class ProdutoRepository : IProdutoRepository
	{
		private readonly ProvaDbContext _context;

		public ProdutoRepository(ProvaDbContext context)
		{
			_context = context;
		}

		public Task AdicionarAsync(Produto produto)
		{
			_context.Produto.Add(produto);

			return Task.CompletedTask;

		}

		public async Task<Produto> ObterPorAggregateIdsync(Guid aggregateId)
		{
			return await _context.Produto.SingleOrDefaultAsync(x => x.AggregateId == aggregateId);
		}

		public async Task<Produto> ObterPorCodigoAsync(int codigo)
		{
			return await _context.Produto.SingleOrDefaultAsync(x => x.Codigo == codigo);
		}

		public async Task<Produto> ObterPorIdAsync(int id)
		{
			return await _context.Produto.SingleOrDefaultAsync(x => x.Id == id);
		}
	}
}
