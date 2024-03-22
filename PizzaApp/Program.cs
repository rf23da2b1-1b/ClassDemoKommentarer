// See https://aka.ms/new-console-template for more information
using ClassDemoKommentarerLib.model;
using ClassDemoKommentarerLib.repositories;

Console.WriteLine("Velkommen til Don't taste Pizza");
Console.WriteLine("... eat them");


PizzaRepository repo = new PizzaRepository(true);

foreach (var pizza in repo.GetAll())
{
    Console.WriteLine(pizza);
}

Pizza pizza1 = new Pizza(99, "Mega", 99);
Console.WriteLine(pizza1);
Pizza pizza1a = repo.Add(pizza1);
Console.WriteLine(pizza1a);

Pizza p2 = repo.GetById(2);
Console.WriteLine(p2);


