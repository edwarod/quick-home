using System;
using System.ComponentModel.DataAnnotations;

namespace QuickHome.Dto
{
    public abstract class PersonDto
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstMidName { get; set; }
        public string FullName => LastName + ", " + FirstMidName;

        [Required]
        public DateTime BirthDate { get; set; }
    }
}
