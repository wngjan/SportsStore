using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using SportsStore;
using SportsStore.Models;
using SportsStore.Models.Repository;

public partial class Pages_Checkout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        checkoutForm.Visible = true;
        checkoutMessage.Visible = false;

        if (IsPostBack) {
            Order myorder = new Order();
            if (TryUpdateModel(myorder, new FormValueProvider(ModelBindingExecutionContext))) {
                myorder.orderline_list = new List<OrderLine>();
                Cart mycart = SessionHelper.GetCart(Session);
                foreach (CartLine line in mycart.Lines) {
                    myorder.orderline_list.Add(new OrderLine { Order = myorder, Product = line.Product, Quantity = line.Quantity });
                }
                new Repository().SaveOrder(myorder);
                mycart.ClearLines();

                checkoutForm.Visible = false;
                checkoutMessage.Visible = true;
            }
        }

    }
}