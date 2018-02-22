<%@ Page Language="C#" Title="ReportProblem" MasterPageFile="~/ProjectApp.Master" AutoEventWireup="true" CodeBehind="ReportProblem.aspx.cs" Inherits="WebApplication1.ReportProblem" %>

<asp:Content ID="content" runat="server" ContentPlaceHolderID="ContentPH">

    <br /><asp:Label ID="nameLabel" runat="server" Font-Bold="true" Text="Name"></asp:Label>
    <br /><asp:Textbox ID="nameBox" runat="server" />
    <br /><br /><asp:Label ID="matricLabel" runat="server" Font-Bold="true" Text="Matriculation Number"></asp:Label>
    <br /><asp:Textbox ID="matricBox" runat="server" />
    <br /><br /><asp:Label ID="subjectLabel" runat="server" Font-Bold="true" Text="Subject"></asp:Label>
    <br /><asp:Textbox ID="subjectBox" runat="server" />
    <br /><br /><asp:Label ID="messageLabel" runat="server" Font-Bold="true" Text="Message"></asp:Label>
    <br /><asp:TextBox ID="messageBox" runat="server" Height="24px" Width="458px" />
    <br /><br />
    <br />
    <asp:Button ID="submitButton" runat="server" OnClick="submitClick" Font-Bold="true" Text="Submit" Width="86px" />
    <br /><br /><asp:Label ID="submitLabel" runat="server" Font-Size="Large" Font-Italic="true"></asp:Label><br /><br /><br />

</asp:Content>