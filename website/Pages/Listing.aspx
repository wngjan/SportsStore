<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Listing.aspx.cs" MasterPageFile="Store.master" Inherits="Pages_Listing" %>
<%@ Import Namespace="System.Web.Routing" %>

<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <asp:Repeater ItemType="SportsStore.Models.Product" SelectMethod="GetProducts" runat="server">
            <ItemTemplate>
                <div class="item">
                    <h3><%# Item.name %></h3>
                    <%# Item.description %>
                    <h4><%# Item.price.ToString("c") %></h4>
                    <button name="add" type="submit" value="<%# Item.id %>">Add to Cart</button>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="pager">
        <%for (int i=1; i<=MaxPage; i++) {

                string path = RouteTable.Routes.GetVirtualPath(null, null, new RouteValueDictionary() { { "page", i } }).VirtualPath;
                Response.Write(string.Format("<a href='{0}' {1}>{2}</a>",
                        path, i == CurPage ? "class='selected'" : "", i));
            } %>
    </div>
</asp:Content>
