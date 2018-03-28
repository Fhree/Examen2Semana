using System;
using System.Linq;
using System.Collections.Generic;

namespace ExamenSegundaSemana
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Ingredient> listIng = new List<Ingredient>()
            {
                new Ingredient(Guid.NewGuid(),"Tomate",5),
                new Ingredient(Guid.NewGuid(),"Mozzarella",10),
                new Ingredient(Guid.NewGuid(),"Ternera",30)
            };

            List<Pizza> listPizza = new List<Pizza>()
            {
                new Pizza(Guid.NewGuid(),"Napolitana",new List<Ingredient>(){
                    listIng[0],listIng[1]
                    }),
                new Pizza(Guid.NewGuid(),"Carbonara",new List<Ingredient>(){
                    listIng[0],listIng[2]
                    }),
                new Pizza(Guid.NewGuid(),"4 Quesos", new List<Ingredient>() {})
            };


            var resul = from p in listPizza
                        where p.Ingredientes.Count() >  0
                        select new
                        {
                            p.Id,
                            p.Name,
                            pt = p.precioTotal()
                        };

            foreach (var aux in resul)
            {
               Console.WriteLine(aux.ToString());
            }

            var resul2 = from p in listPizza
                         where p.Ingredientes.Count() == 0
                        select new
                        {
                            p.Id,
                            p.Name,
                            pt = p.precioTotal()
                        };

            foreach (var aux in resul)
            {
                Console.WriteLine(aux.ToString());
            }


            Console.ReadKey();


        }
    }

    public interface DataMapper {
        void Create(Object o);
        void Delete(Object o);
        void Update(Object o);

    }

    public interface QueryObject {
        Object Select(Guid id)
    }

    public class Pizza {

        public Guid Id { get; set; }
        public String Name { get; set; }
        public IEnumerable<Ingredient> Ingredientes { get; set; }


        public Pizza(Guid id, String name,IList<Ingredient> ingredientes)
        {
            Id = id;
            Name = name;
            Ingredientes = ingredientes;
        }

        public Decimal precioTotal()
        {
            Decimal precio = 0;
            foreach (var item in Ingredientes)
            {
                precio += item.Precio;
            }
            return precio * 1.2m;
        }
    }

    public class Ingredient {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public Decimal Precio { get; set; }

        public Ingredient(Guid id, String name, Decimal precio)
        {
            Id = id;
            Name = name;
            Precio = precio;
        }
    }
}
