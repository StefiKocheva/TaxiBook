namespace TaxiBook.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Vallidation.Bookings;

    public class Booking
    {
        public Booking()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string CurrentLocationId { get; set; }

        public virtual Address CurrentLocation { get; set; }

        public string EndLocationId { get; set; }

        public virtual Address EndLocation { get; set; }

        [MaxLength(MaxDetailsLength)]
        public string CurrentLocationDetails { get; set; }

        [MaxLength(MaxDetailsLength)]
        public string EndLocationDetails { get; set; }

        [Required]
        [Range(MinPassengersCount, MaxPassengersCount)]
        public int CountOfPassengers { get; set; }

        [MaxLength(MaxDetailsLength)]
        public string AdditionalRequirements { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime CompletedOn { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string TaxiId { get; set; }

        public virtual Taxi Taxi { get; set; }
    }
}
