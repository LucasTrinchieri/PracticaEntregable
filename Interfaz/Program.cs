using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArgEventos;
using Logica;

namespace Interfaz
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public static class Utilidades
    {
        public static bool ValidarRAM()
        {
            return true;
        }

        public static void ProductoHandler(object o, AgregarEliminar a)
        {
            Console.WriteLine($" Producto eliminado/agregado - {a.Tipo} - {a.Id}");
        }
    }
}
