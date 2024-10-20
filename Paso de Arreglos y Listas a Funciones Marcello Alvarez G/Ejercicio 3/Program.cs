using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var diccionario = crearDiccionario();

        Console.WriteLine("Modo de traducción: Ingrese palabras en inglés para traducir al español.");
        Console.WriteLine("Escriba 'salir' para terminar.");

        string palabra;
        while (true)
        {
            Console.Write("Ingrese una palabra en inglés: ");
            palabra = Console.ReadLine();

            if (palabra.ToLower() == "salir")
            {
                break;
            }

            string traduccion = traducir(diccionario, palabra);
            if (traduccion != null)
            {
                Console.WriteLine($"La traducción de '{palabra}' es '{traduccion}'.");
            }
            else
            {
                Console.WriteLine($"La palabra '{palabra}' no se encuentra en el diccionario.");
            }
        }
    }

    static Dictionary<string, string> crearDiccionario()
    {
        var diccionario = new Dictionary<string, string>();
        string[,] parejas = new string[5, 2];

        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Ingrese la palabra en inglés para la pareja {i + 1}: ");
            parejas[i, 0] = Console.ReadLine();

            Console.Write($"Ingrese la traducción en español para '{parejas[i, 0]}': ");
            parejas[i, 1] = Console.ReadLine();

            diccionario.Add(parejas[i, 0], parejas[i, 1]);
        }

        return diccionario;
    }

    static string traducir(Dictionary<string, string> diccionario, string palabra)
    {
        if (diccionario.TryGetValue(palabra, out string traduccion))
        {
            return traduccion;
        }
        return null;
    }
}

