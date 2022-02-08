namespace TaxiBook.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Vallidation.Feedback;

    public class Feedback
    {
        public Feedback()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string CompanyName { get; set; }

        [Required]
        public bool IsLiked { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public string ClientId { get; set; }

        public virtual ApplicationUser Client { get; set; }
    }
}
