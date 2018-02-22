<%@ Page Language="C#"  MasterPageFile="~/ProjectApp.Master" AutoEventWireup="true" Title="Login & Vote" CodeBehind="Login and Vote.aspx.cs" Inherits="WebApplication1.Vote" %>

    <asp:Content ID="Content" runat="server" ContentPlaceHolderID="ContentPH">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <table id="Table0" style="background-color: #fee09a; left: 55px; position: absolute" runat="server">
            <tr>
                <td draggable="true">
                    <h1 tabindex="2" aria-orientation="horizontal" style="border-style: solid; text-align: center; width: 357px; margin-right: 0px;" draggable="true" >OAUSU GENERAL ELECTIONS&nbsp;&nbsp; </h1>
                </td>
                <td draggable="true">
                    <asp:Label ID="loginLabel" runat="server"  Text="Enter Login Details" Font-Bold="True" Font-Italic="True" Font-Size="Large"></asp:Label><br />
                    <br />
                    <asp:Label ID="usernameLabel" runat="server" Text="Username/E-mail adress" Font-Size="Large"></asp:Label><br />
                    <asp:TextBox ID="usernameBox" text="" runat="server"></asp:TextBox> <br />
                    <asp:Label ID="passwordLabel" runat="server" Text="Password" Font-Size="Large"></asp:Label><br />
                    <asp:TextBox ID="passwordBox" runat="server" TextMode="Password"></asp:TextBox><br /><br />
                    <asp:Button ID="loginButton" runat="server" Text="Login" Height="40px" OnClick="login_Click" Width="75px" Font-Size="Large" /><br />  
                    <asp:Label runat="server" ID="logLabel" Text="" Font-Italic="true" Font-Size="Large"></asp:Label>
                </td>
                <td draggable="true">
                    <p>New Applicant? Click the button <asp:Button runat="server" ID="regButton" text="reg" OnClick="regButton_Click"/> to register</p>
                    <p>Forgot password, click <asp:Button ID="forgot" runat="server" Text="here" OnClick="forgot_click"/></p>
                </td>
            </tr>
        </table>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />

        <asp:Label ID="logUsername" runat="server" Text="Username:  " Font-Size="Large"></asp:Label><br />
        <asp:Label ID="logName" runat="server" Text="Name:  " Font-Size="Large"></asp:Label><br />
        <asp:Label ID="logMatric" runat="server" Text="Matriculation Number:   " Font-Size="Large"></asp:Label><br />
        <asp:Label ID="logFaculty" runat="server" Text="Faculty:    " Font-Size="Large"></asp:Label><br />
        <asp:Label ID="logDept" runat="server" Text="Department:    " Font-Size="Large"></asp:Label><br /><br />
        <asp:Label runat="server" ID="infoLabel1" Text="" Font-Italic="false" Font-Bold="true" Font-Size="Large"></asp:Label><br /><br />

                <asp:Label runat="server" ID="voteLabel" Text="" Font-Bold="true" Font-Size="XX-Large"></asp:Label><br /><br />
                <asp:Label runat="server" ID="infoLabel" Text="Click on his/her RadioButton to vote for preferred candidate" Font-Italic="true" Font-Bold="false" Font-Size="Large"></asp:Label><br /><br />
        <asp:Button ID="resultButton" runat="server" Text="Click to veiw results" Font-Bold="true" Font-Size="Large" OnClick="resultButton_Click" />
        
        <asp:Label ID="Plabel" runat="server" Text="Presidential Candidates..." Font-Size="XX-Large" Font-Bold="True" Font-Italic="True"/>
        <table id="Table1" runat="server">      
            <tr >       
                <td class="auto-style3">
                <asp:image runat="server" ImageUrl="President/1.jpg" width="200" height="200" id="mahatmapic" />
                    <br />
                <asp:RadioButton runat="server" ID="pRadio1" GroupName="Presidentials" Text="CHINEKE Tobenna Chinonso" Font-Bold="true" />
                <p><b>PROFILE</b><br />I am honest and driven as well as a good follower. I consistently innovate to create value.
            </p>
            </td>
            <td class="auto-style3">
            <asp:image runat="server" ImageUrl="President/2.jpg" id="Ppic" height="200" width="200" /><br />
           <asp:RadioButton runat="server" ID="pRadio2" GroupName="Presidentials" Text="ADEJUWON Omolara Sara" Font-Bold="true" />
                   <p><b>PROFILE</b><br /> I am humble, a team player and a good communicator. I love meeting new people, gathering information, public speaking and debating.
                   </p>
                </td>
                <td class="auto-style3">
            <asp:image runat="server" ImageUrl="President/3.jpg" id="Image3" height="200" width="200" /><br />
           <asp:RadioButton runat="server" ID="pRadio3" GroupName="Presidentials" Text="AREO Ayodeji Adewale" Font-Bold="true" />
                   <p><b>PROFILE</b><br />I find opportunities where others people see none. I turn ideas into projects and projects into serial successes.
                   </p>
                </td>
                  <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Others/NullVote.jpg" id="Image31" height="200" width="200" /><br />
            <asp:RadioButton runat="server" ID="pRadio4" GroupName="Presidentials" Text="Null Vote" Font-Bold="true" />     
                     <p><b>PROFILE</b><br />I do not wish to vote for any aspirant.
                   </p>
                </td>
            </tr>  
        </table><br /><br />

          <asp:Label ID="VPlabel" runat="server" Text="Vice Presidential Candidates..." Font-Size="XX-Large" Font-Bold="True" Font-Italic="True"></asp:Label>
          <table id="Table2" runat="server">        
              <tr>       
                <td class="auto-style3">
        <asp:image runat="server" ImageUrl="VicePresident/1.jpg" width="200" height="200" id="dbeauty" />
        <br />       <asp:RadioButton runat="server" ID="vpRadio1" GroupName="VicePresidentials" Text="ODILI Chigozie  Onyinye" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />NAME:I am Chineke Chigozie a.k.a ChiChi vying for the post of vice-president.
        </p>
            </td>
            <td class="auto-style3">
        <asp:image runat="server" ImageUrl="VicePresident/2.jpg" id="Jide" height="200" width="200" /><br />
           <asp:RadioButton runat="server" ID="vpRadio2" GroupName="VicePresidentials" Text="AKINDE TemItayo Similoluwa" Font-Bold="true" />     
                   <p><b>PROFILE</b><br />I am focused on enhancing academic growth, organization of 
                       a skill orientation and acquistion program, creating a link with the alumni,
                       Transparency and accountability.
                   </p>
                </td>
                  <td class="auto-style3">
        <asp:image runat="server" ImageUrl="VicePresident/3.jpg" id="Image14" height="200" width="200" /><br />
           <asp:RadioButton runat="server" ID="vpRadio3" GroupName="VicePresidentials" Text="AYOOLA Tomide Timothy" Font-Bold="true" />     
                   <p><b>PROFILE</b><br />I am passionate and i also love public speaking. I am always open to communication.
                   </p>
                </td>
                  <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Others/NullVote.jpg" id="Image30" height="200" width="200" /><br />
           <asp:RadioButton runat="server" ID="vpRadio4" GroupName="VicePresidentials" Text="Null Vote" Font-Bold="true" />     
                   <p><b>PROFILE</b><br />I do not wish to vote for any aspirant.
                   </p>
                </td>
            </tr>    
        </table>
            <br /><br />
        
        <asp:Label ID="genlabel" runat="server" Text="General Secretary..." Font-Size="XX-Large" Font-Bold="True" Font-Italic="True"></asp:Label>
        <table id="Table3" runat="server">
                    <tr>       
            <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Gen Secretary/1.jpg" width="200" height="200" id="Image12" />
        <br />       <asp:RadioButton runat="server" ID="gsRadio1" GroupName="GS" Text="BUSARI Babajide James" Font-Bold="true" />
            <p><b>PROFILE</b><br />I am Busari Babajide aka Hazmat vying for the post of General Secretary.
                   </p>
            </td>
            <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Gen Secretary/2.jpg" width="200" height="200" id="Image13" />
        <br />       <asp:RadioButton runat="server" ID="gsRadio2" GroupName="GS" Text="OLUSOLA Feyisayo Gabriel" Font-Bold="true" />
               <p><b>PROFILE</b><br/>I am Olusola Gabriel aka Gabfey. I promise Transparency and accountability.</p>
            </td>
                        <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Gen Secretary/3.jpg" width="200" height="200" id="Image15" />
        <br />       <asp:RadioButton runat="server" ID="gsRadio3" GroupName="GS" Text="ADEBIYI Ademola Jonathan" Font-Bold="true" />
               <p><b>PROFILE</b><br/>I am Adebiyi Ademola vying for the post of General Secretary. If elected,I promise to work in the best interest of all students.</p>
            </td>
                  <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Others/NullVote.jpg" id="Image32" height="200" width="200" /><br />
           <asp:RadioButton runat="server" ID="gsRadio4" GroupName="GS" Text="Null Vote" Font-Bold="true" />     
                   <p><b>PROFILE</b><br />I do not wish to vote for any aspirant.
                   </p>
                </td>
            </tr>
            </table><br /><br />

         <asp:Label ID="finlabel" runat="server" Text="Financial Secretary..." Font-Size="XX-Large" Font-Bold="True" Font-Italic="True"></asp:Label>
        <table id="Table4" runat="server">
                    <tr>       
            <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Fin Secretary/1.jpg" width="200" height="200" id="Image10" />
        <br />       <asp:RadioButton runat="server" ID="fsRadio1" GroupName="FS" Text="AYOMIDE Bajomo Charles" Font-Bold="true" />
            <p><b>PROFILE</b><br />I am humble team player and communicator. I believe all things are possible
                       when VISION & INSPIRATION are COMMUNICATED, ENERGY AND RESOURCES will be generated.
                   </p>
            </td>
            <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Fin Secretary/2.jpg" width="200" height="200" id="Image11" />
        <br />       <asp:RadioButton runat="server" ID="fsRadio2" GroupName="FS" Text="EZE Tochukwu Grace" Font-Bold="true" />
            <p><b>PROFILE</b><br />I am vying for the post of Financial Secretary and need your support.
                   </p>
            </td>
                        <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Fin Secretary/3.jpg" width="200" height="200" id="Image16" />
        <br />       <asp:RadioButton runat="server" ID="fsRadio3" GroupName="FS" Text="OKEKE Chimezie Marcel" Font-Bold="true" />
            <p><b>PROFILE</b><br />I am a good team player and I understand the art of money management. Vote me and your dues are in the right hands.
                   </p>
            </td>
                  <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Others/NullVote.jpg" id="Image33" height="200" width="200" /><br />
           <asp:RadioButton runat="server" ID="fsRadio4" GroupName="FS" Text="Null Vote" Font-Bold="true" />     
                   <p><b>PROFILE</b><br />I do not wish to vote for any aspirant.
                   </p>
                </td>
            </tr>
            </table><br /><br />
        
        <asp:Label ID="PROlabel" runat="server" Text="Public Relation Officer..." Font-Size="XX-Large" Font-Bold="True" Font-Italic="True"></asp:Label>
        <table id="Table5" runat="server">
                <tr>       
        <td class="auto-style3">
        <asp:image runat="server" ImageUrl="PRO/1.jpg" width="200" height="200" id="Gbenga" />
        <br />       <asp:RadioButton runat="server" ID="proRadio1" GroupName="PRO" Text="ADAEZE Obed Lawrentia" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />I intend to acquainte OAU with up to date development in engineering.
                I intend to adequately disseminate notice of congresses, seminars and other functions.
         
            </p>
            </td>
            <td class="auto-style3">
                <asp:image runat="server" ImageUrl="PRO/2.jpg" width="200" height="200" id="gbenge" />
        <br />       <asp:RadioButton runat="server" ID="proRadio2" GroupName="PRO" Text="UBONG Amos Adanorisewo" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />I also intend to guide freshmen information wise and i wish to take OAUSU to greater heights.
         
            </p>
                </td>
                    <td class="auto-style3">
                <asp:image runat="server" ImageUrl="PRO/3.jpg" width="200" height="200" id="Image17" />
        <br />       <asp:RadioButton runat="server" ID="proRadio3" GroupName="PRO" Text="OLAPADE Tomide James" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />As PRO, I intend to acquainte everyone with all activities in OAU, the nation and diaspora.
         
            </p>
                </td>
                  <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Others/NullVote.jpg" id="Image34" height="200" width="200" /><br />
           <asp:RadioButton runat="server" ID="proRadio4" GroupName="PRO" Text="Null Vote" Font-Bold="true" />     
                   <p><b>PROFILE</b><br />I do not wish to vote for any aspirant.
                   </p>
                </td>
            </tr>    </table>
        <br /><br/>

        <asp:Label ID="SOClabel" runat="server" Text="Director of Socials..." Font-Size="XX-Large" Font-Bold="True" Font-Italic="True"></asp:Label>
        <table id="Table6" runat="server">
                <tr>       
        <td class="auto-style3">
            <asp:image runat="server" ImageUrl="Social/1.jpg" width="200" height="200" id="Image24" />
        <br />       
            <asp:RadioButton runat="server" ID="socRadio1" GroupName="SocialDirector" Text="EZE Chiugo Amaka" Font-Bold="true" />
        <p><b>PROFILE</b><br />I am humble team player and communicator. I believe all things are possible
                       when VISION & INSPIRATION are COMMUNICATED, ENERGY AND RESOURCES will be generated.
                   </p>
             </td>
            <td class="auto-style3">
                <asp:image runat="server" ImageUrl="Social/2.jpg" width="200" height="200" id="Image25" />
        <br />       
            <asp:RadioButton runat="server" ID="socRadio2" GroupName="SocialDirector" Text="OLUSEESIN Tomide Daniel" Font-Bold="true" />
         <p><b>PROFILE</b><br /> I love 
                       cooking, meeting new people, gathering information, public speaking and debating.
                   </p>
            </td>
                    <td class="auto-style3">
                <asp:image runat="server" ImageUrl="Social/3.jpg" width="200" height="200" id="Image26" />
        <br />       
            <asp:RadioButton runat="server" ID="socRadio3" GroupName="SocialDirector" Text="MAKINDE Afolabi Micheal" Font-Bold="true" />
         <p><b>PROFILE</b><br />I am fun and great to be around. I promise to improve the social atmosphere in OAU.
                   </p>
            </td>
                  <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Others/NullVote.jpg" id="Image35" height="200" width="200" /><br />
           <asp:RadioButton runat="server" ID="socRadio4" GroupName="SocialDirector" Text="Null Vote" Font-Bold="true" />     
                   <p><b>PROFILE</b><br />I do not wish to vote for any aspirant.
                   </p>
                </td>
            </tr>    </table><br /><br />
        
        <asp:Label ID="trelabel" runat="server" Text="Treasurer..." Font-Size="XX-Large" Font-Bold="True" Font-Italic="True"></asp:Label>
        <table id="Table7" runat="server">
                <tr>       
        <td class="auto-style3">
            <asp:image runat="server" ImageUrl="treasurer/1.jpg" width="200" height="200" id="fola" />
        <br />       
            <asp:RadioButton runat="server" ID="treRadio1" GroupName="treasurer" Text="ADEOYE Abiola Ahmed " Font-Bold="true" />
        <p><b>PROFILE</b><br />I am humble team player and communicator. I believe all things are possible
                       when VISION & INSPIRATION are COMMUNICATED, ENERGY AND RESOURCES will be generated.
                   </p>
             </td>
            <td class="auto-style3">
                <asp:image runat="server" ImageUrl="treasurer/2.jpg" width="200" height="200" id="Image7" />
        <br />       
            <asp:RadioButton runat="server" ID="treRadio2" GroupName="treasurer" Text="OLAPADE Tolulope Cynthia" Font-Bold="true" />
         <p><b>PROFILE</b><br /> I love cooking, meeting new people, gathering information, public speaking and debating.
                   </p>
            </td>
                    <td class="auto-style3">
                <asp:image runat="server" ImageUrl="treasurer/3.jpg" width="200" height="200" id="Image19" />
        <br />       
            <asp:RadioButton runat="server" ID="treRadio3" GroupName="treasurer" Text="SANUSI Temitayo Abiwo" Font-Bold="true" />
         <p><b>PROFILE</b><br />I am humble team player and communicator.
                   </p>
            </td>
                  <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Others/NullVote.jpg" id="Image36" height="200" width="200" /><br />
           <asp:RadioButton runat="server" ID="treRadio4" GroupName="treasurer" Text="Null Vote" Font-Bold="true" />     
                   <p><b>PROFILE</b><br />I do not wish to vote for any aspirant.
                   </p>
                </td>
            </tr>    </table><br /><br />
        
        <asp:Label ID="AGSlabel" runat="server" Text="Assistant General Secretary..." Font-Size="XX-Large" Font-Bold="True" Font-Italic="True"></asp:Label>
        <table id="Table8" runat="server">
                    <tr>       
            <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Gen Secretary/5.jpg" width="200" height="200" id="beloved" />
        <br />       <asp:RadioButton runat="server" ID="agsRadio1" GroupName="AGS" Text="ADEOYE Adela Matawale" Font-Bold="true" />
           <p><b>PROFILE</b><br />I am Adeoye Adela vying for the post of Assistant General Secretary.
                   </p>
                 </td>
            <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Gen Secretary/6.jpg" width="200" height="200" id="Image8" />
        <br />       <asp:RadioButton runat="server" ID="agsRadio2" GroupName="AGS" Text="AZIKIWE Amaka Joy" Font-Bold="true" />
            <p><b>PROFILE</b><br />If voted in, I promise to support the General Seecretary
                   </p>
            </td>
                         <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Gen Secretary/7.jpg" width="200" height="200" id="Image18" />
        <br />       <asp:RadioButton runat="server" ID="agsRadio3" GroupName="AGS" Text="BAKARE Zainab Tolulope" Font-Bold="true" />
            <p><b>PROFILE</b><br />I believe all things are possible and will carry this attitude to my work if voted in.
                   </p>
            </td>
                  <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Others/NullVote.jpg" id="Image37" height="200" width="200" /><br />
           <asp:RadioButton runat="server" ID="agsRadio4" GroupName="AGS" Text="Null Vote" Font-Bold="true" />     
                   <p><b>PROFILE</b><br />I do not wish to vote for any aspirant.
                   </p>
                </td>
            </tr>
            </table><br /><br />

           <asp:Label ID="wellabel" runat="server" Text="Welfare Director..." Font-Size="XX-Large" Font-Bold="True" Font-Italic="True"></asp:Label>
       <table id="Table9" runat="server">   
        <tr>
            <td class="auto-style3">
        <asp:image runat="server" ImageUrl="welfare/1.jpg" width="200" height="200" id="Image1" />
        <br />       <asp:RadioButton runat="server" ID="welRadio1" GroupName="welfare" Text="EZEIRU Chike Philip" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />I am vying for the post of Welfare Director
            </p>
            </td>
            <td class="auto-style3">
                <asp:image runat="server" ImageUrl="welfare/2.jpg" width="200" height="200" id="Image6" />
        <br />       <asp:RadioButton runat="server" ID="welRadio2" GroupName="welfare" Text="UBONG Uduak Harny " Font-Bold="true" />
         
            <p><b>PROFILE</b><br />I promise to cater to the welfare of all.
            </p>
            </td>
            <td class="auto-style3">
                <asp:image runat="server" ImageUrl="welfare/3.jpg" width="200" height="200" id="Image20" />
        <br />       <asp:RadioButton runat="server" ID="welRadio3" GroupName="welfare" Text="MOHAMMED Kabiru" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />I promise to work towards improving the overall well being of everyone.
            </p>
            </td>
                  <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Others/NullVote.jpg" id="Image38" height="200" width="200" /><br />
           <asp:RadioButton runat="server" ID="welRadio4" GroupName="welfare" Text="Null Vote" Font-Bold="true" />     
                   <p><b>PROFILE</b><br />I do not wish to vote for any aspirant.
                   </p>
                </td>
            </tr>
            </table>    <br /><br />

           <asp:Label ID="Slabel" runat="server" Text="Sport Director..." Font-Size="XX-Large" Font-Bold="True" Font-Italic="True"></asp:Label>
       <table id="Table10" runat="server">   
        <tr>
            <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Sports/1.jpg" width="200" height="200" id="Image27" />
        <br />       <asp:RadioButton runat="server" ID="spoRadio1" GroupName="SportDirector" Text="MOHAMMED Quadri" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />I promise to ensure that some other sports outside 
                football is done during the e-week to ensure that nearly everbody participates.
            </p>
            </td>
            <td class="auto-style3">
                <asp:image runat="server" ImageUrl="Sports/2.jpg" width="200" height="200" id="Image28" />
        <br />       <asp:RadioButton runat="server" ID="spoRadio2" GroupName="SportDirector" Text="UBONG Harny Simon" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />I promise to ensure that all levels are carried along, to partner with the national sports
                director and ensure that we are fully represented. 
            </p>
            </td>
            <td class="auto-style3">
                <asp:image runat="server" ImageUrl="Sports/3.jpg" width="200" height="200" id="Image29" />
        <br />       <asp:RadioButton runat="server" ID="spoRadio3" GroupName="SportDirector" Text="KUKU Amina" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />Eze Chika attended Hope high school, Abakaliki. He was born on 16th
                november. Manifestoes include To properly coordinate all sporting activities.
            </p>
            </td>
                  <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Others/NullVote.jpg" id="Image39" height="200" width="200" /><br />
           <asp:RadioButton runat="server" ID="spoRadio4" GroupName="SportDirector" Text="Null Vote" Font-Bold="true" />     
                   <p><b>PROFILE</b><br />I do not wish to vote for any aspirant.
                   </p>
                </td>
            </tr>
            </table>    <br /><br />
         
        <asp:Label ID="Llabel" runat="server" Text="Librarian..." Font-Size="XX-Large" Font-Bold="True" Font-Italic="True"></asp:Label>
         <table id="Table11" runat="server">
        <tr >       
        <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Librarian/1.jpg" width="200" height="200" id="Nat" />
        <br />       <asp:RadioButton runat="server" ID="libRadio1" GroupName="Librarian" Text="EZIKEOHA Joy" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />I ams a 300 level student of electronic and electrical
                engineering department. I once had the opportunity to serve as Library prefect of his secondary school where in
                which he served dutifully and was commended for good service. 
            </p>
            </td>
            <td class="auto-style3">
                <asp:image runat="server" ImageUrl="Librarian/2.jpg" width="200" height="200" id="Image5" />
        <br />       <asp:RadioButton runat="server" ID="libRadio2" GroupName="Librarian" Text="ADEWALE Mayowa Blessing" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />I am willing to serve the OAU society and needs your
                help to do so, vote and experience great service.
            </p>
            </td>
            <td class="auto-style3">
                <asp:image runat="server" ImageUrl="Librarian/3.jpg" width="200" height="200" id="Image21" />
        <br />       <asp:RadioButton runat="server" ID="libRadio3" GroupName="Librarian" Text="AYO Bukunmi Zachary" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />I promise to improve the state of the student union library.
            </p>
            </td>
                  <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Others/NullVote.jpg" id="Image40" height="200" width="200" /><br />
           <asp:RadioButton runat="server" ID="libRadio4" GroupName="Librarian" Text="Null Vote" Font-Bold="true" />     
                   <p><b>PROFILE</b><br />I do not wish to vote for any aspirant.
                   </p>
                </td>
            </tr>    
        </table><br /><br />
        
        <asp:Label ID="ALlabel" runat="server" Text="Assistant Librarian..." Font-Size="XX-Large" Font-Bold="True" Font-Italic="True"></asp:Label>
        <table id="Table12" runat="server">
                   <tr >       
        <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Librarian/5.jpg" width="200" height="200" id="Image4" />
        <br />       <asp:RadioButton runat="server" ID="alRadio1" GroupName="asstlib" Text="OGAYI Okechukwu Frank" Font-Bold="true" />
        <p><b>PROFILE</b><br />I am humble team player and communicator. I believe all things are possible
                       when VISION & INSPIRATION are COMMUNICATED, ENERGY AND RESOURCES will be generated. 
                   </p> 
        </td>
               <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Librarian/6.jpg" width="200" height="200" id="Image9" />
        <br />       <asp:RadioButton runat="server" ID="alRadio2" GroupName="asstlib" Text="ABIOLA Olusola" Font-Bold="true" />
             <p><b>PROFILE</b><br />I love 
                       cooking, meeting new people, gathering information, public speaking and debating.
                   </p>
                     </td>
               <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Librarian/7.jpg" width="200" height="200" id="Image22" />
        <br />       <asp:RadioButton runat="server" ID="alRadio3" GroupName="asstlib" Text="ADEOYE Adesola" Font-Bold="true" />
             <p><b>PROFILE</b><br />If voted in, I promise to support the librarian toward the upkeep of the department.
                   </p>
                     </td>
                  <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Others/NullVote.jpg" id="Image41" height="200" width="200" /><br />
           <asp:RadioButton runat="server" ID="alRadio4" GroupName="asstlib" Text="Null Vote" Font-Bold="true" />     
                   <p><b>PROFILE</b><br />I do not wish to vote for any aspirant.
                   </p>
                </td>
            </tr>  
            </table>

           <asp:Label ID="Elabel" runat="server" Text="Editor in Chief..." Font-Size="XX-Large" Font-Bold="True" Font-Italic="True"></asp:Label>
        <table id="Table13" runat="server">
                <tr >       
        <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Others/1.jpg" width="200" height="200" id="dara" />
        <br />       <asp:RadioButton runat="server" ID="ediRadio1" GroupName="EditorInChief" Text="FALAYI Esther" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />I plan to illuminate the dark continent of OAUSU.
                I plan to provide a board that can relate with its reader. 
            </p>
            </td>
                    <td class="auto-style3">
                    <asp:image runat="server" ImageUrl="Others/2.jpg" width="200" height="200" id="Image2" />
        <br />       <asp:RadioButton runat="server" ID="ediRadio2" GroupName="EditorInChief" Text="IDOWU Olubunmi" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />I will publish articles that provides an educated angle
                to all happenings in the world.
            </p>
            </td>
                    <td class="auto-style3">
                    <asp:image runat="server" ImageUrl="Others/3.jpg" width="200" height="200" id="Image23" />
        <br />       <asp:RadioButton runat="server" ID="ediRadio3" GroupName="EditorInChief" Text="AJAYI Olufemi" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />If voted in, I promise to publish articles that informs all those who read them.
            </p>
            </td>
                  <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Others/NullVote.jpg" id="Image42" height="200" width="200" /><br />
           <asp:RadioButton runat="server" ID="ediRadio4" GroupName="EditorInChief" Text="Null Vote" Font-Bold="true" />     
                   <p><b>PROFILE</b><br />I do not wish to vote for any aspirant.
                   </p>
                </td>
            </tr>    </table><br /><br />

        <asp:Button ID="submitButton" runat="server" Text="Submit" Font-Bold="True" Font-Size="X-Large" Width="400px" OnClick="submit_Click" BorderStyle="Groove" />
        <br /><br /><br />
        <asp:Label ID="holdUsername" runat="server" Text=""></asp:Label>
        <asp:Label ID="holdName" runat="server" Text=""></asp:Label>
        <asp:Label ID="holdMatric" runat="server" Text=""></asp:Label>
        <asp:Label ID="holdFaculty" runat="server" Text=""></asp:Label>
        <asp:Label ID="holdDept" runat="server" Text=""></asp:Label>

        <style type="text/css">
        .auto-style3 
        {
            top: 5px;
            left: 5px;
            width: 237px;
            flex-item-align:start;
        }
    </style>

    </asp:Content>

    

