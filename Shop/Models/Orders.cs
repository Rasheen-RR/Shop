using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shop.Models
{
    public class Orders
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderID { get; set; }
        public int customerID { get; set; }
        public int EmployeeID { get; set; }

        [ForeignKey("customerID")]
        public Customers customers { get; set; }
        
        [ForeignKey("EmployeeID")]
        public Employees employees { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime requriedDate { get; set; }
        public DateTime shippedDate { get; set; }
        public int shippedVia { get; set; }
        public String freight { get; set; }
        public String shipName { get; set; }
        public String shipAddress { get; set; }
        public String shipCity { get; set; }
        public String shipReigon { get; set; }
        public String shipPostalCode { get; set; }
        public String shipCountry { get; set; }

        [ForeignKey("shippedVia")]
        public Shippers shippers { get; set; }
    }
}
