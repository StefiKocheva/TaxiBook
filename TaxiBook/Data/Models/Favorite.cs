namespace TaxiBook.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Favorite
    {
        public string Id { get; set; }

        [Required]
        public string CompanyName { get; set; }

        public string ClientId { get; set; }

        public virtual ApplicationUser Client { get; set; }
    }
}
