using System.ComponentModel.DataAnnotations;

namespace Mission6_Cowart.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId {  get; set; }
        public string CategoryName { get; set; }
    }
}
