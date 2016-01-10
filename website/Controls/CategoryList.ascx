<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CategoryList.ascx.cs" Inherits="Controls_CategoryList" %>

<%=CreateHomeLinkHtml() %>
<% foreach (string cat in GetCategories()) {
        Response.Write(CreateLinkHtml(cat));
    } %>
