using System;
class Prueba
{
	private int nadador;
	private DateTime diaPrueba;
	private int puntosObtenidos;
	//---------------------------------------
	public int Nadador
    {
		get { return nadador; }
		set { nadador = value; }
    }
	public int Puntos
    {
        get { return puntosObtenidos;  }
        set { puntosObtenidos = value; } 
    }
	public string ToString
    {
		mensaje ="Nadador número "+nadador+" realizó prueba el "; 
		mensaje +=diaPrueba.ToString("dd-MM-yyyy");
		mensaje+=" obteniendo los "+Puntos+" puntos" 
		return mensaje;
}
class Nadador
{
	private string nombreCompleto;
	private int escuela;
	//------------------------------------------
	public string Nombre
    {
		set { nombreCompleto = value };
		get { return nombreCompleto; };
    }
	public int Escuela
    {
		set { escuela = value; };
		get { return escuela };
    }
	public string ToString
    {
		return nombreCompleto;
    }
}
class Escuela
{
	private string nombreEscuela;
	private string direccion;
	private int puntosObtenidos;
	//-------------------------------------
	public string Nombre
    {
		set { nombreEscuela = value; };
		get { return nombreEscuela; };
    } 
	public string Direccion
    {
		set { direccion = value; };
		get { return direccion; };
    }
	public int Puntos
    {
		set { puntosObtenidos = value; };
		get { return puntosObtenidos; };
    }
	public string ToString
    {
		return Nombre;
    }
}
public class Competencia
{
	private Prueba[] NivelEscuela;
	private int PruebasE;
	private Prueba[] MasterPromocional;
	private int PruebasMr;
	private Nadador[] CompetidorNEscuela;
	private int NivelE;
	private Nadador[] CompetidorMastProm;
	private int NivelMP;
	private Escuela[] CompiteEscuela;
	private int NEscuelas;
	//--------------------------------------------------
	public const int NIVEL_ESCUELA = 1;
	public const int NIVEL_MASTER = 2;

	public Competencia()
	{
		NivelEscuela = new Prueba[10];
		PruebasE = 0;
		MasterPromocional = new Prueba[10];
		PruebasM = 0;
		CompetidorNEscuela = new Nadador[10];
		NivelE = 0;
		CompetidorMastProm = new Nadador[10];
		NivelMP = 0;
		CompiteEscuela = new Escuela[10];
		NEscuelas = 0;

		for(int i=0;i<10; i++)//--- Para evitar que los arreglos estén en null
        {
			NivelEscuela[i] = new Prueba;
			MasterPromocional[i] = new Prueba;
			CompetidorNEscuela[i] = new Nadador;
			CompetidorMastProm[i] = new Nadador;
			CompiteEscuela[i] = new Escuela;
        }
	}//--fin constructor 
	private int inscripcion(Escuela Representada)//--- Este método agrega una escuela a la lista de escuelas registradas
	{
		int SePudo = -2;

		//-- Para agregar primero vemos si hay espacio.
		if (NEscuelas < 10)
		{
			SePudo = NEscuelas;
			CompiteEscuela[NEscuelas++] = Representada;
		}
		else SePudo = -1;
		return SePudo;
	}
	private string[] EscuelaInscrita()//--- Este método arroja una lista de cadenas que corresponde a la lista de escuelas registradas
    {
		string[] salida = new string[NEscuelas];
		for (int i=0; i < NEscuelas;i++)
        {
			salida[i] = new string();
			salida[i] = i.ToString+"- "+CompiteEscuela[i].ToString;
        }
		return salida;
    }
	public string inscripcion(Nadador compite, int nivel, Escuela representa)// este método agrega un registro de un competidor
    {
		int resultado = 0;
		string estado = "";

		resultado = inscripcion(representa);
		if (resultado > -1)
			compite.Escuela = resultado;
		else estado ="La escuela no se pudo registrar. "
		//--primero observamos el nivel
		if (nivel == NIVEL_ESCUELA)
        {
			if (NivelE < 10)
			{
				CompetidorNEscuela[NivelE++] = compite;
			}
			else 
			{
				estado += "No se pudo inscribir, el límite se ha excedido";
				resultado = 1;
			}
			
        }else if(nivel == NIVEL_MASTER)
        {
			if (NivelE < 10)
			{
				CompetidorMastProm[NivelMP++] = compite;
			}
			else
			{
				estado += "No se pudo inscribir, el límite se ha excedido";
				resultado = 1;
			}
		}
		
			
		if (resultado != 0) estado += " La escuela no se pudo registrar";
		return estado;
    }
	public inscripcion(Nadador compite, int nivel, int representa)// este método agrega un registro de un competidor
	{
		int resultado = 0;
		string estado = "";

		compite.Escuela = representa;
		//--primero observamos el nivel
		if (nivel == NIVEL_ESCUELA)
		{
			if (NivelE < 10)
			{
				CompetidorNEscuela[NivelE++] = compite;
			}
			else
			{
				estado = "No se pudo inscribir, el límite se ha excedido";
				resultado = 1;
			}

		}
		else if (nivel == NIVEL_MASTER)
		{
			if (NivelE < 10)
			{
				CompetidorMastProm[NivelMP++] = compite;
			}
			else
			{
				estado = "No se pudo inscribir, el límite se ha excedido";
				resultado = 1;
			}
		}
	}
		public int Anotacion( int nivel, int competidor, int puntos)//--- Este método registra los puntos obtenidos por un nadador
    {
		Prueba anotacion = new Prueba();
		anotacion.Nadador = competidor;
		anotacion.Puntos = puntos;
		int SePudo = 1;

		if(nivel == NIVEL_ESCUELA)
        {
			if (PruebasE < 10)
			{
				NivelEscuela[PruebasE++] = anotacion;
			}
			else SePudo = -1; //--- Si no se puede es porque se excede de lugares en las anotaciones de la prueba.
        }else if(nivel == NIVEL_MASTER)
        {
			if (PruebasMP < 10)
			{
				NivelMastPro[PruebasMP++] = anotacion;
			}
			else SePudo = -1; //--- Si no se puede es porque se excede de lugares en las anotaciones de la prueba.
		}
		return SePudo;
    }
}
