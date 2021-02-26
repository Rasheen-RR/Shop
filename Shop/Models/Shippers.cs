using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shop.Models
{
    public class Shippers
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int shipperID { get; set; }
        [Required]
        public String companyName { get; set; }
        [Required]
        public String phone { get; set; }


    }
}
