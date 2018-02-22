<%@ Page Language="C#" MasterPageFile="~/ProjectApp.Master" Title="Forgot your password?" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="WebApplication1.ForgotPassword" %>

<asp:Content ID="Content" runat="server" ContentPlaceHolderID="ContentPH">
    <h1>If you have forgotten your password, enter your email below, and your username and password would be sent to you.</h1>
    <br />
    <asp:Label ID="emailLabel" runat="server" Text="<b>Enter your e-mail adress</b>"></asp:Label><br />
    <asp:TextBox ID="emailBox" runat="server"></asp:TextBox><br /><br />
    <asp:Button ID="emailButton" runat="server" Text="Submit" OnClick="emailButton_click" />
   <br /><br />
    <asp:Label ID="Label" runat="server" Font-Size="13" Font-Italic="true"></asp:Label><br />
    <asp:Label ID="Label1" runat="server" Font-Size="13" Font-Italic="true"></asp:Label>
    <br /><br />
    <h1>Or you can retreive your password at the Computer centre<br /></h1><br />
</asp:Content>