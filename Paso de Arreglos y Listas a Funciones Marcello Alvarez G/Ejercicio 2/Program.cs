using System;

class CuentaBancaria
{
    public decimal Saldo { get; private set; }

    public CuentaBancaria()
    {
        Saldo = 0;
    }

    public void Depositar(decimal cantidad)
    {
        if (cantidad > 0)
        {
            Saldo += cantidad;
            Console.WriteLine($"Se han depositado {cantidad:C}. Nuevo saldo: {Saldo:C}");
        }
        else
        {
            Console.WriteLine("La cantidad a depositar debe ser positiva.");
        }
    }

    public bool Retirar(decimal cantidad)
    {
        if (cantidad > 0 && cantidad <= Saldo)
        {
            Saldo -= cantidad;
            Console.WriteLine($"Se han retirado {cantidad:C}. Nuevo saldo: {Saldo:C}");
            return true;
        }
        else if (cantidad > Saldo)
        {
            Console.WriteLine("Fondos insuficientes para realizar el retiro.");
            return false;
        }
        else
        {
            Console.WriteLine("La cantidad a retirar debe ser positiva.");
            return false;
        }
    }

    public decimal ConsultarSaldo()
    {
        return Saldo;
    }
}

class Program
{
    static void Main()
    {
        CuentaBancaria cuenta = new CuentaBancaria();

        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("Gestión de Cuenta Bancaria");
            Console.WriteLine("1. Consultar saldo");
            Console.WriteLine("2. Depositar dinero");
            Console.WriteLine("3. Retirar dinero");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.WriteLine($"Saldo actual: {cuenta.ConsultarSaldo():C}");
                    break;
                case 2:
                    Console.Write("Ingrese la cantidad a depositar: ");
                    decimal cantidadDeposito = decimal.Parse(Console.ReadLine());
                    cuenta.Depositar(cantidadDeposito);
                    break;
                case 3:
                    Console.Write("Ingrese la cantidad a retirar: ");
                    decimal cantidadRetiro = decimal.Parse(Console.ReadLine());
                    cuenta.Retirar(cantidadRetiro);
                    break;
                case 4:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    break;
            }

            if (opcion != 4)
            {
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcion != 4);
    }
}

