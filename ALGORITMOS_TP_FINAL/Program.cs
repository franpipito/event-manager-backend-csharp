using System;
using System.Collections;
namespace ALGORITMOS_TP_FINAL
{
	class Program
	{
		public static void Main(string[] args)
		{
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	--              		
			Salon salon = new Salon("Salon de fiestas");
			Evento evento = new Evento("Nombre Cliente", "12345678", DateTime.Now, new TimeSpan(0, 0, 0), "Tipo de evento", new Encargado("Encargado1", "12345678", 1, 30000, "Tarea", 5000), 0, 5000);
			InicializarServicios(salon);
			int opcion = 0;
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	--              		
			do
			{
				try
				{
					Console.Clear();
					Console.WriteLine("----------------------------------------");
					Console.WriteLine("Menú Principal");
	                Console.WriteLine("1. Agregar un servicio");
	                Console.WriteLine("2. Eliminar un servicio");
	                Console.WriteLine("3. Dar de alta un empleado/encargado");
	                Console.WriteLine("4. Dar de baja un empleado/encargado");
	                Console.WriteLine("5. Reservar el salón para un evento");
	                Console.WriteLine("6. Cancelar un evento");
	                Console.WriteLine("7. Submenú de impresión");
	                Console.WriteLine("8. Salir");
	                Console.WriteLine("----------------------------------------");
	                Console.Write("Seleccione una opción: ");
	                opcion = int.Parse(Console.ReadLine());
//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
	                switch(opcion)
	                {
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------           		
	                	case 1:
               				Console.WriteLine("Agregar servicio al evento");
               				AgregarServicio(evento, salon);
	                		break;
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	--              		
	                	case 2:
				            Console.WriteLine("Eliminar servicio");
				            EliminarServicio(evento, salon);
	                		break;
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	--              		
	                	case 3:
               				AltaEmpleadoEncargado(salon);
	                		break;
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	--              		
	                	case 4:
               				BajaEmpEnc(salon);
               				break;
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  -            				
	                	case 5:
               				try
               				{
               					ReservarEvento(salon);
               				}
               				catch (Exception ex)
               				{
               					Console.WriteLine("ERROR. No se ha podido reservar el evento: {0}", ex.Message);
               				}
	                		break;
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	 -              		
	                	case 6:
	                		try
	                		{
	                			CancelarEvento(salon);
	                		}
	                		catch (Exception ex)
	                		{
	                			Console.WriteLine("ERROR. No se puede cancelar el evento: {0}", ex.Message);
	                		}
               				break;
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  -            				
	                	case 7:
	                		int subOpcion;
	                		do
	                		{
	                			try
	                			{
	                				//Console.Clear();
		                			Console.WriteLine("----------------------------------------");
		                			Console.WriteLine("Submenú de Impresión");
		                            Console.WriteLine("1. Listado de eventos");
		                            Console.WriteLine("2. Listado de clientes");
		                            Console.WriteLine("3. Listado de empleados");
		                            Console.WriteLine("4. Listado de eventos de un mes determinado");
		                            Console.WriteLine("5. Volver al menú principal");
		                            Console.WriteLine("Seleccione una opción: ");
									Console.WriteLine("----------------------------------------");
		                            subOpcion = int.Parse(Console.ReadLine());
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	                            
		                            switch(subOpcion)
		                            {
		                            	case 1:
               								MostrarEventos(salon);
								            break;
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	--							            
		                            	case 2:
               								MostrarClientes(salon);
		                            		break;
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	--	                            		
		                            	case 3:
               								MostrarEmpleados(salon);
		                            		break;
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	--	                            		
		                            	case 4:
               								MostrarEventosPorMes(salon);
		                            		break;
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	--	                            		
		                            	case 5:
		        							Console.WriteLine("Regresar al menu principal");
		                            		break;
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	--	                            		
		                            	default:
		                            		Console.WriteLine("Opcion incorrecta");
		                            		break;
                            		}
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	--	                            
	                			}
	                			catch(FormatException)
	                			{
	                				Console.WriteLine("ERROR. Ingrese un numero valido para el submenu");
	                				subOpcion = 0;
	                			}
	                		}while (subOpcion != 5);
	                		continue;
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	--              		
	                	case 8:
	                		Console.WriteLine("Usted ha salido del programa");
	                		break;
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	--              		
	                	default:
                			throw new OpcionInvalida("La opcion ingresada no es valida"); //Console.WriteLine("Opcion incorrecta");
                	}if(opcion != 8)
                	{
	                	Console.WriteLine("Presione enter para continuar");
	                	Console.ReadKey(true);
                	}
				}
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	--              		
				catch(FormatException)
				{
					Console.WriteLine("ERROR. Ingrese un numero valido para el menu");
					opcion = 0;
				}
				catch(ListaVacia ex)
				{
					Console.WriteLine("ERROR: {0}", ex.motivo);
					opcion = 0;
				}
				catch(NoCliente ex)
				{
					Console.WriteLine("ERROR: {0}", ex.motivo);
					opcion = 0;
				}
				catch(SinEvento ex)
				{
					Console.WriteLine("ERROR: {0}", ex.motivo);
					opcion = 0;
				}
				catch(OpcionInvalida ex)
				{
					Console.WriteLine("ERROR: {0}", ex.motivo);
				}
				catch(ValorFueraDeRango ex)
				{
					Console.WriteLine("ERROR: {0}", ex.motivo);
					opcion = 0;
					
				}
				catch(Exception ex)
				{
					Console.WriteLine("ERROR INESPERADO: {0}", ex);
					opcion = 0;
				}
			}while (opcion != 8);			
			Console.ReadKey(true);
		}
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//-----METODOS EXCEPCIONES----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public class ListaVacia : Exception
		{
			public string motivo;
			public ListaVacia(string motivo)
			{
				this.motivo = motivo;
			}
		}
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	
		public class NoCliente : Exception
		{
			public string motivo;
			public NoCliente(string motivo)
			{
				this.motivo = motivo;
			}
		}
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public class SinEvento : Exception
		{
			public string motivo;
			public SinEvento(string motivo)
			{
				this.motivo = motivo;
			}
		}
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public class OpcionInvalida : Exception
		{
			public string motivo;
			public OpcionInvalida(string motivo)
			{
				this.motivo = motivo;
			}
		}
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public class ValorFueraDeRango : Exception
		{
			public string motivo;
			public ValorFueraDeRango(string motivo)
			{
				this.motivo = motivo;
			}
		}
//------METODOS MENU----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//------METODO AGREGAR SERVICIO-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
		/*public static void AgregarServicio(Evento evento, Salon salon)
		{
			Console.WriteLine("Indique el nombre del servicio: ");
			string nombreServicio = Console.ReadLine();
			Console.WriteLine("Indique una descripcion del servicio: ");
			string descripcion = Console.ReadLine();
			
			foreach(Servicio serv in salon.ListaServicios)
			{
				if(serv.Nombre.ToLower() == nombreServicio.ToLower())
				{
					Console.WriteLine("El servicio ya se encuentra cargado en el sistema");
					return;
				}
			}
			Servicio nuevoServicio = new Servicio(nombreServicio, descripcion, 0, 0);
			evento.ListaServicios.Add(nuevoServicio);
			salon.ListaServicios.Add(nuevoServicio);
			Console.WriteLine("El servicio fue agregado al catalogo del salon correctamente");
		}*/
		
