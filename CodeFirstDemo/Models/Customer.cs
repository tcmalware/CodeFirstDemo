using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace CodeFirstDemo.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        //[Display(Name = "Nombre del Cliente")]
        public string Name { get; set; }
        public string LastName { get; set; }
        public int DNI { get; set; }
        public Invoice Invoice { get; set; }
    }
}