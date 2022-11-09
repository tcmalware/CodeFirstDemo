using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstDemo.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        //[Display(Name = "Nombre del Producto")]
        public string Name { get; set; }
    }
}