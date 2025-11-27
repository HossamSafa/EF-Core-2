using EF_Core_2.DatabaseContext;
using EF_Core_2.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using AirlineDbContext dbContext = new AirlineDbContext(); //open connection with db


            #region Insert a new airline "EgyptAir"
            var airline01 = dbContext.Airlines.FirstOrDefault(a => a.Name == "EgyptAir");

            if (airline01 is null)
            {
                airline01 = new Airline
                {
                    Name = "EgyptAir",
                    ContactPerson = "Ahmed Ali",
                    Phone1 = "0123456789",
                    Phone2 = "0113654789",
                    Address = "Cairo"
                };

                dbContext.Airlines.Add(airline01);
                dbContext.SaveChanges();
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine($"Airline {airline01.Name} already exists ==> ( {airline01.Id} )");
            }
            #endregion

            #region Add a new aircraft Model01 capacity 180 to EgyptAir
            var aircraft01 = dbContext.Aircrafts.FirstOrDefault(a => a.Model == "Model01" && a.AirlineId == airline01.Id);
            if (aircraft01 is null)
            {
                aircraft01 = new Aircraft
                {
                    Model = "Model01",
                    Capacity = 180,
                    AirlineId = airline01.Id
                };

                dbContext.Aircrafts.Add(aircraft01);
                dbContext.SaveChanges();
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine($"Aircraft {aircraft01.Model} already exists ==> ( {aircraft01.Id} )");
            }
            #endregion

            #region Record a new transaction amount 50000 desc "Tickets" for EgyptAir
            //var trans01 = new Transaction
            //{
            //    Amount = 50000,
            //    Description = "Tickets",
            //    Date = DateTime.Now,
            //    AirlineId = airline01.Id,
            //};

            //dbContext.Transactions.Add(trans01);
            //dbContext.SaveChanges();
            //Console.WriteLine("Done"); 
            #endregion

            #region Select all employees who work in "EgyptAir"
            //var employee = dbContext.Employees
            //        .Where(e => e.AirlineId == airline01.Id).ToList(); 
            #endregion

            #region Show all transactions (id, description, amount) recorded by "EgyptAir"
            //var trans02 = dbContext.Transactions.Where(t=>t.AirlineId==airline01.Id)
            //                                    .Select(t=> new
            //                                    {
            //                                        t.Id, t.Description, t.Amount, t.Date

            //                                    }).ToList(); 
            #endregion

            #region Get total number of employees working in each airline
            //var counts = dbContext.Airlines
            //    .Select(a => new
            //    {
            //        a.Name,
            //        EmployeeCount = a.Employees.Count()
            //    })
            //    .ToList();

            //Console.WriteLine("\nEmployee count per airline:");
            //foreach (var c in counts)
            //{
            //    Console.WriteLine($"{c.Name} : {c.EmployeeCount}");
            //} 
            #endregion

            #region Change capacity of Model01 aircraft to 200
            //var aircraftUpdate = dbContext.Aircrafts.FirstOrDefault(a => a.Model == "Model01" && a.AirlineId == airline01.Id);
            //if(aircraftUpdate is not null)
            //{
            //    aircraftUpdate.Capacity = 200;
            //    dbContext.SaveChanges();
            //    Console.WriteLine("Updated Done");
            //}
            //else
            //{
            //    Console.WriteLine("Model not found to update");
            //} 
            #endregion

            #region Delete all transactions older than 2020
            //var trans03 = dbContext.Transactions.Where(t=>t.Date.Year < 2020).ToList();

            //if (trans03.Any())
            //{
            //    dbContext.Transactions.RemoveRange(trans03);
            //    dbContext.SaveChanges();
            //    Console.WriteLine("Deleted Done");
            //}
            //else
            //{
            //    Console.WriteLine("Not found");
            //} 
            #endregion

            #region Insert route from Cairo to Dubai classification "International" distance 2400
             
            var route = dbContext.Routes.FirstOrDefault(r => r.Origin == "Cairo" && r.Destination == "Dubia");

            if (route is null)
            {
                route = new Route
                {
                    Origin = "Cairo",
                    Destination = "Dubia",
                    Classification = "International",
                    Distance = 2400
                };

                dbContext.Routes.Add(route);
                dbContext.SaveChanges();
                Console.WriteLine("Route ==> Cairo to Dubia");

            }
            else
            {
                Console.WriteLine("Already Exist");
            }

            #endregion

            //var aircraftRoute = dbContext.AircraftRoutes.FirstOrDefault(ar => ar.AircraftId == aircraft01.Id && ar.RouteId == route.Id);

            //if (aircraftRoute is null)
            //{
            //    var assignRoute = new AircraftRoute
            //    {
            //        AircraftId = aircraft01.Id,
            //        RouteId = route.Id,
            //        Duration = 4,
            //        Price = 3000m
            //    };

            //    dbContext.AircraftRoutes.Add(assignRoute);
            //    dbContext.SaveChanges();
            //    Console.WriteLine("\nAssigned Model01 to Cairo -> Dubai with duration 4h and price 3000 LE");
            //}
            //else
            //{
            //    Console.WriteLine("\nAssignment already exists between Model01 and Cairo->Dubai");
            //}
            Console.WriteLine();
            Console.WriteLine("########################################################");
            Console.WriteLine();

            #region Load "EgyptAir" With all its aircrafts and their routes
            //var result = dbContext.Airlines.Where(A=>A.Name == "EgyptAir")
            //    .Include(A=>A.Aircrafts)
            //    .ThenInclude(AR=>AR.AircraftRoutes)
            //    .ThenInclude(R=>R.Route)
            //    .FirstOrDefault();

            ////Console.WriteLine("EgyptAir with its aircrafts and routes:");

            //if(result is not null)
            //{
            //    foreach(var aircraft in result.Aircrafts)
            //    {
            //        Console.WriteLine($"Aircraft: {aircraft.Model} ({aircraft.Capacity})");
            //        foreach(var aircraftRoute in aircraft.AircraftRoutes)
            //            Console.WriteLine($"Route: {aircraftRoute.Route.Origin} To {aircraftRoute.Route.Destination}");
            //    }
            //} 
            #endregion

            #region Retrieve all airlines with their employees, and for each employee load their qualifications.
            //var result = dbContext.Airlines.Include(a=>a.Employees).ToList();

            //Console.WriteLine("\nAirlines with employees and qualifications:");

            //foreach (var airline  in result)
            //{
            //    Console.WriteLine($"Airline: {airline.Name}");
            //    foreach (var emp in airline.Employees)
            //    {
            //        Console.WriteLine($"Employee: {emp.Name}, Qualifications: {emp.Qualification1}, {emp.Qualification2}, {emp.Qualification3}");
            //    }
            //} 
            #endregion

            #region Load all airlines with their transactions, but only include transactions where Amount > 10000
            //var result = dbContext.Airlines.Include(a => a.Transactions.Where(t => t.Amount > 10000)).ToList();

            //Console.WriteLine("\nAirlines with transactions > 10000:");

            //foreach (var airline in result)
            //{
            //    Console.WriteLine($"Airline: {airline.Name}");
            //    foreach (var trx in airline.Transactions)
            //    {
            //        Console.WriteLine($"Transaction: {trx.Description}, Amount: {trx.Amount}");
            //    }
            //} 
            #endregion

            #region List all employees with their airline name
            //var employeesWithAirlinesName = dbContext.Employees
            //                                         .Join(dbContext.Airlines,
            //                                               e=>e.AirlineId,
            //                                               a=>a.Id,
            //                                               (e,a) => new
            //                                               {
            //                                                   EmployeeName = e.Name,
            //                                                   AirlineName = a.Name
            //                                               }
            //                                         ).ToList();

            //Console.WriteLine("\nEmployees with their airline name:");

            //foreach ( var item in employeesWithAirlinesName )
            //    Console.WriteLine($"Empolyee: {item.EmployeeName}, Airline: {item.AirlineName}");

            #endregion

            #region Show all transactions (id, amount, description) along with the airline name, but only where Amount > 20000.
            var result = dbContext.Transactions.Where(t => t.Amount > 20000)
                                                   .Join(dbContext.Airlines,
                                                         t => t.AirlineId,
                                                         a => a.Id,
                                                         (t, a) => new
                                                         {
                                                             t.Id,
                                                             t.Amount,
                                                             t.Description,
                                                             AirlineName = a.Name
                                                         });

            Console.WriteLine("\nTransactions > 20000 with airline name:");

            foreach (var t in result)
                Console.WriteLine($"ID: {t.Id}, Amount: {t.Amount}, Description: {t.Description}, Airline: {t.AirlineName}"); 
            #endregion
        }
    }
}
