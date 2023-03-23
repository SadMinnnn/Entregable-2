using System;
using System.Collections.Generic;

namespace Punto2
{
   
    public interface IPastel
    {
        string Nombre { get; set; }
        int Tamaño { get; set; }
        List<Ingrediente> Ingredientes { get; set; }

        void AgregarIngrediente(Ingrediente ingrediente);
        int CantidadIngredientes();
        string ListarIngredientes();
        decimal CalcularCosto();
    }

    
    public class Ingrediente
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public Ingrediente(string nombre, int cantidad, decimal precio)
        {
            Nombre = nombre;
            Cantidad = cantidad;
            Precio = precio;
        }
    }

    
    public class Pastel : IPastel
    {
        public string Nombre { get; set; }
        public int Tamaño { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }

        public Pastel(string nombre, int tamaño)
        {
            Nombre = nombre;
            Tamaño = tamaño;
            Ingredientes = new List<Ingrediente>();
        }

        public void AgregarIngrediente(Ingrediente ingrediente)
        {
            Ingredientes.Add(ingrediente);
        }

        public int CantidadIngredientes()
        {
            return Ingredientes.Count;
        }

        public string ListarIngredientes()
        {
            string lista = "";
            foreach (Ingrediente i in Ingredientes)
            {
                lista += i.Cantidad + " " + i.Nombre + " $" + i.Precio + "\n";
            }
            return lista;
        }

        public decimal CalcularCosto()
        {
            decimal costo = 0;
            foreach (Ingrediente i in Ingredientes)
            {
                costo += i.Precio;
            }
            return costo;
        }
    }

   
    class Program
    {
        static void Main(string[] args)
        {
            
            Pastel pastel = new Pastel("Pastel de chocolate", 10);
            pastel.AgregarIngrediente(new Ingrediente("Harina", 2, 30));
            pastel.AgregarIngrediente(new Ingrediente("Huevos", 4, 5));
            pastel.AgregarIngrediente(new Ingrediente("Azúcar", 1, 15));
            pastel.AgregarIngrediente(new Ingrediente("Chocolate", 3, 40));

            
            Console.WriteLine("El pastel " + pastel.Nombre + " tiene " + pastel.CantidadIngredientes() + " ingredientes:");
            Console.WriteLine(pastel.ListarIngredientes());
            Console.WriteLine("El costo del pastel es $" + pastel.CalcularCosto());

            Console.ReadLine();
        }
    }
}


