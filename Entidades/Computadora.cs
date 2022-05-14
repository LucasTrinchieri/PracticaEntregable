using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Computadora : Dispositivo
    {
        public string Procesador { get; set; }
        public RAM RAM { get; set; }
        public string Fabricante { get; set; }

        public override string ObtenerDescripcion()
        {
            return $" PC {Modelo} - {Marca} - {Procesador} - {(int)RAM} RAM - {Fabricante}";
        }

        public Computadora()
        {

        }

        public Computadora(string marca, string modelo, int nroSerie, string cpu, RAM ram, string fabricante)
        {
            base.CargarDatos(marca, modelo, nroSerie);
            Procesador = cpu;
            Fabricante = fabricante;
            RAM = ram;
        }
    }

    public enum RAM
    {
        GB2 = 2,
        GB4 = 4,
        GB8 = 8,
        GB16 = 16
    }
}
