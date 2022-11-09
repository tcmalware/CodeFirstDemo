using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace CodeFirstDemo.Models
{
    public class Seller
    {
        public int SellerID { get; set; }
        //[Display(Name = "Nombre del Vendedor")]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string IDVendedor { get; set; }
    }
}
