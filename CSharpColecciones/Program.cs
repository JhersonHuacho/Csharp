using System;
using System.Collections.Generic;

namespace CSharpColecciones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // arreglo o vector
            int[] listaDeNumeros = new int[5];
            listaDeNumeros[0] = 1;
            listaDeNumeros[1] = 2;
            listaDeNumeros[2] = 3;
            listaDeNumeros[3] = 4;
            listaDeNumeros[4] = 5;

            int[] listaDeNumerosDos = new int[5] { 0,1,2,3,4};


            for (int i = 0; i < listaDeNumeros.Length; i++)
            {
                Console.WriteLine("Ingrese un número");
                listaDeNumeros[i] = int.Parse(Console.ReadLine());
            }

            int cantidadNumeros = listaDeNumeros.Length - 1;

            while(cantidadNumeros >= 0)
            {
                Console.WriteLine($"{listaDeNumeros[listaDeNumeros.Length - 1 - cantidadNumeros]}");
                cantidadNumeros -= 1;
            }

            foreach (var item in listaDeNumeros)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"El valor número 3 es: {listaDeNumeros[2]}");

            // Diccionarios
            Dictionary<string, int> listaDeDatos = new Dictionary<string, int>();

            string valorDigitado = "";
             
            while (valorDigitado != ".")
            {
                Console.WriteLine($"Ingrese número o ingrese . para terminar");
                valorDigitado= Console.ReadLine();

                if (valorDigitado != ".")
                {
                    try
                    {
                        listaDeDatos.Add(Guid.NewGuid().ToString(), int.Parse(valorDigitado));
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("El dato ingresado no es un número o ya existe dentro de la colección");
                    }
                }
            }

            foreach (var item in listaDeDatos)
            {
                Console.WriteLine($"Clave {item.Key} - Valor: {item.Value}");
            }

            // Listas
            var listaDePorcentajes = new List<short>()
            {
                50, 30, 70
            };
            Console.WriteLine($"Mi lista contiene {listaDePorcentajes.Count} elementos.");
            Console.WriteLine($"Mi lista contiene 80? {listaDePorcentajes.Contains(80)} ");

            foreach (var item in listaDePorcentajes)
            {
                Console.WriteLine(item);
            }
        }
    }
}
