<%@ Page Title="Create To-Do Item" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateItem.aspx.cs" Inherits="ToDoListWebForms.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Page.Title %>.</h1>
        <h2>Create tasks to add in your To-Do List</h2>
    </hgroup>

    <article>
        <p>
            <label>Title : </label>
            <asp:TextBox ID="ItemTitle"  Text=""  runat="server"/>
        </p>
        <p>
            <label>Description : </label>
            <asp:TextBox ID="ItemDescription"  rows="5" TextMode="MultiLine" runat="server" Text=""></asp:TextBox>
        </p>
        <p>
            <asp:Button OnClick="CreateItem"  Text="Create Item"  runat="server"/>
        </p>
    </article>

    <aside>
        <h3>Aside Title</h3>
        <p>
            Use this area to provide additional information.
        </p>
        <ul>
            <li><a runat="server" href="~/">Home</a></li>
            <li><a runat="server" href="~/CreateItem.aspx">Create Item</a></li>
            <li><a runat="server" href="~/Contact.aspx">Contact</a></li>
        </ul>
    </aside>
</asp:Content>
