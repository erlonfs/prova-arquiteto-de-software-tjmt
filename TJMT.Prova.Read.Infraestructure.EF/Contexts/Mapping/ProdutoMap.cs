using System.Data.Entity.ModelConfiguration;
using TJMT.Prova.Read.Infraestructure.EF.Contexts.Entities;

namespace TJMT.Prova.Read.Infraestructure.EF.Contexts.Mapping
{
	public class ProdutoMap : EntityTypeConfiguration<Produto>
	{
		public ProdutoMap()
		{
			ToTable("Produto");

			HasKey(x => x.Id);

			Property(x => x.Id)
				.HasColumnName("Id");

			Property(x => x.Codigo)
				.HasColumnName("Codigo");

			Property(x => x.Nome)
				.HasColumnName("Nome")
				.HasMaxLength(50)
				.IsUnicode(false);

			Property(x => x.Preco)
				.HasColumnName("Preco");


		}
	}
}
