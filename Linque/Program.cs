using LinqMastery.Data;
using LinqMastery.Models;
using System.Linq;
using System.Security.Cryptography;

namespace LinqMastery;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("LINQ Mastery Practice Project");
        Console.WriteLine("Uncomment one exercise method at a time in Main().");

        Exercise01_Filtering();
        Exercise02_Projection();
        Exercise03_SelectMany();
        Exercise04_Sorting();
        Exercise05_ElementOperators();
        Exercise06_Aggregation();
        Exercise07_AnyAll();
        Exercise08_Grouping();
        Exercise09_SetOperations();
        Exercise10_InnerJoin();
        Exercise11_LeftJoin();
        Exercise12_GroupJoin();
        Exercise13_Partitioning();
        Exercise14_QuantifiersAndMembership();
        Exercise15_StringAndNumericQueries();
        Exercise16_NestedQueries();
        Exercise17_CombinedQueries();
        Exercise18_DictionaryAndLookup();
        Exercise19_JoinOrdersAndCustomers();
        Exercise20_Reports();
    }

    // RULE: For every task, implement both styles where supported.
    // Use these labels to keep your work organised:
    // METHOD SYNTAX PRACTICE
    // QUERY SYNTAX PRACTICE

    static void Exercise01_Filtering()
    {
        var products = StoreData.Products;

        // Task 1: Find products priced above 5,000.
        // METHOD SYNTAX PRACTICE
        // TODO: products.Where(...)

        //var m1 = products.Where(p => p.Price > 5000m);
        //foreach (var p in m1)
        //    Console.WriteLine($"{p.ProductName}: {p.Price}");

        //// QUERY SYNTAX PRACTICE
        //// TODO: from p in products where ... select p

        //var m2 = from p in products where p.Price > 5000m select p;
        //foreach (var p in m2)
        //    Console.WriteLine($"{p.ProductName}:{p.Price}");

        //// Task 2: Find Electronics products that are in stock.
        //// METHOD SYNTAX PRACTICE
        //// TODO: Where with &&

        //var m3 = products.Where(p => p.Category == "Electronics" && p.Stock > 0);
        //foreach (var p in m3)
        //    Console.WriteLine($"{p.Category}:{p.Stock}");


        //// QUERY SYNTAX PRACTICE
        //// TODO: where with &&
        //var m4 = from p in products where p.Category == ("Electronics") && p.Stock > 0 select p;
        //foreach (var p in m4)
        //    Console.WriteLine($"{p.Category}:{p.Price}");

        //// Task 3: Find products priced between 1,000 and 20,000.
        //// METHOD SYNTAX PRACTICE
        //// TODO
        //var m5 = products.Where(p => p.Price >= 1000m && p.Price <= 20000m);
        //foreach (var p in m5)
        //    Console.WriteLine($"{p.ProductName}:{p.Price}");

        //// QUERY SYNTAX PRACTICE
        //// TODO

        //var m6 = from p in products where p.Price >= 1000m && p.Price <= 20000m select p;
        //foreach (var p in m6)
        //    Console.WriteLine($"{p.ProductName}:{p.Price}");

        //// Task 4: Find products whose names contain "Office".
        //// METHOD SYNTAX PRACTICE
        //// TODO: Contains()
        //var m7 = products.Where(p => p.ProductName.Contains("Office"));
        //foreach (var p in m7)
        //    Console.WriteLine($"{p.ProductName}");

        //// QUERY SYNTAX PRACTICE
        //// TODO

        //var m8 = from p in products where p.ProductName.Contains("Office") select p;
        //foreach (var p in m8)
        //    Console.WriteLine($"{p.ProductName}");

    }

    static void Exercise02_Projection()
    {
        var products = StoreData.Products;

        // Task 1: Select only product names.
        // METHOD SYNTAX PRACTICE
        // TODO: Select(...)
        //var m9 = products.Select(p => p);
        //foreach (var p in m9)
        //    Console.WriteLine($"{p.ProductName}");



        //// QUERY SYNTAX PRACTICE
        //// TODO: select p.ProductName
        //var m10 = from p in products select p.ProductName;
        //foreach (var p in m10)
        //    Console.WriteLine(p);

        //// Task 2: Return ProductName and Price using an anonymous type.
        //// METHOD SYNTAX PRACTICE
        //// TODO: Select(p => new { ... })
        //var m11 = products.Select(p => new { p.ProductName, p.Price });
        //foreach (var p in m11)
        //    Console.WriteLine($"{p.ProductName}:{p.Price}");

        //// QUERY SYNTAX PRACTICE
        //// TODO: select new { ... }
        //var m12 = from p in products select new { p.ProductName, p.Price };
        //foreach (var p in m12)
        //    Console.WriteLine($"{p.ProductName}:{p.Price}");

        //// Task 3: Return ProductName, Price, and PriceWithTax (18%).
        //// METHOD SYNTAX PRACTICE
        //// TODO
        //var m13 = products.Select(p => new { p.ProductName, p.Price, PriceWithTax = p.Price * 1.18m });
        //foreach (var p in m13)
        //    Console.WriteLine($"ProductName: {p.ProductName}:Price: {p.Price}: Tax: {p.PriceWithTax}");


        //// QUERY SYNTAX PRACTICE
        //// TODO
        //var m14 = from p in products select new {p.ProductName,p.Price,PriceWithTax = p.Price * 1.18m};
        //foreach (var p in m14)
        //    Console.WriteLine($"ProductName: {p.ProductName}:Price: {p.Price}: Tax: {p.PriceWithTax}");
    }

    static void Exercise03_SelectMany()
    {
        var batches = StoreData.TrainingBatches;
        var products = StoreData.Products;

        // Task 1: Flatten all training batches into one sequence.
        // METHOD SYNTAX PRACTICE
        // TODO: SelectMany()
        var m15 = batches.SelectMany(p => p);
        foreach (var p in m15)
            Console.WriteLine(p);

        // QUERY SYNTAX PRACTICE
        // TODO: use two from clauses
        var m16 = from batch in batches from course in batch select course;
        foreach (var p in m16)
            Console.WriteLine(p);
        // Task 2: Get every product tag as one flat sequence.
        // METHOD SYNTAX PRACTICE
        // TODO
        var m = products.SelectMany(p => p.Tags);
        foreach (var p in m)
            Console.WriteLine(p);

        // QUERY SYNTAX PRACTICE
        // TODO
        var m18 = from p in products from tag in p.Tags select tag;
        foreach (var p in m18)
            Console.WriteLine(p);
    }

    static void Exercise04_Sorting()
    {
        var products = StoreData.Products;

        // Task 1: Sort by price ascending.
        // METHOD SYNTAX PRACTICE
        // TODO: OrderBy()

        var c = products.OrderBy(p => p.Price);
        foreach (var p in c)
            Console.WriteLine($"{p.Price}");

        // QUERY SYNTAX PRACTICE
        // TODO: orderby
        var b = from p in products orderby p.Price select p;
        foreach (var p in b)
            Console.WriteLine(p.Price);

        // Task 2: Sort by price descending.
        // METHOD SYNTAX PRACTICE
        // TODO: OrderByDescending
        var c1 = products.OrderByDescending(p => p.Price);
        foreach (var p in c1)
            Console.WriteLine(p.Price);

        // QUERY SYNTAX PRACTICE
        // TODO: orderby ... descending
        var d = from p in products orderby p.Price descending select p;
        foreach (var p in d)
            Console.WriteLine(p.Price);

        // Task 3: Sort by Category ascending, then Price descending.
        // METHOD SYNTAX PRACTICE
        // TODO: OrderBy().ThenByDescending()
        var e = products.OrderBy(p => p.Category).ThenByDescending(p => p.Price);
        foreach (var p in e)
            Console.WriteLine($"{p.Category}: {p.Price}");


        // QUERY SYNTAX PRACTICE
        // TODO
        var f = from p in products orderby p.Category, p.Price descending select p;
        foreach (var p in f)
            Console.WriteLine($"{p.Category}: {p.Price}");
    }

    static void Exercise05_ElementOperators()
    {
        var products = StoreData.Products;

        // Task 1: Find the first product priced above 10,000.
        // METHOD SYNTAX PRACTICE
        // TODO: First()
        var a1 = products.First(p => p.Price > 10000m);
        Console.WriteLine(a1.ProductName);


        // QUERY SYNTAX PRACTICE
        // TODO: query + First()
        var b1 = (from p in products where p.Price > 10000m select p).First();
        Console.WriteLine(b1.ProductName);


        // Task 2: Search for ProductId 999 safely.
        // METHOD SYNTAX PRACTICE
        // TODO: FirstOrDefault()
        var c = products.FirstOrDefault(p => p.ProductId == 1);
        if (c != null)
            Console.WriteLine($"Product Found: {c.ProductName}");
        else
            Console.WriteLine("Product not found");

        // QUERY SYNTAX PRACTICE
        // TODO: query + FirstOrDefault()
        var d = (from p in products where p.ProductId == 9 select p).FirstOrDefault();
        if (d != null)
            Console.WriteLine(d.ProductName);
        else
            Console.WriteLine("Product not found");

        // Task 3: Find ProductId 3 using Single().
        // METHOD SYNTAX PRACTICE
        // TODO: Single()
        var e = products.Single(p => p.ProductId == 3);
        Console.WriteLine(e.ProductName);


        // QUERY SYNTAX PRACTICE
        // TODO: query + Single()
        var f = (from p in products where p.ProductId == 3 select p).Single();
        Console.WriteLine(f.ProductName);
    }

    static void Exercise06_Aggregation()
    {
        var products = StoreData.Products;

        // Task 1: Count all products.
        // METHOD SYNTAX PRACTICE
        // TODO: Count()
        var a = products.Count();
        Console.WriteLine(a);

        // QUERY SYNTAX PRACTICE
        // TODO: query + Count()
        var b = (from p in products select p).Count();
        Console.WriteLine(b);


        // Task 2: Calculate total stock.
        // METHOD SYNTAX PRACTICE
        // TODO: Sum()
        var c = products.Sum(p => p.Stock);
        Console.WriteLine(c);

        // QUERY SYNTAX PRACTICE
        // TODO: query + Sum()
        var d = (from p in products select p.Stock).Sum();
        Console.WriteLine(d);

        // Task 3: Find average, minimum and maximum price.
        // METHOD SYNTAX PRACTICE
        // TODO
        Console.WriteLine(products.Average(p => p.Price));
        Console.WriteLine(products.Min(p => p.Price));
        Console.WriteLine(products.Max(p => p.Price));

        // QUERY SYNTAX PRACTICE
        // TODO
        var e = from p in products select p.Price;
        Console.WriteLine(e.Average());
        Console.WriteLine(e.Min());
        Console.WriteLine(e.Max());


        // Task 4: Calculate total inventory value (Price * Stock).
        // METHOD SYNTAX PRACTICE
        // TODO
        var f = products.Sum(p => p.Price * p.Stock);
        Console.WriteLine(f);

        // QUERY SYNTAX PRACTICE
        // TODO
        var g = (from p in products select p.Price * p.Stock).Sum();
        Console.WriteLine(g);
    }

    static void Exercise07_AnyAll()
    {
        var products = StoreData.Products;

        // Task 1: Check whether any product costs more than 50,000.
        // METHOD SYNTAX PRACTICE
        // TODO: Any()
        var a = products.Any(p => p.Price > 50000m);
        Console.WriteLine(a);

        // QUERY SYNTAX PRACTICE
        // TODO: query + Any()
        var b = (from p in products where p.Price > 50000m select p).Any();
        Console.WriteLine(b);


        // Task 2: Check whether all products have non-negative stock.
        // METHOD SYNTAX PRACTICE
        // TODO: All()
        var c = products.All(p => p.Stock >= 0);
        Console.WriteLine(c);

        // QUERY SYNTAX PRACTICE
        // TODO: query + All()
        var d = (from p in products where p.Stock < 0 select p).Any() == false;
        Console.WriteLine(d);
    }

    static void Exercise08_Grouping()
    {
        var products = StoreData.Products;

        // Task 1: Group products by Category.
        // METHOD SYNTAX PRACTICE
        // TODO: GroupBy()
        var a = products.GroupBy(p => p.Category);
        foreach (var group in a)
        {
            Console.WriteLine(group.Key);
            foreach (var p in group)
                Console.WriteLine(p.ProductName);
        }


        // QUERY SYNTAX PRACTICE
        // TODO: group ... by ...
        var b = from p in products group p by p.Category;
        foreach (var group in b)
        {
            Console.WriteLine(group.Key);
            foreach (var p in group)
                Console.WriteLine(p.ProductName);
        }

        // Task 2: For each category, calculate product count,
        // total stock, and average price.
        // METHOD SYNTAX PRACTICE
        // TODO: GroupBy + Select
        var c = products.GroupBy(p => p.Category).Select(g => new {Category = g.Key,Count = g.Count(),TotalStock = g.Sum(p => p.Stock),AveragePrice = g.Average(p => p.Price)});
        foreach (var p in c)
            Console.WriteLine($"{p.Category}: {p.Count}, {p.TotalStock}, {p.AveragePrice}");

        // QUERY SYNTAX PRACTICE
        // TODO: group ... by ... into ...
        var d = from p in products group p by p.Category into g select new {Category = g.Key,Count = g.Count(),TotalStock = g.Sum(p => p.Stock),AveragePrice = g.Average(p => p.Price)};
        foreach (var p in d)
            Console.WriteLine($"{p.Category}: {p.Count}, {p.TotalStock}, {p.AveragePrice}");
    }

    static void Exercise09_SetOperations()
    {
        var a = StoreData.ListA;
        var b = StoreData.ListB;

        // Task 1: Remove duplicates.
        // METHOD SYNTAX PRACTICE
        // TODO: Distinct()
        var c = a.Distinct();
        foreach (var p in c)
            Console.WriteLine(p);


        // QUERY SYNTAX PRACTICE
        // TODO: query + Distinct()
        var d = (from p in a select p).Distinct();
        foreach (var p in d)
            Console.WriteLine(p);

        // Task 2: Find union, intersection and A-only values.
        // METHOD SYNTAX PRACTICE
        // TODO: Union(), Intersect(), Except()
        var e = a.Union(b);
        var f = a.Intersect(b);
        var g = a.Except(b);
        foreach (var p in e)
            Console.WriteLine(p);
        foreach (var p in f)
            Console.WriteLine(p);
        foreach (var p in g)
            Console.WriteLine(p);

        // QUERY SYNTAX PRACTICE
        // TODO: query results + set operators
        var h = from p in a select p;
        var i = from p in b select p;
        foreach (var p in h.Union(i))
            Console.WriteLine(p);
        foreach (var p in h.Intersect(i))
            Console.WriteLine(p);
        foreach (var p in h.Except(i))
            Console.WriteLine(p);
    }

    static void Exercise10_InnerJoin()
    {
        var employees = StoreData.Employees;
        var departments = StoreData.Departments;

        // Task: Display EmployeeName and DepartmentName for matching records.
        // METHOD SYNTAX PRACTICE
        // TODO: Join()
        var a = employees.Join(departments,
        e => e.DepartmentId,
        d => d.DepartmentId,
        (e, d) => new
        {e.EmployeeName,d.DepartmentName});
        foreach (var p in a)
            Console.WriteLine($"{p.EmployeeName}: {p.DepartmentName}");

        // QUERY SYNTAX PRACTICE
        // TODO: join ... on ... equals ...
        var b = from e in employees join d in departments on e.DepartmentId equals d.DepartmentId select new{e.EmployeeName,d.DepartmentName};
        foreach (var p in b)
            Console.WriteLine($"{p.EmployeeName}: {p.DepartmentName}");
    }

    static void Exercise11_LeftJoin()
    {
        var employees = StoreData.Employees;
        var departments = StoreData.Departments;

        // Task: Return every employee, displaying "Unassigned" if
        // no matching department exists.
        // METHOD SYNTAX PRACTICE
        // TODO: LeftJoin() on .NET 10, or GroupJoin + SelectMany
        var a = employees.GroupJoin(departments,
        e => e.DepartmentId,
        d => d.DepartmentId,
        (e, dept) => new { e, dept })
        .SelectMany(x => x.dept.DefaultIfEmpty(),
        (x, d) => new
        {x.e.EmployeeName,DepartmentName = d == null ? "Unassigned" : d.DepartmentName});
        foreach (var p in a)
            Console.WriteLine($"{p.EmployeeName}: {p.DepartmentName}");


        // QUERY SYNTAX PRACTICE
        // TODO: join ... into ... then DefaultIfEmpty()
        var b = from e in employees join d in departments on e.DepartmentId equals d.DepartmentId into dept
                from d in dept.DefaultIfEmpty()select new{e.EmployeeName,DepartmentName = d == null ? "Unassigned" : d.DepartmentName};
        foreach (var p in b)
            Console.WriteLine($"{p.EmployeeName}: {p.DepartmentName}");
    }

    static void Exercise12_GroupJoin()
    {
        var employees = StoreData.Employees;
        var departments = StoreData.Departments;

        // Task: Return each department with its employee count.
        // METHOD SYNTAX PRACTICE
        // TODO: GroupJoin()
        var a = departments.GroupJoin(employees, d => d.DepartmentId, e => e.DepartmentId,
       (d, emp) => new
       {
           d.DepartmentName,
           EmployeeCount = emp.Count()
       });
        foreach (var p in a)
            Console.WriteLine($"{p.DepartmentName}: {p.EmployeeCount}");

        // QUERY SYNTAX PRACTICE
        // TODO: join ... into ...
        var b = from d in departments
                join e in employees
                on d.DepartmentId equals e.DepartmentId into emp
                select new
                {
                    d.DepartmentName,
                    EmployeeCount = emp.Count()
                };
        foreach (var p in b)
            Console.WriteLine($"{p.DepartmentName}: {p.EmployeeCount}");
    }

    static void Exercise13_Partitioning()
    {
        var products = StoreData.Products.OrderBy(p => p.ProductId);

        // Task 1: Get first three products.
        // METHOD SYNTAX PRACTICE
        // TODO: Take(3)
        var a = products.Take(3);
        foreach (var p in a)
            Console.WriteLine(p.ProductName);

        // QUERY SYNTAX PRACTICE
        // TODO: query + Take(3)
        var b = (from p in products select p).Take(3);
        foreach (var p in b)
            Console.WriteLine(p.ProductName);

        // Task 2: Skip first three products.
        // METHOD SYNTAX PRACTICE
        // TODO: Skip(3)
        var c = products.Skip(3);
        foreach (var p in c)
            Console.WriteLine(p.ProductName);

        // QUERY SYNTAX PRACTICE
        // TODO: query + Skip(3)
        var d = (from p in products select p).Skip(3);
        foreach (var p in d)
            Console.WriteLine(p.ProductName);
    }

    static void Exercise14_QuantifiersAndMembership()
    {
        var products = StoreData.Products;
        List<int> requestedIds = new() { 1, 3, 5 };

        // Task: Find products whose IDs occur in requestedIds.
        // METHOD SYNTAX PRACTICE
        // TODO: Where + Contains
        var a = products.Where(p => requestedIds.Contains(p.ProductId));
        foreach (var p in a)
            Console.WriteLine(p.ProductName);


        // QUERY SYNTAX PRACTICE
        // TODO: where + Contains
        var b = from p in products where requestedIds.Contains(p.ProductId) select p; 

        foreach (var p in b)
            Console.WriteLine(p.ProductName);
    }

    static void Exercise15_StringAndNumericQueries()
    {
        var products = StoreData.Products;

        // Task 1: Find names starting with "O".
        // METHOD SYNTAX PRACTICE
        // TODO: StartsWith()
        var a = products.Where(p => p.ProductName.StartsWith("O"));
        foreach (var p in a)
            Console.WriteLine(p.ProductName);

        // QUERY SYNTAX PRACTICE
        // TODO
        var b = from p in products where p.ProductName.StartsWith("O") select p;
        foreach (var p in b)
            Console.WriteLine(p.ProductName);

        // Task 2: Find products with even ProductIds.
        // METHOD SYNTAX PRACTICE
        // TODO: modulo operator %
        var c = products.Where(p => p.ProductId % 2 == 0);
        foreach (var p in c)
            Console.WriteLine(p.ProductId);


        // QUERY SYNTAX PRACTICE
        // TODO
        var d = from p in products where p.ProductId % 2 == 0 select p;
        foreach (var p in d)
            Console.WriteLine(p.ProductId);
    }

    static void Exercise16_NestedQueries()
    {
        var products = StoreData.Products;
        var orders = StoreData.Orders;

        // Task 1: Find products priced above average.
        // METHOD SYNTAX PRACTICE
        // TODO: Average + Where
        var average = products.Average(p => p.Price);
        var a = products.Where(p => p.Price > average);
        foreach (var p in a)
            Console.WriteLine(p.ProductName);

        // QUERY SYNTAX PRACTICE
        // TODO
        var b = from p in products where p.Price > products.Average(x => x.Price) select p;
        foreach (var p in b)
            Console.WriteLine(p.ProductName);



        // Task 2: Find customers with at least one order.
        // METHOD SYNTAX PRACTICE
        // TODO: Where + Any
        var customers = StoreData.Customers;
        var c1 = customers.Where(c => orders.Any(o => o.CustomerId == c.CustomerId));
        foreach (var p in c1)
            Console.WriteLine(p.CustomerName);


        // QUERY SYNTAX PRACTICE
        // TODO

        var d = from c in customers
                where (from o in orders
                       where o.CustomerId == c.CustomerId
                       select o).Any()
                select c;

        foreach (var p in d)
            Console.WriteLine(p.CustomerName);
    }

    static void Exercise17_CombinedQueries()
    {
        var products = StoreData.Products;

        // Task: Find in-stock Electronics products, sort by descending
        // price, and return only product names.
        // METHOD SYNTAX PRACTICE
        // TODO: Where + OrderByDescending + Select
        var a = products.Where(p => p.Category == "Electronics" && p.Stock > 0).OrderByDescending(p => p.Price).Select(p => p.ProductName);
        foreach (var p in a)
            Console.WriteLine(p);

        // QUERY SYNTAX PRACTICE
        // TODO: from + where + orderby + select
        var b = from p in products
                where p.Category == "Electronics" && p.Stock > 0
                orderby p.Price descending
                select p.ProductName;
        foreach (var p in b)
            Console.WriteLine(p);
    }

    static void Exercise18_DictionaryAndLookup()
    {
        var products = StoreData.Products;

        // Task 1: Create a dictionary keyed by ProductId.
        // METHOD SYNTAX PRACTICE
        // TODO: ToDictionary()
        var a = products.ToDictionary(p => p.ProductId);
        // QUERY SYNTAX PRACTICE
        // TODO: query + ToDictionary()
        var b = (from p in products select p).ToDictionary(p => p.ProductId);
        // Task 2: Create a lookup by Category.
        // METHOD SYNTAX PRACTICE
        // TODO: ToLookup()
        var c = products.ToLookup(p => p.Category);

        // QUERY SYNTAX PRACTICE
        // TODO: query + ToLookup()
        var d = (from p in products
                 select p).ToLookup(p => p.Category);

        foreach (var p in c["Electronics"])
            Console.WriteLine(p.ProductName);

        foreach (var p in d["Furniture"])
            Console.WriteLine(p.ProductName);
    }

    static void Exercise19_JoinOrdersAndCustomers()
    {
        var orders = StoreData.Orders;
        var customers = StoreData.Customers;

        // Task: Show OrderId, CustomerName, OrderDate and Status.
        // METHOD SYNTAX PRACTICE
        // TODO: Join + Select
        var a = orders.Join(customers,
        o => o.CustomerId,
        c => c.CustomerId,
        (o, c) => new
        {
            o.OrderId,
            c.CustomerName,
            o.OrderDate,
            o.Status
        });
        foreach (var p in a)
            Console.WriteLine($"{p.OrderId}: {p.CustomerName}: {p.OrderDate}: {p.Status}");


        // QUERY SYNTAX PRACTICE
        // TODO: join + select
        var b = from o in orders
                join c in customers
                on o.CustomerId equals c.CustomerId
                select new
                {
                    o.OrderId,
                    c.CustomerName,
                    o.OrderDate,
                    o.Status
                };
        foreach (var p in b)
            Console.WriteLine($"{p.OrderId}: {p.CustomerName}: {p.OrderDate}: {p.Status}");
    }

    static void Exercise20_Reports()
    {
        var products = StoreData.Products;
        var orders = StoreData.Orders;

        // Task 1: Count orders by Status.
        // METHOD SYNTAX PRACTICE
        // TODO: GroupBy + Count
        var a = orders.GroupBy(o => o.Status)
                  .Select(g => new
                  {
                      Status = g.Key,
                      Count = g.Count()
                  });
        foreach (var p in a)
            Console.WriteLine($"{p.Status}: {p.Count}");


        // QUERY SYNTAX PRACTICE
        // TODO: group by + Count
        var b = from o in orders
                group o by o.Status into g
                select new
                {
                    Status = g.Key,
                    Count = g.Count()
                };
        foreach (var p in b)
            Console.WriteLine($"{p.Status}: {p.Count}");


        // Task 2: Create a category report with product count,
        // average price, total stock and inventory value.
        // METHOD SYNTAX PRACTICE
        // TODO
        var c = products.GroupBy(p => p.Category)
                    .Select(g => new
                    {
                        Category = g.Key,
                        ProductCount = g.Count(),
                        AveragePrice = g.Average(p => p.Price),
                        TotalStock = g.Sum(p => p.Stock),
                        InventoryValue = g.Sum(p => p.Price * p.Stock)
                    });

        foreach (var p in c)
            Console.WriteLine($"{p.Category}: Count={p.ProductCount}, Average={p.AveragePrice}, Stock={p.TotalStock}, Value={p.InventoryValue}");


        // QUERY SYNTAX PRACTICE
        // TODO
        var d = from p in products
                group p by p.Category into g
                select new
                {
                    Category = g.Key,
                    ProductCount = g.Count(),
                    AveragePrice = g.Average(p => p.Price),
                    TotalStock = g.Sum(p => p.Stock),
                    InventoryValue = g.Sum(p => p.Price * p.Stock)
                };
        foreach (var p in d)
            Console.WriteLine($"{p.Category}: Count={p.ProductCount}, Average={p.AveragePrice}, Stock={p.TotalStock}, Value={p.InventoryValue}");
    }
}
