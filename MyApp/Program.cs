// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;



var url = $"https://age-of-empires-2-api.herokuapp.com/api/v1/civilizations"; 
var request = (HttpWebRequest)WebRequest.Create(url);
request.Method = "GET";
request.ContentType = "application/json";
request.Accept = "application/json";

try
{
    using (WebResponse response = request.GetResponse())
    {
        using (Stream strReader = response.GetResponseStream())
        {
            if (strReader == null) return;
            using (StreamReader objReader = new StreamReader(strReader))
            {
                string responseBody = objReader.ReadToEnd();


                Root Listado = JsonSerializer.Deserialize<Root>(responseBody);

                foreach (Civilization civilization in Listado.Civilizations)
                {
                    Console.WriteLine("\nID: [" + civilization.Id + "]\nNombre: " + civilization.Name + "\nExpansion: " + civilization.Expansion + "\n");
                }


                Console.WriteLine("\n-------------------------------------------\n");
                Console.WriteLine($"ID: [{Listado.Civilizations[22].Id}]");
                Console.WriteLine("Nombre: " + Listado.Civilizations[22].Name);
                Console.WriteLine("Expansion: " + Listado.Civilizations[22].Expansion);
                Console.WriteLine("Tipo de ejército: " + Listado.Civilizations[22].ArmyType);
                Console.WriteLine("Bono de equipo: " + Listado.Civilizations[22].TeamBonus);
            }
        }
    }
}

catch (WebException ex)
{
    Console.WriteLine("\nNo pudimos conectar con la API.");
}