using ClassDemoKommentarerLib.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoKommentarerLib.repositories
{
    /// <summary>
    /// Repositoriet indeholder Pizzaer og understøtter CRUD operationer
    /// </summary>
    public class PizzaRepository
    {
        // instance field
        private List<Pizza> _pizzas;

        /// <summary>
        /// Initialiserer repositoriet med en tom liste af pizzaer, medmindre mockdata et sat til true
        /// </summary>
        /// <param name="mockData">Angiver om der skal udfyldes med mock data eller ej, default er false</param>
        public PizzaRepository(bool mockData=false)
        {
            _pizzas = new List<Pizza>();

            if (mockData )
            {
                PopulateData();
            }
        }

        
        /// <summary>
        /// Giver en kopi af den interne liste
        /// </summary>
        /// <returns>Liste med alle pizzaerne</returns>
        public List<Pizza> GetAll()
        {
            return new List<Pizza>(_pizzas);
        }

        /// <summary>
        /// Finder en pizza med det givne id
        /// </summary>
        /// <param name="id">Det id på en pizza vi søger</param>
        /// <returns>Et pizza objekt med det givne id</returns>
        /// <exception cref="KeyNotFoundException">Hvis der ikke findes en pizza med id'et kastes denne exception</exception>
        public Pizza GetById(int id)
        {
            Pizza? pizza = _pizzas.Find(p => p.Id == id);
            if( pizza is null)
            {
                throw new KeyNotFoundException($"No pizza with id {id}");
            }
            return pizza;
        }

        /// <summary>
        /// Tilføjer den angivne pizza til listen
        /// </summary>
        /// <param name="pizza">Den nye pizza</param>
        /// <returns>Den tilføjede pizza med et opdateret ID</returns>
        public Pizza Add(Pizza pizza)
        {
            pizza.Id = GenerateId();
            _pizzas.Add(pizza);
            return pizza;
        }

        /// <summary>
        /// Sletter en pizza fra listen, med det angivne id
        /// </summary>
        /// <param name="id">Det id på den pizza der skal slettes</param>
        /// <returns>Det pizza objekt er slettet</returns>
        /// <exception cref="KeyNotFoundException">Hvis der ikke findes en pizza med id'et kastes denne exception</exception>
        public Pizza Delete(int id)
        {
            Pizza pizza = GetById(id);
            _pizzas.Remove(pizza);
            return pizza;
        }

        /// <summary>
        /// Finder en pizza med det givne id og updaterer med værdierne fra det angivne pizza objekt
        /// </summary>
        /// <param name="id">Det id på den pizza der skal opdateres</param>
        /// <param name="pizza">Pizza objekt med de nye værdier</param>
        /// <returns>Det pizza objekt der er opdatteret</returns>
        /// <exception cref="ArgumentException">Hvis id ikke stemmer overens med id i pizza</exception>
        /// <exception cref="KeyNotFoundException">Hvis der ikke findes en pizza med id'et kastes denne exception</exception>
        public Pizza Update(int id, Pizza pizza)
        {
            if (id != pizza.Id)
            {
                throw new ArgumentException("kan ikke updatere id og id i pizza er forskellige");
            }

            int index = _pizzas.IndexOf(GetById(id));
            _pizzas[index] = pizza;
            return _pizzas[index];
        }




        // help function to find next Id
        private int GenerateId()
        {
            return (_pizzas.Count == 0) ? 1 : _pizzas.Max(p => p.Id) + 1;
        }

        // help funktion to insert some mock data into the list
        private void PopulateData()
        {
            _pizzas.Clear();
            _pizzas.Add(new Pizza(1, "Vesio", 51));
            _pizzas.Add(new Pizza(2, "Napolitaina", 54));
            _pizzas.Add(new Pizza(4, "Magarita", 51));
            _pizzas.Add(new Pizza(5, "Pedro", 55));
            _pizzas.Add(new Pizza(6, "Jacoby", 55));

        }
    }
}
