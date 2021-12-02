using System;

namespace QuickHome.Data.Models
{
    public enum RentStatus
    {
        Rejected,
        Approved,
        Optional,
        Defeated
    }

    public class Rent
    {
        public int RentID { get; set; }
        public int PropertyID { get; set; }
        public int LesseeID { get; set; }
        public DateTime RequirementDate { get; set; }
        public DateTime DueDate { get; set; }
        public long Canon { get; set; }
        public RentStatus RentStatus { get; set; }
        
        public Property Property { get; set; }
        public Lessee Lessee { get; set; }

    }
}
