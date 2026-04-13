using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDeEventosCulturales
{
    class GestorAutenticacion
    {
        public bool Login(string nombre, string contrasena)
        {
            return dao.ValidarUsuario(nombre, contrasena);
        }
    }
}
