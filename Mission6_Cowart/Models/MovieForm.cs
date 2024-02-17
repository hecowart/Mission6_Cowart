using System.ComponentModel.DataAnnotations;

namespace Mission6_Cowart.Models
{
    public class MovieForm
    {
        [Key]
        [Required]

        public int MovieID { get; set; }  //automatically creates a getter and setter

        //public int AppID {get;}       this is a readonly variable
        [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool? Edited { get; set; }
        public string? LentTo { get; set; }
        public string? Notes { get; set; }
    }
}
