using System.ComponentModel.DataAnnotations;

namespace QuickHome.Dto
{
    public class LesseeDto : PersonDto
    {
        [Required]
        public long MonthlyIncome { get; set; }
    }
}
