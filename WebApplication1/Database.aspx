<%@ Page Language="C#" Title="Database" MasterPageFile="~/ProjectApp.Master" AutoEventWireup="true" CodeBehind="Database.aspx.cs" Inherits="WebApplication1.Database" %>

<asp:Content ID="Content" runat="server" ContentPlaceHolderID="ContentPH">

    <asp:Label ID="HeadLabel" runat="server" Font-Size="Large" Font-Bold="true" Text="Enter Administrative credential to view or delete content"></asp:Label>
    <br /><br />      
    <asp:Label ID="nameLabel" Text="Admin. Name" Font-Size="Medium" Width="100px" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    <asp:TextBox ID="nameBox" runat="server" ></asp:TextBox>
    <br />  
    <asp:Label id="adminLabel" Text="Password" Font-Size="Medium" Width="100px" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="adminBox" runat="server" TextMode="Password" ></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="adminButton" runat="server" Text="Submit" Font-Bold="true" OnClick="adminClick" /><br /><br />
    <asp:Label ID="holdLabel" runat="server" Font-italic="true" Font-Size="Large" Font-Bold="true"></asp:Label><br /><br /><br />

    <asp:Label ID="dispLabel" Text="Display Database Table Content" runat="server" Font-Bold="true" Font-Size="X-Large"></asp:Label><br /><br />
    <asp:Button ID="users" Text="Display Users Table" runat="server" Font-Size="Large" Font-Bold="true" OnClick="userdClick" Width="250px"/><br />
    <asp:Button ID="faculty" Text="Display faculty Table" Font-Size="Large" Font-Bold="true" runat="server" OnClick="facdClick" Width="250px"/>&nbsp&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <select id="fac2" runat="server" multiple="false">
            <option>Administration</option>
            <option>Agriculture</option>
            <option>Arts</option>
            <option>Basic Medical Sciences</option>
            <option>Clinical Sciences</option>
            <option>Dentistry</option>
            <option>Education</option>
            <option>Environmental Design and Management</option>
            <option>Law</option>
            <option>Pharmacy</option>
            <option>Sciences</option>
            <option>Social Sciences</option>
            <option>Technology</option>
            <option>Other Faculties</option>
            <option>All</option>
        </select>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
    <asp:Button ID="facgend" runat="server" Text="Generate Departments" Font-Bold="true" Font-Italic="true" OnClick="selectdClick" Width="150px" />
    <br />
    <asp:Button ID="department" Text ="Display Department Table"  Font-Size="Large" Font-Bold="true" runat="server" OnClick="deptdClick" Width="250px" />
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:DropDownList ID="admd" runat="server">
            <asp:ListItem>International Relations</asp:ListItem>
            <asp:ListItem>Local Government Studies</asp:ListItem>
            <asp:ListItem>Management and Accounting</asp:ListItem>
            <asp:ListItem>Public Administration</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
            <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="agrd" runat="server">
            <asp:ListItem>Agricultural Economics</asp:ListItem>
            <asp:ListItem>Agricultural Extension and Rural Development</asp:ListItem>
            <asp:ListItem>Animal Science</asp:ListItem>
            <asp:ListItem>Crop Production and Protection</asp:ListItem>
            <asp:ListItem>Family Nutrition and Consumer Science</asp:ListItem>
            <asp:ListItem>Soil Science</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
            <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="artd" runat="server">
            <asp:ListItem>Dramatic arts</asp:ListItem>
            <asp:ListItem>English Language</asp:ListItem>
            <asp:ListItem>Foreign Languages</asp:ListItem>
            <asp:ListItem>History</asp:ListItem>
            <asp:ListItem>Linguistics and African Languages</asp:ListItem>
            <asp:ListItem>Music</asp:ListItem>
            <asp:ListItem>Philosophy</asp:ListItem>
            <asp:ListItem>Religious Studies</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
            <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="medd" runat="server">
            <asp:ListItem>Medical Rehabilitation</asp:ListItem>
            <asp:ListItem>Nursing</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
            <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="clid" runat="server">
            <asp:ListItem>Medicine and Surgery</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
            <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="dend" runat="server">
            <asp:ListItem>Dentistry</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
            <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="edud" runat="server">
            <asp:ListItem>Adult Eduction</asp:ListItem>
            <asp:ListItem>Continuing Eduction</asp:ListItem>
            <asp:ListItem>Education Administration and Planning</asp:ListItem>
            <asp:ListItem>Education Foundation and Counselling</asp:ListItem>
            <asp:ListItem>Eduction Technology</asp:ListItem>
            <asp:ListItem>Physical Education</asp:ListItem>
            <asp:ListItem>Special Education and Curriculum Studies</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
            <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="edmd" runat="server">
            <asp:ListItem>Architecture</asp:ListItem>
            <asp:ListItem>Building</asp:ListItem>
            <asp:ListItem>Estate Management</asp:ListItem>
            <asp:ListItem>Fine Arts</asp:ListItem>
            <asp:ListItem>Quantity Surveying</asp:ListItem>
            <asp:ListItem>Urban and Regional Planning</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
            <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="lawd" runat="server">
            <asp:ListItem>Law</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
            <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="phmd" runat="server">
            <asp:ListItem>Pharmacy</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
            <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="scid" runat="server">
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
            <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="socd" runat="server">
            <asp:ListItem>Demography and Social Statistics</asp:ListItem>
            <asp:ListItem>Economics</asp:ListItem>
            <asp:ListItem>Geography</asp:ListItem>
            <asp:ListItem>Philosophy</asp:ListItem>
            <asp:ListItem>Political Science</asp:ListItem>
            <asp:ListItem>Psychology</asp:ListItem>
            <asp:ListItem>Sociology and Anthropology</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
            <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="techd" runat="server">
            <asp:ListItem>Agricultural Science and Engineering</asp:ListItem>
            <asp:ListItem>Chemical Engineering</asp:ListItem>
            <asp:ListItem>Civil Engineering</asp:ListItem>
            <asp:ListItem>Computer Science and Engineering</asp:ListItem>
            <asp:ListItem>Electrical and Electronic Engineering</asp:ListItem>
            <asp:ListItem>Food Science and Engineering</asp:ListItem>
            <asp:ListItem>Material Science and Engineering</asp:ListItem>
            <asp:ListItem>Mechanical Engineering</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
            <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList>
    <asp:DropDownList ID="otherd" runat="server">
        <asp:ListItem>Other_Department</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="alld" runat="server">
        <asp:ListItem>All_Departments</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Button ID="haveVoted" Font-Bold="true" Text="Display HaveVoted Table" Font-Size="Large" runat="server" OnClick="hvdClick" Width="250px"/><br />
    <asp:Button ID="totalVotes" Font-Bold="true" Font-Size="Large" Text="Display TotalVotes Table" runat="server" OnClick="tvdClick" Width="250px"/><br />
    <asp:Button ID="allVotes" Font-Bold="true" Font-Size="Large" Text="Display AllVotes Table" runat="server" OnClick="avdClick" Width="250px"/><br />
    <asp:Button ID="keycode" Font-Bold="true" Font-Size="Large" Text="Display KeyCodes Table" runat="server" OnClick="kcdClick" Width="250px"/><br /><br />
    <asp:Label ID="contentLabel" runat="server" Text="Table content will be shown below" Font-Italic="true" Font-Bold="true" Font-Size="Large"></asp:Label>
    <br /><br /><asp:PlaceHolder ID="ph" runat="server"></asp:PlaceHolder><br /><br /><br /><br />
    
    <asp:Label ID="titleLabel" runat="server" Text="Clear Database Tables (Apply with caution, changes are irreversible)" Font-Bold="true" Font-Size="X-Large"></asp:Label><br /><br />
    <asp:Button ID="userButton" Font-Bold="true" Font-Size="Large" runat="server" Text="Clear" OnClick="userClick" style="width: 100px" />&nbsp;&nbsp;&nbsp; <asp:RadioButton ID="userRB" runat="server" Text="Click radiobutton to proceed" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="userLabel" runat="server" Text="Users (Table for all users)" Font-Bold="true" Font-Size="Large"></asp:Label>&nbsp;&nbsp;
    <br />
     <asp:Button ID="facButton" Font-Bold="true" Font-Size="Large" Text="Clear" OnClick="facClick" runat="server" style="width: 100px" />&nbsp;&nbsp;&nbsp; <asp:RadioButton ID="facrb" runat="server" Text="Click radiobutton to proceed" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="facLabel" runat="server" Text="Faculty (Table for each faculty)" Font-Bold="true" Font-Size="Large"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
        <select id="fac" runat="server" multiple="false">
            <option>Administration</option>
            <option>Agriculture</option>
            <option>Arts</option>
            <option>Basic Medical Sciences</option>
            <option>Clinical Sciences</option>
            <option>Dentistry</option>
            <option>Education</option>
            <option>Environmental Design and Management</option>
            <option>Law</option>
            <option>Pharmacy</option>
            <option>Sciences</option>
            <option>Social Sciences</option>
            <option>Technology</option>
            <option>Other Faculties</option>
            <option>All</option>
        </select>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="facgen" runat="server" Text="Generate Departments" Font-Italic="true" Font-Bold="true" Font-Size="13px" OnClick="selectClick" Width="150px" />
    <br />
    <asp:Button ID="deptButton" Font-Bold="true" Font-Size="Large" Text="Clear" OnClick="deptClick" runat="server" style="width: 100px" />&nbsp;&nbsp;&nbsp; <asp:RadioButton ID="deptrb" runat="server" Text="Click radiobutton to proceed" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="deptLabel" runat="server" Text="Department (Table for each Department)" Font-Bold="true" Font-Size="Large"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
        <asp:DropDownList ID="adm" runat="server">
            <asp:ListItem>International Relations</asp:ListItem>
            <asp:ListItem>Local Government Studies</asp:ListItem>
            <asp:ListItem>Management and Accounting</asp:ListItem>
            <asp:ListItem>Public Administration</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
            <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="agr" runat="server">
            <asp:ListItem>Agricultural Economics</asp:ListItem>
            <asp:ListItem>Agricultural Extension and Rural Development</asp:ListItem>
            <asp:ListItem>Animal Science</asp:ListItem>
            <asp:ListItem>Crop Production and Protection</asp:ListItem>
            <asp:ListItem>Family Nutrition and Consumer Science</asp:ListItem>
            <asp:ListItem>Soil Science</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
            <asp:ListItem>All</asp:ListItem>
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
            <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="med" runat="server">
            <asp:ListItem>Medical Rehabilitation</asp:ListItem>
            <asp:ListItem>Nursing</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
            <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="cli" runat="server">
            <asp:ListItem>Medicine and Surgery</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
            <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="den" runat="server">
            <asp:ListItem>Dentistry</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
            <asp:ListItem>All</asp:ListItem>
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
            <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="edm" runat="server">
            <asp:ListItem>Architecture</asp:ListItem>
            <asp:ListItem>Building</asp:ListItem>
            <asp:ListItem>Estate Management</asp:ListItem>
            <asp:ListItem>Fine Arts</asp:ListItem>
            <asp:ListItem>Quantity Surveying</asp:ListItem>
            <asp:ListItem>Urban and Regional Planning</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
            <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="law" runat="server">
            <asp:ListItem>Law</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
            <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="phm" runat="server">
            <asp:ListItem>Pharmacy</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
            <asp:ListItem>All</asp:ListItem>
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
            <asp:ListItem>All</asp:ListItem>
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
            <asp:ListItem>All</asp:ListItem>
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
            <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList>
    <asp:DropDownList ID="other" runat="server">
        <asp:ListItem>Other_Department</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="all" runat="server">
        <asp:ListItem>All_Departments</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Button ID="hvButton" Font-Bold="true" Font-Size="Large" Text="Clear" runat="server" OnClick="hvClick" style="width: 100px" />&nbsp;&nbsp;&nbsp; <asp:RadioButton ID="hvrb" runat="server" Text="Click radiobutton to proceed" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="hvLabel" runat="server" Text="HaveVoted (Table for those that have voted)" Font-Bold="true" Font-Size="Large"></asp:Label>&nbsp;&nbsp;
        <br />
    <asp:Button ID="tvButton" Font-Bold="true" Font-Size="Large" Text="Clear" runat="server" OnClick="tvClick" style="width: 100px" />&nbsp;&nbsp;&nbsp; <asp:RadioButton ID="tvrb" runat="server" Text="Click radiobutton to proceed" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="tvLabel" runat="server" Text="TotalVotes (Table for aspirant's votes)" Font-Bold="true" Font-Size="Large"></asp:Label>&nbsp;&nbsp;
        <br />
    <asp:Button OnClick="avClick" Font-Bold="true" Font-Size="Large" Text="Clear" ID="avButton" runat="server" style="width: 100px" />&nbsp;&nbsp;&nbsp; <asp:RadioButton ID="avrb" runat="server" Text="Click radiobutton to proceed" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="avLabel" runat="server" Text="AllVotes (Table for individual votes)" Font-Bold="true" Font-Size="Large"></asp:Label>&nbsp;&nbsp;
        <br />
    <asp:Button OnClick="kcClick" Font-Bold="true" Font-Size="Large" Text="Clear" ID="kcButton" runat="server" style="width: 100px" />&nbsp;&nbsp;&nbsp; <asp:RadioButton ID="kcrb" runat="server" Text="Click radiobutton to proceed" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="kcLabel" runat="server" Text="KeyCodes (Table for Validation Codes)" Font-Bold="true" Font-Size="Large"></asp:Label>&nbsp;&nbsp;
        <br /><br />

</asp:Content>