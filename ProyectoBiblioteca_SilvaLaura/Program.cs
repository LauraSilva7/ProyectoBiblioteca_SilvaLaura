/*
 * Created by SharpDevelop.
 * User: laura
 * Date: 5/18/2025
 * Time: 9:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ProyectoBiblioteca_SilvaLaura
{
	class Program
		
	{
		public static void Main(string[] args)
		{
			
			Biblioteca biblioteca1;

			biblioteca1=new Biblioteca();
			while (true)
			{
				Console.WriteLine("Elija una opción: ");
				Console.WriteLine("1- Agregar un libro nuevo a la biblioteca");//ok
				Console.WriteLine("2- Eliminar un libro de la biblioteca");//ok
				Console.WriteLine("3- Dar de alta un socio");//ok
				Console.WriteLine("4- Dar de baja un socio");//ok
				Console.WriteLine("5- Prestar un libro");//ok
				Console.WriteLine("6- Devolver un libro");//ok
				Console.WriteLine("7- submenu: listados");//pk
				Console.WriteLine("8 - Salir ");
				string op=Console.ReadLine();
				switch (op.Trim().ToLower()){
					case "1":
						Console.WriteLine("agregar un libro");
						string titulo, autor, editorial;
						Console.WriteLine("Ingrese el titulo del libro");
						titulo=Console.ReadLine();
						Console.WriteLine("Ingrese el autor del libro");
						autor=Console.ReadLine();
						Console.WriteLine("Ingrese la editorial del libro");
						editorial=Console.ReadLine();
						Libro lib = new Libro(titulo, autor, editorial);
						biblioteca1.AgregarLibro(lib);
						break;
					case "2":
						Console.WriteLine("2- Eliminar un libro de la biblioteca");
						Console.WriteLine("ingrese el codigo del libro a eliminar");
						string codigoEliminar=Console.ReadLine();
						bool eliminado = biblioteca1.EliminarLibro(codigoEliminar);
						if (eliminado)
						{
							Console.WriteLine("Libro eliminado con éxito.");
						}
						else
						{
							Console.WriteLine("No se pudo eliminar el libro, rev. que exista o que no este prestado");
						}
						break;
					case "3":
						Console.WriteLine("3- Dar de alta un socio");
						Console.WriteLine("ingrese el dni del socio");
						string dni= Console.ReadLine();
						Console.WriteLine("Ingrese el nombre del socio");
						string nombreSocio=Console.ReadLine();
						Console.WriteLine("Ingrese el apellido del socio");
						string apeSocio=Console.ReadLine();
						Console.WriteLine("Ingrese el telefono del socio");
						string telSocio=Console.ReadLine();
						Console.WriteLine("Ingrese el direccion  del socio");
						string dirSocio=Console.ReadLine();
						Console.WriteLine("El socio es un lector de sala si/no");
						string lectorSala=Console.ReadLine();
						if (lectorSala.Trim().ToLower() == "si" ) {
							Socio socioL= new SocioLectorSala(dni, nombreSocio,apeSocio, telSocio, dirSocio);
							biblioteca1.AgregarSocio(socioL);
						}else{
							Socio socio= new Socio(dni, nombreSocio,apeSocio, telSocio, dirSocio);
							biblioteca1.AgregarSocio(socio);
						}
						
						break;
					case "4":
						Console.WriteLine("Ingrese el dni del socio para la baja");
						string dniSocio= Console.ReadLine();
						bool bajaSocio = biblioteca1.BajaSocio(dniSocio);
						Console.WriteLine(bajaSocio? "\nSe dio la baja correctamente": "\nno se pudo dar la baja al usuario(rev. que el usaurio sea correcto y que no tenga libros prestados)");
						break;
					case "5":
						Console.WriteLine("Ingrese el dni del socio ");
						string dniSocioPrestamo = Console.ReadLine();
						Console.WriteLine("Ingrese el codigo del libro");
						string codigoLibroPrestamo = Console.ReadLine();
						try
						{
							biblioteca1.PrestarLibro(dniSocioPrestamo, codigoLibroPrestamo);
							Console.WriteLine("\nPréstamo realizado con éxito.");
						}
						catch (ExcepcionPrestamoInvalido ex)
						{
							Console.WriteLine("\nNo se pudo prestar el libro: " + ex.Message);
						}
						
						break;
					case "6":
						Console.WriteLine("Ingrese el DNI del socio:");
						string dniDevolver = Console.ReadLine();
						Console.WriteLine("Ingrese el codigo del libro a devolver:");
						string codigoDevolver = Console.ReadLine();

						string resultado = biblioteca1.DevolverLibro(dniDevolver, codigoDevolver);
						Console.WriteLine(resultado);
						break;
					case "7":
						bool salirSubmenu = false;
						while (!salirSubmenu)
						{
							Console.WriteLine("\nSubmenú de impresión:");
							Console.WriteLine("a - Listado de libros prestados");
							Console.WriteLine("b - Listado de libros de la biblioteca");
							Console.WriteLine("c - Listado de socios");
							Console.WriteLine("x - Volver al menú principal");

							string subop = Console.ReadLine();

							switch (subop.Trim().ToLower())
							{
								case "a":
									biblioteca1.ListadoLibrosPrestados();
									break;
								case "b":
									biblioteca1.ListadoLibros();
									break;
								case "c":
									biblioteca1.ListadoSocios();
									break;
								case "x":
									salirSubmenu = true;
									break;
								default:
									Console.WriteLine("Opción inválida.");
									break;
							}
						}
						break;

					case "8":
						Console.WriteLine("sale del sistema");
						Console.ReadKey();
						return;
					default:
						Console.WriteLine("Opción inválida");
						break;
				}
			}
		}

	}
}