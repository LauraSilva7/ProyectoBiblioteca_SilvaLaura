using System;
using System.Collections;
using System.Collections.Generic;
namespace ProyectoBiblioteca_SilvaLaura
{
	/// <summary>
	/// Description of LectorSala.
	/// </summary>
	public class SocioLectorSala:Socio
	{
		private List<string> librosEnSala;
		
		public SocioLectorSala(string dni, string nombre, string apellido, string telefono, string direccion)
			: base(dni, nombre, apellido, telefono, direccion)
		{
			librosEnSala = new List<string>();
		}

		public override void SolicitarLibro(string codigoLibro)
		{
			librosEnSala.Add(codigoLibro);
			cantLibrosPrestados++;
		}
		public override void DevolverLibro(string codigoLibro)
		{
			if (!librosEnSala.Contains(codigoLibro))
				throw new Exception("El lector de sala no tiene este libro.");

			librosEnSala.Remove(codigoLibro);
			cantLibrosPrestados--;
		}

	}
}
