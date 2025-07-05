using System;

namespace ProyectoBiblioteca_SilvaLaura
{
	public class ExcepcionPrestamoInvalido:Exception
	{
		public ExcepcionPrestamoInvalido(string mensaje) : base(mensaje)
		{
		}
	}
}
