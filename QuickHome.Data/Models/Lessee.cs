using System.Collections.Generic;

namespace QuickHome.Data.Models
{
    public class Lessee : Person
    {
        public long MonthlyIncome { get; set; }
        public ICollection<Rent> Rents { get; set; }
    }
}
