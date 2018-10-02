using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

namespace EjercicioMartes2.Clases
{
    [Serializable]
    public class Datos
    {
        public List<Contacto> CargarDatos(string path)
        {

            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            List<Contacto> l = bf.Deserialize(fs) as List<Contacto>;
            fs.Close();
            return l;
        }

        public void GrabarDatos(List<Contacto> li, string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, li);
            fs.Close();
        }



        public void Buscar(List<Contacto> li)
        {

            System.Console.Write("Buscar telefono: ");
            string auxtel = System.Console.ReadLine();
            int flag = 0;

            foreach (Contacto c in li)
            {
                if (c.Telefono == auxtel)
                {
                    flag = 1;
                    Console.Write($"Telefono: {c.Telefono}\nNombre: {c.Nombre}\nApellido: {c.Apellido}\n");
                }

            }
            if (flag == 0)
            {
                Console.WriteLine("No se encuentra el contacto.");
            }

        }



        public Contacto ModificarContacto(string auxtel,List<Contacto> li){


            int flag = 0;

            foreach (Contacto c in li)
            {
                if (c.Telefono == auxtel)
                {
                    flag = 1;
                    Console.Write($"Telefono: {c.Telefono}\nNombre: {c.Nombre}\nApellido: {c.Apellido}\n");
                    li.Remove(c);break;
                }

            }

            if (flag == 0)
            {
                Console.WriteLine("No se encuentra el contacto."); return null;
            }


            Console.WriteLine($"Telefono: {auxtel}");


            Console.Write("Nombre: ");
            string nom = Console.ReadLine();

            Console.Write("Apellido: ");
            string ape = Console.ReadLine();

            Contacto auxx = new Contacto(auxtel, nom, ape);
            return auxx;
        }

    }
}