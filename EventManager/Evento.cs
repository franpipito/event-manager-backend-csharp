using System;
using System.Collections;
namespace EventManager
{
	/// <summary>
	/// Description of Evento.
	/// </summary>
	public class Evento
	{
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
		//Atributos
		private string nombreCliente;
		private string dniCliente;
		private DateTime fechaEvento;
		private TimeSpan horaEvento;
		private string tipoEvento;
		private Encargado encargado;
		private ArrayList listaServicios;
		private double costoTotal;
		private double seña;
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		//Constructor
		public Evento(string nombreCliente, string dniCliente, DateTime fechaEvento, TimeSpan horaEvento, string tipoEvento, Encargado encargado, double costoTotal, double seña)
		{
			this.nombreCliente = nombreCliente;
        	this.dniCliente = dniCliente;
        	this.fechaEvento = fechaEvento;
       	 	this.horaEvento = horaEvento;
        	this.tipoEvento = tipoEvento;
        	this.encargado = encargado;
        	this.listaServicios = new ArrayList();
        	this.costoTotal = costoTotal;
        	this.seña = seña;
		}
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		//Propiedades
		public string NombreCliente
    	{
        	get{return nombreCliente;}
        	set{nombreCliente = value;}
    	}
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public string DniCliente
    	{
        	get{return dniCliente;}
        	set{dniCliente = value;}
    	}
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    	public DateTime FechaEvento
    	{
        	get{return fechaEvento;}
        	set{fechaEvento = value;}
    	}
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    	public TimeSpan HoraEvento
    	{
        	get{return horaEvento;}
        	set{horaEvento = value;}
    	}
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    	public string TipoEvento
    	{
        	get{return tipoEvento;}
        	set{tipoEvento = value;}
    	}
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    	public Encargado Encargado
    	{
        	get{return encargado;}
        	set{encargado = value;}
    	}
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    	public ArrayList ListaServicios
    	{
        	get{return listaServicios;}
    	}
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    	public double CostoTotal
    	{
        	get{return costoTotal;}
        	set{costoTotal = value;}
    	}
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    	public double Seña
    	{
        	get{return seña;}
        	set{seña = value;}
    	}
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    	
	}
}
