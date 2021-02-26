using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shop.Models
{
    public class Employees
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int employeeID { get; set; }
        public String lastName { get; set; }
        public String firstName { get; set; }
        public String title { get; set; }
        public String titleOfCourtesy { get; set; }
        public DateTime birthDate { get; set; }
        public DateTime hireDate { get; set; }
        public String address { get; set; }
        public String city { get; set; }
        public String region { get; set; }
        public String postalCode { get; set; }
        public String country { get; set; }
        public String homePhone { get; set; }
        public String extension { get; set; }
        public String photo { get; set; }
        public String notes { get; set; }
        public int? reportsTo { get; set; }
        public String photoPath { get; set; }

        [ForeignKey("reportsTo")]
        public Employees employees { get; set; }
    }
}
