using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shop.Models
{
    public class Suppliers
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int supplierID { get; set; }
        [Required]
        public String companyName { get; set; }
        [Required]
        public String contactName { get; set; }
        [Required]
        public String contactTitle { get; set; }
        [Required]
        public String address { get; set; }
        [Required]
        public String city { get; set; }
        [Required]
        public String region { get; set; }
        [Required]
        public String postalCode { get; set; }
        [Required]
        public String country { get; set; }
        [Required]
        public String fax { get; set; }
        [Required]
        public String homepage { get; set; }

    }
}
