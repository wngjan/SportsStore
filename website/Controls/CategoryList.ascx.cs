using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;
using SportsStore.Models.Repository;

public partial class Controls_CategoryList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected IEnumerable<string> GetCategories()
    {
        return new Repository().Products.Select(p => p.category).Distinct().OrderBy(x => x);
    }

    protected string CreateHomeLinkHtml()
    {
        string path = RouteTable.Routes.GetVirtualPath(null, null).VirtualPath;
        return string.Format("<a href='{0}'>Home</a>", path);
    }

    protected string CreateLinkHtml(string category)
    {
        string scat = (string)Page.RouteData.Values["category"] ?? Request.QueryString["category"];

        RouteValueDictionary rvd = new RouteValueDictionary() { { "category", category }, { "page", "1" } };
        string path = RouteTable.Routes.GetVirtualPath(null, null, rvd).VirtualPath;
        return string.Format("<a href='{0}' {1}>{2}</a>", path, (category == scat ? "class='selected'" : ""), category);
    }
}