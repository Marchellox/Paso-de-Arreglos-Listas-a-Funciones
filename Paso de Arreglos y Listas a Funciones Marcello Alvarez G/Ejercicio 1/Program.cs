using System;
using System.Collections.Generic;

class Producto
{
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }

    public override string ToString()
    {
        return $"Código: {Codigo}, Nombre: {Nombre}, Cantidad: {Cantidad}, Precio: {Precio:C}";
    }
}

class Program
{
    static List<Producto> inventario = new List<Producto>();

    static void Main()
    {
        int opcion;

        do
        {
            Console.Clear();
            Console.WriteLine("Gestión de Inventario");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Eliminar producto");
            Console.WriteLine("3. Modificar producto");
            Console.WriteLine("4. Consultar producto");
            Console.WriteLine("5. Mostrar todos los productos");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarProducto();
                    break;
                case 2:
                    EliminarProducto();
                    break;
                case 3:
                    ModificarProducto();
                    break;
                case 4:
                    ConsultarProducto();
                    break;
                case 5:
                    MostrarProductos();
                    break;
                case 6:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    break;
            }

            if (opcion != 6)
            {
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcion != 6);
    }

    static void AgregarProducto()
    {
        var nuevoProducto = new Producto();

        Console.Write("Ingrese el código del producto: ");
        nuevoProducto.Codigo = Console.ReadLine();
        Console.Write("Ingrese el nombre del producto: ");
        nuevoProducto.Nombre = Console.ReadLine();
        Console.Write("Ingrese la cantidad del producto: ");
        nuevoProducto.Cantidad = int.Parse(Console.ReadLine());
        Console.Write("Ingrese el precio del producto: ");
        nuevoProducto.Precio = decimal.Parse(Console.ReadLine());

        inventario.Add(nuevoProducto);
        Console.WriteLine("Producto agregado con éxito.");
    }

    static void EliminarProducto()
    {
        Console.Write("Ingrese el código del producto a eliminar: ");
        string codigo = Console.ReadLine();
        Producto productoAEliminar = inventario.Find(p => p.Codigo == codigo);

        if (productoAEliminar != null)
        {
            inventario.Remove(productoAEliminar);
            Console.WriteLine("Producto eliminado con éxito.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    static void ModificarProducto()
    {
        Console.Write("Ingrese el código del producto a modificar: ");
        string codigo = Console.ReadLine();
        Producto productoAModificar = inventario.Find(p => p.Codigo == codigo);

        if (productoAModificar != null)
        {
            Console.Write("Ingrese el nuevo nombre del producto (deje en blanco para no modificar): ");
            string nuevoNombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoNombre)) productoAModificar.Nombre = nuevoNombre;

            Console.Write("Ingrese la nueva cantidad del producto (deje en blanco para no modificar): ");
            string nuevaCantidad = Console.ReadLine();
            if (int.TryParse(nuevaCantidad, out int cantidad)) productoAModificar.Cantidad = cantidad;

            Console.Write("Ingrese el nuevo precio del producto (deje en blanco para no modificar): ");
            string nuevoPrecio = Console.ReadLine();
            if (decimal.TryParse(nuevoPrecio, out decimal precio)) productoAModificar.Precio = precio;

            Console.WriteLine("Producto modificado con éxito.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    static void ConsultarProducto()
    {
        Console.Write("Ingrese el código del producto a consultar: ");
        string codigo = Console.ReadLine();
        Producto productoAConsultar = inventario.Find(p => p.Codigo == codigo);

        if (productoAConsultar != null)
        {
            Console.WriteLine(productoAConsultar);
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    static void MostrarProductos()
    {
        Console.WriteLine("Lista de productos en el inventario:");
        foreach (var producto in inventario)
        {
            Console.WriteLine(producto);
        }
    }
}
