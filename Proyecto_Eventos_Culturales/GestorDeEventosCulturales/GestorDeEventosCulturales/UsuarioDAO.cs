using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace GestorDeEventosCulturales
{
    class UsuarioDAO
    {
        public bool ValidarUsuario(string nombre, string contrasena)
        {
            var con = Conexion.ObtenerConexion();

            string query = "SELECT * FROM Usuario WHERE nombre=@n AND contrasena=@c";
            MySqlCommand cmd = new MySqlCommand(query, con);

            cmd.Parameters.AddWithValue("@n", nombre);
            cmd.Parameters.AddWithValue("@c", contrasena);

            MySqlDataReader reader = cmd.ExecuteReader();

            bool existe = reader.HasRows;

            reader.Close();
            con.Close();

            return existe;
        }
    }
}

