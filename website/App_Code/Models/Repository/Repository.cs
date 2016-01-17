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

        public void SaveProduct(Product product)
        {
            if (product.id == 0) {
                product = context.Products.Add(product);
            } else {
                Product dbProduct = context.Products.Find(product.id);
                if (dbProduct == null) {
                    dbProduct.name = product.name;
                    dbProduct.description = product.description;
                    dbProduct.price = product.price;
                    dbProduct.category = product.category;
                }
            }
            context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            IEnumerable<Order> orders = context.Orders.Include(o => o.orderline_list.Select(ol => ol.Product))
                .Where(o => o.orderline_list.Count(ol => ol.Product.id == product.id) > 0).ToArray();

            foreach (Order order in orders) {
                context.Orders.Remove(order);
            }
            context.Products.Remove(product);
            context.SaveChanges();
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
