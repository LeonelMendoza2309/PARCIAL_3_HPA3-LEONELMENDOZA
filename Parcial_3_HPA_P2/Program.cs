using System;
using Newtonsoft.Json;

class program
{
    static void Main(string[] args)
    {
        var Persona = new
        {
            Nombre = "Cristell",
            Edad = 20,
            Carrera = "Ingenieria en Sistemas"
        };
        string json = JsonConvert.SerializeObject(Persona);
        Console.WriteLine(json);
     }
}

