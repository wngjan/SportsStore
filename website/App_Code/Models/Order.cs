using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Order 的摘要说明
/// </summary>
namespace SportsStore.Models
{
    public class Order
    {
        public int id { get; set; }

        [Required(ErrorMessage ="Please enter your name")]
        public string name { get; set; }

        [Required(ErrorMessage ="Please enter the first address line")]
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string line3 { get; set; }

        [Required(ErrorMessage ="Please enter a city name")]
        public string city { get; set; }

        [Required(ErrorMessage ="Please enter a state")]
        public string state { get; set; }
        public bool giftwrap { get; set; }
        public bool dispatched { get; set; }
        public virtual List<OrderLine> orderline_list { get; set; }
    }

    public class OrderLine
    {
        public int id { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}