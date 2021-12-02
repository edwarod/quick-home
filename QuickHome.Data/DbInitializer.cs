using System;
using Microsoft.EntityFrameworkCore.Internal;
using QuickHome.Data.Models;

namespace QuickHome.Data
{
    public class DbInitializer
    {
        public static void Initialize(QuickHomeContext context)
        {
            context.Database.EnsureCreated();

            //// Look for any students.
            //if (context.Properties.Any())
            //{
            //    return;   // DB has been seeded
            //}

            //var properties = new Property[]
            //{
            //new Property{Address = "Fake Street 123", Stratum = 3,  Appraisal = 150000000, PropertyType = PropertyType.Flat}
            //};
            //foreach (Property s in properties)
            //{
            //    context.Properties.Add(s);
            //}
            //context.SaveChanges();


            // Look for any students.
            if (context.Lessees.Any())
            {
                return;   // DB has been seeded
            }

            var lessees = new Lessee[]
            {
            new Lessee{ID = 1016058200, FirstMidName = "Edwar Arturo", LastName = "Rodriguez", BirthDate = DateTime.Now, MonthlyIncome = 123131},
            new Lessee{ID = 1015474887, FirstMidName = "Tatiana", LastName = "Higuera", BirthDate = DateTime.Now, MonthlyIncome = 456456}
            };

            foreach (Lessee l in lessees)
            {
                context.Lessees.Add(l);
            }

            context.SaveChanges();

        }
    }
}
