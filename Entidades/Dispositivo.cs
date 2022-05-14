using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Dispositivo
    {
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int NroSerie { get; set; }
        public string Id { 
            get
            {
                return $"{Modelo} - {Marca} - {NroSerie}";
            }
        }

        public abstract string ObtenerDescripcion();

        public virtual void CargarDatos(string marca, string modelo, int nroSerie)
        {
            Marca = marca;
            NroSerie = nroSerie;
            Modelo = modelo;
        }
    }
}
