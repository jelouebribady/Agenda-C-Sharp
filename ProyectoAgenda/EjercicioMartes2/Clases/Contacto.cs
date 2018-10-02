using System;
using System.Collections.Generic;

namespace EjercicioMartes2.Clases
{

    [Serializable]
    public class Contacto : Datos
    {
        string nombre;
        string apellido;
        string telefono;


        public Contacto()
        {

        }

        public Contacto(string telefono, string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; }

        public Contacto AniadirContacto(List<Contacto>contactos)
        {

            Console.Write("Telefono:");
            string tel = Console.ReadLine();

            for (int i = 0; i < contactos.Count; i++)
            {
                if (tel == contactos[i].Telefono)
                {
                    Console.WriteLine("Este contacto ya existe");return null;
                }
            } 

            Console.Write("Nombre: ");
            string nom = Console.ReadLine();

            Console.Write("Apellido: ");
            string ape = Console.ReadLine();

            Contacto auxx = new Contacto(tel, nom, ape);
            return auxx;

        }

        public void MostrarContacto(Contacto c)
        {

            Console.Write($"Nombre: {c.Nombre}");
            Console.Write($"Apellido: {c.Apellido}");
            Console.Write($"Telefono: {c.Telefono}");
        }

        public void Visualizar(List<Contacto> contactos)
        {

            foreach (Contacto item in contactos)
            {
                Console.WriteLine($"Nombre: {item.Nombre} \nApellido: {item.Apellido} \nTelefono: {item.Telefono}\n");
            }
        }

        public void EliminarContacto(List<Contacto> contactos)
        {

            Console.WriteLine("Introduzca el numero del contacto que se quiere eliminar");
            Console.Write("Telefono: ");
            string tele = Console.ReadLine();

            for (int i = 0; i < contactos.Count; i++)
            {
                if (contactos[i].Telefono == tele)
                {
                    contactos.Remove(contactos[i]);
                }
            }

            Console.Write("Contacto eliminado");
        }

    }

}
