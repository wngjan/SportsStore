using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;
using SportsStore.Models;
using SportsStore;

public partial class Controls_CartSummary : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Cart mycart = SessionHelper.GetCart(Session);
        csQuantity.InnerText = mycart.Lines.Sum(x => x.Quantity).ToString();
        csTotal.InnerText = mycart.Subtotal().ToString("c");
        csLink.HRef = RouteTable.Routes.GetVirtualPath(null, "cart", null).VirtualPath;
    }
}