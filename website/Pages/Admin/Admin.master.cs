using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;

public partial class Pages_Admin_Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string OrdersUrl
    {
        get
        {
            return generateURL("admin_orders");
        }
    }

    public string ProductsUrl
    {
        get
        {
            return generateURL("admin_products");
        }
    }

    private string generateURL(string routeName)
    {
        return RouteTable.Routes.GetVirtualPath(null, routeName, null).VirtualPath;
    }
}
