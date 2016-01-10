<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CartView.aspx.cs" Inherits="Pages_CartView" MasterPageFile="~/Pages/Store.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <h2>Your Cart</h2>
        <table id="cartTable">
            <thead>
                <tr>
                    <th>Quantity</th>
                    <th>Item</th>
                    <th>Price</th>
                    <th>Subtotal</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ItemType="SportsStore.Models.CartLine" SelectMethod="GetCartLines" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <tr>
                            <td><%# Item.Quantity %></td>
                            <td><%# Item.Product.name %></td>
                            <td><%# Item.Product.price.ToString("c") %></td>
                            <td><%# (Item.Quantity * Item.Product.price).ToString("c") %></td>
                            <td>
                                <button type="submit" class="actionButtons" name="remove" value="<%# Item.Product.id %>">Remove</button>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <td colspan="3">Total:</td>
                <td><%=Subtotal.ToString("c") %></td>
            </tfoot>
        </table>
        <p class="actionButtons">
            <a href="<%=ReturnUrl %>">Continue Shopping</a>
            <a href="<%=CheckoutUrl %>">Checkout Now</a>
        </p>
    </div>
</asp:Content>
