using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Cowart.Models
{
    public class Movies
    {
        [Key]
        [Required]

        public int MovieId { get; set; }  //automatically creates a getter and setter

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }

        public Categories? Category { get; set; }
        [Required(ErrorMessage = "Please enter a Movie Title.")]
        public string Title { get; set; }
        [Required]
        [Range(1888, 2024, ErrorMessage = "You must enter a year from 1888-Present.")]
        public int Year { get; set; } = 0;
        public string? Director { get; set; }
        public string? Rating { get; set; }
        [Required(ErrorMessage = "Please specify if the movie is edited or not.")]
        public bool Edited { get; set; }
        public string? LentTo { get; set; }
        [Required(ErrorMessage = "Please specify if the movie is copied to plex or not.")]
        public bool CopiedToPlex { get; set; }
        public string? Notes { get; set; }
    }
}
