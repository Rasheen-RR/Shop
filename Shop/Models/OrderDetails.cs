using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shop.Models
{
    public class OrderDetails
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderDetailID { get; set; }
        public int productID { get; set; }
        public int orderID { get; set; }
        public float unitPrice { get; set; }
        public int quantity { get; set; }
        public float discount { get; set; }
        [ForeignKey("productID")]
        public Products products { get; set; }
        [ForeignKey("orderID")]
        public Orders orders { get; set; }

    }
}
