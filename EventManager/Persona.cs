using System;

namespace EventManager
{
	/// <summary>
	/// Description of Persona.
	/// </summary>
	public class Persona
	{
		protected string nombreYapellido;
		protected string documento;
		public Persona(string nombreYapellido, string documento)
		{
			this.nombreYapellido = nombreYapellido;
			this.documento = documento;
		}
		public string NombreYapellido
		{
			get{return nombreYapellido;}
			set{nombreYapellido= value;}
		}
		public string Documento
		{
			get{return documento;}
			set{documento = value;}
		}
	}
}