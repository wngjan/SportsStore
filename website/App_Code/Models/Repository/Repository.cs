using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

/// <summary>
/// Repository 的摘要说明
/// </summary>

namespace SportsStore.Models.Repository
{
    public class Repository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }

        public IEnumerable<Order> Orders
        {
            get
            {
                return context.Orders.Include(o => o.orderline_list.Select(ol => ol.Product));
            }
        }
        public void SaveOrder(Order order)
        {
            if (order.id == 0) {
                order = context.Orders.Add(order);
                foreach (OrderLine ol in order.orderline_list) {
                    context.Entry(ol.Product).State = System.Data.Entity.EntityState.Modified;
                }
            } else {
                Order dbOrder = context.Orders.Find(order.id);
                if (dbOrder != null) {
                    dbOrder.name = order.name;
                    dbOrder.line1 = order.line1;
                    dbOrder.line2 = order.line2;
                    dbOrder.line3 = order.line3;
                    dbOrder.city = order.city;
                    dbOrder.state = order.state;
                    dbOrder.giftwrap = order.giftwrap;
                    dbOrder.dispatched = order.dispatched;
                }
            }
            context.SaveChanges();
        }

    }
}
