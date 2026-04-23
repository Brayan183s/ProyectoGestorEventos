using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDeEventosCulturales
{
    public class GestorAutenticacion
    {
        UsuarioDAO dao = new UsuarioDAO();

        public Usuario Login(string nombre, string contrasena)
        {
            return dao.ObtenerUsuario(nombre, contrasena);
        }
    }
}
