using System;

namespace QuickHome.Dto
{
    public enum RentStatus
    {
        Rejected,
        Approved,
        Optional,
        Defeated
    }

    public class RentDto
    {
        public int RentID { get; set; }
        public int PropertyID { get; set; }
        public int LesseeID { get; set; }
        public DateTime RequirementDate { get; set; }
        public DateTime DueDate { get; set; }
        public long Canon { get; set; }
        public RentStatus RentStatus { get; set; }

        public PropertyDto Property { get; set; }
        public LesseeDto Lessee { get; set; }

    }
}
