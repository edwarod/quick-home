using System.ComponentModel.DataAnnotations;

namespace QuickHome.Dto
{
    public enum PropertyType
    {
        Flat,
        House,
        Room
    }

    public class PropertyDto
    {
        [Required]
        public int PropertyID { get; set; }
        [Required]
        public int LessorID { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Stratum { get; set; }
        [Required]
        public int Area { get; set; }
        [Required]
        public int Rooms { get; set; }
        [Required]
        public int Bathrooms { get; set; }
        public int ParkingSlots { get; set; }
        public bool HasElevator { get; set; }
        public int Balconies { get; set; }
        [Required]
        public long Appraisal { get; set; }
        [Required]
        public PropertyType PropertyType { get; set; }
        [Required]
        public long? SuggestedCanon { get; set; }

        public LessorDto Lessor { get; set; }
    }
}
