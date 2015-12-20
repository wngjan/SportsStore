<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="Pages_ProductList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Product List</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%foreach (SportsStore.Models.Product product in GetProducts()) {
                Response.Write("<div class='item'>");
                Response.Write(string.Format("<h3>{0}</h3>", product.name));
                Response.Write(product.description);
                Response.Write(string.Format("<h4>{0:c}</h4>", product.price));
                Response.Write("</div>");
            } %>
    </div>
    <div>
        <%for (int i=1; i<=MaxPage; i++) {
                Response.Write(string.Format("<a href='/Pages/ProductList.aspx?page={0}' {1}>{2}</a>",
                    i, i == CurPage ? "class='selected'" : "", i));
            } %>
    </div>
    </form>
</body>
</html>
