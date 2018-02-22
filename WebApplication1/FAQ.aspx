<%@ Page Language="C#" Title="FAQ" MasterPageFile="~/ProjectApp.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="WebApplication1.FAQ" %>

<asp:Content ID="content" runat="server" ContentPlaceHolderID="ContentPH">

        <asp:Label ID="contactLabel" runat="server" Text="Frequently Asked Questions" Font-Bold="true" Font-Size="XX-Large"></asp:Label><br /><br />
    <h2>What is E-voting: </h2>
    <p>
        E-voting stands for Electronic Voting<br />
        E-voting is simply the use of electronic means to carry out a voting process. It could be remote (In a chosen location) or network based (Through the internet).
    </p>
    <h2>How secure is e-voting</h2>
    <p>
        No process is 100% secure. But with the advent of IT security, e-voting can be said to be very secure.
    </p>
    <h2>Where has e-voting been used successfully</h2>
    <p>
        It has been used in Estonia and Norway for their elections.
    </p>
    <h2>Can I vote more than once</h2>
    <p>
        No!
    </p>
    <h2>Can I view my result or the total result</h2>
    <p>
        Yes!
    </p>
    <h2>How can I view results</h2>
    <p>
        Through the results page. Login to see your votes. Total votes can be seen by anyone.
    </p><br/>
    <asp:Button ID="layout" runat="server" Text="Click to veiw system layout" ForeColor="Blue" OnClick="layout_Click"/>

</asp:Content>
