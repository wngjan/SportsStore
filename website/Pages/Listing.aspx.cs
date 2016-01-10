using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;
using SportsStore;
using SportsStore.Models;
using SportsStore.Models.Repository;


public partial class Pages_Listing : System.Web.UI.Page
{
    private Repository repo = new Repository();
    private int page_size = 4;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) {
            int sel_prodid;
            if (int.TryParse(Request.Form["add"], out sel_prodid)) {
                Product sel_prod = repo.Products.Where(p => p.id == sel_prodid).FirstOrDefault();
                if (sel_prod != null) {
                    SessionHelper.GetCart(Session).AddLine(sel_prod, 1);
                    SessionHelper.Set(Session, SKEY.RETURN_URL, Request.RawUrl);
                    Response.Redirect(RouteTable.Routes.GetVirtualPath(null, "cart", null).VirtualPath);
                }
            }
        }

    }

    public IEnumerable<Product> GetProducts()
    {
        return FilterProducts().OrderBy(p => p.id).Skip((CurPage - 1) * page_size).Take(page_size);
    }

    protected int CurPage
    {
        get
        {
            int page = 1;
            string reqValue = (string)RouteData.Values["page"] ?? Request.QueryString["page"];
            if (reqValue != null) {
                page = int.TryParse(reqValue, out page) ? page : 1;
            }
            return page > MaxPage ? MaxPage : page;
        }
    }

    protected int MaxPage
    {
        get
        {
            int nprods = FilterProducts().Count();
            return (int)Math.Ceiling((decimal)nprods / page_size);
        }
    }

    private IEnumerable<Product> FilterProducts()
    {
        IEnumerable<Product> products = repo.Products;
        string category = (string)RouteData.Values["category"] ?? Request.QueryString["category"];
        return category == null ? products : products.Where(p => p.category == category);
    }
}
