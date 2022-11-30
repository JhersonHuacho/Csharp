using System;

namespace CSharpExcepciones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string numeroString = Console.ReadLine();

            try
            {
                int numero = int.Parse(numeroString);
                Console.WriteLine($"Has escrito el número: {numero}");
            }
            catch (FormatException fx)
            {
                Console.WriteLine("El dato ingresado no es un número.");
                #if DEBUG
                Console.WriteLine( fx.Message );
                Console.WriteLine( fx.StackTrace );
                #endif
            }
            catch (Exception)
            {
                Console.WriteLine("Ha ocurrido un error.");
            }

        }
    }
}
