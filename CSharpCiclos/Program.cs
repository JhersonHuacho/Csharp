using System;

namespace CSharpCiclos
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i);
            }

            int contador = 0;
            while( contador <= 5 )
            {
                Console.WriteLine(contador);
                contador++;
            }

            foreach (var item in new[] { 1,2,3,4,5})
            {
                Console.WriteLine(item);
            }
        }
    }
}