		public static void AgregarServicio(Evento evento, Salon salon)
		{
    		// 1) Si el catálogo está vacío, solo dejamos crear uno nuevo.
    		if (salon.ListaServicios.Count == 0)
    		{
        		Console.WriteLine("No hay servicios predefinidos. Se procederá a crear uno nuevo.");
        		CrearServicioNuevo(salon);
        		return;
    		}

    		// 2) Mostrar servicios existentes
    		Console.WriteLine("Servicios ya cargados en el catálogo:");
    		for (int i = 0; i < salon.ListaServicios.Count; i++)
    		{
        		var s = (Servicio)salon.ListaServicios[i];
        		Console.WriteLine("{0}. {1} — {2}", i + 1, s.Nombre, s.Descripcion);
    		}
    		Console.WriteLine("----------------------------------------");
    		Console.WriteLine("Si desea agregar servicios seleccione la siguiente opcion");
    		Console.WriteLine("{0}. Agregar servicio nuevo", salon.ListaServicios.Count + 1);
    		Console.WriteLine("0. Volver al menú principal");
    		Console.WriteLine("----------------------------------------");

    		// 3) Leer selección
    		int sel;
    		while (true)
    		{
        		Console.Write("Seleccione un número: ");
        		string ingreso = Console.ReadLine();
        		try
        		{
            		sel = int.Parse(ingreso);
        		}
        		catch (FormatException)
        		{
            		Console.WriteLine("ERROR. Debe ingresar un número.");
            		continue;
        		}

        		if (sel < 0 || sel > salon.ListaServicios.Count + 1)
        		{
            		Console.WriteLine("ERROR. Opción fuera de rango.");
            		continue;
        		}
        		break;
    		}

    		// 4) Procesar
    		if (sel == 0)
    		{
        		// Volver al menú
        		return;
    		}
    		else if (sel == salon.ListaServicios.Count + 1)
    		{
        		// Crear un servicio nuevo
        		CrearServicioNuevo(salon);
    		}
    		else
    		{
        		// Elegió un servicio existente
        		var elegido = (Servicio)salon.ListaServicios[sel - 1];
        		Console.WriteLine("El servicio '{0}' ya existe en el catálogo (descr: {1}).", elegido.Nombre, elegido.Descripcion);
    		}
		}

