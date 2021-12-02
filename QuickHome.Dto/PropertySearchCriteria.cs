namespace QuickHome.Dto
{
    public class PropertySearchCriteria
    {
        public RangeDto? Stratum { get; set; }
        public RangeDto? Area { get; set; }
        public RangeDto? Rooms { get; set; }
        public RangeDto? Bathrooms { get; set; }
        public RangeDto? ParkingSlots { get; set; }
        public bool? HasElevator { get; set; }
        public RangeDto? Balconies { get; set; }
        public PropertyType? PropertyType { get; set; }
        public LongRangeDto? SuggestedCanon { get; set; }
    }
}
