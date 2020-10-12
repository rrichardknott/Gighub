using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Models
{
    public class Gig
    {
        public int Id { get; set; }

        [Required]
        public ApplicationUser Artist { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public DateTime DateTime { get; set; }

        [NotMapped]
        [DisplayName("Created")]
        public string DateTimeString
        {
            get
            {
                string stringDateTime = DateTime.ToString("MMM dd, yyy");
                return stringDateTime;
            }
        }

    }
}