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

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
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
                                Id = Convert.ToInt32(reader["id_evento"]),
                                Nombre = reader["nombre"].ToString(),
                                Descripcion = reader["descripcion"].ToString(),
                                Fecha = Convert.ToDateTime(reader["fecha"]),
                                Hora = reader["hora"] != DBNull.Value ? (TimeSpan)reader["hora"] : TimeSpan.Zero,
                                Lugar = reader["lugar"].ToString(),
                                Organizador = reader["organizador"].ToString(),
                                Tipo = reader["tipo"].ToString(),
                                Cupo = reader["cupo"] != DBNull.Value ? Convert.ToInt32(reader["cupo"]) : 0,
                                Costo = reader["costo"] != DBNull.Value ? Convert.ToDouble(reader["costo"]) : 0
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
                                Cupo = reader.GetInt32("cupo"),
                                Organizador = reader.GetString("organizador")
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
                ON DUPLICATE KEY UPDATE fecha_marcado = NOW()";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@u", idUsuario);
                    cmd.Parameters.AddWithValue("@e", idEvento);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Evento> ObtenerEventosInteres(int idUsuario)
        {
            List<Evento> lista = new List<Evento>();

            using (MySqlConnection con = new ConexionBD().ObtenerConexion())
            {
                con.Open();

                string query = @"SELECT e.* 
                         FROM Evento_cultural e
                         JOIN evento_interes i ON e.id_evento = i.id_evento
                         WHERE i.id_usuario = @u";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@u", idUsuario);

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
                                Hora = reader.GetTimeSpan("hora"),
                                Lugar = reader.GetString("lugar"),
                                Costo = reader.GetDouble("costo"),
                                Cupo = reader.GetInt32("cupo")
                            });
                        }
                    }
                }
            }

            return lista;
        }

        public List<Evento> FiltrarEventos(DateTime desde, DateTime hasta, double costoMin, double costoMax)
        {
            List<Evento> lista = new List<Evento>();

            using (MySqlConnection con = new ConexionBD().ObtenerConexion())
            {
                con.Open();
                string query = @"SELECT id_evento, nombre, descripcion, fecha, hora, lugar, organizador, tipo, cupo, costo 
                         FROM Evento_cultural
                         WHERE fecha BETWEEN @desde AND @hasta
                         AND costo BETWEEN @min AND @max";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@desde", desde.Date);
                    cmd.Parameters.AddWithValue("@hasta", hasta.Date);
                    cmd.Parameters.AddWithValue("@min", costoMin);
                    cmd.Parameters.AddWithValue("@max", costoMax);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Evento e = new Evento();

                            e.Id = Convert.ToInt32(reader["id_evento"]);
                            e.Nombre = reader["nombre"].ToString();
                            e.Descripcion = reader["descripcion"].ToString();
                            e.Fecha = Convert.ToDateTime(reader["fecha"]);
                            e.Hora = reader["hora"] != DBNull.Value ? (TimeSpan)reader["hora"] : TimeSpan.Zero;
                            e.Lugar = reader["lugar"].ToString();
                            e.Organizador = reader["organizador"].ToString();
                            e.Tipo = reader["tipo"].ToString();
                            e.Cupo = reader["cupo"] != DBNull.Value ? Convert.ToInt32(reader["cupo"]) : 0;
                            e.Costo = reader["costo"] != DBNull.Value ? Convert.ToDouble(reader["costo"]) : 0;

                            lista.Add(e);
                        }
                    }
                }
            }

            return lista;
        }

        public List<Evento> ObtenerEventosProximos()
        {
            List<Evento> lista = new List<Evento>();

            DateTime hoy = DateTime.Today;
            DateTime limite = hoy.AddDays(7);

            using (MySqlConnection con = new ConexionBD().ObtenerConexion())
            {
                con.Open();

                string query = @"SELECT * FROM Evento_cultural
                                 WHERE fecha >= @hoy 
                                 AND fecha <= @limite
                                 ORDER BY fecha ASC";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@hoy", hoy);
                    cmd.Parameters.AddWithValue("@limite", limite);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Evento
                            {
                                Id = Convert.ToInt32(reader["id_evento"]),
                                Nombre = reader["nombre"].ToString(),
                                Descripcion = reader["descripcion"].ToString(),
                                Fecha = Convert.ToDateTime(reader["fecha"]),
                                Hora = reader["hora"] != DBNull.Value ? (TimeSpan)reader["hora"] : TimeSpan.Zero,
                                Lugar = reader["lugar"].ToString(),
                                Organizador = reader["organizador"].ToString(),
                                Tipo = reader["tipo"].ToString(),
                                Cupo = reader["cupo"] != DBNull.Value ? Convert.ToInt32(reader["cupo"]) : 0,
                                Costo = reader["costo"] != DBNull.Value ? Convert.ToDouble(reader["costo"]) : 0
                            });
                        }
                    }
                }
            }

            return lista;
        }

        public bool Eliminar(int id)
        {
            using (MySqlConnection con = new ConexionBD().ObtenerConexion())
            {
                con.Open();

                string query = "DELETE FROM Evento_cultural WHERE id_evento = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Actualizar(Evento e)
        {
            using (MySqlConnection con = new ConexionBD().ObtenerConexion())
            {
                con.Open();

                string query = @"UPDATE Evento_cultural SET 
                        nombre=@n,
                        descripcion=@d,
                        fecha=@f,
                        hora=@h,
                        lugar=@l,
                        organizador=@o,
                        tipo=@t,
                        cupo=@cu,
                        costo=@c
                        WHERE id_evento=@id";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
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
                    cmd.Parameters.AddWithValue("@id", e.Id);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
       
