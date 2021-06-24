using System;


namespace Natacion
{
    
    class Program
    {
        static void Reporte_NivelEscuela()
        {

        }
        static void Reporte_MasterPromocional()
        {

        }
        static void Reporte_Escuelas()
        {

        }
        static void Formulario4()
        {
            MenuV MenuResultados;
            string[] opciones;
            int seleccion;

            opciones = new string[3];
            opciones[0] = "Nivel Escuela";
            opciones[1] = "Master Promocional";
            opciones[2] = "Escuelas";
            MenuResultados = new MenuV(opciones, 3, 3);

            seleccion = MenuResultados.Menu(60);

            switch (seleccion)
            {
                case 1:
                    Reporte_NivelEscuela();
                    break;
                case 2:
                    Reporte_MasterPromocional();
                    break;
                case 3:
                    Reporte_Escuelas();
                    break;
            }
            

        }
        static void Formulario3()
        {

        }
        static void Formulario2(ref Competencia Torneo)
        {
            string Nombre_part, Nombre_Escuela, Direcc_Escuela, Categoria;
            Nadador competidorNuevo = new Nadador();
            Escuela nuevaEscuela = new Escuela();
            bool esNumero = false;
            int esc, nivel, cuantasSon;
            string[] inscritas;
            string[] opciones_salir;
            MenuV MenuGuardaoSale;
            int selecciono;
            bool SigueInscribiendo;

            do
            {
                SigueInscribiendo = false;

                Console.SetCursorPosition(1, 4);
                Console.WriteLine("Participante (Nombre completo):                       ");

                Console.SetCursorPosition(1, 5);
                Console.WriteLine("Escuela que representa:                           ");

                Console.SetCursorPosition(1, 6);
                Console.WriteLine("Direción postal de la escuela:                    ");

                Console.SetCursorPosition(1, 7);
                Console.WriteLine("Categoría de participación:                    ");

                Console.SetCursorPosition(60, 4);
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Escuelas ya registradas:   ");
                //------------------------------------------------- Aquí verificamos las escuelas inscritas
                inscritas = Torneo.EscuelaInscrita();
                cuantasSon = inscritas.GetLength(0);
                for (int i = 0; i < 9; i++)
                {
                    Console.SetCursorPosition(60, 5 + i);
                    if (i < cuantasSon)//--- Si está en rango poner la escuela
                    {
                        Console.WriteLine(inscritas[i]);
                    }
                    else Console.WriteLine("                           ");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;



                //-- Aqui va el ciclo que despliega en pantalla las escuelas ya registradas
                //-----------------------------------------------------------------------
                Console.SetCursorPosition(32, 4);
                Nombre_part = Console.ReadLine();

                Console.SetCursorPosition(25, 5);
                Nombre_Escuela = Console.ReadLine();

                Console.SetCursorPosition(32, 6);
                Direcc_Escuela = Console.ReadLine();

                Console.SetCursorPosition(28, 20);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Escriba un 1 para Nivel Escuela y un 2 para Master Promocional");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(28, 7);
                Categoria = Console.ReadLine();

                Console.SetCursorPosition(28, 20);
                Console.WriteLine("                                                                ");

                Console.SetCursorPosition(1, 9);
                Console.ForegroundColor = ConsoleColor.Cyan;

                competidorNuevo.Nombre = Nombre_part;
                esNumero = Int32.TryParse(Categoria, out nivel);//-- convertir a número la categoría
                esNumero = Int32.TryParse(Nombre_Escuela, out esc);//-- intentar convertir el Nombre de la Escuela en número

                opciones_salir = new string[4];
                opciones_salir[0] = "Guardar y seguir inscribiendo";
                opciones_salir[1] = "Guardar y salir";
                opciones_salir[2] = "Cancelar y seguir inscribiendo";
                opciones_salir[3] = "Cancelar y salir";

                MenuGuardaoSale = new MenuV(opciones_salir, 15, 4);
                selecciono = MenuGuardaoSale.Menu(10);

                switch (selecciono)
                {
                    case 1://------------ Guardar y seguir inscribiendo
                        SigueInscribiendo = true;
                        if (esNumero)//-- Si Nombre_Escuela es un número quiere decir que la escuela ya se registró
                        {
                            Torneo.Inscripcion(competidorNuevo, nivel, esc);
                        }
                        else//--- La escuela es nueva
                        {
                            nuevaEscuela.Nombre = Nombre_Escuela;
                            nuevaEscuela.Direccion = Direcc_Escuela;
                            Torneo.inscripcion(competidorNuevo, nivel, nuevaEscuela);
                        }
                        break;
                    case 2://------------ Guardar y salir
                        if (esNumero)//-- Si Nombre_Escuela es un número quiere decir que la escuela ya se registró
                        {
                            Torneo.Inscripcion(competidorNuevo, nivel, esc);
                        }
                        else//--- La escuela es nueva
                        {
                            nuevaEscuela.Nombre = Nombre_Escuela;
                            nuevaEscuela.Direccion = Direcc_Escuela;
                            Torneo.inscripcion(competidorNuevo, nivel, nuevaEscuela);
                        }
                        break;
                    case 3://------------ Cancelar y seguir inscribiendo;
                        SigueInscribiendo = true;
                        break;
                    case 4://------------ Cancelar y salir
                        break;
                }

            } while (SigueInscribiendo);

        }
        static int Formulario1()// este es el menú principal
        {
            //int opcion_menu = 1;//--- para controlar las opciones que se seleccionan
            //char tecla;
            MenuH MenuPrincipal;
            string[] opciones;
            int[] columnas;

            Console.Clear();
            int maxcolumnas = Console.LargestWindowWidth;
            int centro = maxcolumnas / 4;
            Console.SetCursorPosition(centro - 9, 1);
            //-------------------------------------- TITULO DEL SISTEMA -------------------------------------------
            Console.WriteLine("Torneo de Natacion");
            opciones = new string[3];
            opciones[0] = "Inscripciones";
            opciones[1] = "Anotaciones de la competencia";
            opciones[2] = "Resultados";
            columnas = new int[3];
            columnas[0] = 1;
            columnas[1] = 23;
            columnas[2] = 60;
            MenuPrincipal = new MenuH(opciones, columnas, 3);

            return MenuPrincipal.Menu(2);

            //------------------------------------- OPCIONES PRINCIPALES -----------------------------------------
            //do
            //{
            //    Console.SetCursorPosition(1, 2);
            //    if(opcion_menu==1)
            //       Console.ForegroundColor = ConsoleColor.Cyan;
            //   Console.WriteLine("Inscripciones");
            //   
            //   Console.ForegroundColor = ConsoleColor.White;
            //   Console.SetCursorPosition(23, 2);
            //   if(opcion_menu==2)
            //       Console.ForegroundColor = ConsoleColor.Cyan;
            //   Console.WriteLine("Anotaciones de la competencia");
            //
            //   Console.ForegroundColor = ConsoleColor.White;
            //   Console.SetCursorPosition(60, 2);
            //   if(opcion_menu==3)
            //       Console.ForegroundColor = ConsoleColor.Cyan;
            //   Console.WriteLine("Resultados");
            //
            //   Console.ForegroundColor = ConsoleColor.White;
            //   tecla = (char)Console.ReadKey().Key;//leemos una tecla
            //   switch (tecla)
            //   {
            //       case (char)ConsoleKey.LeftArrow:
            //           if (opcion_menu == 1) opcion_menu = 3; else opcion_menu--;
            //           break;
            //       case (char)ConsoleKey.RightArrow:
            //           if (opcion_menu == 3) opcion_menu = 1; else opcion_menu++;
            //           break;
            //   }
            //while (tecla != (char)ConsoleKey.Escape  && tecla != (char) ConsoleKey.Enter);
            //if (tecla == (char)ConsoleKey.Escape)
            //   opcion_menu = 0;
            //return opcion_menu;
        }
        static void Main(string[] args)
        {
            int seleccion;
            Competencia Torneo = new Competencia();

            do
            {


                seleccion = Formulario1();

                switch (seleccion)
                {
                    case 1:
                        Formulario2(ref Torneo); //--Inscripciones
                        break;
                    case 2:
                        Formulario3();//--Anotaciones de la competencia
                        break;
                    case 3:
                        Formulario4();// activar menú de opciones de reporte
                        break;
                }
            } while (seleccion == 0);
           
        }
    }
}
