namespace TaxiBook.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Favorite
    {
        public Favorite()
        {
            this.Id = Guid.NewGuid().ToString();

            this.CreatedOn = DateTime.Now;
        }

        public string Id { get; set; }

        [Required]
        public string CompanyName { get; set; }

        public string PhoneNumber { get; set; }

        public string Province { get; set; }

        [Required]
        public decimal? OneКilometerМileageDailyPrice { get; set; }

        [Required]
        public decimal? OneКilometerМileageNightPrice { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ClientId { get; set; }

        public virtual ApplicationUser Client { get; set; }
    }
}
