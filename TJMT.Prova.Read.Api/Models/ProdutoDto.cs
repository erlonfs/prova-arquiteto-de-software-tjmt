using System;

namespace TJMT.Prova.Read.Api.Models
{
	public class ProdutoDto
	{
		public Guid AggregateId { get; set; }
		public int Codigo { get; set; }
		public string Nome { get; set; }
		public decimal Preco { get; set; }
	}
}