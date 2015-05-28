namespace BgPeopleWebApi.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RangeModel
    {
        private const int MaxPeople = 1000000;

        // For testing purposes min and max age can be very big numbers
        private const int MaxPossibleAge = int.MaxValue;

        public RangeModel()
        {
        }

        public RangeModel(int numberOfPeople, int minAge = 1, int maxAge = 100, bool unique = false, bool language = false)
        {
            this.NumberOfPeople = numberOfPeople;
            this.MinAge = minAge;
            this.MaxAge = maxAge;
            this.Unique = unique;
            this.Language = language;
        }

        [Required]
        [Range(0, MaxPeople)]
        public int NumberOfPeople { get; set; }

        [Required]
        [Range(0, MaxPossibleAge)]
        public int MinAge { get; set; }

        [Required]
        [Range(0, MaxPossibleAge)]
        public int MaxAge { get; set; }

        public bool Unique { get; set; }

        public bool Language { get; set; }
    }
}
