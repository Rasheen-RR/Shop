using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shop.Models
{
    public class Categories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int categoryID { get; set; }
        [Required]
        public String categoryName { get; set; }
        [Required]
        public String description { get; set; }
        [Required]
        public String picture { get; set; }

    }
}
