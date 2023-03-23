public interface IMonoplaza
{
    void Encender();
    void Apagar();
    void Detener();
    void Mover();
}

public abstract class Monoplaza : IMonoplaza
{
    private bool encendido;
    private bool movimiento;

    public bool Marca { get; set; }

    public Monoplaza()
    {
        encendido = false;
        movimiento = false;
    }

    public void Encender()
    {
        if (!encendido)
        {
            encendido = true;
            Console.WriteLine("El auto está encendido.");
        }
    }

    public void Apagar()
    {
        if (encendido && !movimiento)
        {
            encendido = false;
            Console.WriteLine("El auto está apagado.");
        }
    }

    public void Detener()
    {
        if (encendido && movimiento)
        {
            movimiento = false;
            Console.WriteLine("El auto está detenido.");
        }
    }

    public void Mover()
    {
        if (encendido && !movimiento)
        {
            movimiento = true;
            Console.WriteLine("El auto se está moviendo.");
        }
    }

    public abstract int TiempoV();
}


public class McLaren : Monoplaza
{
    public override int TiempoV()
    {
        
        Random rnd = new Random();
        return rnd.Next(100000, 999999);
    }
}


public class Ferrari : Monoplaza
{
    public override int TiempoV()
    {
        
        Random rnd = new Random();
        return rnd.Next(100000, 999999);
    }
}


public class Redbull : Monoplaza
{
    public override int TiempoV()
    {
        
        Random rnd = new Random();
        return rnd.Next(100000, 999999);
    }
}


public class Circuito
{
    private Monoplaza monoplaza;
    private int vueltas;
    private string nombre;

    public Circuito(int vueltas, string nombre)
    {
        this.vueltas = vueltas;
        this.nombre = nombre;
    }

    public void AggMonoplaza(Monoplaza monoplaza)
    {
        if (this.monoplaza == null)
        {
            this.monoplaza = monoplaza;
            Console.WriteLine("Auto listo para empezar vuelta.");
        }
    }

    public void SacarMonoplaza()
    {
        if (monoplaza != null)
        {
            monoplaza = null;
            Console.WriteLine("Auto fuera de circuito.");
        }
    }

    public void RealizarPrueba()
    {
        if (monoplaza != null)
        {
            Console.WriteLine("Realizando vuelta");

            int mejorTiempo = int.MaxValue;

            for (int i = 1; i <= vueltas; i++)
            {
                int tiempo = monoplaza.TiempoV();
                Console.WriteLine("Vuelta " + i + ": " + tiempo + " ms.");

                if (tiempo < mejorTiempo)
                {
                    mejorTiempo = tiempo;
                }
            }

            Console.WriteLine("Tiempo del ganador: " + mejorTiempo + " ms.");
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        
        McLaren mclaren = new McLaren();
        Ferrari ferrari = new Ferrari();
        Redbull redbull = new Redbull();

       
        Circuito circuito = new Circuito(5,"Circuito A");

        
        circuito.AggMonoplaza(mclaren);
        circuito.RealizarPrueba();
        circuito.SacarMonoplaza();

        circuito.AggMonoplaza(ferrari);
        circuito.RealizarPrueba();
        circuito.SacarMonoplaza();

        circuito.AggMonoplaza(redbull);
        circuito.RealizarPrueba();
        circuito.SacarMonoplaza();

        Console.ReadKey();
    }
}