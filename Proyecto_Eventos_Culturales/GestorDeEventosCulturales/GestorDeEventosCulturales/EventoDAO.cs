using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GestorDeEventosCulturales
{
    class EventoDAO
    {
        ConexionBD conexion = new ConexionBD();

        public bool Insertar(Evento e)
        {
            try
            {
                using (MySqlConnection con = conexion.ObtenerConexion())
                {
                    con.Open();

                    string query = @"INSERT INTO Evento_cultural
                (nombre, descripcion, fecha, hora, lugar, organizador, tipo, cupo, costo)
                VALUES(@n,@d,@f,@h,@l,@o,@t,@cu,@c)";

                    using (MySqlCommand cmd = new MySqlCommand(query, con)) // 🔥 IMPORTANTE
                    {
                        cmd.Parameters.AddWithValue("@n", e.Nombre);
                        cmd.Parameters.AddWithValue("@d", e.Descripcion);
                        cmd.Parameters.AddWithValue("@f", e.Fecha);
                        cmd.Parameters.AddWithValue("@h", e.Hora);
                        cmd.Parameters.AddWithValue("@l", e.Lugar);
                        cmd.Parameters.AddWithValue("@o", e.Organizador);
                        cmd.Parameters.AddWithValue("@t", e.Tipo);
                        cmd.Parameters.AddWithValue("@cu", e.Cupo);
                        cmd.Parameters.AddWithValue("@c", e.Costo);

                        cmd.CommandTimeout = 10;

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error BD: " + ex.Message);
                return false;
            }
        }
    }
}
       
