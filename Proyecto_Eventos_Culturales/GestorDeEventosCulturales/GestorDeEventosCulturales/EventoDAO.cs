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

        public List<Evento> ObtenerEventos()
        {
            List<Evento> lista = new List<Evento>();

            using (MySqlConnection con = new ConexionBD().ObtenerConexion())
            {
                con.Open();

                string query = "SELECT * FROM Evento_cultural";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Evento
                            {
                                Id = reader.GetInt32("id_evento"),
                                Nombre = reader.GetString("nombre"),
                                Descripcion = reader.GetString("descripcion"),
                                Fecha = reader.GetDateTime("fecha"),
                                Lugar = reader.GetString("lugar"),
                                Costo = reader.GetDouble("costo")
                            });
                        }
                    }
                }
            }

            return lista;
        }

        public Evento ObtenerPorId(int id)
        {
            using (MySqlConnection con = new ConexionBD().ObtenerConexion())
            {
                con.Open();

                string query = "SELECT * FROM Evento_cultural WHERE id_evento=@id";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Evento
                            {
                                Id = reader.GetInt32("id_evento"),
                                Nombre = reader.GetString("nombre"),
                                Descripcion = reader.GetString("descripcion"),
                                Fecha = reader.GetDateTime("fecha"),
                                Hora = reader.GetTimeSpan("hora"),
                                Lugar = reader.GetString("lugar"),
                                Costo = reader.GetDouble("costo"),
                                Cupo = reader.GetInt32("cupo")
                            };
                        }
                    }
                }
            }

            return null;
        }

        public void MarcarInteres(int idUsuario, int idEvento)
        {
            using (MySqlConnection con = new ConexionBD().ObtenerConexion())
            {
                con.Open();

                string query = @"INSERT INTO evento_interes (id_usuario, id_evento, fecha_marcado)
                VALUES (@u,@e,NOW())
                ON DUPLICATE KEY UPDATE fecha_marcado = NOW()"; // 🔥 AQUÍ VA

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@u", idUsuario);
                    cmd.Parameters.AddWithValue("@e", idEvento);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
       
