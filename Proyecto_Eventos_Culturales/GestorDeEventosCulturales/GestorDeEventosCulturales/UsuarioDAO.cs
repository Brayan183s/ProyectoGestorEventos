using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace GestorDeEventosCulturales
{
    class UsuarioDAO
    {
        ConexionBD conexion = new ConexionBD();

        public Usuario ObtenerUsuario(string nombre, string contrasena)
        {
            using (var con = conexion.ObtenerConexion())
            {
                con.Open();
                string query = "SELECT * FROM Usuario WHERE nombre=@n AND contrasena=@c";
                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@n", nombre);
                cmd.Parameters.AddWithValue("@c", contrasena);

                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Usuario
                    {
                        Id = reader.GetInt32("id_usuario"),
                        Nombre = reader.GetString("nombre"),
                        Contrasena = reader.GetString("contrasena"),
                        TipoUsuario = reader.GetString("tipo_usuario")
                    };
                }
                else
                {
                    return null;
                }
            }
        }
    }
        
}
