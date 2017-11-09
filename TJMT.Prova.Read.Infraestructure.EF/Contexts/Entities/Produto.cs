using System;

namespace TJMT.Prova.Read.Infraestructure.EF.Contexts.Entities
{
	public class Produto
	{
		public Guid AggregateId { get; set; }
		public DateTime DataCriacao { get; set; }
		public int Id { get; set; }
		public int Codigo { get; set; }
		public string Nome { get; set; }
		public decimal Preco { get; set; }
		public int Quantidade { get; set; }
	}
}
