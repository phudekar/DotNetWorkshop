<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ItemControl.ascx.cs" Inherits="ToDoListWebForms.Controls.ItemControl" %>
<div runat="server" ID="itemDiv">
    <div id="Section1" class="itemHeader" runat="server">
        <asp:Label runat="server" ID="itemTitle" Text=""></asp:Label>
    </div>
    <div id="Section2" class="itemDeadline" runat="server">
        <asp:Label runat="server" ID="itemDeadline" Text=""></asp:Label>
    </div>
    <div id="Section3" class="itemDescription" runat="server">
        <asp:Label runat="server" ID="itemDescription" Text=""></asp:Label>
    </div>

</div>