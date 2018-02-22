<%@ Page Language="C#" MasterPageFile="~/ProjectApp.Master" Title="Result" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="WebApplication1.Result" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPH" runat="server">
    <table id="Table0" runat="server" style="background-color: #e6e898; left: 82px; position:relative">
            <tr>
                <td>
                    <h1 tabindex="2" aria-orientation="horizontal" style="border-style: solid; text-align: center; width: 357px; margin-right: 0px;" draggable="true" >Result Display Login</h1>
                </td>
                <td draggable="true">
                    <asp:Label ID="loginLabel" runat="server"  Text="Enter Details" Font-Bold="True" Font-Italic="True" Font-Size="Large"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp&nbsp&nbsp&nbsp
                    <asp:Button ID="visButton" runat="server" Text="Visitor? Click here" Font-Bold="true" OnClick="visClick" />
                    <br /><br />
                    <asp:Label ID="usernameLabel" runat="server" Text="Username" Font-Size="Large"></asp:Label>&nbsp&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="usernameBox" text="" runat="server"></asp:TextBox><br /><br />
                    <asp:Label ID="passwordLabel" runat="server" Text="Password" Font-Size="Large"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="passwordBox" runat="server" TextMode="Password"></asp:TextBox><br /><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="loginButton" runat="server" Text="Display Result" OnClick="login_Click" Font-Size="Large" style=" margin-bottom: 0px;" Height="27px" Width="127px" /><br />  
                    <asp:Label runat="server" ID="logLabel" Text="" Font-Italic="true" Font-Size="Large"></asp:Label><br />
                </td>
                </tr>
        </table><br /><br />

    <asp:Label ID="logUsername" runat="server" Text="Userame:  " Font-Size="Large" Font-Bold="true"></asp:Label><br />
        <asp:Label ID="logName" runat="server" Text="Name:  " Font-Size="Large"></asp:Label><br />
        <asp:Label ID="logMatric" runat="server" Text="Matric Number:   " Font-Size="Large"></asp:Label><br />
        <asp:Label ID="logFaculty" runat="server" Text="Faculty:    " Font-Size="Large"></asp:Label><br />
    <asp:Label ID="logDept" runat="server" Text="Department:    " Font-Size="Large"></asp:Label><br />

    <table id="tlabel" runat="server">
        <tr><td><h2>Voting Status:  <asp:Label ID="votestatusLabel" runat="server" Text="Unknown"></asp:Label></h2><br /></td></tr>
    </table>

    <table id="Table1" runat="server">
        <tr>
            <td >
    <asp:Label ID="yourVotes" runat="server" Text="Your Votes" Font-Bold="true" Font-Size="X-Large"></asp:Label><br /><br />
                </td>
            </tr>
        <tr>
            <td>
    <asp:Label ID="P" runat="server" Text="President" Font-Bold="true" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="P1" runat="server" ></asp:Label>
                <br />
    <asp:Label ID="P2" runat="server" ></asp:Label><br />
    <asp:Label ID="P3" runat="server" ></asp:Label><br />
    <asp:Label ID="PN" runat="server" ></asp:Label><br /><br />
                </td>
            <td>
                <asp:Image ID="pi1" runat="server" ImageUrl="President/1.jpg" Width="100" Height="100" />
                <asp:Image ID="pi2" runat="server" ImageUrl="President/2.jpg" Width="100" Height="100" />
                <asp:Image ID="pi3" runat="server" ImageUrl="President/3.jpg" Width="100" Height="100" />
            </td>
            </tr>
        <tr>
            <td>
    <asp:Label ID="VP" runat="server" Text="Vice-President" Font-Bold="true" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="VP1" runat="server" ></asp:Label><br />
    <asp:Label ID="VP2" runat="server" ></asp:Label><br />
    <asp:Label ID="VP3" runat="server" ></asp:Label><br />
    <asp:Label ID="VPN" runat="server" ></asp:Label><br /><br />
                </td>
            <td>
                <asp:Image ID="vpi1" runat="server" ImageUrl="VicePresident/1.jpg" Width="100" Height="100" />
                <asp:Image ID="vpi2" runat="server" ImageUrl="VicePresident/2.jpg" Width="100" Height="100" />
                <asp:Image ID="vpi3" runat="server" ImageUrl="VicePresident/3.jpg" Width="100" Height="100" />
            </td>
            </tr>
        <tr>
            <td>
    <asp:Label ID="GS" runat="server" Text="General Secretary " Font-Bold="true" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="GS1" runat="server" ></asp:Label><br />
    <asp:Label ID="GS2" runat="server" ></asp:Label><br />
    <asp:Label ID="GS3" runat="server" ></asp:Label><br />
    <asp:Label ID="GSN" runat="server" ></asp:Label><br /><br />
                </td>
            <td>
                <asp:Image ID="gsi1" runat="server" ImageUrl="Gen Secretary/1.jpg" Width="100" Height="100" />
                <asp:Image ID="gsi2" runat="server" ImageUrl="Gen Secretary/2.jpg" Width="100" Height="100" />
                <asp:Image ID="gsi3" runat="server" ImageUrl="Gen Secretary/3.jpg" Width="100" Height="100" />
            </td>
            </tr>
        <tr>
            <td>
    <asp:Label ID="FS" runat="server" Text="Financial Secretary" Font-Bold="true" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="FS1" runat="server" ></asp:Label><br />
    <asp:Label ID="FS2" runat="server" ></asp:Label><br />
    <asp:Label ID="FS3" runat="server" ></asp:Label><br />
    <asp:Label ID="FSN" runat="server" ></asp:Label><br /><br />
                </td>
            <td>
                <asp:Image ID="fsi1" runat="server" ImageUrl="Fin Secretary/1.jpg" Width="100" Height="100" />
                <asp:Image ID="fsi2" runat="server" ImageUrl="Fin Secretary/2.jpg" Width="100" Height="100" />
                <asp:Image ID="fsi3" runat="server" ImageUrl="Fin Secretary/3.jpg" Width="100" Height="100" />
            </td>
            </tr>
        <tr>
            <td>
    <asp:Label ID="PRO" runat="server" Text="Public Relation Officer" Font-Bold="true" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="PRO1" runat="server" ></asp:Label><br />
    <asp:Label ID="PRO2" runat="server" ></asp:Label><br />
    <asp:Label ID="PRO3" runat="server" ></asp:Label><br />
    <asp:Label ID="PRON" runat="server" ></asp:Label><br /><br />
                </td>
            <td>
                <asp:Image ID="proi1" runat="server" ImageUrl="PRO/1.jpg" Width="100" Height="100" />
                <asp:Image ID="proi2" runat="server" ImageUrl="PRO/2.jpg" Width="100" Height="100" />
                <asp:Image ID="proi3" runat="server" ImageUrl="PRO/3.jpg" Width="100" Height="100" />
            </td>
            </tr>
        <tr>
            <td>
    <asp:Label ID="SOC" runat="server" Text="Social Director" Font-Bold="true" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="SOC1" runat="server" ></asp:Label><br />
    <asp:Label ID="SOC2" runat="server" ></asp:Label><br />
    <asp:Label ID="SOC3" runat="server" ></asp:Label><br />
    <asp:Label ID="SOCN" runat="server" ></asp:Label><br /><br />
                </td>
            <td>
                <asp:Image ID="soci1" runat="server" ImageUrl="Social/1.jpg" Width="100" Height="100" />
                <asp:Image ID="soci2" runat="server" ImageUrl="Social/2.jpg" Width="100" Height="100" />
                <asp:Image ID="soci3" runat="server" ImageUrl="Social/3.jpg" Width="100" Height="100" />
            </td>
            </tr>
        <tr>
            <td>
    <asp:Label ID="TRE" runat="server" Text="Treasurer" Font-Bold="true" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="TRE1" runat="server" ></asp:Label><br />
    <asp:Label ID="TRE2" runat="server" ></asp:Label><br />
    <asp:Label ID="TRE3" runat="server" ></asp:Label><br />
    <asp:Label ID="TREN" runat="server" ></asp:Label><br /><br />
                </td>
            <td>
                <asp:Image ID="trei1" runat="server" ImageUrl="treasurer/1.jpg" Width="100" Height="100" />
                <asp:Image ID="trei2" runat="server" ImageUrl="treasurer/2.jpg" Width="100" Height="100" />
                <asp:Image ID="trei3" runat="server" ImageUrl="treasurer/3.jpg" Width="100" Height="100" />
            </td>
            </tr>
        <tr>
            <td>
    <asp:Label ID="AGS" runat="server" Text="Assistant General Secretary" Font-Bold="true" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="AGS1" runat="server" ></asp:Label><br />
    <asp:Label ID="AGS2" runat="server" ></asp:Label><br />
    <asp:Label ID="AGS3" runat="server" ></asp:Label><br />
    <asp:Label ID="AGSN" runat="server" ></asp:Label><br /><br />
                </td>
            <td>
                <asp:Image ID="agsi1" runat="server" ImageUrl="Gen Secretary/5.jpg" Width="100" Height="100" />
                <asp:Image ID="agsi2" runat="server" ImageUrl="Gen Secretary/6.jpg" Width="100" Height="100" />
                <asp:Image ID="agsi3" runat="server" ImageUrl="Gen Secretary/7.jpg" Width="100" Height="100" />
            </td>
            </tr>
        <tr>
            <td>
    <asp:Label ID="WEL" runat="server" Text="Welfare Director" Font-Bold="true" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="WEL1" runat="server" ></asp:Label><br />
    <asp:Label ID="WEL2" runat="server" ></asp:Label><br />
    <asp:Label ID="WEL3" runat="server" ></asp:Label><br />
    <asp:Label ID="WELN" runat="server" ></asp:Label><br /><br />
                </td>
            <td>
                <asp:Image ID="weli1" runat="server" ImageUrl="welfare/1.jpg" Width="100" Height="100" />
                <asp:Image ID="weli2" runat="server" ImageUrl="welfare/2.jpg" Width="100" Height="100" />
                <asp:Image ID="weli3" runat="server" ImageUrl="welfare/3.jpg" Width="100" Height="100" />
            </td>
            </tr>
        <tr>
            <td>
    <asp:Label ID="SD" runat="server" Text="Sport Director" Font-Bold="true" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="SD1" runat="server" ></asp:Label><br />
    <asp:Label ID="SD2" runat="server" ></asp:Label><br />
    <asp:Label ID="SD3" runat="server" ></asp:Label><br />
    <asp:Label ID="SDN" runat="server" ></asp:Label><br /><br />
                </td>
            <td>
                <asp:Image ID="spoi1" runat="server" ImageUrl="Sports/1.jpg" Width="100" Height="100" />
                <asp:Image ID="spoi2" runat="server" ImageUrl="Sports/2.jpg" Width="100" Height="100" />
                <asp:Image ID="spoi3" runat="server" ImageUrl="Sports/3.jpg" Width="100" Height="100" />
            </td>
            </tr>
        <tr>
            <td>
    <asp:Label ID="LIB" runat="server" Text="Librarian" Font-Bold="true" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="LIB1" runat="server" ></asp:Label><br />
    <asp:Label ID="LIB2" runat="server" ></asp:Label><br />
    <asp:Label ID="LIB3" runat="server" ></asp:Label><br />
    <asp:Label ID="LIBN" runat="server" ></asp:Label><br /><br />
                </td>
            <td>
                <asp:Image ID="libi1" runat="server" ImageUrl="Librarian/1.jpg" Width="100" Height="100" />
                <asp:Image ID="libi2" runat="server" ImageUrl="Librarian/2.jpg" Width="100" Height="100" />
                <asp:Image ID="libi3" runat="server" ImageUrl="Librarian/3.jpg" Width="100" Height="100" />
            </td>
            </tr>
        <tr>
            <td>
    <asp:Label ID="AL" runat="server" Text="Assitant Librarian" Font-Bold="true" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="AL1" runat="server" ></asp:Label><br />
    <asp:Label ID="AL2" runat="server" ></asp:Label><br />
    <asp:Label ID="AL3" runat="server" ></asp:Label><br />
    <asp:Label ID="ALN" runat="server" ></asp:Label><br /><br />
                </td>
            <td>
                <asp:Image ID="ali1" runat="server" ImageUrl="Librarian/5.jpg" Width="100" Height="100" />
                <asp:Image ID="ali2" runat="server" ImageUrl="Librarian/6.jpg" Width="100" Height="100" />
                <asp:Image ID="ali3" runat="server" ImageUrl="Librarian/7.jpg" Width="100" Height="100" />
            </td>
            </tr>
        <tr>
            <td>
    <asp:Label ID="EDI" runat="server" Text="Editor-In-Chief" Font-Bold="true" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="EDI1" runat="server" ></asp:Label><br />
    <asp:Label ID="EDI2" runat="server" ></asp:Label><br />
    <asp:Label ID="EDI3" runat="server" ></asp:Label><br />
    <asp:Label ID="EDIN" runat="server" ></asp:Label><br /><br />
                </td>
            <td>
                <asp:Image ID="edii1" runat="server" ImageUrl="Others/1.jpg" Width="100" Height="100" />
                <asp:Image ID="edii2" runat="server" ImageUrl="Others/2.jpg" Width="100" Height="100" />
                <asp:Image ID="edii3" runat="server" ImageUrl="Others/3.jpg" Width="100" Height="100" />
            </td>
            </tr>
            </table><br /><br /><br />

    <table id="Table2" runat="server">
        <tr>
            <td>
    <asp:Label ID="totalVotes" runat="server" Text="Total Votes" Font-Bold="true" Font-Size="X-Large"></asp:Label><br /><br />
    </td>
            </tr>
        <tr>
            <td>
                <asp:Label ID="P0" runat="server" Text="President" Font-Bold="true" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="P01" runat="server"></asp:Label><br />
    <asp:Label ID="P02" runat="server" ></asp:Label><br />
    <asp:Label ID="P03" runat="server" ></asp:Label><br />
    <asp:Label ID="P0N" runat="server" ></asp:Label><br /><br />
                </td>
            <td>
                <asp:Image ID="Image1" runat="server" ImageUrl="President/1.jpg" Width="100" Height="100" />
                <asp:Image ID="Image2" runat="server" ImageUrl="President/2.jpg" Width="100" Height="100" />
                <asp:Image ID="Image3" runat="server" ImageUrl="President/3.jpg" Width="100" Height="100" />
                <asp:Image ID="Image4" runat="server" ImageUrl="Others/tie.jpg" Width="100" Height="100" />
            </td>
            </tr>
        <tr>
            <td>
    <asp:Label ID="VP0" runat="server" Text="Vice-President" Font-Bold="true" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="VP01" runat="server"></asp:Label><br />
    <asp:Label ID="VP02" runat="server"></asp:Label><br />
    <asp:Label ID="VP03" runat="server"></asp:Label><br />
    <asp:Label ID="VP0N" runat="server" ></asp:Label><br /><br />
                </td>
            <td>
                <asp:Image ID="Image5" runat="server" ImageUrl="VicePresident/1.jpg" Width="100" Height="100" />
                <asp:Image ID="Image6" runat="server" ImageUrl="VicePresident/2.jpg" Width="100" Height="100" />
                <asp:Image ID="Image7" runat="server" ImageUrl="VicePresident/3.jpg" Width="100" Height="100" />
                <asp:Image ID="Image8" runat="server" ImageUrl="Others/tie.jpg" Width="100" Height="100" />
            </td>
            </tr>
        <tr>
            <td>
    <asp:Label ID="GS0" runat="server" Text="General Secretary " Font-Bold="true" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="GS01" runat="server" ></asp:Label><br />
    <asp:Label ID="GS02" runat="server" ></asp:Label><br />
    <asp:Label ID="GS03" runat="server" ></asp:Label><br />
    <asp:Label ID="GS0N" runat="server" ></asp:Label><br /><br />
                </td>
            <td>
                <asp:Image ID="Image9" runat="server" ImageUrl="Gen Secretary/1.jpg" Width="100" Height="100" />
                <asp:Image ID="Image10" runat="server" ImageUrl="Gen Secretary/2.jpg" Width="100" Height="100" />
                <asp:Image ID="Image11" runat="server" ImageUrl="Gen Secretary/3.jpg" Width="100" Height="100" />
                <asp:Image ID="Image12" runat="server" ImageUrl="Others/tie.jpg" Width="100" Height="100" />
            </td>
            </tr>
        <tr>
            <td>
    <asp:Label ID="FS0" runat="server" Text="Financial Secretary" Font-Bold="true" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="FS01" runat="server" ></asp:Label><br />
    <asp:Label ID="FS02" runat="server"></asp:Label><br />
    <asp:Label ID="FS03" runat="server" ></asp:Label><br />
    <asp:Label ID="FS0N" runat="server" ></asp:Label><br /><br />
                </td>
            <td>
                <asp:Image ID="Image13" runat="server" ImageUrl="Fin Secretary/1.jpg" Width="100" Height="100" />
                <asp:Image ID="Image14" runat="server" ImageUrl="Fin Secretary/2.jpg" Width="100" Height="100" />
                <asp:Image ID="Image15" runat="server" ImageUrl="Fin Secretary/3.jpg" Width="100" Height="100" />
                <asp:Image ID="Image16" runat="server" ImageUrl="Others/tie.jpg" Width="100" Height="100" />
            </td>
            </tr>
        <tr>
            <td>
    <asp:Label ID="PRO0" runat="server" Text="Public Relation Officer" Font-Bold="true" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="PRO01" runat="server" ></asp:Label><br />
    <asp:Label ID="PRO02" runat="server" ></asp:Label><br />
    <asp:Label ID="PRO03" runat="server" ></asp:Label><br />
    <asp:Label ID="PRO0N" runat="server" ></asp:Label><br /><br />
                </td>
            <td>
                <asp:Image ID="Image17" runat="server" ImageUrl="PRO/1.jpg" Width="100" Height="100" />
                <asp:Image ID="Image18" runat="server" ImageUrl="PRO/2.jpg" Width="100" Height="100" />
                <asp:Image ID="Image19" runat="server" ImageUrl="PRO/3.jpg" Width="100" Height="100" />
                <asp:Image ID="Image20" runat="server" ImageUrl="Others/tie.jpg" Width="100" Height="100" />
            </td>
            </tr>
        <tr>
            <td>
    <asp:Label ID="SOC0" runat="server" Text="Social Director" Font-Bold="true" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="SOC01" runat="server" ></asp:Label><br />
    <asp:Label ID="SOC02" runat="server" ></asp:Label><br />
    <asp:Label ID="SOC03" runat="server" ></asp:Label><br />
    <asp:Label ID="SOC0N" runat="server" ></asp:Label><br /><br />
                </td>
            <td>
                <asp:Image ID="Image21" runat="server" ImageUrl="Social/1.jpg" Width="100" Height="100" />
                <asp:Image ID="Image22" runat="server" ImageUrl="Social/2.jpg" Width="100" Height="100" />
                <asp:Image ID="Image23" runat="server" ImageUrl="Social/3.jpg" Width="100" Height="100" />
                <asp:Image ID="Image24" runat="server" ImageUrl="Others/tie.jpg" Width="100" Height="100" />
            </td>
            </tr>
        <tr>
            <td>
    <asp:Label ID="TRE0" runat="server" Text="Treasurer" Font-Bold="true" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="TRE01" runat="server" ></asp:Label><br />
    <asp:Label ID="TRE02" runat="server" ></asp:Label><br />
    <asp:Label ID="TRE03" runat="server" ></asp:Label><br />
    <asp:Label ID="TRE0N" runat="server" ></asp:Label><br /><br />
                </td>
            <td>
                <asp:Image ID="Image25" runat="server" ImageUrl="treasurer/1.jpg" Width="100" Height="100" />
                <asp:Image ID="Image26" runat="server" ImageUrl="treasurer/2.jpg" Width="100" Height="100" />
                <asp:Image ID="Image27" runat="server" ImageUrl="treasurer/3.jpg" Width="100" Height="100" />
                <asp:Image ID="Image28" runat="server" ImageUrl="Others/tie.jpg" Width="100" Height="100" />
            </td>
            </tr>
        <tr>
            <td>
    <asp:Label ID="AGS0" runat="server" Text="Assistant General Secretary" Font-Bold="true" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="AGS01" runat="server" ></asp:Label><br />
    <asp:Label ID="AGS02" runat="server" ></asp:Label><br />
    <asp:Label ID="AGS03" runat="server" ></asp:Label><br />
    <asp:Label ID="AGS0N" runat="server" ></asp:Label><br /><br />
                </td>
            <td>
                <asp:Image ID="Image29" runat="server" ImageUrl="Gen Secretary/5.jpg" Width="100" Height="100" />
                <asp:Image ID="Image30" runat="server" ImageUrl="Gen Secretary/6.jpg" Width="100" Height="100" />
                <asp:Image ID="Image31" runat="server" ImageUrl="Gen Secretary/7.jpg" Width="100" Height="100" />
                <asp:Image ID="Image32" runat="server" ImageUrl="Others/tie.jpg" Width="100" Height="100" />
            </td>
            </tr>
        <tr>
            <td>
    <asp:Label ID="WEL0" runat="server" Text="Welfare Director" Font-Bold="true" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="WEL01" runat="server" ></asp:Label><br />
    <asp:Label ID="WEL02" runat="server" ></asp:Label><br />
    <asp:Label ID="WEL03" runat="server" ></asp:Label><br />
    <asp:Label ID="WEL0N" runat="server" ></asp:Label><br /><br />
                </td>
            <td>
                <asp:Image ID="Image33" runat="server" ImageUrl="welfare/1.jpg" Width="100" Height="100" />
                <asp:Image ID="Image34" runat="server" ImageUrl="welfare/2.jpg" Width="100" Height="100" />
                <asp:Image ID="Image35" runat="server" ImageUrl="welfare/3.jpg" Width="100" Height="100" />
                <asp:Image ID="Image36" runat="server" ImageUrl="Others/tie.jpg" Width="100" Height="100" />
            </td>
            </tr>
        <tr>
            <td>
    <asp:Label ID="SD0" runat="server" Text="Sport Director" Font-Bold="true" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="SD01" runat="server" ></asp:Label><br />
    <asp:Label ID="SD02" runat="server" ></asp:Label><br />
    <asp:Label ID="SD03" runat="server" ></asp:Label><br />
    <asp:Label ID="SD0N" runat="server" ></asp:Label><br /><br />
                </td>
            <td>
                <asp:Image ID="Image37" runat="server" ImageUrl="Sports/1.jpg" Width="100" Height="100" />
                <asp:Image ID="Image38" runat="server" ImageUrl="Sports/2.jpg" Width="100" Height="100" />
                <asp:Image ID="Image39" runat="server" ImageUrl="Sports/3.jpg" Width="100" Height="100" />
                <asp:Image ID="Image40" runat="server" ImageUrl="Others/tie.jpg" Width="100" Height="100" />
            </td>
            </tr>
        <tr>
            <td>
    <asp:Label ID="LIB0" runat="server" Text="Librarian" Font-Bold="true" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="LIB01" runat="server" ></asp:Label><br />
    <asp:Label ID="LIB02" runat="server" ></asp:Label><br />
    <asp:Label ID="LIB03" runat="server" ></asp:Label><br />
    <asp:Label ID="LIB0N" runat="server" ></asp:Label><br /><br />
                </td>
            <td>
                <asp:Image ID="Image41" runat="server" ImageUrl="Librarian/1.jpg" Width="100" Height="100" />
                <asp:Image ID="Image42" runat="server" ImageUrl="Librarian/2.jpg" Width="100" Height="100" />
                <asp:Image ID="Image43" runat="server" ImageUrl="Librarian/3.jpg" Width="100" Height="100" />
                <asp:Image ID="Image44" runat="server" ImageUrl="Others/tie.jpg" Width="100" Height="100" />
            </td>
            </tr>
        <tr>
            <td>
    <asp:Label ID="AL0" runat="server" Text="Assitant Librarian" Font-Bold="true" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="AL01" runat="server" ></asp:Label><br />
    <asp:Label ID="AL02" runat="server" ></asp:Label><br />
    <asp:Label ID="AL03" runat="server" ></asp:Label><br />
    <asp:Label ID="AL0N" runat="server" ></asp:Label><br /><br />
                </td>
            <td>
                <asp:Image ID="Image45" runat="server" ImageUrl="Librarian/5.jpg" Width="100" Height="100" />
                <asp:Image ID="Image46" runat="server" ImageUrl="Librarian/6.jpg" Width="100" Height="100" />
                <asp:Image ID="Image47" runat="server" ImageUrl="Librarian/7.jpg" Width="100" Height="100" />
                <asp:Image ID="Image48" runat="server" ImageUrl="Others/tie.jpg" Width="100" Height="100" />
            </td>
            </tr>
        <tr>
            <td>
    <asp:Label ID="EDI0" runat="server" Text="Editor-In-Chief" Font-Bold="true" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="EDI01" runat="server" ></asp:Label><br />
    <asp:Label ID="EDI02" runat="server" ></asp:Label><br />
    <asp:Label ID="EDI03" runat="server" ></asp:Label><br />
    <asp:Label ID="EDI0N" runat="server" ></asp:Label><br /><br />
                </td>
            <td>
                <asp:Image ID="Image49" runat="server" ImageUrl="Others/1.jpg" Width="100" Height="100" />
                <asp:Image ID="Image50" runat="server" ImageUrl="Others/2.jpg" Width="100" Height="100" />
                <asp:Image ID="Image51" runat="server" ImageUrl="Others/3.jpg" Width="100" Height="100" />
                <asp:Image ID="Image52" runat="server" ImageUrl="Others/tie.jpg" Width="100" Height="100" />
            </td>
            </tr>
    </table>

        <asp:Label ID="holdUsername" runat="server" Text=""></asp:Label>
        <asp:Label ID="holdName" runat="server" Text=""></asp:Label>
        <asp:Label ID="holdMatric" runat="server" Text=""></asp:Label>
        <asp:Label ID="holdFaculty" runat="server" Text=""></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="holdDept" runat="server" Text=""></asp:Label>

    </asp:Content>

