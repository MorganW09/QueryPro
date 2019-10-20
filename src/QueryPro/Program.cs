using System;
using System.Linq;

namespace QueryPro
{
    class Program
    {
        static void Main(string[] args)
        {

            var provider = new QueryProvider();
            var customer = new Query<Customer>(provider);

            IQueryable<Customer> query = customer.Where(c => c.Id == 1);
            
            Console.WriteLine($"query: {query}");
            Console.ReadKey();
        }
    }
}
