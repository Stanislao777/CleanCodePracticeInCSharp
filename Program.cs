using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; } = TaskList = new List<string>();

        static void Main(string[] args)
        {
            //inicializa la tarea cuando es null, ahora se lleva arriba después de = 
            //TaskList = new List<string>();
            int menuSelected = 0;
            do
            {
                menuSelected = ShowMainMenu();
                if ((Menu)menuSelected == Menu.Add)
                {
                    ShowMenuAdd();
                }
                else if ((Menu)menuSelected == Menu.Remove)
                {
                    ShowMenuRemove();
                }
                else if ((Menu)menuSelected == Menu.List)
                {
                    ShowMenuMostrar();
                }
            } while ((Menu)menuSelected != Menu.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string line = Console.ReadLine();
            return Convert.ToInt32(line);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                ShowMenuMostrar();

                string line = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(line) - 1;

                if (indexToRemove > (TaskList.Count -1) || indexToRemove < 0) 
                Console.WriteLine("Numero de tarea seleccionado no es validdo");
                else
                {
                    if (indexToRemove > -1 && TaskList.Count > 0)
                    {
                        string taskToRemove = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine("Tarea " + taskToRemove + " eliminada");
                
                    }                    
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string task = Console.ReadLine();
                TaskList.Add(task);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuMostrar()
        {
            //mejorando código
            //if (TaskList == null || TaskList.Count == 0) luego se invierten valores
            if (TaskList?.Count > 0) //si es null o es mayor a cero
            {
                Console.WriteLine("----------------------------------------");
                var indexTask=0;                
                TaskList.ForEach(p=>Console.WriteLine($"{++indexTask} . {p}"));

                Console.WriteLine("----------------------------------------");
            } 
            else
            {
                /*Console.WriteLine("----------------------------------------");
                // Refactorizando código
                //for (int i = 0; i < TaskList.Count; i++)
                //{
                //    Console.WriteLine((i + 1) + ". " + TaskList[i]);
                //}
                var indexTask=0;
                //Mejorando código de interpolación de cadenas (cuando lleva ++ por delante de la variable es un preincremento)
                TaskList.ForEach(p=>Console.WriteLine($"{++indexTask} . {p}"));
                Console.WriteLine("----------------------------------------");*/
                Console.WriteLine("No hay tareas por realizar");
            }
        }
    }

    public enum Menu
    {
        Add = 1,

        Remove = 2,

        List = 3,

        Exit = 4
    }
}
