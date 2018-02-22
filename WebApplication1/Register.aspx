<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ProjectApp.Master" Title="Register" CodeBehind="Register.aspx.cs" Inherits="WebApplication1.Register" %>


<asp:Content ID="Content" ContentPlaceHolderID="ContentPH" runat="server">
        <p>Click <a href="Login and Vote.aspx" style="background-color: orange">&nbsp;Login&nbsp;</a> to go to the login page</p> 
    <asp:Button runat="server" ID="rButton" text="Click to register another candidate" OnClick="rButton_Click"/><br /><br />
        <asp:Label ID="infoLabel" runat="server" Text="" Font-Bold="true" Font-Size="XLarge" Font-Italic="true"></asp:Label>
        <br /><br /><br />
        <asp:Label ID="nameLabel" runat="server" Text="Name" Font-Bold="true" Font-Size="Large"></asp:Label><br />
        <asp:TextBox ID="nameBox" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Label ID="matricLabel" runat="server" Text="Matriculation Number" Font-Bold="true" Font-Size="Large"></asp:Label><br />
        <asp:TextBox ID="matricBox" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Label ID="facLabel" runat="server" Text="Faculty" Font-Bold="true" Font-Size="Large"></asp:Label><br />
        <asp:TextBox ID="facBox" runat="server"></asp:TextBox>
        <asp:DropDownList id="fac" runat="server">
            <asp:ListItem>Administration</asp:ListItem>
            <asp:ListItem>Agriculture</asp:ListItem>
            <asp:ListItem>Arts</asp:ListItem>
            <asp:ListItem>Basic Medical Sciences</asp:ListItem>
            <asp:ListItem>Clinical Sciences</asp:ListItem>
            <asp:ListItem>Dentistry</asp:ListItem>
            <asp:ListItem>Education</asp:ListItem>
            <asp:ListItem>Environmental Design and Management</asp:ListItem>
            <asp:ListItem>Law</asp:ListItem>
            <asp:ListItem>Pharmacy</asp:ListItem>
            <asp:ListItem>Sciences</asp:ListItem>
            <asp:ListItem>Social Sciences</asp:ListItem>
            <asp:ListItem>Technology</asp:ListItem>
            <asp:ListItem>Other</asp:ListItem>
        </asp:DropDownList> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="facgen" runat="server" Text="Generate Departments" Font-Bold="true" Font-Italic="true" OnClick="selectClick" Width="150px" />
        <br /><br />
    
    <asp:Label ID="deptLabel" runat="server" Text="Department" Font-Bold="true" Font-Size="Large"></asp:Label><br />
        <asp:DropDownList ID="adm" runat="server">
            <asp:ListItem>International Relations</asp:ListItem>
            <asp:ListItem>Local Government Studies</asp:ListItem>
            <asp:ListItem>Management and Accounting</asp:ListItem>
            <asp:ListItem>Public Administration</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="agr" runat="server">
            <asp:ListItem>Agricultural Economics</asp:ListItem>
            <asp:ListItem>Agricultural Extension and Rural Development</asp:ListItem>
            <asp:ListItem>Animal Science</asp:ListItem>
            <asp:ListItem>Crop Production and Protection</asp:ListItem>
            <asp:ListItem>Family Nutrition and Consumer Science</asp:ListItem>
            <asp:ListItem>Soil Science</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="art" runat="server">
            <asp:ListItem>Dramatic arts</asp:ListItem>
            <asp:ListItem>English Language</asp:ListItem>
            <asp:ListItem>Foreign Languages</asp:ListItem>
            <asp:ListItem>History</asp:ListItem>
            <asp:ListItem>Linguistics and African Languages</asp:ListItem>
            <asp:ListItem>Music</asp:ListItem>
            <asp:ListItem>Philosophy</asp:ListItem>
            <asp:ListItem>Religious Studies</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="med" runat="server">
            <asp:ListItem>Medical Rehabilitation</asp:ListItem>
            <asp:ListItem>Nursing</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="cli" runat="server">
            <asp:ListItem>Medicine and Surgery</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="den" runat="server">
            <asp:ListItem>Dentistry</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="edu" runat="server">
            <asp:ListItem>Adult Eduction</asp:ListItem>
            <asp:ListItem>Continuing Eduction</asp:ListItem>
            <asp:ListItem>Education Administration and Planning</asp:ListItem>
            <asp:ListItem>Education Foundation and Counselling</asp:ListItem>
            <asp:ListItem>Eduction Technology</asp:ListItem>
            <asp:ListItem>Physical Education</asp:ListItem>
            <asp:ListItem>Special Education and Curriculum Studies</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="edm" runat="server">
            <asp:ListItem>Architecture</asp:ListItem>
            <asp:ListItem>Building</asp:ListItem>
            <asp:ListItem>Estate Management</asp:ListItem>
            <asp:ListItem>Fine Arts</asp:ListItem>
            <asp:ListItem>Quantity Surveying</asp:ListItem>
            <asp:ListItem>Urban and Regional Planning</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="law" runat="server">
            <asp:ListItem>Law</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="phm" runat="server">
            <asp:ListItem>Pharmacy</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="sci" runat="server">
            <asp:ListItem>Biochemistry</asp:ListItem>
            <asp:ListItem>Botany</asp:ListItem>
            <asp:ListItem>Chemistry</asp:ListItem>
            <asp:ListItem>Conservation Sience and Tourism</asp:ListItem>
            <asp:ListItem>Geology and Applied Geophysics</asp:ListItem>
            <asp:ListItem>Mathematics and Statistics</asp:ListItem>
            <asp:ListItem>Microbiology</asp:ListItem>
            <asp:ListItem>Physics</asp:ListItem>
            <asp:ListItem>Zoology</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="soc" runat="server">
            <asp:ListItem>Demography and Social Statistics</asp:ListItem>
            <asp:ListItem>Economics</asp:ListItem>
            <asp:ListItem>Geography</asp:ListItem>
            <asp:ListItem>Philosophy</asp:ListItem>
            <asp:ListItem>Political Science</asp:ListItem>
            <asp:ListItem>Psychology</asp:ListItem>
            <asp:ListItem>Sociology and Anthropology</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="tech" runat="server">
            <asp:ListItem>Agricultural Science and Engineering</asp:ListItem>
            <asp:ListItem>Chemical Engineering</asp:ListItem>
            <asp:ListItem>Civil Engineering</asp:ListItem>
            <asp:ListItem>Computer Science and Engineering</asp:ListItem>
            <asp:ListItem>Electrical and Electronic Engineering</asp:ListItem>
            <asp:ListItem>Food Science and Engineering</asp:ListItem>
            <asp:ListItem>Material Science and Engineering</asp:ListItem>
            <asp:ListItem>Mechanical Engineering</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="otherd" runat="server"></asp:TextBox>
        <br /><br />
    <asp:Label ID="levelLabel" runat="server" Text="Level" Font-Bold="true" Font-Size="Large"></asp:Label><br />
        <asp:TextBox ID="levelBox" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Label ID="facultyKC" runat="server" Text="Keycode" Font-Bold="true" Font-Size="Large"></asp:Label><br />
        <asp:TextBox ID="facKCBox" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Label ID="usernameLabel" runat="server" Text="Username" Font-Bold="true" Font-Size="Large"></asp:Label><br />
        <asp:TextBox ID="usernameBox" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Label ID="passwordLabel" runat="server" Text="Password" Font-Bold="true" Font-Size="Large"></asp:Label><br />
        <asp:TextBox ID="passwordBox" TextMode="Password" runat="server"></asp:TextBox>
        <br /><br />
    <asp:Label ID="password2Label" runat="server" Text="Re-enter Password" Font-Bold="true" Font-Size="Large"></asp:Label><br />
        <asp:TextBox ID="password2Box" TextMode="Password" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Label ID="phoneLabel" runat="server" Text="Phone Number" Font-Bold="true" Font-Size="Large"></asp:Label><br />
        <asp:TextBox ID="phoneBox" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Label ID="emailLabel" runat="server" Text="E-mail Adress" Font-Bold="true" Font-Size="Large"></asp:Label><br />
        <asp:TextBox ID="emailBox" runat="server"></asp:TextBox><br /><br />
        <asp:image id="image" width="120" height="50" runat="server" />&nbsp;
    <asp:Label ID="imgLabel" runat="server" Font-Bold="true" Font-Size="Large" Text="Enter the value in the captcha box below (for security purposes)"></asp:Label><br />
    <asp:TextBox ID="imageBox" runat="server"></asp:TextBox><br /><br />
    <asp:Label ID="sure" runat="server" Font-Bold="true" Font-Italic="true" Text="Are you satisfied with your details?"></asp:Label>
    &nbsp;
    <asp:RadioButton ID="yesR" GroupName="check" runat="server" Font-Bold="true" Text="Yes" />&nbsp; <asp:RadioButton ID="noR" GroupName="check" Font-Bold="true" runat="server" Text="No" />
        <br /><br /><br />
                <br />
                <asp:Button ID="regButton" runat="server" Text="Register" OnClick="regButton_Click" Font-Size="X-Large" Font-Bold="true" Height="42px" Width="173px" /><br /><br /><br />
    <asp:Label ID="holdLabel" runat="server"></asp:Label><asp:Label ID="holdLabel1" runat="server"></asp:Label>
    </asp:Content>
