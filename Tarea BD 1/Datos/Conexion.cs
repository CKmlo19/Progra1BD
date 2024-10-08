﻿using System.Data.SqlClient;

namespace Tarea_BD_1.Datos
{
    public class Conexion
    {
        private string cadenaSQL = string.Empty; // por default esta vacio

        // constructor
        public Conexion()
        {
            // variable dinamica
            // conexion a la base de datos que se encuentra en el appsettings.json mediate el patron builder incluido en visual
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value; // colocamos el string de la cadena
        }
        public string getCadenaSQL()
        {
            return cadenaSQL;

        }
    }
}