		private static void CrearServicioNuevo(Salon salon)
		{
    		// 1) Definir el catálogo extra como ArrayList de string[2] { nombre, descripción }
    		ArrayList extras = new ArrayList()
    		{
        	new string[] { "Payaso",        "Diversión asegurada" },
        	new string[] { "Show de magia", "Quedarás sorprendido" },
        	new string[] { "Billar",        "Juego completo" },
        	new string[] { "Metegol",       "RIVER vs boca" },
        	new string[] { "Ping pong",     "Juego de mesa pequeño" }
    		};

    		// 2) Mostrar las opciones
    		Console.WriteLine("Servicios extras disponibles para agregar:");
    		for (int i = 0; i < extras.Count; i++)
    		{
        		string[] s = (string[])extras[i];
        		Console.WriteLine("{0}. {1} — {2}", i + 1, s[0], s[1]);
    		}
    		Console.WriteLine("0. Volver sin agregar");

    		// 3) Leer la elección con bucle hasta valor válido
    		int sel = -1;
    		while (true)
    		{
        		Console.Write("Seleccione un número (0-{0}): ", extras.Count);
        		string input = Console.ReadLine();
        		try
        		{
            		sel = int.Parse(input);
            		if (sel < 0 || sel > extras.Count)
            		{
                		Console.WriteLine("ERROR. Opción fuera de rango.");
                		continue;
            		}
            		break;
        		}
        		catch (FormatException)
        		{
            		Console.WriteLine("ERROR. Debe ingresar un número válido.");
        		}
    		}

    		// 4) Procesar la selección
    		if (sel == 0)
    		{
        		Console.WriteLine("No se agregó ningún servicio al catalogo.");
        		return;
    		}

    		string[] elegido = (string[])extras[sel - 1];
    		string nombreElegido      = elegido[0];
    		string descripcionElegida = elegido[1];

    		// 5) Verificar que no exista ya en el catálogo global
    		foreach (Servicio serv in salon.ListaServicios)
    		{
        		if (serv.Nombre.ToLower() == nombreElegido.ToLower())
        		{
            		Console.WriteLine("El servicio '{0}' ya existe en el catálogo. No se duplica.", nombreElegido);
            		return;
        		}
    		}

    		// 6) Agregar al catálogo con cantidad y costo 0
    		salon.ListaServicios.Add(new Servicio(nombreElegido, descripcionElegida, 0, 0));
    		Console.WriteLine("Servicio especial '{0}' agregado correctamente al catálogo.", nombreElegido);
		}



//------METODO INICIALIZAR SERVICIO----------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public static void InicializarServicios(Salon salon)
		{
			salon.ListaServicios.Add(new Servicio("Catering", "Comida y bebida", 0, 0));
    		salon.ListaServicios.Add(new Servicio("Mozos", "Servicio de mozos", 0, 0));
    		salon.ListaServicios.Add(new Servicio("DJ", "Música y sonido", 0, 0));
    		salon.ListaServicios.Add(new Servicio("Decoración", "Decoración temática", 0, 0));
    		salon.ListaServicios.Add(new Servicio("Bebidas", "Bebidas varias", 0, 0));
    		salon.ListaServicios.Add(new Servicio("Fotografía", "Cobertura fotográfica", 0, 0));
    		salon.ListaServicios.Add(new Servicio("Animación", "Espectáculos", 0, 0));
    		salon.ListaServicios.Add(new Servicio("Inflables", "Castillos inflables", 0, 0));
    		salon.ListaServicios.Add(new Servicio("Cama elástica", "Cama saltarina", 0, 0));
    		salon.ListaServicios.Add(new Servicio("Seguridad", "Personal de seguridad", 0, 0));
		}
//------METODO ELIMINAR SERVICIO----------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public static void EliminarServicio(Evento evento, Salon salon)
		{
    		//Solicito el nombre del servicio a eliminar
    		Console.WriteLine("Servicio a eliminar");
    		Console.WriteLine("Indique el nombre del servicio que desea eliminar: ");
    		string nombreServicioEliminar = Console.ReadLine();

    		bool servicioEncontradoEvento = false; //Variable que verifica si el servicio fue encontrado
    		Servicio servicioAEliminarEvento = null; //Variable que almacena el servicio que se elimina

    		//Buscar en la lista de servicios del evento
    		foreach (Servicio serv in evento.ListaServicios)
    		{
    			//Si el nombre coincide
        		if (serv.Nombre.ToLower() == nombreServicioEliminar.ToLower())
        		{
            		servicioAEliminarEvento = serv; //Almaceno el servicio
            		servicioEncontradoEvento = true; //Se marca como encontrado
            		break;
        		}
    		}
    		//Si el servicio fue encontrado
    		if (servicioEncontradoEvento)
    		{
        		evento.ListaServicios.Remove(servicioAEliminarEvento); //Elimino el servicio de la lista
        		//Console.WriteLine("El servicio fue eliminado del evento.");
    		}
    		else
    		{
        		//Console.WriteLine("No se encontró un servicio con ese nombre en el evento.");
    		}

    		//Buscar en la lista de servicios del salón
    		bool servicioEncontradoSalon = false;
    		Servicio servicioAEliminarSalon = null;

    		foreach (Servicio serv in salon.ListaServicios)
    		{
    			//Si el nombre coincide
        		if (serv.Nombre.ToLower() == nombreServicioEliminar.ToLower())
        		{
            		servicioAEliminarSalon = serv; //Almaceno el servicio
            		servicioEncontradoSalon = true; //Se marca como encontrado
            		break;
        		}
    		}

    		//Si el servicio fue encontrado
    		if (servicioEncontradoSalon)
    		{
        		salon.ListaServicios.Remove(servicioAEliminarSalon); //Elimino el servicio de la lista
        		Console.WriteLine("El servicio fue eliminado del sistema general del salón.");
    		}
    		else
    		{
        		Console.WriteLine("No se encontró un servicio con ese nombre en el sistema general del salón.");
    		}
		}
//------METODO CARGAR EMPLEADO O ENCARGADO------------------------------------------------------------------------------------------------------------------------------------------------------------
		public static void AltaEmpleadoEncargado(Salon salon)
		{
			//Solicito los datos del empleado/encargado
			Console.WriteLine("Ingrese nombre del empleado/encargado: ");
			string nomYape = Console.ReadLine();
			Console.WriteLine("Ingrese el DNI del empleado/encargado: ");
			string dni = Console.ReadLine();
			Console.WriteLine("Ingrese el legajo del empleado/encargado: ");
			int legajo = int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese el sueldo del empleado/encargado: ");
			double sueldo = double.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese la tarea que realiza el empleado/encargado: ");
			string tarea = Console.ReadLine();
			
			string rta; //Almaceno la respuesta del usuario por la bonificacion
			do
			{
				Console.WriteLine("¿Recibe plus? (s/n): ");
				rta = Console.ReadLine().ToLower();
				//Si la respuesta no es s o n
				if(rta != "s" && rta != "n")
				{
					Console.WriteLine("Opcion incorrecta. Por favor ingrese 'S' o 'N'");
				}
			}while(rta != "s" && rta != "n"); //Repito hasta que ingrese la respuesta correcta
			//Si hay bonificacion
			if(rta == "s")
			{
				//Solicito la bonificacion
				Console.WriteLine("Ingrese el plus del encargado: ");
        		double bonificacion = double.Parse(Console.ReadLine());
        		//Creo un objeto encargado y lo agrego a la lista
        		Encargado encargado = new Encargado(nomYape, dni, legajo, sueldo, tarea, bonificacion);
        		salon.ListaEncargados.Add(encargado);
        		Console.WriteLine("El encargado fue agregado con éxito.");
			}
			//Si no hay bonificacion
			else
			{
				//Creo un objeto empleado y lo agrego a la lista
				Empleado empleado = new Empleado(nomYape, dni, legajo, sueldo, tarea);
        		salon.ListaEmpleados.Add(empleado);
       			Console.WriteLine("El empleado fue agregado con éxito.");
			}
		}
//------METODO DAR DE BAJA EMPLEADO O ENCARGADO-------------------------------------------------------------------------------------------------------------------------------------------------------	
		public static void BajaEmpEnc(Salon salon)
		{
			//Solicito saber si elimino un empleado o encargado
			string empOenc = ""; //Almaceno la eleccion del usuario
			while(empOenc != "EMP" && empOenc != "ENC")
			{
				Console.WriteLine("¿Desea dar de baja un EMPLEADO o un ENCARGADO? (EMP/ENC): ");
				empOenc = Console.ReadLine().ToUpper();
				if(empOenc != "EMP" && empOenc != "ENC")
				{
					Console.WriteLine("Opcion incorrecta. Debe ingresar EMP o ENC");
				}
			}
			
			Console.WriteLine("Ingrese el legajo: ");
			int legajo = int.Parse(Console.ReadLine());
			//Si se elige empleado
			if(empOenc == "EMP")
			{
				Empleado empleadoEliminar = null; //Variable que almacena el empleado a eliminar
				//Recorro la lista de empleados
				foreach(Empleado emp in salon.ListaEmpleados)
				{
					//Si el legajo coincide
					if(emp.Legajo == legajo)
					{
						empleadoEliminar = emp; //Almaceno el empleado encontrado
						break;
					}
				}
				//Si se encontro el empleado
				if(empleadoEliminar != null)
				{
					salon.ListaEmpleados.Remove(empleadoEliminar); //Elimino el empleado de la lista
					Console.WriteLine("El empleado fue eliminado correctamente");
				}
				else
				{
					Console.WriteLine("No se encontro ningun empleado con ese N° de legajo");
				}
			}
			//Si se elige encargado
			else
			{
				Encargado EncargadoEliminar = null; //Almaceno al encargado encontrado
				//Recorro la lista de encargados
				foreach(Encargado enc in salon.ListaEncargados)
				{
					//Si el legajo coincide
					if(enc.Legajo == legajo)
					{
						EncargadoEliminar = enc; //Almaceno el encargado encontrado
						break;
					}
				}
				//Si se encontro el encargado
				if(EncargadoEliminar != null)
				{
					salon.ListaEncargados.Remove(EncargadoEliminar); //Elimino el encargado de la lista
					Console.WriteLine("El encargado fue eliminado correctamente");
				}
				else
				{
					Console.WriteLine("No se encontro ningun encargado con ese N° de legajo");
				}
			}
		}
//------METODO CALCULAR COSTO TOTAL-------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public static double CalcularCostoTotal(Evento evento)
		{
			//Calculo el costo total de todos los servicios de un evento
			double total = 0;
			//Recorro la lista de servicios
			foreach(Servicio serv in evento.ListaServicios)
			{
				total += serv.CostoUnitario * serv.Cantidad; //Realizo el calculo costo de un servicio por cantidad
			}
			return total; //Devuelvo el costo total calculado
		}
//------METODO ESTABLECER COSTO TOTAL-----------------------------------------------------------------------------------------------------------------------------------------------------------------
		public static void EstablecerCostoTotal(Evento evento)
		{
			//Establezco el costo total de un evento usando otro metodo
			double total = CalcularCostoTotal(evento); //Obtengo el costo total llamando al metodo
			evento.CostoTotal = total; //Asigno el costo total calculado al atributo costoTotal del evento
		}
//------METODO ESTABLECER SEÑA------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public static void EstablecerSeña(Evento evento)
		{
			//Establece la seña del evento como la mitad del costo total
			evento.Seña = evento.CostoTotal/2; //Calcula la seña dividiendo el costo total por 2
		}
//------METODO ASIGNAR ENCARGADO A EVENTO-------------------------------------------------------------------------------------------------------------------------------------------------------------
		public static void AsignarEncargado(Evento evento, ArrayList listaEncargados, ArrayList listaEventos)
		{
			//Asigno un encargado a un evento, verificando que este disponible en la lista de encargados
			foreach(Encargado enc in listaEncargados)
			{
				bool estaAsignado = false; //Variable que verifica si el encargado ya esta asignado a un evento
				//Recorro la lista de eventos para comprobar si el encargado esta asignado
				foreach(Evento ev in listaEventos)
				{
					//Si el encargado esta asignado
					if(ev.Encargado != null && ev.Encargado.Legajo == enc.Legajo)
					{
						estaAsignado = true; //Marco como asignado
						break;
					}
				}
				//Si el encargado no esta asignado a ningun evento
				if(!estaAsignado)
				{
					evento.Encargado = enc; //Asigno el encargado al evento
					//Console.WriteLine("Encargado {0} asignado al evento", enc.NomYape);
					Console.WriteLine("Encargado {0} asignado al evento", enc.NombreYapellido);
					return;
				}
			}
			
			//Si no se encontro ningun encargado, debemos cargarlo automaticamente nosotros en en momento de la reserva
			Console.WriteLine("No hay encargados disponibles para asignar");
			Console.WriteLine("Debe registrar un encargado para el evento. Por favor, registrelo");
			//Solicito los datos
			Console.WriteLine("Ingrese nombre y apellido del encargado: ");
			string nomYape = Console.ReadLine();
			Console.WriteLine("Ingrese el DNI del encargado: ");
			string dni = Console.ReadLine();
			Console.WriteLine("Ingrese el legajo del encargado: ");
			int legajo = int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese el sueldo del encargado: ");
			double sueldo = double.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese la tarea que desempeña el encargado: ");
			string tarea = Console.ReadLine();
			Console.WriteLine("Ingrese el plus del encargado: ");
			double bonificacion = double.Parse(Console.ReadLine());
			
			//Creo un objeto encargado, lo asigno al evento y lo agrego a la lista de encargados
			Encargado nuevoEncargado = new Encargado(nomYape, dni, legajo, sueldo, tarea, bonificacion);
			evento.Encargado = nuevoEncargado;
			listaEncargados.Add(nuevoEncargado);
			
			Console.WriteLine("Encargado {0} registrado y asignado al evento", nomYape);
		}
//------METODO CREAR O BUSCAR CLIENTE-----------------------------------------------------------------------------------------------------------------------------------------------------------------
		public static Cliente CreoBuscoCliente(Salon salon)
		{
			//Busco si un cliente esta registrado en el salon y, sino lo creo y agrego a la lista de clientes
			Console.WriteLine("Ingrese nombre y apellido del cliente: ");
			string nomYape = Console.ReadLine();
			Console.WriteLine("Ingrese el DNI del cliente: ");
			string dni = Console.ReadLine();
			//Recorro la lista de clientes
			foreach(Cliente cli in salon.ListaClientes)
			{
				//Si el dni coincide
				if(cli.Documento == dni)
				{
					Console.WriteLine("Cliente ya registrado");
					return cli; //Devuelvo el cliente
				}
			}
			//Si el cliente no esta registrado, creo un objeto cliente y lo agrego a la lista
			Cliente nuevoCliente = new Cliente(nomYape, dni);
			salon.ListaClientes.Add(nuevoCliente);
			Console.WriteLine("Cliente agregado con exito");
			return nuevoCliente; //Devuelvo el nuevo cliente
		}
//------METODO SABER SI FECHA ESTA OCUPADA------------------------------------------------------------------------------------------------------------------------------------------------------------
		public static bool FechaOcupada(Salon salon, DateTime fecha)
		{
			//Verifico si una fecha especifica ya esta ocupara para otro evento
			foreach(Evento ev in salon.ListaEventos)
			{
				//Si la fecha coincide
				if(ev.FechaEvento.Date == fecha.Date)
				{
					return true; //Devuelvo que ya se encuentra ocupada
				}
			}
			return false; //Si la fecha no coincide, devuevlo que no esta ocupada
		}
//------METODO RESERVAR EVENTO------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public static void ReservarEvento(Salon salon)
		{
			Cliente cliente = CreoBuscoCliente(salon);
			
			//Arraylist fechas disponibles
			ArrayList fechasDisponibles = new ArrayList()
			{
				new DateTime(2025, 6, 01),
				new DateTime(2025, 6, 10),
				new DateTime(2025, 7, 20),
				new DateTime(2025, 8, 15),
				new DateTime(2025, 9, 08),
				new DateTime(2025, 10, 25),
				new DateTime(2025, 11, 19),
				new DateTime(2026, 1, 15),
				new DateTime(2026, 2, 20),
				new DateTime(2026, 3, 31)
			};
			
			Console.WriteLine("Fechas disponibles para reservar: ");
			
			for(int i = 0; i < fechasDisponibles.Count; i++)
			{
				DateTime f = (DateTime)fechasDisponibles[i];
				Console.WriteLine("{0}. {1}", i+1, f.ToString("dd/MM/yyyy"));
			}
			int opcionFecha = 0;
			DateTime fechaSeleccionada = DateTime.MinValue;
			
			while(true)
			{
				Console.WriteLine("Seleccione una fecha ingresando el numero correspondiente");
				try
				{
					opcionFecha = int.Parse(Console.ReadLine());
					
					if(opcionFecha < 1 || opcionFecha > fechasDisponibles.Count)
					{
						Console.WriteLine("ERROR. Opcion fuera de rango");
					}
					else
					{
						fechaSeleccionada = (DateTime)fechasDisponibles[opcionFecha - 1];
						
						if(FechaOcupada(salon, fechaSeleccionada))
						{
							Console.WriteLine("ERROR. La fecha seleccinada ya esta ocupada");
						}
						else
						{
							break;
						}
					}
				}
				catch(FormatException)
				{
					Console.WriteLine("ERROR. Ingrese un numero valido");
				}
			}
			ArrayList horasDisponibles = new ArrayList()
			{
				new TimeSpan(9, 0, 0),
        		new TimeSpan(11, 0, 0),
        		new TimeSpan(13, 0, 0),
        		new TimeSpan(15, 0, 0),
        		new TimeSpan(17, 0, 0),
        		new TimeSpan(19, 0, 0),
        		new TimeSpan(21, 0, 0),
        		new TimeSpan(23, 0, 0)
			};
			Console.WriteLine("Horas disponibles para reservar: ");
			for(int i = 0; i < horasDisponibles.Count; i++)
			{
				TimeSpan h = (TimeSpan)horasDisponibles[i];
				Console.WriteLine("{0}. {1}", i + 1, h.ToString(@"hh\:mm"));
			}
			int opcionHora;
			TimeSpan horaSeleccionada;
			while(true)
			{
				Console.WriteLine("Seleccione hora (1-{0}): ",horasDisponibles.Count);
				try
				{
					opcionHora = int.Parse(Console.ReadLine());
					if(opcionHora <1 || opcionHora > horasDisponibles.Count)
					{
						Console.WriteLine("ERROR. Opcion fuera de rango");
						continue;
					}
					horaSeleccionada = (TimeSpan)horasDisponibles[opcionHora - 1];
					break;
				}
				catch(FormatException)
				{
					Console.WriteLine("ERROR. Ingrese un numero valido");
				}
			}
			
			Console.WriteLine("Ingrese el tipo de evento que desea reservar: ");
			string tipo = Console.ReadLine();
			
			Evento nuevoEvento = new Evento(cliente.NombreYapellido, cliente.Documento, fechaSeleccionada, horaSeleccionada, tipo, null, 0, 0);
			
			string r = "";
			while(r != "s" && r != "n")
			{
				Console.WriteLine("¿Desea agregar servicios al evento? (s/n): ");
				r = Console.ReadLine().ToLower();
				if(r != "s" && r != "n")
				{
					Console.WriteLine("Opcion incorrecta. Ingrese 's' o 'n'");
				}
			}
			if(r == "s")
			{
				SeleccionarServiciosParaEvento(nuevoEvento, salon);
			}
			else
			{
				Console.WriteLine("No se agregaron servicios al evento");
			}
			AsignarEncargado(nuevoEvento, salon.ListaEncargados, salon.ListaEventos);
			EstablecerCostoTotal(nuevoEvento);
			EstablecerSeña(nuevoEvento);
			
			Evento eventoFinal = new Evento(nuevoEvento.NombreCliente, nuevoEvento.DniCliente, nuevoEvento.FechaEvento, nuevoEvento.HoraEvento, nuevoEvento.TipoEvento, nuevoEvento.Encargado, nuevoEvento.CostoTotal, nuevoEvento.Seña);
			foreach(Servicio serv in nuevoEvento.ListaServicios)
			{
				eventoFinal.ListaServicios.Add(serv);
			}
			salon.ListaEventos.Add(eventoFinal);
			Console.WriteLine("Evento reservado con exito");
			Console.WriteLine("Costo total del evento: {0}", eventoFinal.CostoTotal);
			Console.WriteLine("Monto total de la seña: ${0}", eventoFinal.Seña);
		}
//------METODO CARGAR SERVICIOS AL EVENTO-------------------------------------------------------------------------------------------------------------------------------------------------------------
		public static void SeleccionarServiciosParaEvento(Evento evento, Salon salon)
		{
			string seguir;
			do
			{
				Console.WriteLine("Servicios disponibles: ");
				for(int i = 0; i < salon.ListaServicios.Count; i++)
				{
					Servicio s = (Servicio)salon.ListaServicios[i];
					Console.WriteLine("{0}. {1} - {2}", i+1, s.Nombre, s.Descripcion);
				}
				int index = 0;
				while(true)
				{
					Console.WriteLine("Seleccione el servicio por numero: ");
					try
					{
						index = int.Parse(Console.ReadLine());
						if(index < 1 || index > salon.ListaServicios.Count)
						{
							Console.WriteLine("ERROR. Numero fuera de rango");
						}
						else
						{
							break;
						}
					}
					catch(FormatException)
					{
						Console.WriteLine("ERROR. Ingrese un numero valido");
					}
				}
				Servicio plantilla = (Servicio)salon.ListaServicios[index - 1];
				
				int cantidad = 0;
				while(true)
				{
					Console.WriteLine("¿Cuantos '{0}' desea agregar?", plantilla.Nombre);
					try
					{
						cantidad = int.Parse(Console.ReadLine());
						if(cantidad > 0) break;
						Console.WriteLine("ERROR. La cantidad debe ser mayor a cero");
					}
					catch(FormatException)
					{
						Console.WriteLine("ERROR. Debe ingresar un numero valido");
					}
				}
				double costoUnitario = 0;
				while(true)
				{
					Console.WriteLine("Indique el costo unitario para '{0}': ", plantilla.Nombre);
					try
					{
						costoUnitario = double.Parse(Console.ReadLine());
						if(costoUnitario >= 0) break;
						Console.WriteLine("ERROR. El costo debe ser mayor o igual a 0");
					}
					catch(FormatException)
					{
						Console.WriteLine("ERROR. Debe ingresar un numero valido");
					}
				}
				Servicio servSeleccionado = new Servicio(plantilla.Nombre, plantilla.Descripcion, cantidad, costoUnitario);
				evento.ListaServicios.Add(servSeleccionado);
				Console.WriteLine("Servicio '{0}' agregado al evento", plantilla.Nombre);
				
				seguir = "";
				while(seguir != "s" && seguir != "n")
				{
					Console.WriteLine("¿Desea agregar otro servicio al evento? (s/n): ");
					seguir = Console.ReadLine().ToLower();
					if(seguir != "s" && seguir != "n")
					{
						Console.WriteLine("Opcion incorrecta. Ingrese 's' o 'n'");
					}
				}
			} while(seguir == "s");
		}
//------METODO CANCELAR EVENTO------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public static void CancelarEvento(Salon salon)
		{
			//Solicito cancelar el evento mediante el DNI del usuario
			Console.WriteLine("CANCELAR EVENTO");
			Console.WriteLine("Ingrese el DNI del cliente que desea cancelar el evento: ");
			string dni = Console.ReadLine();
			//Busco al cliente en la lista del salon usando un metodo
			Cliente cliente = BuscarClientePorDni(salon, dni);
			//Si el cliente no existe
			if(cliente == null)
			{
				Console.WriteLine("No se encontro un cliente con ese DNI");
				return;
			}
			//Busco el evento asociado al cliente usando un metodo
			Evento evento = BuscarEventoPorDni(salon, dni);
			//Si el evento no esta registrado
			if(evento == null)
			{
				Console.WriteLine("No se encontro ningun evento registrado para ese cliente");
				return;
			}
			//Calculo cuantos dias faltan para el evento
			int diasAnticipacion = CalcularDiasAnticipacion(evento.FechaEvento);
			Console.WriteLine(string.Format("El evento está registrado para el día {0:dd/MM/yyyy} ({1} días de anticipación)", evento.FechaEvento, diasAnticipacion));
			//Console.WriteLine($"El evento está registrado para el día {evento.FechaEvento:dd/MM/yyyy} ({diasAnticipacion} días de anticipación)");
			//Console.WriteLine("El evento esta registrado para el dia {0}/{1}/{2} ({3} dias de anticipacion)", evento.FechaEvento.Day, evento.FechaEvento.Month, evento.FechaEvento.Year, diasAnticipacion);		
			//Si son mas de 30 dias de anticipacion
			if(diasAnticipacion > 30)
			{
				Console.WriteLine("El evento se cancelara con mas de 30 dias de anticipacion. No se reintegra la seña");
				Console.WriteLine("Solo se paga la seña: ${0}", evento.Seña);

			}
			//Si son menos de 30 dias de anticipacion
			else
			{
				Console.WriteLine("El evento se cancelara con menos de 30 dias de anticipacion. Se cobrara el servicio completo");
				Console.WriteLine("Costo total: {0}", evento.CostoTotal);
			}
			//Elimino el evento de la lista
			salon.ListaEventos.Remove(evento);
			Console.WriteLine("El evento fue cancelado y eliminado de la lista");
		}
//------METODO BUSCAR CLIENTE POR DNI-----------------------------------------------------------------------------------------------------------------------------------------------------------------
		public static Cliente BuscarClientePorDni(Salon salon, string dni)
		{
			//Busco un cliente en la lista de clientes del salon por el DNI
			foreach(Cliente cli in salon.ListaClientes)
			{
				//Si el dni coincide
				if(cli.Documento == dni)
				{
					return cli; //Devuelvo el cliente
				}
			}
			return null; //Si no encuentro un cliente, retorno null;
		}
//------METODO BUSCAR EVENTO POR DNI------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public static Evento BuscarEventoPorDni(Salon salon, string dni)
		{
			//Busco un evento en la lista de eventos del salon por el DNI
			foreach(Evento ev in salon.ListaEventos)
			{
				//Si el DNI coincide
				if(ev.DniCliente == dni)
				{
					return ev; //Devuelvo el evento
				}
			}
			return null; //Si no encuentro un evento, retorno null;
		}
//------METODO CALCULO DIAS---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public static int CalcularDiasAnticipacion(DateTime fechaEvento)
		{
			//Calculo la cantidad de dias entre la fecha actual y la fecha del evento
			DateTime fechaActual = DateTime.Today; //Recibo la fecha actual
			TimeSpan diferenciaDias = fechaEvento - fechaActual; //Realizo el calculo de diferencia de dias
			return diferenciaDias.Days; //Devuelvo la cantidad de dias de diferencia
		}
//------METODOS SUBMENU-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//------METODO MOSTRAR EVENTOS------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public static void MostrarEventos(Salon salon)
		{
			//Muestro la lista de eventos del salon
			Console.WriteLine("----------------------------------------");
			Console.WriteLine("Listado de eventos: ");
			//Si no hay eventos registrados
			if(salon.ListaEventos.Count == 0)
			{
				Console.WriteLine("No hay eventos registrados");
				return;
			}
			//Recorro la lista de eventos y muestro los datos de cada uno
			foreach(Evento ev in salon.ListaEventos)
			{
				string encargado; //Almaceno el nombre del encargado
				//Si el evento tiene un encargado
				if(ev.Encargado != null)
				{
					encargado = ev.Encargado.NombreYapellido;
					//encargado = ev.Encargado.NomYape; //Se asigna el nombre correspondiente
				}
				//Si el evento no tiene un encargado
				else
				{
					encargado = "Sin asignar";
				}
				//Console.WriteLine("- {0} | Cliente: {1} | | DNI: {7} | Fecha: {2} | Hora: {3} | Encargado: {4} | Costo: {5} | Seña: {6}", ev.TipoEvento, ev.NombreCliente, ev.FechaEvento.ToString("dd/MM/yyyy"), ev.HoraEvento, encargado, ev.CostoTotal, ev.Seña, ev.DniCliente);
				Console.WriteLine("{0}", ev.TipoEvento);
				Console.WriteLine("Cliente: {0}", ev.NombreCliente);
				Console.WriteLine("DNI: {0}", ev.DniCliente);
				Console.WriteLine("Fecha del Evento: {0}", ev.FechaEvento.ToString("yy-MM-dd"));
				Console.WriteLine("Hora: {0}", ev.HoraEvento);
				Console.WriteLine("Encargado: {0}", encargado);
				Console.WriteLine("Costo total: {0}", ev.CostoTotal);
				Console.WriteLine("Seña: {0}", ev.Seña);
			}
		}
//------METODO MOSTRAR CLIENTES-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public static void MostrarClientes(Salon salon)
		{
			//Muestro la lista de clientes del salon
			Console.WriteLine("----------------------------------------");
			Console.WriteLine("Listado de clientes: ");
			//Si no hay clientes registrados
			if(salon.ListaClientes.Count == 0)
			{
				Console.WriteLine("No hay clientes registrados");
				return;
			}
			//Recorro la lista y muestro los datos de cada uno
			foreach(Cliente cli in salon.ListaClientes)
			{
				//Console.WriteLine("- {0} | DNI: {1}", cli.NombreYapellido, cli.Documento);
				Console.WriteLine("Cliente: {0}", cli.NombreYapellido);
				Console.WriteLine("DNI: {0}", cli.Documento);
			}
		}
//------METODO MOSTRAR EMPLEADOS----------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public static void MostrarEmpleados(Salon salon)
		{
			//Muestro la lista de empleados del salon
			Console.WriteLine("----------------------------------------");
			Console.WriteLine("Listado de empleados: ");
			//Si no hay empleados registrados
			if(salon.ListaEmpleados.Count == 0)
			{
				Console.WriteLine("No hay empleados registrados");
				return;
			}
			//Recorro la lista y muestro los datos de cada uno
			foreach(Empleado emp in salon.ListaEmpleados)
			{
				//Console.WriteLine("- {0} | DNI: {1} | Legajo: {2} | Sueldo: ${3} | Tarea: {4} ", emp.NomYape, emp.Dni, emp.Legajo, emp.Sueldo, emp.Tarea);
				//Console.WriteLine("Empleado: {0}", emp.NomYape);
				//Console.WriteLine("DNI: {0}", emp.Dni);
				Console.WriteLine("Empleado: {0}", emp.NombreYapellido);
				Console.WriteLine("DNI: {0}", emp.Documento);
				Console.WriteLine("Legajo: {0}", emp.Legajo);
				Console.WriteLine("Sueldo: ${0}", emp.Sueldo);
				Console.WriteLine("Tarea: {0}", emp.Tarea);
			}
		}
//------METODO MOSTRAR EVENTOS POR MES----------------------------------------------------------------------------------------------------------------------------------------------------------------
		public static void MostrarEventosPorMes(Salon salon)
		{
			//Muestro la lista de eventos por mes determinado
			Console.WriteLine("----------------------------------------");
			Console.WriteLine("Listado de eventos en determinado mes");
			int mes; //Almaceno el mes ingresado por el usuario
			//Bucle para asegurar que el usuario ingrese un mes valido
			while(true)
			{
				try
				{
					Console.WriteLine("Ingrese el numero del mes (1-12): ");
					mes = int.Parse(Console.ReadLine());
				
					if(mes >= 1 && mes <= 12)
					{
						break;
					}
					else
					{
						Console.WriteLine("ERROR. Tiene que ingresar un mes valido");
					}
				}
				catch(FormatException)
				{
					Console.WriteLine("ERROR. Tiene que ingresar un numero valido");
				}
			}
			bool hayEventosDeterminados = false;
			//Recorro la lista de eventos y muestro los que coinciden con el mes ingresado
			foreach(Evento ev in salon.ListaEventos)
			{
				if(ev.FechaEvento.Month == mes)
				{
					hayEventosDeterminados = true;
					
					string encargado; //Almaceno el nombre del encargado
					//Si el encargado esta registrado
					if(ev.Encargado != null)
					{
						encargado = ev.Encargado.NombreYapellido; 
						//encargado = ev.Encargado.NomYape; //Se asigna el nombre correspondiente
					}
					//Si el evento no tiene un encargado
					else
					{
						encargado = "Sin asignar";
					}
					//Console.WriteLine("- {0} | Cliente: {1} | Fecha: {2} | Hora: {3} | Encargado: {4} | Costo: {5} | Seña: {6}", ev.TipoEvento, ev.NombreCliente, ev.FechaEvento.ToString("dd/MM/yyyy"), ev.HoraEvento, encargado, ev.CostoTotal, ev.Seña);
					Console.WriteLine("{0}", ev.TipoEvento);
					Console.WriteLine("Cliente: {0}", ev.NombreCliente);
					Console.WriteLine("DNI: {0}", ev.DniCliente);
					Console.WriteLine("Fecha del Evento: {0}", ev.FechaEvento.ToString("yy-MM-dd"));
					Console.WriteLine("Hora: {0}", ev.HoraEvento);
					Console.WriteLine("Encargado: {0}", encargado);
					Console.WriteLine("Costo total: {0}", ev.CostoTotal);
					Console.WriteLine("Seña: {0}", ev.Seña);
				}
			}
			//Si no hay eventos en el mes determinado
			if(!hayEventosDeterminados)
			{
				Console.WriteLine("----------------------------------------");
				Console.WriteLine("No hay eventos registrados para este mes");
			}
		}
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	}
}