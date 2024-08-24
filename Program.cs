using ConsoleApp7.data;
using ConsoleApp7.moduls;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationonDbcontext dbcontext = new ApplicationonDbcontext();

            product p1 = new product()
            {
                Name = "Laptop",
                Price = 999.99m
            };

            product p2 = new product()
            {
                Name = "phone",
                Price = 555.99m
            };

            product p3 = new product()
            {
                Name = "tablet",
                Price = 450.99m
            };



            dbcontext.products.Add(p1);
            dbcontext.products.Add(p2);
            dbcontext.products.Add(p3);

            order o1 = new order()
            {
                address = "123 Main St, Springfield",
                CreatedAt = DateTime.Now.AddDays(-1)
            };

            order o2 = new order()
            {
                address = "456 Elm St, Springfield",
                CreatedAt = DateTime.Now
            };

            order o3 = new order()
            {
                address = "789 Oak St, Springfield",
                CreatedAt = DateTime.Now.AddDays(-2)
            };


            dbcontext.orders.Add(o1);
            dbcontext.orders.Add(o2);
            dbcontext.orders.Add(o3);

            dbcontext.SaveChanges();
            Console.WriteLine("Products have been added to the database.");

            var products = dbcontext.products.ToList();

            // Display the products
            if (products.Any())
            {
                Console.WriteLine("List of Products:");
                foreach (var product in products)
                {
                    Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price:C}");
                }
            }

            var orders = dbcontext.orders.ToList();


            if (orders.Any())
            {
                // Display each order's details
                foreach (var order in orders)
                {
                    Console.WriteLine($"Order ID: {order.Id}");
                    Console.WriteLine($"Address: {order.address}");
                    Console.WriteLine($"Created At: {order.CreatedAt}");
                    Console.WriteLine("-----------");
                }
            }


            var product1 = dbcontext.products.First(p => p.Id == 1);
            product1.Name = "ipad";
            dbcontext.SaveChanges();



            var order1 = dbcontext.orders.FirstOrDefault(o => o.Id == 1);
            order1.CreatedAt = DateTime.Now;
            dbcontext.SaveChanges();

            var product2 = dbcontext.products.First(p => p.Id == 2);
            dbcontext.products.Remove(product2);
            dbcontext.SaveChanges();

            var order2 = dbcontext.orders.First(p => p.Id == 3);
            dbcontext.orders.Remove(order2);
            dbcontext.SaveChanges();


        }



    }
}
