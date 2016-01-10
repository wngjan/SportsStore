<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CartSummary.ascx.cs" Inherits="Controls_CartSummary" %>

<div>
    <span class="caption">
        <b>Your Cart:</b>
        <span id="csQuantity" runat="server"></span> item(s),
        <span id="csTotal" runat="server"></span>
    </span>
    <a id="csLink" runat="server">Checkout</a>
</div>