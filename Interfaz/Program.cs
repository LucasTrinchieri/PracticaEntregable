using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArgEventos;
using Logica;

namespace Interfaz
{
    public class Program
    {
        static void Main(string[] args)
        {
            string accion = CargarTitulo().ToUpper();

            Principal.Intancia.agregarEliminar += Eventos.ProductoHandler;

            while (accion != "FIN")
            {
                switch (accion)
                {
                    case "AP":
                        CargarMonitor();
                        break;
                    case "AC":
                        CargarPC();
                        break;
                    case "E":
                        Console.WriteLine(" Escriba el ID:");
                        Console.Write(" Modelo: ");
                        string modelo = Console.ReadLine();
                        Console.Write(" Marca: ");
                        string marca = Console.ReadLine();
                        Console.Write(" NroSerie: ");
                        int nro = int.Parse(Console.ReadLine());

                        Principal.Intancia.Eliminar(Utilidades.ArmarID(marca, modelo, nro));
                        break;
                }

                Console.ReadKey();
                Console.Clear();



                accion = CargarTitulo();
            }

            Console.ReadKey();
        }

        public static void MostrarProductos()
        {
            Console.Write(" Mostrar productos: S || No mostrar: N");
            string mostrar = Console.ReadLine().ToUpper();

            if (mostrar == "S")
            {
                Mostrar();
            }
        }

        private static void Mostrar()
        {
            //
        }

        public static void CargarMonitor()
        {
            Console.Write(" Marca:");
            string marca = Console.ReadLine();
            Console.Write(" Modelo:");
            string modelo = Console.ReadLine();
            Console.Write(" Numero de serie:");
            int nroSerie = int.Parse(Console.ReadLine());
            Console.Write(" Año:");
            int año = int.Parse(Console.ReadLine());
            Console.Write(" Pulgadas:");
            int pulgadas = int.Parse(Console.ReadLine());

            Principal.Intancia.Agregar(marca, modelo, nroSerie, año, pulgadas);
        }

        public static void CargarPC()
        {
            Console.Write(" Marca:");
            string marca = Console.ReadLine();
            Console.Write(" Modelo:");
            string modelo = Console.ReadLine();
            Console.Write(" Numero de serie:");
            int nroSerie = int.Parse(Console.ReadLine());
            Console.Write(" Procesador:");
            string cpu = Console.ReadLine();
            Console.Write(" RAM:");
            short ram = short.Parse(Console.ReadLine());

            while(!ram.ValidarRAM())
            {
                Console.WriteLine(" La cantidad de RAM no es valida");
                Console.Write(" RAM:");
                ram = short.Parse(Console.ReadLine());
            }

            Console.Write(" fabricante:");
            string fabricante = Console.ReadLine();

            Principal.Intancia.Agregar(marca, modelo, nroSerie, cpu, ram, fabricante);
        }

        public static string CargarTitulo()
        {
            Console.WriteLine(" Agregar Pantalla = AP | Agregar Computadora = AC | Eliminar = E | Finalizar = FIN");
            string accion = Console.ReadLine().ToUpper();

            Console.Clear();

            if (accion != "AP" && accion != "AC" && accion != "E" && accion != "FIN")
            {
                Console.WriteLine(" Ingrese un valor correcto");
            }

            return accion;
        }
    }

    public static class Utilidades
    {
        public static bool ValidarRAM(this short ram)
        {
            return ram == 2 || ram == 4 || ram == 8 || ram == 16;
        }

        public static string ArmarID(string marca, string modelo, int nro)
        {
            return $"{modelo} - {marca} - {nro}";
        }
    }

    public static class Eventos
    {
        public static void ProductoHandler(object o, AgregarEliminar a)
        {
            Console.WriteLine($" Producto eliminado/agregado:");
            Console.WriteLine($"{Principal.Intancia.ObtenerDescripcion(a.Id)}");
            Console.WriteLine($" Computadoras: {Principal.Intancia.ObtenerCantidadPC()} / Monitores: {Principal.Intancia.ObtenerCantidadPantallas()}");
            Console.WriteLine($" Monitores: {Principal.Intancia.ObtenerCantidadPantallas() / Principal.Intancia.ObtenerCantidadDispositivos() * 100}%");
            Console.WriteLine($" Computadoras: {Principal.Intancia.ObtenerCantidadPC() / Principal.Intancia.ObtenerCantidadDispositivos() * 100}%");
        }
    }
}
