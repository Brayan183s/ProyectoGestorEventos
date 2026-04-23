using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace GestorDeEventosCulturales
{
    public class ConexionBD
    {
        private string cadena = "server=127.0.0.1;database=sgec;user=root;password=Gears.20s;Pooling=true;Max Pool Size=50;Connection Timeout=30;";

        public MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(cadena);
        }
    }
}
