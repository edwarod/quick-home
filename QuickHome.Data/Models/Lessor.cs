using System.Collections.Generic;

namespace QuickHome.Data.Models
{
    public class Lessor : Person
    {
        public ICollection<Property> Properties { get; set; }

    }
}