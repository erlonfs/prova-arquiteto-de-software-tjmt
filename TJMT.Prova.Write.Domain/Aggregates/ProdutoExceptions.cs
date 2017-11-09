using System;
using System.Collections.Generic;
using System.Text;

namespace TJMT.Prova.Write.Domain.Aggregates
{
	public class ProdutoJaExcluidoException : Exception
	{
		public ProdutoJaExcluidoException() : base("O produto já esta excluído.") { }
	}

	public class NomeNaoDeveUltrapassarCinquentaCaracteresException : Exception
	{
		public NomeNaoDeveUltrapassarCinquentaCaracteresException() : base("Nome não deve ultrapassar 50 caracteres.") { }
	}
}
