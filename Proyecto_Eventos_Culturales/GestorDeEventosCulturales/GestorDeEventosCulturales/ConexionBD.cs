using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace GestorDeEventosCulturales
{
    public class ConexionBD
    {
        private string cadena = "server=localhost;database=eventos_culturales;user=root;password=1234;";

        public MySqlConnection ObtenerConexion()
        {
            MySqlConnection conexion = new MySqlConnection(cadena);
            conexion.Open();
            return conexion;
        }
    }
}
