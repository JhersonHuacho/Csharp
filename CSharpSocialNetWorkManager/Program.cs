using CSharpSocialNetWorkManager.Models;
using CSharpSocialNetWorkManager.Utilities.Log;
using System;
using System.Linq;

namespace CSharpSocialNetWorkManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppManager app = new AppManager(new LogJson());

            Console.WriteLine($"Bienvenido a {app.AppTitle}");

            while (true)
            {
                Console.WriteLine("Redes Sociales disponibles");

                foreach (var item in app.SocialNetworks.Concat(app.SocialNetworkWithGroups))
                {
                    Console.WriteLine($"{item.Name}");
                }

                Console.Write("Escriba el nombre de la red social a la que desee ingresar : ");

                string socialNetworkName = Console.ReadLine();

                SocialNetwork socialNetworkSelected = app.SocialNetworks.FirstOrDefault(item => item.Name.ToLower() == socialNetworkName.ToLower());

                Console.Write(app.GetSocialNetWorkInformation(socialNetworkSelected));

                SocialNetworkWithGroups socialNetworkWithGroupSelected = app.SocialNetworkWithGroups
                    .FirstOrDefault(item => item.Name.ToLower() == socialNetworkName.ToLower());

                Console.Write(app.GetSocialNetWorkInformation(socialNetworkWithGroupSelected));
                Console.WriteLine("");
                Console.WriteLine("1=Agregar nuevo usuario, 2=Para las estadistica");

                var optionsSelected = int.Parse(Console.ReadLine());

                switch (optionsSelected)
                {
                    case 1:
                        {
                            Console.WriteLine("Por favor ingrese su Nombre");
                            string name = Console.ReadLine();
                            Console.WriteLine("Por favor ingrese su Correo");
                            string email = Console.ReadLine();
                            Console.WriteLine("Por favor ingrese su edad");
                            short age = short.Parse(Console.ReadLine());

                            var user = new User
                            {
                                Name = name,
                                Email = email,
                                Age = age
                            };

                            if (!user.IsValid(false))
                            {
                                Console.WriteLine("Los datos del usuario no son válidos");
                                return;
                            }

                            if (socialNetworkSelected!= null)
                            {
                                int indexElement = app.SocialNetworks.IndexOf(socialNetworkSelected);
                                app.SocialNetworks[indexElement].Users.Add(user);
                            }

                            if (socialNetworkWithGroupSelected != null)
                            {
                                int indexElement = app.SocialNetworkWithGroups.IndexOf(socialNetworkWithGroupSelected);
                                app.SocialNetworkWithGroups[indexElement].Users.Add(user);
                            }

                            Console.WriteLine("Sus datos son: ");
                            Console.WriteLine($"Nombre: {user.Name}");
                            Console.WriteLine($"Correo: {user.Email}");
                            Console.WriteLine($"Edad: {user.Age}");
                            Console.WriteLine($"Estado Activo: {user.IsActive}");
                            Console.WriteLine($"Fecha: {user.DateCreated}");

                            app.log.SaveLog("Se creo el usuario correctamente.");
                        };
                        break;
                    case 2:
                        {
                            if (socialNetworkSelected != null)
                            {
                                Console.WriteLine(app.GetSocialNetWorkStats(socialNetworkSelected));
                            }

                            if (socialNetworkWithGroupSelected != null)
                            {
                                Console.WriteLine(app.GetSocialNetWorkStats(socialNetworkWithGroupSelected));
                            }
                        };
                        break;
                }

                
            }            
        }
    }
}
