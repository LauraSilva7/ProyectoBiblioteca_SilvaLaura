using System;

namespace ProyectoBiblioteca_SilvaLaura
{
	/// <summary>
	/// Description of Socio.
	/// </summary>
	public class Socio
	{
		private string dni;
		private string nombre;
		private string apellido;
		private string telefono;
		private string direccion;
		protected int cantLibrosPrestados;
		
		
		public Socio(string dniSocio, string nombreSocio, string ape, string tel, string dir)
		{
			dni= dniSocio;
			nombre= nombreSocio;
			apellido=ape;
			telefono= tel;
			direccion=dir;
			cantLibrosPrestados=0;
		}
		public string Dni{
			get{return dni;}
		}
		public string Nombre{
			get{return nombre;}
		}
		public string Apellido{
			get{return apellido;}
		}
		public int CantLibrosPrestados{
			get{return cantLibrosPrestados;}
		}
		public virtual void SolicitarLibro(string codigoLibro)
		{
			if (CantLibrosPrestados >= 1)
				throw new ExcepcionPrestamoInvalido("Ya tiene un libro prestado.");

			cantLibrosPrestados++;
		}
		public virtual void DevolverLibro(string codigoLibro)
		{
			if (cantLibrosPrestados == 0)
				throw new Exception("No tiene libros para devolver.");

			cantLibrosPrestados--;
		}
	}
}
