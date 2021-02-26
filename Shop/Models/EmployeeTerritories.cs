using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shop.Models
{
    public class EmployeeTerritories
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeTerritoryID { get; set; }
        public int employeeID { get; set; }
        public int territoryID { get; set; }



        [ForeignKey("employeeID")]
        public Employees employees { get; set; }
        
        [ForeignKey("territoryID")]
        public Territories territories { get; set; }

    }
}
