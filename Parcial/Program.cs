using Parcial.Classes;
using System;
using System.Collections.Generic;

namespace Parcial
{
    class Program
    {
        public enum Servicios
        {
            internet, luz, telefono, agua, comida 
        }
        public enum Publici
        {
            redes_sociales, Prensa, pancartas, volantes
        }
        public enum Donaciones
        {
            Q500, Q100, Q200, Q1000 
        }
        public interface IFilter<T>
        {
            IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
        }
        public interface ISpecification<T>
        {
            bool IsSatisfied(client c);
        }
        public class BetterFilter : IFilter<client>
        {
            public IEnumerable<client> Filter(IEnumerable<client> items, ISpecification<client> spec)
            {
                foreach (var c in items)
                {
                    if (spec.IsSatisfied(c))
                    {
                        yield return c;
                    }
                }
            }
        }
        public class client
        {
            public string nombre;
            public Donaciones donacion;
            public Servicios ser;
            public Publici publicid;
            public client(string name, Donaciones donat, Publici publi, Servicios servicios)
            {
                nombre = name ?? throw new ArgumentNullException(paramName: nameof(name));
                donacion = donat;
                ser = servicios;
                publicid = publi;
            }
        }
        public class DonacionSpecification : ISpecification<client>
        {
            private Donaciones donaci;
            public DonacionSpecification(Donaciones donaciones)
            {
                this.donaci = donaciones;
            }
            public bool IsSatisfied(client c)
            {
                return c.donacion == donaci;
            }
        }
        public class ServicioSpecification : ISpecification<client>
        {
            private Servicios services;
            public ServicioSpecification(Servicios servic)
            {
                this.services = servic;
            }
            public bool IsSatisfied(client c)
            {
                return c.ser == services;
            }
        }
        public class PublicidadSpecification : ISpecification<client>
        {
            private Publici publici;
            public PublicidadSpecification(Publici publi)
            {
                this.publici = publi;
            }
            public bool IsSatisfied(client c)
            {
                return c.publicid == publici;
            }
        }
        static void Main(string[] args)
        {
            var C1 = new client("Edgar", Donaciones.Q500, Publici.redes_sociales, Servicios.comida);
            var C2 = new client("Sophia", Donaciones.Q1000, Publici.pancartas, Servicios.internet);

            client[] clients = { C1, C2 };

            var donation = new DonacionSpecification(Donaciones.Q1000);
            var betterf = new BetterFilter();
            var services = new ServicioSpecification(Servicios.internet);
            var publicity = new PublicidadSpecification(Publici.redes_sociales);

            Console.WriteLine("Donaciones a Q1000+: ");
            foreach (var p in betterf.Filter(clients, donation))
                Console.WriteLine($" -{p.nombre} hizo una donación para {p.ser} y {p.publicid}");

            Console.WriteLine("Donaciones a Q500: ");
            foreach (var p in betterf.Filter(clients, publicity))
                Console.WriteLine($" -{p.nombre} hizo una donación para {p.ser} y {p.publicid}");
        }
    }
}
