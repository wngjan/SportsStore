<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Pages_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ValidationSummary runat="server" DisplayMode="SingleParagraph" CssClass="error" />
    <div class="loginContainer">
        <div>
            <label for="name">Name:</label>
            <input name="name" />
        </div>
        <div>
            <label for="password">Password:</label>
            <input name="password" />
        </div>
        <button type="submit">Log In</button>
    </div>
</asp:Content>

