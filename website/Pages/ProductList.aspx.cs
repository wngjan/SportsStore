using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SportsStore.Models;
using SportsStore.Models.Repository;


public partial class Pages_ProductList : System.Web.UI.Page
{
    private Repository repo = new Repository();
    private int page_size = 4;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected IEnumerable<Product> GetProducts()
    {
        return repo.Products.OrderBy(p => p.id).Skip((CurPage - 1) * page_size).Take(page_size);
    }

    protected int CurPage
    {
        get
        {
            int page = int.TryParse(Request.QueryString["page"], out page) ? page : 1;
            return page > MaxPage ? MaxPage : page;
        }
    }

    protected int MaxPage
    {
        get
        {
            return (int)Math.Ceiling((decimal)repo.Products.Count() / page_size);
        }
    }
}
