using Csharp.Enumerations;
using System;

namespace Csharp
{
    /// <summary>
    /// Clase Principal del programa
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            #region variables

            string nombre = "Francisco";
            var apellido = "Huacho Inga";
            const string nombreDos = "Jherson";

            Console.WriteLine("Hola " + nombre + " " + apellido);
            Console.WriteLine(string.Format("Mi nombre tiene {0} letras", nombre.Length));
            Console.WriteLine($"Mi apellido tiene {apellido.Length} letras");
            Console.WriteLine($"Mi apellido tiene {apellido.Trim().Length} letras");
            Console.WriteLine($"Mi apellido tiene {apellido.Trim().Replace(" ", "").Length} letras");

            #endregion            

            short edad = 30;
            Int16 altura = 173;
            float alturaEnMetros = 1.78f;
            float alturaEnMetrosDos = float.Parse((1.78f).ToString());

            Console.WriteLine($"Mi edad es: {edad}");
            Console.WriteLine($"Mi altura es: {altura} cm");
            Console.WriteLine($"Mi altura en metros es: {alturaEnMetros}");

            DateTime fechaNacimiento = new DateTime(1990,4,1);
            var fechaActual = DateTime.Now;

            Console.WriteLine(fechaNacimiento.ToString());
            Console.WriteLine($"Mi fecha de nacimiento es: {fechaNacimiento.Date.ToShortDateString()}");
            Console.WriteLine($"Mi fecha de nacimiento es: {fechaNacimiento.ToString("MM/dd/yyyy")}");
            Console.WriteLine($"Mi fecha de nacimiento es: {fechaNacimiento:MM/dd/yyyy}");
            Console.WriteLine($"La fecha Actual es {fechaActual}");
            Console.WriteLine($"La fecha Actual es {fechaActual.Date}");
            Console.WriteLine($"La fecha Actual es {fechaActual.Date.ToString("MM/dd/yyyy")}");

            var diferenciaDeFechas = fechaActual - fechaNacimiento;
            Console.WriteLine($"Mi edad de acuerdo a mi fecha de nacimiento es {diferenciaDeFechas.Days / 365}");

            var miGenero = Genero.Masculino;

            Console.WriteLine($"Mi genero es: {miGenero}");
            Console.WriteLine($"Mi genero es: {miGenero}");

            DateTime? fechaTerminacionCurso = null;
            short? edadNulo = null;
            string nombreNulo = null;

            Console.WriteLine($"Fechas terminación curso: {fechaTerminacionCurso}");
            //Console.WriteLine($"Fechas terminación curso: {fechaTerminacionCurso.Value}"); // Genero error
            Console.WriteLine($"Fechas terminación curso: {fechaTerminacionCurso?.Date}");
            Console.WriteLine($"Mi edad es: {edadNulo}");
            Console.WriteLine("Hola " + nombreNulo + " " + apellido);

            bool tieneMascota = true;
            Console.WriteLine($"Tengo mascota? : {tieneMascota}");            

            Console.ReadLine();
        }
    }    
}
