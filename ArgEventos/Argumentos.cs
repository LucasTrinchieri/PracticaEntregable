using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgEventos
{
    public class AgregarEliminar : EventArgs
    {
        public Tipo Tipo { get; set; }
        public string Id { get; set; }
    }

    public enum Tipo
    {
        Monitor,
        Computadora
    }
}
