using System;

public class MenuH
{
	private string[] Opciones;
    private int[] Coord_x;
    private int MaxOpciones;
	public MenuH(string[] opciones, int[] coordenadas, int cuantas )
	{
        MaxOpciones = cuantas;
        Opciones = new string[cuantas];
        Coord_x = new int[cuantas];
        for (int i= 0; i<cuantas; i++)
        {
            Coord_x[i] = coordenadas[i];
            Opciones[i] = opciones[i];
        }
	}
	public int Menu(int renglon)
    {
        int opcion_menu = 1;
        char tecla;

        do
        {
            for ( int i= 0; i<MaxOpciones; i++)//-- Aquí se despliegan las opciones.
            {
                Console.SetCursorPosition( Coord_x[i], renglon);
                if (opcion_menu == i+1)
                    Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(Opciones[i]);
                Console.ForegroundColor = ConsoleColor.White;
            }
      
            tecla = (char)Console.ReadKey().Key;//leemos una tecla
            switch (tecla)
            {
                case (char)ConsoleKey.LeftArrow:
                    if (opcion_menu == 1) opcion_menu = MaxOpciones; else opcion_menu--;
                    break;
                case (char)ConsoleKey.RightArrow:
                    if (opcion_menu == MaxOpciones) opcion_menu = 1; else opcion_menu++;
                    break;
            }
        } while (tecla != (char)ConsoleKey.Escape && tecla != (char)ConsoleKey.Enter);
        if (tecla == (char)ConsoleKey.Escape)
            opcion_menu = 0;
        return opcion_menu;
    }
}
public class MenuV
{
    private string[] Opciones;
    private int Coord_y;
    private int MaxOpciones;

    public MenuV(string[] opciones, int renglon, int cuantas)
    {
        MaxOpciones = cuantas;
        Opciones = new string[cuantas];
        Coord_y = renglon;
        for (int i = 0; i < cuantas; i++)
        {
           Opciones[i] = opciones[i];
        }
    }
    public int Menu(int columna)
    {
        int opcion_menu = 1;
        char tecla;

        do
        {
            for (int i = 0; i < MaxOpciones; i++)//-- Aquí se despliegan las opciones.
            {
                Console.SetCursorPosition( columna, Coord_y + i );
                if (opcion_menu == i+1)
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(Opciones[i]);
                Console.ForegroundColor = ConsoleColor.White;
            }

            tecla = (char)Console.ReadKey().Key;//leemos una tecla
            switch (tecla)
            {
                case (char)ConsoleKey.UpArrow:
                    if (opcion_menu == 1) opcion_menu = MaxOpciones; else opcion_menu--;
                    break;
                case (char)ConsoleKey.DownArrow:
                    if (opcion_menu == MaxOpciones) opcion_menu = 1; else opcion_menu++;
                    break;
            }
        } while (tecla != (char)ConsoleKey.Escape && tecla != (char)ConsoleKey.Enter);
        if (tecla == (char)ConsoleKey.Escape)
            opcion_menu = 0;

        for (int i = 0; i < MaxOpciones; i++)//-- Aquí se despliegan las opciones.
        {
            Console.SetCursorPosition(columna, Coord_y + i);
           
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                          ");
        }
        return opcion_menu;
    }
}