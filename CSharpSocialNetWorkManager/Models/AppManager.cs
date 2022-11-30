using CSharpSocialNetWorkManager.Utilities.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpSocialNetWorkManager.Models
{
    class AppManager
    {
        public string AppTitle { get; set; }
        public ILog<string> log { get; set; }
        public List<SocialNetwork> SocialNetworks { get; set; }
        public List<SocialNetworkWithGroups> SocialNetworkWithGroups { get; set; }        
        public AppManager(ILog<string> logger)
        {
            log = logger;
            AppTitle = "Administrador de redes sociales";
            SocialNetworks = new List<SocialNetwork>();
            SocialNetworkWithGroups= new List<SocialNetworkWithGroups>();
            InitializeSocialNetworks();
        }
        public string GetSocialNetWorkInformation<T>(T socialNetwork)
        {
            if (socialNetwork == null)
            {
                return "";
            }

            StringBuilder stringBuilder = new StringBuilder();
            var socialNetworkItem = socialNetwork as SocialNetwork;

            stringBuilder.AppendLine($"Nombre : {socialNetworkItem.Name}");
            stringBuilder.AppendLine($"Descripción : {socialNetworkItem.Description}");
            stringBuilder.AppendLine($"Año de creación : {socialNetworkItem.DateCreated.Year}");

            if (socialNetworkItem is SocialNetworkWithGroups)
            {
                var socialNetworkWithGroupsItem = socialNetwork as SocialNetworkWithGroups;
                stringBuilder.AppendLine($"Grupos : {string.Join(",",socialNetworkWithGroupsItem.Groups)}");
            }
            log.SaveLog("GetSocialNetWorkInformation");
            return stringBuilder.ToString();
        }

        public string GetSocialNetWorkStats<T>(T socialNetwork)
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                if (socialNetwork == null)
                {
                    return "";
                }
                
                var socialNetworkItem = socialNetwork as SocialNetwork;

                stringBuilder.AppendLine($"Cantidad de Usuarios : {socialNetworkItem.Users.Count}");
                stringBuilder.AppendLine($"Promedio de edad : {socialNetworkItem.Users.Average(p => p.Age)}");
                stringBuilder.AppendLine($"El usuario de mayor edad tiene : {socialNetworkItem.Users.Max(p => p.Age)} años");
                stringBuilder.AppendLine($"El usuario de menor edad tiene : {socialNetworkItem.Users.Min(p => p.Age)} años");

                if (socialNetworkItem is SocialNetworkWithGroups)
                {
                    var socialNetworkWithGroupsItem = socialNetwork as SocialNetworkWithGroups;
                    stringBuilder.AppendLine($"Cantidad de Grupos : {socialNetworkWithGroupsItem.Groups.Count}");
                }                        
            }
            catch (Exception ex)
            {
                log.SaveLog(ex.Message);
            }

            log.SaveLog("GetSocialNetWorkStats");
            return stringBuilder.ToString();
        }

        public void InitializeSocialNetworks()
        {
            SocialNetworks.Add(new SocialNetwork()
            {
                Name= "Twitter",
                Description = "Red social para intercambio de mensajes cortos",
                Users= new List<User>(),
                DateCreated = new DateTime(2008, 1, 20)
            });

            SocialNetworks.Add(new SocialNetwork()
            {
                Name = "Instagram",
                Description = "Red social para intercambio de fotos y videos",
                Users = new List<User>(),
                DateCreated = new DateTime(2010, 1, 10)
            });

            SocialNetworkWithGroups.Add(new SocialNetworkWithGroups()
            {
                Name = "Facebook",
                Description = "Intercambio de fotos, videos y pensamientos",
                Users = new List<User>(),
                Groups = new List<string>() { "Programadores CSharp", "Amantes de la música", "Programador Go" },
                DateCreated = new DateTime(2010, 1, 10)
            });

            log.SaveLog("InitializeSocialNetworks");
        }
    }
}
