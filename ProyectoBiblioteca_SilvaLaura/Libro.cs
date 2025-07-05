/*
 * Created by SharpDevelop.
 * User: laura
 * Date: 5/18/2025
 * Time: 9:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ProyectoBiblioteca_SilvaLaura
{
	public class Libro
	{
		private static int contador = 1; // Contador para asignar codigos
		private string codigo;
		private string titulo;
		private string autor;
		private string editorial;
		private bool estado; // true prestado, false disponible
		private string dniSocio;
		private DateTime? fechaPrestamo;
		private DateTime? fechaDevolucion;
		// Constructor
		public Libro( string tituloL, string autorL, string editorialL)
		{
			codigo = "c" + contador;
			contador++;
			titulo = tituloL;
			autor = autorL;
			editorial = editorialL;
			estado = false;
			dniSocio = "0";
			fechaPrestamo = null;
			fechaDevolucion = null;
		}

		public string Codigo
		{
			get { return codigo; }
		}

		public string Titulo
		{
			get { return titulo; }
			
		}

		public string Autor
		{
			get { return autor; }
			
		}

		public string Editorial
		{
			get { return editorial; }
			
		}
		
		public bool Estado{
			get{return estado;}
			set {estado=value;}
		}
		public string DniSocio{
			get{return dniSocio;}
			set {dniSocio=value;}
		}
		public DateTime? FechaDevolucion{
			get{return fechaDevolucion;}
			set {fechaDevolucion=value;}
		}
		public DateTime? FechaPrestamo{
			get{return fechaPrestamo;}
			set {fechaPrestamo=value;}
		}

	}
}
