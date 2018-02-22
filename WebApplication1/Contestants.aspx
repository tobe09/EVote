<%@ Page Language="C#" MasterPageFile="~/ProjectApp.Master" Title="Contestants" AutoEventWireup="true" CodeBehind="Contestants.aspx.cs" Inherits="WebApplication1.Contestants" %>

<asp:Content ID="Content" runat="server" ContentPlaceHolderID="ContentPH">

    <br />
    <asp:Label ID="Plabel" runat="server" Text="Presidential Candidates..." Font-Size="XX-Large" Font-Bold="True" Font-Italic="True"/>
        <table id="Table1" runat="server">      
            <tr >       
                <td class="auto-style3">
                <asp:image runat="server" ImageUrl="President/1.jpg" width="200" height="200" id="mahatmapic" />
                    <br />
                <asp:Label runat="server" ID="pRadio1" Text="CHINEKE Tobenna Chinonso" Font-Bold="true" />
                <p><b>PROFILE</b><br />I am honest and driven as well as a good follower. I consistently innovate to create value.
            </p>
            </td>
            <td class="auto-style3">
            <asp:image runat="server" ImageUrl="President/2.jpg" id="Ppic" height="200" width="200" /><br />
           <asp:Label runat="server" ID="pRadio2" Text="ADEJUWON Omolara Sara" Font-Bold="true" />
                   <p><b>PROFILE</b><br /> I am humble, a team player and a good communicator. I love meeting new people, gathering information, public speaking and debating.
                   </p>
                </td>
                <td class="auto-style3">
            <asp:image runat="server" ImageUrl="President/3.jpg" id="Image3" height="200" width="200" /><br />
           <asp:Label runat="server" ID="pRadio3" Text="AREO Ayodeji Adewale" Font-Bold="true" />
                   <p><b>PROFILE</b><br />I find opportunities where others people see none. I turn ideas into projects and projects into serial successes.
                   </p>
                </td>
            </tr>  
        </table><br /><br />

          <asp:Label ID="VPlabel" runat="server" Text="Vice Presidential Candidates..." Font-Size="XX-Large" Font-Bold="True" Font-Italic="True"></asp:Label>
          <table id="Table2" runat="server">        
              <tr>       
                <td class="auto-style3">
        <asp:image runat="server" ImageUrl="VicePresident/1.jpg" width="200" height="200" id="dbeauty" />
        <br />       <asp:Label runat="server" ID="vpRadio1" Text="ODILI Chigozie  Onyinye" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />NAME:I am Chineke Chigozie a.k.a ChiChi vying for the post of vice-president.
        </p>
            </td>
            <td class="auto-style3">
        <asp:image runat="server" ImageUrl="VicePresident/2.jpg" id="Jide" height="200" width="200" /><br />
           <asp:Label runat="server" ID="vpRadio2" Text="AKINDE TemItayo Similoluwa" Font-Bold="true" />     
                   <p><b>PROFILE</b><br />I am focused on enhancing academic growth, organization of 
                       a skill orientation and acquistion program, creating a link with the alumni,
                       Transparency and accountability.
                   </p>
                </td>
                  <td class="auto-style3">
        <asp:image runat="server" ImageUrl="VicePresident/3.jpg" id="Image14" height="200" width="200" /><br />
           <asp:Label runat="server" ID="vpRadio3" Text="AYOOLA Tomide Timothy" Font-Bold="true" />     
                   <p><b>PROFILE</b><br />I am passionate and i also love public speaking. I am always open to communication.
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
        <br />       <asp:Label runat="server" ID="gsRadio1" Text="BUSARI Babajide James" Font-Bold="true" />
            <p><b>PROFILE</b><br />I am Busari Babajide aka Hazmat vying for the post of General Secretary.
                   </p>
            </td>
            <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Gen Secretary/2.jpg" width="200" height="200" id="Image13" />
        <br />       <asp:Label runat="server" ID="gsRadio2" Text="OLUSOLA Feyisayo Gabriel" Font-Bold="true" />
               <p><b>PROFILE</b><br/>I am Olusola Gabriel aka Gabfey. I promise Transparency and accountability.</p>
            </td>
                        <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Gen Secretary/3.jpg" width="200" height="200" id="Image15" />
        <br />       <asp:Label runat="server" ID="gsRadio3" Text="ADEBIYI Ademola Jonathan" Font-Bold="true" />
               <p><b>PROFILE</b><br/>I am Adebiyi Ademola vying for the post of General Secretary. If elected,I promise to work in the best interest of all students.</p>
            </td>
            </tr>
            </table><br /><br />

         <asp:Label ID="finlabel" runat="server" Text="Financial Secretary..." Font-Size="XX-Large" Font-Bold="True" Font-Italic="True"></asp:Label>
        <table id="Table4" runat="server">
                    <tr>       
            <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Fin Secretary/1.jpg" width="200" height="200" id="Image10" />
        <br />       <asp:Label runat="server" ID="fsRadio1" Text="AYOMIDE Bajomo Charles" Font-Bold="true" />
            <p><b>PROFILE</b><br />I am humble team player and communicator. I believe all things are possible
                       when VISION & INSPIRATION are COMMUNICATED, ENERGY AND RESOURCES will be generated.
                   </p>
            </td>
            <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Fin Secretary/2.jpg" width="200" height="200" id="Image11" />
        <br />       <asp:Label runat="server" ID="fsRadio2" Text="EZE Tochukwu Grace" Font-Bold="true" />
            <p><b>PROFILE</b><br />I am vying for the post of Financial Secretary and need your support.
                   </p>
            </td>
                        <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Fin Secretary/3.jpg" width="200" height="200" id="Image16" />
        <br />       <asp:Label runat="server" ID="fsRadio3" Text="OKEKE Chimezie Marcel" Font-Bold="true" />
            <p><b>PROFILE</b><br />I am a good team player and I understand the art of money management. Vote me and your dues are in the right hands.
                   </p>
            </td>
            </tr>
            </table><br /><br />
        
        <asp:Label ID="PROlabel" runat="server" Text="Public Relation Officer..." Font-Size="XX-Large" Font-Bold="True" Font-Italic="True"></asp:Label>
        <table id="Table5" runat="server">
                <tr>       
        <td class="auto-style3">
        <asp:image runat="server" ImageUrl="PRO/1.jpg" width="200" height="200" id="Gbenga" />
        <br />       <asp:Label runat="server" ID="proRadio1" Text="ADAEZE Obed Lawrentia" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />I intend to acquainte OAU with up to date development in engineering.
                I intend to adequately disseminate notice of congresses, seminars and other functions.
         
            </p>
            </td>
            <td class="auto-style3">
                <asp:image runat="server" ImageUrl="PRO/2.jpg" width="200" height="200" id="gbenge" />
        <br />       <asp:Label runat="server" ID="proRadio2" Text="UBONG Amos Adanorisewo" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />I also intend to guide freshmen information wise and i wish to take OAUSU to greater heights.
         
            </p>
                </td>
                    <td class="auto-style3">
                <asp:image runat="server" ImageUrl="PRO/3.jpg" width="200" height="200" id="Image17" />
        <br />       <asp:Label runat="server" ID="proRadio3" Text="OLAPADE Tomide James" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />As PRO, I intend to acquainte everyone with all activities in OAU, the nation and diaspora.
         
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
            <asp:Label runat="server" ID="socRadio1" Text="EZE Chiugo Amaka" Font-Bold="true" />
        <p><b>PROFILE</b><br />I am humble team player and communicator. I believe all things are possible
                       when VISION & INSPIRATION are COMMUNICATED, ENERGY AND RESOURCES will be generated.
                   </p>
             </td>
            <td class="auto-style3">
                <asp:image runat="server" ImageUrl="Social/2.jpg" width="200" height="200" id="Image25" />
        <br />       
            <asp:Label runat="server" ID="socRadio2" Text="OLUSEESIN Tomide Daniel" Font-Bold="true" />
         <p><b>PROFILE</b><br /> I love 
                       cooking, meeting new people, gathering information, public speaking and debating.
                   </p>
            </td>
                    <td class="auto-style3">
                <asp:image runat="server" ImageUrl="Social/3.jpg" width="200" height="200" id="Image26" />
        <br />       
            <asp:Label runat="server" ID="socRadio3" Text="MAKINDE Afolabi Micheal" Font-Bold="true" />
         <p><b>PROFILE</b><br />I am fun and great to be around. I promise to improve the social atmosphere in OAU.
                   </p>
            </td>
            </tr>    </table><br /><br />
        
        <asp:Label ID="trelabel" runat="server" Text="Treasurer..." Font-Size="XX-Large" Font-Bold="True" Font-Italic="True"></asp:Label>
        <table id="Table7" runat="server">
                <tr>       
        <td class="auto-style3">
            <asp:image runat="server" ImageUrl="treasurer/1.jpg" width="200" height="200" id="fola" />
        <br />       
            <asp:Label runat="server" ID="treRadio1" Text="ADEOYE Abiola Ahmed " Font-Bold="true" />
        <p><b>PROFILE</b><br />I am humble team player and communicator. I believe all things are possible
                       when VISION & INSPIRATION are COMMUNICATED, ENERGY AND RESOURCES will be generated.
                   </p>
             </td>
            <td class="auto-style3">
                <asp:image runat="server" ImageUrl="treasurer/2.jpg" width="200" height="200" id="Image7" />
        <br />       
            <asp:Label runat="server" ID="treRadio2" Text="OLAPADE Tolulope Cynthia" Font-Bold="true" />
         <p><b>PROFILE</b><br /> I love cooking, meeting new people, gathering information, public speaking and debating.
                   </p>
            </td>
                    <td class="auto-style3">
                <asp:image runat="server" ImageUrl="treasurer/3.jpg" width="200" height="200" id="Image19" />
        <br />       
            <asp:Label runat="server" ID="treRadio3" Text="SANUSI Temitayo Abiwo" Font-Bold="true" />
         <p><b>PROFILE</b><br />I am humble team player and communicator.
                   </p>
            </td>
            </tr>    </table><br /><br />
        
        <asp:Label ID="AGSlabel" runat="server" Text="Assistant General Secretary..." Font-Size="XX-Large" Font-Bold="True" Font-Italic="True"></asp:Label>
        <table id="Table8" runat="server">
                    <tr>       
            <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Gen Secretary/5.jpg" width="200" height="200" id="beloved" />
        <br />       <asp:Label runat="server" ID="agsRadio1" Text="ADEOYE Adela Matawale" Font-Bold="true" />
           <p><b>PROFILE</b><br />I am Adeoye Adela vying for the post of Assistant General Secretary.
                   </p>
                 </td>
            <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Gen Secretary/6.jpg" width="200" height="200" id="Image8" />
        <br />       <asp:Label runat="server" ID="agsRadio2" Text="AZIKIWE Amaka Joy" Font-Bold="true" />
            <p><b>PROFILE</b><br />If voted in, I promise to support the General Seecretary
                   </p>
            </td>
                         <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Gen Secretary/7.jpg" width="200" height="200" id="Image18" />
        <br />       <asp:Label runat="server" ID="agsRadio3" Text="BAKARE Zainab Tolulope" Font-Bold="true" />
            <p><b>PROFILE</b><br />I believe all things are possible and will carry this attitude to my work if voted in.
                   </p>
            </td>
            </tr>
            </table><br /><br />

           <asp:Label ID="wellabel" runat="server" Text="Welfare Director..." Font-Size="XX-Large" Font-Bold="True" Font-Italic="True"></asp:Label>
       <table id="Table9" runat="server">   
        <tr>
            <td class="auto-style3">
        <asp:image runat="server" ImageUrl="welfare/1.jpg" width="200" height="200" id="Image1" />
        <br />       <asp:Label runat="server" ID="welRadio1" Text="EZEIRU Chike Philip" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />I am vying for the post of Welfare Director
            </p>
            </td>
            <td class="auto-style3">
                <asp:image runat="server" ImageUrl="welfare/2.jpg" width="200" height="200" id="Image6" />
        <br />       <asp:Label runat="server" ID="welRadio2" Text="UBONG Uduak Harny " Font-Bold="true" />
         
            <p><b>PROFILE</b><br />I promise to cater to the welfare of all.
            </p>
            </td>
            <td class="auto-style3">
                <asp:image runat="server" ImageUrl="welfare/3.jpg" width="200" height="200" id="Image20" />
        <br />       <asp:Label runat="server" ID="welRadio3" Text="MOHAMMED Kabiru" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />I promise to work towards improving the overall well being of everyone.
            </p>
            </td>
            </tr>
            </table>    <br /><br />

           <asp:Label ID="Slabel" runat="server" Text="Sport Director..." Font-Size="XX-Large" Font-Bold="True" Font-Italic="True"></asp:Label>
       <table id="Table10" runat="server">   
        <tr>
            <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Sports/1.jpg" width="200" height="200" id="Image27" />
        <br />       <asp:Label runat="server" ID="spoRadio1" Text="MOHAMMED Quadri" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />I promise to ensure that some other sports outside 
                football is done during the e-week to ensure that nearly everbody participates.
            </p>
            </td>
            <td class="auto-style3">
                <asp:image runat="server" ImageUrl="Sports/2.jpg" width="200" height="200" id="Image28" />
        <br />       <asp:Label runat="server" ID="spoRadio2" Text="UBONG Harny Simon" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />I promise to ensure that all levels are carried along, to partner with the national sports
                director and ensure that we are fully represented. 
            </p>
            </td>
            <td class="auto-style3">
                <asp:image runat="server" ImageUrl="Sports/3.jpg" width="200" height="200" id="Image29" />
        <br />       <asp:Label runat="server" ID="spoRadio3" Text="KUKU Amina" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />Eze Chika attended Hope high school, Abakaliki. He was born on 16th
                november. Manifestoes include To properly coordinate all sporting activities.
            </p>
            </td>
            </tr>
            </table>    <br /><br />
         
        <asp:Label ID="Llabel" runat="server" Text="Librarian..." Font-Size="XX-Large" Font-Bold="True" Font-Italic="True"></asp:Label>
         <table id="Table11" runat="server">
        <tr >       
        <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Librarian/1.jpg" width="200" height="200" id="Nat" />
        <br />       <asp:Label runat="server" ID="libRadio1" Text="EZIKEOHA Joy" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />I ams a 300 level student of electronic and electrical
                engineering department. I once had the opportunity to serve as Library prefect of his secondary school where in
                which he served dutifully and was commended for good service. 
            </p>
            </td>
            <td class="auto-style3">
                <asp:image runat="server" ImageUrl="Librarian/2.jpg" width="200" height="200" id="Image5" />
        <br />       <asp:Label runat="server" ID="libRadio2" Text="ADEWALE Mayowa Blessing" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />I am willing to serve the OAU society and needs your
                help to do so, vote and experience great service.
            </p>
            </td>
            <td class="auto-style3">
                <asp:image runat="server" ImageUrl="Librarian/3.jpg" width="200" height="200" id="Image21" />
        <br />       <asp:Label runat="server" ID="libRadio3" Text="AYO Bukunmi Zachary" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />I promise to improve the state of the student union library.
            </p>
            </td>
            </tr>    
        </table><br /><br />
        
        <asp:Label ID="ALlabel" runat="server" Text="Assistant Librarian..." Font-Size="XX-Large" Font-Bold="True" Font-Italic="True"></asp:Label>
        <table id="Table12" runat="server">
                   <tr >       
        <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Librarian/5.jpg" width="200" height="200" id="Image4" />
        <br />       <asp:Label runat="server" ID="alRadio1" Text="OGAYI Okechukwu Frank" Font-Bold="true" />
        <p><b>PROFILE</b><br />I am humble team player and communicator. I believe all things are possible
                       when VISION & INSPIRATION are COMMUNICATED, ENERGY AND RESOURCES will be generated. 
                   </p> 
        </td>
               <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Librarian/6.jpg" width="200" height="200" id="Image9" />
        <br />       <asp:Label runat="server" ID="alRadio2" Text="ABIOLA Olusola" Font-Bold="true" />
             <p><b>PROFILE</b><br />I love 
                       cooking, meeting new people, gathering information, public speaking and debating.
                   </p>
                     </td>
               <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Librarian/7.jpg" width="200" height="200" id="Image22" />
        <br />       <asp:Label runat="server" ID="alRadio3"  Text="ADEOYE Adesola" Font-Bold="true" />
             <p><b>PROFILE</b><br />If voted in, I promise to support the librarian toward the upkeep of the department.
                   </p>
                     </td>
            </tr>  
            </table>

           <asp:Label ID="Elabel" runat="server" Text="Editor in Chief..." Font-Size="XX-Large" Font-Bold="True" Font-Italic="True"></asp:Label>
        <table id="Table13" runat="server">
                <tr >       
        <td class="auto-style3">
        <asp:image runat="server" ImageUrl="Others/1.jpg" width="200" height="200" id="dara" />
        <br />       <asp:Label runat="server" ID="ediRadio1" Text="FALAYI Esther" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />I plan to illuminate the dark continent of OAUSU.
                I plan to provide a board that can relate with its reader. 
            </p>
            </td>
                    <td class="auto-style3">
                    <asp:image runat="server" ImageUrl="Others/2.jpg" width="200" height="200" id="Image2" />
        <br />       <asp:Label runat="server" ID="ediRadio2" Text="IDOWU Olubunmi" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />I will publish articles that provides an educated angle
                to all happenings in the world.
            </p>
            </td>
                    <td class="auto-style3">
                    <asp:image runat="server" ImageUrl="Others/3.jpg" width="200" height="200" id="Image23" />
        <br />       <asp:Label runat="server" ID="ediRadio3" Text="AJAYI Olufemi" Font-Bold="true" />
         
            <p><b>PROFILE</b><br />If voted in, I promise to publish articles that informs all those who read them.
            </p>
            </td>
            </tr>    </table><br /><br />

    <style type="text/css">
        .auto-style3 
        {
            top: 5px;
            left: 5px;
            width: 317px;
            flex-item-align:start;
        }
    </style>

    </asp:Content>

