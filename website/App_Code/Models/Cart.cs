using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Cart 的摘要说明
/// </summary>
namespace SportsStore.Models
{
    public class Cart
    {
        private List<CartLine> line_list = new List<CartLine>();
        public Cart()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public void AddLine(Product product, int quantity)
        {
            CartLine line = line_list.Where(p => p.Product.id == product.id).FirstOrDefault();
            if (line == null) {
                line_list.Add(new CartLine { Product = product, Quantity = quantity });
            } else {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product)
        {
            line_list.RemoveAll(l => l.Product.id == product.id);
        }

        public void ClearLines()
        {
            line_list.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get
            {
                return line_list;
            }
        }

        public decimal Subtotal()
        {
            return line_list.Sum(e => e.Product.price * e.Quantity);
        }
    }

    public class CartLine
    {
        public Product Product
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }
    }
}