using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class Usuario
    {
        public string IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Edad { get; set; }
        public string CorreoElectronico { get; set; }
        public string Clave { get; set; }

        public bool EstaActivo { get; set; }

        public Usuario()
        {
        }

        public Usuario(string idUsuario, string nombre, string apellido, string edad, string correoElectronico, string clave, bool estaActivo)
        {
            IdUsuario = idUsuario;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            CorreoElectronico = correoElectronico;
            Clave = clave;
            EstaActivo = estaActivo;
        }
    }

}
