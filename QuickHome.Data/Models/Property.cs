using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickHome.Data.Models
{
    public enum PropertyType
    {
        Flat,
        House,
        Room
    }

    public class Property
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PropertyID { get; set; }
        public int LessorID { get; set; }
        public string Address { get; set; }
        public int Stratum { get; set; }
        public int Area { get; set; }
        public int Rooms { get; set; }
        public int Bathrooms { get; set; }
        public int ParkingSlots { get; set; }
        public bool HasElevator { get; set; }
        public int Balconies { get; set; }
        public long Appraisal { get; set; }
        public PropertyType PropertyType { get; set; }
        public long? SuggestedCanon { get; set; }


        public Lessor Lessor { get; set; }

        public ICollection<Rent> Rents { get; set; }

    }
}
