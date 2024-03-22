using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoKommentarerLib.model
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public int Price { get; set; }

        public Pizza(int id, string name, int price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public Pizza():this(-1,"dummy",0)
        {
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Price)}={Price.ToString()}}}";
        }
    }
}
