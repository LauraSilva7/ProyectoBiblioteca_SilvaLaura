using System;
using System.Collections;
namespace ProyectoBiblioteca_SilvaLaura
{
	/// <summary>
	/// Description of Biblioteca.
	/// </summary>
	public class Biblioteca
	{
		private ArrayList libros= new ArrayList();
		private ArrayList socios= new ArrayList();
		
		public Biblioteca()
		{
		}
		
		public void AgregarLibro(Libro lib){
			try {
				libros.Add(lib);
			} catch (Exception) {
				Console.WriteLine("error al agregar libro");
				throw;
			}
		}
		public bool EliminarLibro(string codigo)
		{
			foreach (object obj in libros)
			{
				Libro lib = (Libro)obj;
				if (lib.Codigo == codigo)
				{
					if (lib.Estado)
					{
						return false; // no se puede eliminar porque esta prestado
					}
					libros.Remove(obj);
					return true;
				}
			}
			return false; // no se encontró el libro
		}
		public void AgregarSocio(Socio soci){
			try {
				socios.Add(soci);
			} catch (Exception) {
				Console.WriteLine("error al agregar socio");
				throw;
			}
		}
		public bool BajaSocio(string dniSocio){
			foreach(object obj in socios){
				Socio soci= (Socio)obj;
				if(soci.Dni == dniSocio){
					if (soci.CantLibrosPrestados > 0)
					{
						return false;// no se puede dar de baja porque tiene libros prestados
					}
					socios.Remove(obj);
					return true;
				}
			}
			return false;
			
		}
		public void PrestarLibro(string dniSocio, string codigoLibro){
			//1 consulto si el libro esta disponible
			//2 busco al usuario
			Libro libro = BuscarLibro(codigoLibro);
			if (libro == null)
			{
				throw new ExcepcionPrestamoInvalido("El libro no existe");
			}
			if (libro.Estado) {
				throw new ExcepcionPrestamoInvalido("El libro ya esta prestado");
			}
			Socio socio=BuscarSocio(dniSocio);
			if (socio == null)
			{
				throw new ExcepcionPrestamoInvalido("El socio no existe.");
			}
			
			socio.SolicitarLibro(codigoLibro);

			libro.Estado = true; // pasa a prestado
			libro.DniSocio = socio.Dni;
			libro.FechaPrestamo = DateTime.Now;
			libro.FechaDevolucion = DateTime.Now.AddDays(15);
			

		}
		public string DevolverLibro(string dniSocio, string codigoLibro)
		{
			Libro libro = BuscarLibro(codigoLibro);
			if (libro == null)
				return "El libro no existe.";

			Socio socio = BuscarSocio(dniSocio);
			if (socio == null)
				return "El socio no existe.";

			if (!libro.Estado  || libro.DniSocio != socio.Dni)
				return "El libro no está registrado como prestado a este socio.";

			try
			{
				socio.DevolverLibro(codigoLibro);

				libro.Estado = false;
				libro.DniSocio = "0";
				libro.FechaPrestamo = DateTime.MinValue;
				libro.FechaDevolucion = DateTime.MinValue;

				return "Libro devuelto con éxito.";
			}
			catch (Exception e)
			{
				return "Error al devolver el libro: " + e.Message;
			}
		}

		public void ListadoLibros(){
			foreach (Libro item in libros) {
				Libro lib=(Libro)item;
				Console.WriteLine("Codigo: " + lib.Codigo + " | Titulo: " + lib.Titulo + " | Editorial: " + lib.Editorial + " | Estado(prestado?): " + lib.Estado  );
			}
		}
		public void ListadoSocios(){
			foreach (Socio item in socios) {
				Socio soc=(Socio)item;
				Console.WriteLine("DNI: " + soc.Dni + " | Nombre: " + soc.Nombre + " | Apellido: " + soc.Apellido + " | Total libros prestados: " + soc.CantLibrosPrestados  );
			}
		}
		public void ListadoLibrosPrestados()
		{
			foreach (Libro lib in libros)
			{
				if (lib.Estado)
				{
					Console.WriteLine("Código: " + lib.Codigo + " | Título: " + lib.Titulo + " | Prestado a DNI: " + lib.DniSocio + " | Devuelve: " + (lib.FechaDevolucion != null ? lib.FechaDevolucion.Value.ToShortDateString() : "-"));

				}
			}
		}

		private Socio BuscarSocio(string dni){
			foreach (Socio item in socios) {
				Socio socio = (Socio)item;
				if (socio.Dni == dni) {
					return socio;
				}
			}
			return null;
		}
		private Libro BuscarLibro(string codigo){
			foreach (Libro item in libros) {
				Libro libro = (Libro)item;
				if (libro.Codigo == codigo) {
					return libro;
				}
			}
			return null;
		}
	}
}
