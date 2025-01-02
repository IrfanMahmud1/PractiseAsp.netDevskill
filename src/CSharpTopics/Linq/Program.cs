using Linq;

List<string> names = new List<string> { "apple", "banana", "mango" };
List<Order> order = new List<Order>
    {
        new Order{Item = "banana",Quantity = 10},
        new Order{Item = "mango",Quantity = 20},
        new Order{Item = "jackfruit",Quantity = 5},
    };
var quantity = (from o in order
join n in names on o.Item equals n
select o.Quantity);

foreach (var q in quantity)
{
    Console.WriteLine(q);
}
 var cnt = order.Count(x => x.Quantity > 5);