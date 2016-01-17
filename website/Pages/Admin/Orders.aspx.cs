using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using SportsStore.Models;
using SportsStore.Models.Repository;

namespace SportsStore.Pages.Admin
{
    public partial class Pages_Admin_Orders : System.Web.UI.Page
    {
        private Repository repo = new Repository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) {
                int dispatchID;
                if (int.TryParse(Request.Form["dispatch"], out dispatchID)) {
                    Order myorder = repo.Orders.Where(o => o.id == dispatchID).FirstOrDefault();
                    if (myorder != null) {
                        myorder.dispatched = true;
                        repo.SaveOrder(myorder);
                    }
                }
            }
        }

        public decimal Total(IEnumerable<OrderLine> orderlines)
        {
            decimal total = 0;
            foreach (OrderLine ol in orderlines) {
                total += ol.Product.price * ol.Quantity;
            }
            return total;
        }

        public IEnumerable<Order> GetOrders([Control] bool showDispatched)
        {
            if (showDispatched) {
                return repo.Orders;
            } else {
                return repo.Orders.Where(o => !o.dispatched);
            }
        }
    }
}