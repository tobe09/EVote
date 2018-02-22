<%@ Page Language="C#"  MasterPageFile="~/ProjectApp.Master" Title="RegisterKey" AutoEventWireup="true" CodeBehind="RegisterKey.aspx.cs" Inherits="WebApplication1.RegisterKey" %>

<asp:Content ID="Content" runat="server" ContentPlaceHolderID="ContentPH">
    <asp:Label ID="Label1" runat="server" Font-Size="Large" Font-Bold="true" Text="Enter Administrative credential to generate keycode"></asp:Label>
    <br /><br />
    <asp:Label ID="Label2" Text="Admin. Name" Font-Size="Medium" Width="100px" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    <asp:TextBox ID="admNameBox" runat="server" ></asp:TextBox>
    <br />  
    <asp:Label id="adminLabel" Text="Password" Font-Size="Medium" Width="100px" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="adminBox" runat="server" TextMode="Password"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="adminButton" runat="server" Text="Submit" Font-Bold="true" OnClick="adminClick" /><br /><br />
    <asp:Label ID="holdLabel" runat="server" Font-italic="true" Font-Size="Large" Font-Bold="true"></asp:Label><br /><br /><br />

    <asp:Label ID="headLabel" runat="server" Text="Enter Student name and matriculation number" Font-Bold="true" Font-Size="X-Large" ></asp:Label><br /><br />
    <asp:Label ID="nameLabel" runat="server" Text="Name"></asp:Label><br />
    <asp:TextBox ID="nameBox" runat="server"></asp:TextBox><br /><br />
    <asp:Label ID="matricLabel" runat="server" Text="Matric no."></asp:Label><br />
    <asp:TextBox ID="matricBox" runat="server"></asp:TextBox><br /><br /><br />
    <asp:Button ID="keygenButton" runat="server" Text="Generate Keycode" OnClick="keygenButton_Click" />
    <br />
    <br />
    <br /><br /><br />
    <asp:Label ID="keycodeLabel" runat="server" Text="Your Keycode is: "></asp:Label>&nbsp&nbsp&nbsp&nbsp
    <asp:TextBox ID="keycodeBox" runat="server"></asp:TextBox><br /><br />
    <asp:Label ID="infoLabel" runat="server" Text="" Font-Italic="true" Font-Size="X-Large"></asp:Label>
</asp:Content>
