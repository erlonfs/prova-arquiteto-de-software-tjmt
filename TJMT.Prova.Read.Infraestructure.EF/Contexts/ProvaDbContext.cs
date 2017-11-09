using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using TJMT.Prova.Read.Infraestructure.EF.Contexts.Entities;

namespace TJMT.Prova.Read.Infraestructure.EF.Contexts
{
	public class ProvaDbContext : DbContext
	{
		public DbSet<Produto> Produto { get; set; }

		static ProvaDbContext()
		{
			Database.SetInitializer<ProvaDbContext>(null);
		}

		public ProvaDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<ForeignKeyNavigationPropertyAttributeConvention>();
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

			AddMappingsDynamically(modelBuilder);
		}

		private void AddMappingsDynamically(DbModelBuilder modelBuilder)
		{
			var currentAssembly = typeof(ProvaDbContext).Assembly;
			var efMappingTypes = currentAssembly.GetTypes().Where(t =>
				t.FullName.StartsWith("TJMT.Prova.Infrastructure.EF.Contexts.Mapping.") &&
				t.FullName.EndsWith("Map"));

			foreach (var map in efMappingTypes.Select(Activator.CreateInstance))
			{
				//modelBuilder.Configurations.Add((dynamic)map);
			}
		}
	}
}
