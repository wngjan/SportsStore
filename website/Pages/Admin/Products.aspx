<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="Products.aspx.cs" Inherits="SportsStore.Pages.Admin.Pages_Admin_Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ListView ItemType="SportsStore.Models.Product" SelectMethod="GetProducts"
        DataKeyNames="id" UpdateMethod="UpdateProduct"
        DeleteMethod="DeleteProduct" InsertMethod="InsertProduct"
        InsertItemPosition="LastItem" EnableViewState="false" runat="server">
        <LayoutTemplate>
            <div class="outerContainer">
                <table id="productsTable">
                    <tr>
                        <th>Name</th>
                        <th>Description</th>
                        <th>Category</th>
                        <th>Price</th>
                    </tr>
                    <tr runat="server" id="itemPlaceHolder"></tr>
                </table>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Item.name %></td>
                <td class="description"><%# Item.description %></td>
                <td><%# Item.category %></td>
                <td><%# Item.price.ToString("C") %></td>
                <td>
                    <asp:Button CommandName="Edit" Text="Edit" runat="server" />
                    <asp:Button CommandName="Delete" Text="Delete" runat="server" />
                </td>
            </tr>
        </ItemTemplate>
        <EditItemTemplate>
            <tr>
                <td>
                    <input name="name" value="<%# Item.name %>" />
                    <input name="hidden" name="id" value="<%# Item.id %>" />
                </td>
                <td><input name="description" value="<%# Item.description %>"/></td>
                <td><input name="category" value="<%# Item.category %>"</td>
                <td><input name="price" value="<%# Item.price %>"</td>
                <td>
                    <asp:Button CommandName="Update" Text="Update" runat="server" />
                    <asp:Button CommandName="Cancel" Text="Cancel" runat="server" />
                </td>
            </tr>
        </EditItemTemplate>

        <InsertItemTemplate>
            <tr>
                <td>
                    <input name="name" />
                    <input type="hidden" name="id" value="0" />
                </td>
                <td><input name="description" /></td>
                <td><input name="category" /></td>
                <td><input name="price" /></td>
                <td>
                    <asp:Button CommandName="Insert" Text="Add" runat="server" />
                </td>
            </tr>
        </InsertItemTemplate>
    </asp:ListView>
</asp:Content>

