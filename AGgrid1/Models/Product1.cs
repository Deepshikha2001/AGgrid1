using System.ComponentModel.DataAnnotations;

namespace AGgrid1.Models
{
    public class Product1
   
        {
            [Key]
            public int Id { get; set; }

            [Required]
            public string? Name { get; set; }
            [Required]
            public string? Description { get; set; }

            public string? Category { get; set; }
        }
}

