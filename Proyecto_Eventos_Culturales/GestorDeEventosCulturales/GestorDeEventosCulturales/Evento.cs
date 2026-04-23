using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDeEventosCulturales
{
    class Evento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string Lugar { get; set; }
        public string Organizador { get; set; }
        public string Tipo { get; set; }
        public int Cupo { get; set; }
        public double Costo { get; set; }
    }
}
