using System;
using System.Collections.Generic;
using EjercicioMartes2.Clases;
using System.IO;

namespace EjercicioMartes2
{
    class MainClass
    {
        
        public static void Main(string[] args)
        {
            string eleccion;

            Datos datos = new Datos();
            Contacto c = new Contacto();
            List<Contacto> contactos = new List<Contacto>();

            if (File.Exists("ListaContactos.dat"))
            {
                contactos = datos.CargarDatos("ListaContactos.dat");
            }

            do
            {

                System.Console.WriteLine("**MENU**");
                System.Console.WriteLine("1. Añadir Contacto");
                System.Console.WriteLine("2. Editar contacto");
                System.Console.WriteLine("3. Generar agenda");
                System.Console.WriteLine("4. Buscar Contacto");
                System.Console.WriteLine("5. Visualizar agenda");
                System.Console.WriteLine("6. Eliminar Contacto");
                System.Console.WriteLine("7. Guardar y Salir");

                eleccion = System.Console.ReadLine();

                switch (eleccion)
                {
                    case "1":
                        {
                            contactos.Add(c.AniadirContacto(contactos));

                            Console.ReadKey();

                        }
                        break;

                    case "2":
                        {
                            Console.Write("Telefono del contacto a editar: ");
                            string auxtel = Console.ReadLine();

                            contactos.Add(datos.ModificarContacto(auxtel, contactos));

                            Console.ReadKey();

                        }
                        break;

                    case "3":
                        {
                            
                            StreamWriter ds = File.CreateText($"/Users/I.Montoya/Desktop/Agenda.txt");

                            foreach (Contacto item in contactos)
                            {
                                ds.WriteLine($"Nombre: {item.Nombre} \nApellido: {item.Apellido} \nTelefono: {item.Telefono}\n");
                            }

                            ds.Close();

                            Console.WriteLine("Se ha generado un fichero en el escritorio\n");

                            Console.ReadKey();
                        }
                        break;

                    case "4":
                        {
                            datos.Buscar(contactos);

                            Console.ReadKey();
                        }
                        break;

                    case "5":
                        {
                            c.Visualizar(contactos);

                            Console.ReadKey();
                        }
                        break;

                    case "6":
                        {
                            c.EliminarContacto(contactos);

                            Console.ReadKey();
                        }
                        break;

                    case "7":
                        {
                            Console.WriteLine("Hasta luego!");
                        }
                        break;
                }
            } while (eleccion != "7");

            datos.GrabarDatos(contactos, "ListaContactos.dat");
        }
    }
}


