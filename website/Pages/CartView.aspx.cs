using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SportsStore;
using SportsStore.Models;
using SportsStore.Models.Repository;

public partial class Pages_CartView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) {
            Repository repo = new Repository();
            int pid;
            if (int.TryParse(Request.Form["remove"], out pid)) {
                Product products = repo.Products.Where(p => p.id == pid).FirstOrDefault();
                if (products != null) {
                    SessionHelper.GetCart(Session).RemoveLine(products);
                }
            }
        }
    }

    public IEnumerable<CartLine> GetCartLines()
    {
        return SessionHelper.GetCart(Session).Lines;
    }

    public decimal Subtotal
    {
        get
        {
            return SessionHelper.GetCart(Session).Subtotal();
        }
    }

    public string ReturnUrl
    {
        get
        {
            return (string)SessionHelper.Get(Session, SKEY.RETURN_URL);
        }
    }
}