using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Model.Model db = new Model.Model())
            {
                var custom = db.Orders.Join(db.Customers, a => a.CustomerID, b => b.CustomerID,(orders,customer) => new
                {
                    count = customer.CustomerID
                    , customer = customer.CustomerID
                }
                ).GroupBy(a=>a.customer);

                foreach (var q in custom)
                {
                    Console.WriteLine("{0}", q.Key);
                }

            }
            Console.ReadKey();
/*
            select cs.CustomerID,COUNT(cs.CustomerID)
            from dbo.Orders os
                inner join dbo.Customers cs on os.CustomerID = cs.CustomerID
            group by cs.CustomerID
            having COUNT(cs.CustomerID) = 3

*/

        }
    }
}
