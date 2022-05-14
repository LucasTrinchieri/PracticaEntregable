using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pantalla : Dispositivo
    {
        public int Año { get; set; }
        public bool EsNuevo { get { return Año == DateTime.Today.Year; } }
        public int? Pulgadas { get; set; }

        public override string ObtenerDescripcion()
        {
            return $" MONITOR {Marca} - {Modelo} - {Pulgadas}´";
        }

        public Pantalla()
        {

        }

        public Pantalla(string marca, string modelo, int nroSerie, int año, int pulgadas)
        {
            base.CargarDatos(marca, modelo, nroSerie);
            Año = año;
            Pulgadas = pulgadas;
        }
    }
}
