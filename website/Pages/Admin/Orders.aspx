<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.master" AutoEventWireup="true" CodeFile="Orders.aspx.cs"
    EnableViewState="false" Inherits="SportsStore.Pages.Admin.Pages_Admin_Orders" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="outerContainer">
        <table id="ordersTable">
            <tr><th>Name</th><th>City</th><th>Items</th><th>Total</th><th></th></tr>
            <asp:Repeater runat="server" SelectMethod="GetOrders" ItemType="SportsStore.Models.Order">
                <ItemTemplate>
                    <tr>
                        <td><%#: Item.name %></td>
                        <td><%#: Item.city %></td>
                        <td><%# Item.orderline_list.Sum(ol => ol.Quantity) %></td>
                        <td><%# Total(Item.orderline_list).ToString("C") %></td>
                        <td>
                            <asp:PlaceHolder Visible="<%# !Item.dispatched %>" runat="server">
                                <button type="submit" name="dispatch" value="<%# Item.id %>">Dispatch</button>
                            </asp:PlaceHolder>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div id="ordersCheck">
        <asp:CheckBox ID="showDispatched" runat="server" Checked="false" AutoPostBack="true" />Show Dispatched Orders?
    </div>
</asp:Content>

