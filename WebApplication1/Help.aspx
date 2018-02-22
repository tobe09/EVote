<%@ Page Language="C#" MasterPageFile="~/ProjectApp.Master" Title="Help" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="WebApplication1.Help" %>

<asp:Content ID="Content" runat="server" ContentPlaceHolderID="ContentPH">
    <asp:Table runat="server" ID="InstructionTable">
    <asp:TableRow>
        <asp:TableCell>
                <h2>Registration Instructions</h2>
                    <p>1. Get a registration keycode from the nearest voting centre</p>
                    <p>2. Enter your details through the registration page</p>
                    <p>3. Verify your details and then submit</p><br />

                <h2>Login Instructions</h2>
                    <p>1. Enter your username</p>
                    <p>2. Enter the password you chose during registration, as your password</p>
                    <p>3. Click Login to gain access to the voter's page</p><br />
                    
                    <h2>Voting Instructions</h2>
                    <p>1. Please, do not attempt to vote twice. Such action shall be detected and<br />
                     &nbsp;&nbsp;&nbsp;appropraite action taken</p>
                    <p>2. Vote for preferred candidates by clicking on his/her radiobutton</p>
                    <p>3. After you have finished voting, click submit</p>
                    <p>4. A success message will be displayed</p>
                    <p>5.. You have successfully voted!</p><br />
            
                    <h2>Result Instructions</h2>
                    <p>1. Enter your username and password and submit, to view your votes</p>
                    <p>2. Total votes are available to all students including visitors</p><br />

                    <h2>Other issues</h2>
                    <p>Please contact any of the electoral committee members</p>
                    <p>1. Chineke Tobenna- 08136831102</p><br /><br />
        </asp:TableCell>
    </asp:TableRow>
        </asp:Table>
</asp:Content>