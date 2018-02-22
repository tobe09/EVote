using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Security.Cryptography;
using System.IO;
using System.Text;


namespace WebApplication1
{
    public partial class Result : System.Web.UI.Page
    {
        //using this class
        ResultCode rs = new ResultCode();
        protected void Page_Load(object sender, EventArgs e)
        {
            //initial state of component visibility
            logUsername.Font.Bold = true;
            logName.Font.Bold = false;
            logUsername.Visible = false;
            logName.Visible = false;
            logFaculty.Visible = false;
            logMatric.Visible = false;
            logDept.Visible = false;
            holdUsername.Visible = false;
            holdName.Visible = false;
            holdFaculty.Visible = false;
            holdDept.Visible = false;
            holdMatric.Visible = false;
            Table1.Visible = false;
            Table2.Visible = false;
            tlabel.Visible = false;
            logLabel.Visible = false;

            pi1.Visible = false; pi2.Visible = false; pi3.Visible = false;
            vpi1.Visible = false; vpi2.Visible = false; vpi3.Visible = false;
            gsi1.Visible = false; gsi2.Visible = false; gsi3.Visible = false;
            fsi1.Visible = false; fsi2.Visible = false; fsi3.Visible = false;
            proi1.Visible = false; proi2.Visible = false; proi3.Visible = false;
            soci1.Visible = false; soci2.Visible = false; soci3.Visible = false;
            trei1.Visible = false; trei2.Visible = false; trei3.Visible = false;
            agsi1.Visible = false; agsi2.Visible = false; agsi3.Visible = false;
            weli1.Visible = false; weli2.Visible = false; weli3.Visible = false;
            spoi1.Visible = false; spoi2.Visible = false; spoi3.Visible = false;
            libi1.Visible = false; libi2.Visible = false; libi3.Visible = false;
            ali1.Visible = false; ali2.Visible = false; ali3.Visible = false;
            edii1.Visible = false; edii2.Visible = false; edii3.Visible = false;

            Image1.Visible = false; Image2.Visible = false; Image3.Visible = false; Image4.Visible = false;
            Image5.Visible = false; Image6.Visible = false; Image7.Visible = false; Image8.Visible = false;
            Image9.Visible = false; Image10.Visible = false; Image11.Visible = false; Image12.Visible = false;
            Image13.Visible = false; Image14.Visible = false; Image15.Visible = false; Image16.Visible = false;
            Image17.Visible = false; Image18.Visible = false; Image19.Visible = false; Image20.Visible = false;
            Image21.Visible = false; Image22.Visible = false; Image23.Visible = false; Image24.Visible = false;
            Image25.Visible = false; Image26.Visible = false; Image27.Visible = false; Image28.Visible = false;
            Image29.Visible = false; Image30.Visible = false; Image31.Visible = false; Image32.Visible = false;
            Image33.Visible = false; Image34.Visible = false; Image35.Visible = false; Image36.Visible = false;
            Image37.Visible = false; Image38.Visible = false; Image39.Visible = false; Image40.Visible = false;
            Image41.Visible = false; Image42.Visible = false; Image43.Visible = false; Image44.Visible = false;
            Image45.Visible = false; Image46.Visible = false; Image47.Visible = false; Image48.Visible = false;
            Image49.Visible = false; Image50.Visible = false; Image51.Visible = false; Image52.Visible = false;
        }

        //create encryption key for validation
        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        protected void login_Click(object sender, EventArgs e)
        {
            if (usernameBox.Text.ToUpper() == "adminregister".ToUpper() && passwordBox.Text.ToUpper() == "admin101".ToUpper())
            { Response.Redirect("RegisterKey.aspx"); }

            if (usernameBox.Text.ToUpper() == "admindatabase".ToUpper() && passwordBox.Text.ToUpper() == "admin101".ToUpper())
            { Response.Redirect("Database.aspx"); }

            logUsername.Text = "Username: ";
            logName.Text = "Name: ";
            logMatric.Text = "Matric. Number: ";
            logDept.Text = "Department: ";
            logFaculty.Text = "Faculty: ";

            //imitialize labels with values
            P1.Text = "CHINEKE Tobenna Chinonso: "; P2.Text = "ADEJUWON Omolara Sara: "; P3.Text = "AREO Ayodeji Adewale: "; PN.Text = "Null Vote: ";
            VP1.Text = "ODILI Chigozie Onyinye: "; VP2.Text = "AKINDE Temitayo Similoluwa: "; VP3.Text = "AYOOLA Tomide Timothy: "; VPN.Text = "Null Vote: ";
            GS1.Text = "BUSARI Babajide James: "; GS2.Text = "OLUSOLA Feyisayo Gabriel: "; GS3.Text = "ADEBIYI Ademola Jonathan: "; GSN.Text = "Null Vote: ";
            FS1.Text = "AYOMIDE Bajomo Charles: "; FS2.Text = "EZE Tochukwu Grace: "; FS3.Text = "OKEKE Chimezie Marcel: "; FSN.Text = "Null Vote: ";
            PRO1.Text = "ADAEZE Obed Lawrentia: "; PRO2.Text = "UBONG Amos Adanorisewo: "; PRO3.Text = "OLAPADE Tomide James: "; PRON.Text = "Null Vote: ";
            SOC1.Text = "EZE Chiugo Amaka: "; SOC2.Text = "OLUSEESIN Tomide Daniel: "; SOC3.Text = "MAKINDE Afolabi Micheal: "; SOCN.Text = "Null Vote: ";
            TRE1.Text = "ADEOYE Abiola Ahmed: "; TRE2.Text = "OLAPADE Tolulope Cynthia: "; TRE3.Text = "SANUSI Temitayo Abiwo: "; TREN.Text = "Null Vote: ";
            AGS1.Text = "ADEOYE Adela Matawale: "; AGS2.Text = "AZIKIWE Amaka Joy: "; AGS3.Text = "BAKARE Zainab Tolulope: "; AGSN.Text = "Null Vote: ";
            WEL1.Text = "EZEIRU Chike Philip: "; WEL2.Text = "UBONG Uduak Harny: "; WEL3.Text = "MOHAMMED Kabiru: "; WELN.Text = "Null Vote: ";
            SD1.Text = "MOHAMMED Quadri: "; SD2.Text = "UBONG James Simon: "; SD3.Text = "KUKU Amina aka Amina: "; SDN.Text = "Null Vote: ";
            LIB1.Text = "EZIKEOHA Joy: "; LIB2.Text = "ADEWALE Mayowa Blessing: "; LIB3.Text = "AYO Bukunmi Zachary: "; LIBN.Text = "Null Vote: ";
            AL1.Text = "OGAYI Okechukwu Frank: "; AL2.Text = "ABIOLA Olusola aka Sola: "; AL3.Text = "ADEOYE Adesola: "; ALN.Text = "Null Vote: ";
            EDI1.Text = "FALAYI Esther: "; EDI2.Text = "IDOWU Olubunmi: "; EDI3.Text = "AJAYI Olufemi: "; EDIN.Text = "Null Vote: ";

            P01.Text = "CHINEKE Tobenna Chinonso: "; P02.Text = "ADEJUWON Omolara Sara: "; P03.Text = "AREO Ayodeji Adewale: "; P0N.Text = "Null Vote: ";
            VP01.Text = "ODILI Chigozie Onyinye: "; VP02.Text = "AKINDE Temitayo Similoluwa: "; VP03.Text = "AYOOLA Tomide Timothy: "; VP0N.Text = "Null Vote: ";
            GS01.Text = "BUSARI Babajide James: "; GS02.Text = "OLUSOLA Feyisayo Gabriel: "; GS03.Text = "ADEBIYI Ademola Jonathan: "; GS0N.Text = "Null Vote: ";
            FS01.Text = "AYOMIDE Bajomo Charles: "; FS02.Text = "EZE Tochukwu Grace: "; FS03.Text = "OKEKE Chimezie Marcel: "; FS0N.Text = "Null Vote: ";
            PRO01.Text = "ADAEZE Obed Lawrentia: "; PRO02.Text = "UBONG Amos Adanorisewo: "; PRO03.Text = "OLAPADE Tomide James: "; PRO0N.Text = "Null Vote: ";
            SOC01.Text = "EZE Chiugo Amaka: "; SOC02.Text = "OLUSEESIN Tomide Daniel: "; SOC03.Text = "MAKINDE Afolabi Micheal: "; SOC0N.Text = "Null Vote: ";
            TRE01.Text = "ADEOYE Abiola Ahmed: "; TRE02.Text = "OLAPADE Tolulope Cynthia: "; TRE03.Text = "SANUSI Temitayo Abiwo: "; TRE0N.Text = "Null Vote: ";
            AGS01.Text = "ADEOYE Adela Matawale: "; AGS02.Text = "AZIKIWE Amaka Joy: "; AGS03.Text = "BAKARE Zainab Tolulope: "; AGS0N.Text = "Null Vote: ";
            WEL01.Text = "EZEIRU Chike Philip: "; WEL02.Text = "UBONG Uduak Harny: "; WEL03.Text = "MOHAMMED Kabiru: "; WEL0N.Text = "Null Vote: ";
            SD01.Text = "MOHAMMED Quadri: "; SD02.Text = "UBONG James Simon: "; SD03.Text = "KUKU Amina aka Amina: "; SD0N.Text = "Null Vote: ";
            LIB01.Text = "EZIKEOHA Joy: "; LIB02.Text = "ADEWALE Mayowa Blessing: "; LIB03.Text = "AYO Bukunmi Zachary: "; LIB0N.Text = "Null Vote: ";
            AL01.Text = "OGAYI Okechukwu Frank: "; AL02.Text = "ABIOLA Olusola aka Sola: "; AL03.Text = "ADEOYE Adesola: "; AL0N.Text = "Null Vote: ";
            EDI01.Text = "FALAYI Esther: "; EDI02.Text = "IDOWU Olubunmi: "; EDI03.Text = "AJAYI Olufemi: "; EDI0N.Text = "Null Vote: ";


            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                con.Open();

                //check username and password
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Username = @Username AND Password=@Password", con);
                cmd.Parameters.AddWithValue("@Username", usernameBox.Text);
                cmd.Parameters.AddWithValue("@Password", Encrypt(passwordBox.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                //check email and password
                SqlCommand cmmd = new SqlCommand("SELECT * FROM Users WHERE Email = @email AND Password=@Password", con);
                cmmd.Parameters.AddWithValue("@email", usernameBox.Text);
                cmmd.Parameters.AddWithValue("@Password", Encrypt(passwordBox.Text));
                SqlDataAdapter dma = new SqlDataAdapter(cmmd);
                DataTable dmt = new DataTable();
                dma.Fill(dmt);

                if (dt.Rows.Count > 0 || dmt.Rows.Count > 0)
                {
                    logUsername.Visible = true;
                    logName.Visible = true;
                    logFaculty.Visible = true;
                    logMatric.Visible = true;
                    logDept.Visible = true;

                    //generate user datails
                    SqlCommand cmdu = new SqlCommand("SELECT Username FROM Users WHERE Username=@Username OR Email=@email", con);
                    cmdu.CommandType = CommandType.Text;
                    cmdu.Parameters.AddWithValue("@Username", usernameBox.Text);
                    cmdu.Parameters.AddWithValue("@email", usernameBox.Text);
                    String username = cmdu.ExecuteScalar().ToString();
                    logUsername.Text += username;
                    holdUsername.Text = username;

                    SqlCommand cmd1 = new SqlCommand("SELECT name FROM Users WHERE Username=@Username", con);
                    cmd1.CommandType = CommandType.Text;
                    cmd1.Parameters.AddWithValue("@Username", holdUsername.Text);
                    String name = cmd1.ExecuteScalar().ToString();
                    logName.Text += name;
                    holdName.Text = name;

                    SqlCommand cmd2 = new SqlCommand("SELECT Matric_no FROM Users WHERE Username=@Username", con);
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Parameters.AddWithValue("@Username", holdUsername.Text);
                    string matric = cmd2.ExecuteScalar().ToString();
                    logMatric.Text += matric;
                    holdMatric.Text = matric;

                    SqlCommand cmd3 = new SqlCommand("SELECT Faculty FROM Users WHERE Username=@Username", con);
                    cmd3.CommandType = CommandType.Text;
                    cmd3.Parameters.AddWithValue("@Username", holdUsername.Text);
                    string faculty = cmd3.ExecuteScalar().ToString();
                    logFaculty.Text += faculty;
                    holdFaculty.Text = faculty;

                    SqlCommand cmd31 = new SqlCommand("SELECT Department FROM Users WHERE Username=@Username", con);
                    cmd31.CommandType = CommandType.Text;
                    cmd31.Parameters.AddWithValue("@Username", holdUsername.Text);
                    string dept = cmd31.ExecuteScalar().ToString();
                    logDept.Text += dept;
                    holdDept.Text = dept;

                    SqlCommand cd = new SqlCommand("SELECT * FROM HaveVoted WHERE Username = @Username", con);
                    cd.Parameters.AddWithValue("@Username", holdUsername.Text);
                    cd.ExecuteNonQuery();
                    SqlDataAdapter da1 = new SqlDataAdapter(cd);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);

                    if (dt1.Rows.Count > 0)
                    {
                        votestatusLabel.Text = "VOTED";
                        tlabel.Visible = true;
                        Table1.Visible = true;
                        Table2.Visible = true;
                        String unString = holdUsername.Text;

                        //display voting status for each contestant
                        int ap1 = rs.show("P1", unString);
                        if (ap1 == 0) { P1.Text += "Not voted"; P1.Font.Bold = false; } else { P1.Text += "*VOTED*"; P1.Font.Bold = true; pi1.Visible = true; }
                        int ap2 = rs.show("P2", unString);
                        if (ap2 == 0) { P2.Text += "Not voted"; P2.Font.Bold = false; } else { P2.Text += "*VOTED*"; P2.Font.Bold = true; pi2.Visible = true; }
                        int ap3 = rs.show("P3", unString);
                        if (ap3 == 0) { P3.Text += "Not voted"; P3.Font.Bold = false; } else { P3.Text += "*VOTED*"; P3.Font.Bold = true; pi3.Visible = true; }
                        int apN = rs.show("PN", unString);
                        if (apN == 0) { PN.Text += "Not voted"; PN.Font.Bold = false; } else { PN.Text += "*VOTED*"; PN.Font.Bold = true; pi1.ImageUrl = "Others/NullVote.jpg"; pi1.Visible = true; }
                        int avp1 = rs.show("VP1", unString);
                        if (avp1 == 0) { VP1.Text += "Not voted"; VP1.Font.Bold = false; } else { VP1.Text += "*VOTED*"; VP1.Font.Bold = true; vpi1.Visible = true; }
                        int avp2 = rs.show("VP2", unString);
                        if (avp2 == 0) { VP2.Text += "Not voted"; VP2.Font.Bold = false; } else { VP2.Text += "*VOTED*"; VP2.Font.Bold = true; vpi2.Visible = true; }
                        int avp3 = rs.show("VP3", unString);
                        if (avp3 == 0) { VP3.Text += "Not voted"; VP3.Font.Bold = false; } else { VP3.Text += "*VOTED*"; VP3.Font.Bold = true; vpi3.Visible = true; }
                        int avpN = rs.show("VPN", unString);
                        if (avpN == 0) { VPN.Text += "Not voted"; VPN.Font.Bold = false; } else { VPN.Text += "*VOTED*"; VPN.Font.Bold = true; vpi1.ImageUrl = "Others/NullVote.jpg"; vpi1.Visible = true; }
                        int ags1 = rs.show("GS1", unString);
                        if (ags1 == 0) { GS1.Text += "Not voted"; GS1.Font.Bold = false; } else { GS1.Text += "*VOTED*"; GS1.Font.Bold = true; gsi1.Visible = true; }
                        int ags2 = rs.show("GS2", unString);
                        if (ags2 == 0) { GS2.Text += "Not voted"; GS2.Font.Bold = false; } else { GS2.Text += "*VOTED*"; GS2.Font.Bold = true; gsi2.Visible = true; }
                        int ags3 = rs.show("GS3", unString);
                        if (ags3 == 0) { GS3.Text += "Not voted"; GS3.Font.Bold = false; } else { GS3.Text += "*VOTED*"; GS3.Font.Bold = true; gsi3.Visible = true; }
                        int agsN = rs.show("GSN", unString);
                        if (agsN == 0) { GSN.Text += "Not voted"; GSN.Font.Bold = false; } else { GSN.Text += "*VOTED*"; GSN.Font.Bold = true; gsi1.ImageUrl = "Others/NullVote.jpg"; gsi1.Visible = true; }
                        int aFs1 = rs.show("FS1", unString);
                        if (aFs1 == 0) { FS1.Text += "Not voted"; FS1.Font.Bold = false; } else { FS1.Text += "*VOTED*"; FS1.Font.Bold = true; fsi1.Visible = true; }
                        int aFs2 = rs.show("FS2", unString);
                        if (aFs2 == 0) { FS2.Text += "Not voted"; FS2.Font.Bold = false; } else { FS2.Text += "*VOTED*"; FS2.Font.Bold = true; fsi2.Visible = true; }
                        int aFs3 = rs.show("FS3", unString);
                        if (aFs3 == 0) { FS3.Text += "Not voted"; FS3.Font.Bold = false; } else { FS3.Text += "*VOTED*"; FS3.Font.Bold = true; fsi3.Visible = true; }
                        int aFsN = rs.show("FSN", unString);
                        if (aFsN == 0) { FSN.Text += "Not voted"; FSN.Font.Bold = false; } else { FSN.Text += "*VOTED*"; FSN.Font.Bold = true; fsi1.ImageUrl = "Others/NullVote.jpg"; fsi1.Visible = true; }
                        int aPRO1 = rs.show("PR1", unString);
                        if (aPRO1 == 0) { PRO1.Text += "Not voted"; PRO1.Font.Bold = false; } else { PRO1.Text += "*VOTED*"; PRO1.Font.Bold = true; proi1.Visible = true; }
                        int aPRO2 = rs.show("PR2", unString);
                        if (aPRO2 == 0) { PRO2.Text += "Not voted"; PRO2.Font.Bold = false; } else { PRO2.Text += "*VOTED*"; PRO2.Font.Bold = true; proi2.Visible = true; }
                        int aPRO3 = rs.show("PR3", unString);
                        if (aPRO3 == 0) { PRO3.Text += "Not voted"; PRO3.Font.Bold = false; } else { PRO3.Text += "*VOTED*"; PRO3.Font.Bold = true; proi3.Visible = true; }
                        int aPRON = rs.show("PRN", unString);
                        if (aPRON == 0) { PRON.Text += "Not voted"; PRON.Font.Bold = false; } else { PRON.Text += "*VOTED*"; PRON.Font.Bold = true; proi1.ImageUrl = "Others/NullVote.jpg"; proi1.Visible = true; }
                        int aSOC1 = rs.show("SOC1", unString);
                        if (aSOC1 == 0) { SOC1.Text += "Not voted"; SOC1.Font.Bold = false; } else { SOC1.Text += "*VOTED*"; SOC1.Font.Bold = true; soci1.Visible = true; }
                        int aSOC2 = rs.show("SOC2", unString);
                        if (aSOC2 == 0) { SOC2.Text += "Not voted"; SOC2.Font.Bold = false; } else { SOC2.Text += "*VOTED*"; SOC2.Font.Bold = true; soci2.Visible = true; }
                        int aSOC3 = rs.show("SOC3", unString);
                        if (aSOC3 == 0) { SOC3.Text += "Not voted"; SOC3.Font.Bold = false; } else { SOC3.Text += "*VOTED*"; SOC3.Font.Bold = true; soci3.Visible = true; }
                        int aSOCN = rs.show("SOCN", unString);
                        if (aSOCN == 0) { SOCN.Text += "Not voted"; SOCN.Font.Bold = false; } else { SOCN.Text += "*VOTED*"; SOCN.Font.Bold = true; soci1.ImageUrl = "Others/NullVote.jpg"; soci1.Visible = true; }
                        int aTRE1 = rs.show("TRE1", unString);
                        if (aTRE1 == 0) { TRE1.Text += "Not voted"; TRE1.Font.Bold = false; } else { TRE1.Text += "*VOTED*"; TRE1.Font.Bold = true; trei1.Visible = true; }
                        int aTRE2 = rs.show("TRE2", unString);
                        if (aTRE2 == 0) { TRE2.Text += "Not voted"; TRE2.Font.Bold = false; } else { TRE2.Text += "*VOTED*"; TRE2.Font.Bold = true; trei2.Visible = true; }
                        int aTRE3 = rs.show("TRE3", unString);
                        if (aTRE3 == 0) { TRE3.Text += "Not voted"; TRE3.Font.Bold = false; } else { TRE3.Text += "*VOTED*"; TRE3.Font.Bold = true; trei3.Visible = true; }
                        int aTREN = rs.show("TREN", unString);
                        if (aTREN == 0) { TREN.Text += "Not voted"; TREN.Font.Bold = false; } else { TREN.Text += "*VOTED*"; TREN.Font.Bold = true; trei1.ImageUrl = "Others/NullVote.jpg"; trei1.Visible = true; }
                        int aAgs1 = rs.show("AGS1", unString);
                        if (aAgs1 == 0) { AGS1.Text += "Not voted"; AGS1.Font.Bold = false; } else { AGS1.Text += "*VOTED*"; AGS1.Font.Bold = true; agsi1.Visible = true; }
                        int aAgs2 = rs.show("AGS2", unString);
                        if (aAgs2 == 0) { AGS2.Text += "Not voted"; AGS2.Font.Bold = false; } else { AGS2.Text += "*VOTED*"; AGS2.Font.Bold = true; agsi2.Visible = true; }
                        int aAgs3 = rs.show("AGS3", unString);
                        if (aAgs3 == 0) { AGS3.Text += "Not voted"; AGS3.Font.Bold = false; } else { AGS3.Text += "*VOTED*"; AGS3.Font.Bold = true; agsi3.Visible = true; }
                        int aAgsN = rs.show("AGSN", unString);
                        if (aAgsN == 0) { AGSN.Text += "Not voted"; AGSN.Font.Bold = false; } else { AGSN.Text += "*VOTED*"; AGSN.Font.Bold = true; agsi1.ImageUrl = "Others/NullVote.jpg"; agsi1.Visible = true; }
                        int aWEL1 = rs.show("WEL1", unString);
                        if (aWEL1 == 0) { WEL1.Text += "Not voted"; WEL1.Font.Bold = false; } else { WEL1.Text += "*VOTED*"; WEL1.Font.Bold = true; weli1.Visible = true; }
                        int aWEL2 = rs.show("WEL2", unString);
                        if (aWEL2 == 0) { WEL2.Text += "Not voted"; WEL2.Font.Bold = false; } else { WEL2.Text += "*VOTED*"; WEL2.Font.Bold = true; weli2.Visible = true; }
                        int aWEL3 = rs.show("WEL3", unString);
                        if (aWEL3 == 0) { WEL3.Text += "Not voted"; WEL3.Font.Bold = false; } else { WEL3.Text += "*VOTED*"; WEL3.Font.Bold = true; weli3.Visible = true; }
                        int aWELN = rs.show("WELN", unString);
                        if (aWELN == 0) { WELN.Text += "Not voted"; WELN.Font.Bold = false; } else { WELN.Text += "*VOTED*"; WELN.Font.Bold = true; weli1.ImageUrl = "Others/NullVote.jpg"; weli1.Visible = true; }
                        int aSD1 = rs.show("SD1", unString);
                        if (aSD1 == 0) { SD1.Text += "Not voted"; SD1.Font.Bold = false; } else { SD1.Text += "*VOTED*"; SD1.Font.Bold = true; spoi1.Visible = true; }
                        int aSD2 = rs.show("SD2", unString);
                        if (aSD2 == 0) { SD2.Text += "Not voted"; SD2.Font.Bold = false; } else { SD2.Text += "*VOTED*"; SD2.Font.Bold = true; spoi2.Visible = true; }
                        int aSD3 = rs.show("SD3", unString);
                        if (aSD3 == 0) { SD3.Text += "Not voted"; SD3.Font.Bold = false; } else { SD3.Text += "*VOTED*"; SD3.Font.Bold = true; spoi3.Visible = true; }
                        int aSDN = rs.show("SDN", unString);
                        if (aSDN == 0) { SDN.Text += "Not voted"; SDN.Font.Bold = false; } else { SDN.Text += "*VOTED*"; SDN.Font.Bold = true; spoi1.ImageUrl = "Others/NullVote.jpg"; spoi1.Visible = true; }
                        int aLIB1 = rs.show("LIB1", unString);
                        if (aLIB1 == 0) { LIB1.Text += "Not voted"; LIB1.Font.Bold = false; } else { LIB1.Text += "*VOTED*"; LIB1.Font.Bold = true; libi1.Visible = true; }
                        int aLIB2 = rs.show("LIB2", unString);
                        if (aLIB2 == 0) { LIB2.Text += "Not voted"; LIB2.Font.Bold = false; } else { LIB2.Text += "*VOTED*"; LIB2.Font.Bold = true; libi2.Visible = true; }
                        int aLIB3 = rs.show("LIB3", unString);
                        if (aLIB3 == 0) { LIB3.Text += "Not voted"; LIB3.Font.Bold = false; } else { LIB3.Text += "*VOTED*"; LIB3.Font.Bold = true; libi3.Visible = true; }
                        int aLIBN = rs.show("LIBN", unString);
                        if (aLIBN == 0) { LIBN.Text += "Not voted"; LIBN.Font.Bold = false; } else { LIBN.Text += "*VOTED*"; LIBN.Font.Bold = true; libi1.ImageUrl = "Others/NullVote.jpg"; libi1.Visible = true; }
                        int aAL1 = rs.show("AL1", unString);
                        if (aAL1 == 0) { AL1.Text += "Not voted"; AL1.Font.Bold = false; } else { AL1.Text += "*VOTED*"; AL1.Font.Bold = true; ali1.Visible = true; }
                        int aAL2 = rs.show("AL2", unString);
                        if (aAL2 == 0) { AL2.Text += "Not voted"; AL2.Font.Bold = false; } else { AL2.Text += "*VOTED*"; AL2.Font.Bold = true; ali2.Visible = true; }
                        int aAL3 = rs.show("AL3", unString);
                        if (aAL3 == 0) { AL3.Text += "Not voted"; AL3.Font.Bold = false; } else { AL3.Text += "*VOTED*"; AL3.Font.Bold = true; ali3.Visible = true; }
                        int aALN = rs.show("ALN", unString);
                        if (aALN == 0) { ALN.Text += "Not voted"; ALN.Font.Bold = false; } else { ALN.Text += "*VOTED*"; ALN.Font.Bold = true; ali1.ImageUrl = "Others/NullVote.jpg"; ali1.Visible = true; }
                        int aEDI1 = rs.show("EDI1", unString);
                        if (aEDI1 == 0) { EDI1.Text += "Not voted"; EDI1.Font.Bold = false; } else { EDI1.Text += "*VOTED*"; EDI1.Font.Bold = true; edii1.Visible = true; }
                        int aEDI2 = rs.show("EDI2", unString);
                        if (aEDI2 == 0) { EDI2.Text += "Not voted"; EDI2.Font.Bold = false; } else { EDI2.Text += "*VOTED*"; EDI2.Font.Bold = true; edii2.Visible = true; }
                        int aEDI3 = rs.show("EDI3", unString);
                        if (aEDI3 == 0) { EDI3.Text += "Not voted"; EDI3.Font.Bold = false; } else { EDI3.Text += "*VOTED*"; EDI3.Font.Bold = true; edii3.Visible = true; }
                        int aEDIN = rs.show("EDIN", unString);
                        if (aEDIN == 0) { EDIN.Text += "Not voted"; EDIN.Font.Bold = false; } else { EDIN.Text += "*VOTED*"; EDIN.Font.Bold = true; edii1.ImageUrl = "Others/NullVote.jpg"; edii1.Visible = true; }
                    }
                    else
                    {
                        votestatusLabel.Text = "    NOT VOTED";
                        tlabel.Visible = true;
                        Table1.Visible = false;
                        Table2.Visible = true;
                    }

                    //display total votes for each contestant
                    P01.Text += rs.showTotal("P1").ToString();
                    P02.Text += rs.showTotal("P2").ToString();
                    P03.Text += rs.showTotal("P3").ToString();
                    P0N.Text += rs.showTotal("PN").ToString();
                    if (rs.showTotal("P3") > rs.showTotal("P2") && rs.showTotal("P3") > rs.showTotal("P1"))
                    { P03.Font.Bold = true; Image3.Visible = true; }
                    else if (rs.showTotal("P2") > rs.showTotal("P3") && rs.showTotal("P2") > rs.showTotal("P1"))
                    { P02.Font.Bold = true; Image2.Visible = true; }
                    else if (rs.showTotal("P1") > rs.showTotal("P3") && rs.showTotal("P1") > rs.showTotal("P2"))
                    { P01.Font.Bold = true; Image1.Visible = true; }
                    else Image4.Visible = true;
                    VP01.Text += rs.showTotal("VP1").ToString();
                    VP02.Text += rs.showTotal("VP2").ToString();
                    VP03.Text += rs.showTotal("VP3").ToString();
                    VP0N.Text += rs.showTotal("VPN").ToString();
                    if (rs.showTotal("VP3") > rs.showTotal("VP2") && rs.showTotal("VP3") > rs.showTotal("VP1"))
                    { VP03.Font.Bold = true; Image7.Visible = true; }
                    else if (rs.showTotal("VP2") > rs.showTotal("VP3") && rs.showTotal("VP2") > rs.showTotal("VP1"))
                    { VP02.Font.Bold = true; Image6.Visible = true; }
                    else if (rs.showTotal("VP1") > rs.showTotal("VP3") && rs.showTotal("VP1") > rs.showTotal("VP2"))
                    { VP01.Font.Bold = true; Image5.Visible = true; }
                    else Image8.Visible = true;
                    GS01.Text += rs.showTotal("GS1").ToString();
                    GS02.Text += rs.showTotal("GS2").ToString();
                    GS03.Text += rs.showTotal("GS3").ToString();
                    GS0N.Text += rs.showTotal("GSN").ToString();
                    if (rs.showTotal("GS3") > rs.showTotal("GS2") && rs.showTotal("GS3") > rs.showTotal("GS1"))
                    { GS03.Font.Bold = true; Image11.Visible = true; }
                    else if (rs.showTotal("GS2") > rs.showTotal("GS3") && rs.showTotal("GS2") > rs.showTotal("GS1"))
                    { GS02.Font.Bold = true; Image10.Visible = true; }
                    else if (rs.showTotal("GS1") > rs.showTotal("GS3") && rs.showTotal("GS1") > rs.showTotal("GS2"))
                    { GS01.Font.Bold = true; Image9.Visible = true; }
                    else Image12.Visible = true;
                    FS01.Text += rs.showTotal("FS1").ToString();
                    FS02.Text += rs.showTotal("FS2").ToString();
                    FS03.Text += rs.showTotal("FS3").ToString();
                    FS0N.Text += rs.showTotal("FSN").ToString();
                    if (rs.showTotal("FS3") > rs.showTotal("FS2") && rs.showTotal("FS3") > rs.showTotal("FS1"))
                    { FS03.Font.Bold = true; Image15.Visible = true; }
                    else if (rs.showTotal("FS2") > rs.showTotal("FS3") && rs.showTotal("FS2") > rs.showTotal("FS1"))
                    { FS02.Font.Bold = true; Image14.Visible = true; }
                    else if (rs.showTotal("FS1") > rs.showTotal("FS3") && rs.showTotal("FS1") > rs.showTotal("FS2"))
                    { FS01.Font.Bold = true; Image13.Visible = true; }
                    else Image16.Visible = true;
                    PRO01.Text += rs.showTotal("PR1").ToString();
                    PRO02.Text += rs.showTotal("PR2").ToString();
                    PRO03.Text += rs.showTotal("PR3").ToString();
                    PRO0N.Text += rs.showTotal("PRN").ToString();
                    if (rs.showTotal("PR3") > rs.showTotal("PR2") && rs.showTotal("PR3") > rs.showTotal("PR1"))
                    { PRO03.Font.Bold = true; Image19.Visible = true; }
                    else if (rs.showTotal("PR2") > rs.showTotal("PR3") && rs.showTotal("PR2") > rs.showTotal("PR1"))
                    { PRO02.Font.Bold = true; Image18.Visible = true; }
                    else if (rs.showTotal("PR1") > rs.showTotal("PR3") && rs.showTotal("PR1") > rs.showTotal("PR2"))
                    { PRO01.Font.Bold = true; Image17.Visible = true; }
                    else Image20.Visible = true;
                    SOC01.Text += rs.showTotal("SOC1").ToString();
                    SOC02.Text += rs.showTotal("SOC2").ToString();
                    SOC03.Text += rs.showTotal("SOC3").ToString();
                    SOC0N.Text += rs.showTotal("SOCN").ToString();
                    if (rs.showTotal("SOC3") > rs.showTotal("SOC2") && rs.showTotal("SOC3") > rs.showTotal("SOC1"))
                    { SOC03.Font.Bold = true; Image23.Visible = true; }
                    else if (rs.showTotal("SOC2") > rs.showTotal("SOC3") && rs.showTotal("SOC2") > rs.showTotal("SOC1"))
                    { SOC02.Font.Bold = true; Image22.Visible = true; }
                    else if (rs.showTotal("SOC1") > rs.showTotal("SOC3") && rs.showTotal("SOC1") > rs.showTotal("SOC2"))
                    { SOC01.Font.Bold = true; Image21.Visible = true; }
                    else Image24.Visible = true;
                    TRE01.Text += rs.showTotal("TRE1").ToString();
                    TRE02.Text += rs.showTotal("TRE2").ToString();
                    TRE03.Text += rs.showTotal("TRE3").ToString();
                    TRE0N.Text += rs.showTotal("TREN").ToString();
                    if (rs.showTotal("TRE3") > rs.showTotal("TRE2") && rs.showTotal("TRE3") > rs.showTotal("TRE1"))
                    { TRE03.Font.Bold = true; Image27.Visible = true; }
                    else if (rs.showTotal("TRE2") > rs.showTotal("TRE3") && rs.showTotal("TRE2") > rs.showTotal("TRE1"))
                    { TRE02.Font.Bold = true; Image26.Visible = true; }
                    else if (rs.showTotal("TRE1") > rs.showTotal("TRE3") && rs.showTotal("TRE1") > rs.showTotal("TRE2"))
                    { TRE01.Font.Bold = true; Image25.Visible = true; }
                    else Image28.Visible = true;
                    AGS01.Text += rs.showTotal("AGS1").ToString();
                    AGS02.Text += rs.showTotal("AGS2").ToString();
                    AGS03.Text += rs.showTotal("AGS3").ToString();
                    AGS0N.Text += rs.showTotal("AGSN").ToString();
                    if (rs.showTotal("AGS3") > rs.showTotal("AGS2") && rs.showTotal("AGS3") > rs.showTotal("AGS1"))
                    { AGS03.Font.Bold = true; Image31.Visible = true; }
                    else if (rs.showTotal("AGS2") > rs.showTotal("AGS3") && rs.showTotal("AGS2") > rs.showTotal("AGS1"))
                    { AGS02.Font.Bold = true; Image30.Visible = true; }
                    else if (rs.showTotal("AGS1") > rs.showTotal("AGS3") && rs.showTotal("AGS1") > rs.showTotal("AGS2"))
                    { AGS01.Font.Bold = true; Image29.Visible = true; }
                    else Image32.Visible = true;
                    WEL01.Text += rs.showTotal("WEL1").ToString();
                    WEL02.Text += rs.showTotal("WEL2").ToString();
                    WEL03.Text += rs.showTotal("WEL3").ToString();
                    WEL0N.Text += rs.showTotal("WELN").ToString();
                    if (rs.showTotal("WEL3") > rs.showTotal("WEL2") && rs.showTotal("WEL3") > rs.showTotal("WEL1"))
                    { WEL03.Font.Bold = true; Image35.Visible = true; }
                    else if (rs.showTotal("WEL2") > rs.showTotal("WEL3") && rs.showTotal("WEL2") > rs.showTotal("WEL1"))
                    { WEL02.Font.Bold = true; Image34.Visible = true; }
                    else if (rs.showTotal("WEL1") > rs.showTotal("WEL3") && rs.showTotal("WEL1") > rs.showTotal("WEL2"))
                    { WEL01.Font.Bold = true; Image33.Visible = true; }
                    else Image36.Visible = true;
                    SD01.Text += rs.showTotal("SD1").ToString();
                    SD02.Text += rs.showTotal("SD2").ToString();
                    SD03.Text += rs.showTotal("SD3").ToString();
                    SD0N.Text += rs.showTotal("SDN").ToString();
                    if (rs.showTotal("SD3") > rs.showTotal("SD2") && rs.showTotal("SD3") > rs.showTotal("SD1"))
                    { SD03.Font.Bold = true; Image39.Visible = true; }
                    else if (rs.showTotal("SD2") > rs.showTotal("SD3") && rs.showTotal("SD2") > rs.showTotal("SD1"))
                    { SD02.Font.Bold = true; Image38.Visible = true; }
                    else if (rs.showTotal("SD1") > rs.showTotal("SD3") && rs.showTotal("SD1") > rs.showTotal("SD2"))
                    { SD01.Font.Bold = true; Image37.Visible = true; }
                    else Image40.Visible = true;
                    LIB01.Text += rs.showTotal("LIB1").ToString();
                    LIB02.Text += rs.showTotal("LIB2").ToString();
                    LIB03.Text += rs.showTotal("LIB3").ToString();
                    LIB0N.Text += rs.showTotal("LIBN").ToString();
                    if (rs.showTotal("LIB3") > rs.showTotal("LIB2") && rs.showTotal("LIB3") > rs.showTotal("LIB1"))
                    { LIB03.Font.Bold = true; Image43.Visible = true; }
                    else if (rs.showTotal("LIB2") > rs.showTotal("LIB3") && rs.showTotal("LIB2") > rs.showTotal("LIB1"))
                    { LIB02.Font.Bold = true; Image42.Visible = true; }
                    else if (rs.showTotal("LIB1") > rs.showTotal("LIB3") && rs.showTotal("LIB1") > rs.showTotal("LIB2"))
                    { LIB01.Font.Bold = true; Image41.Visible = true; }
                    else Image44.Visible = true;
                    AL01.Text += rs.showTotal("AL1").ToString();
                    AL02.Text += rs.showTotal("AL2").ToString();
                    AL03.Text += rs.showTotal("AL3").ToString();
                    AL0N.Text += rs.showTotal("ALN").ToString();
                    if (rs.showTotal("AL3") > rs.showTotal("AL2") && rs.showTotal("AL3") > rs.showTotal("AL1"))
                    { AL03.Font.Bold = true; Image47.Visible = true; }
                    else if (rs.showTotal("AL2") > rs.showTotal("AL3") && rs.showTotal("AL2") > rs.showTotal("AL1"))
                    { AL02.Font.Bold = true; Image46.Visible = true; }
                    else if (rs.showTotal("AL1") > rs.showTotal("AL3") && rs.showTotal("AL1") > rs.showTotal("AL2"))
                    { AL01.Font.Bold = true; Image45.Visible = true; }
                    else Image48.Visible = true;
                    EDI01.Text += rs.showTotal("EDI1").ToString();
                    EDI02.Text += rs.showTotal("EDI2").ToString();
                    EDI03.Text += rs.showTotal("EDI3").ToString();
                    EDI0N.Text += rs.showTotal("EDIN").ToString();
                    if (rs.showTotal("EDI3") > rs.showTotal("EDI2") && rs.showTotal("EDI3") > rs.showTotal("EDI1"))
                    { EDI03.Font.Bold = true; Image51.Visible = true; }
                    else if (rs.showTotal("EDI2") > rs.showTotal("EDI3") && rs.showTotal("EDI2") > rs.showTotal("EDI1"))
                    { EDI02.Font.Bold = true; Image50.Visible = true; }
                    else if (rs.showTotal("EDI1") > rs.showTotal("EDI3") && rs.showTotal("EDI1") > rs.showTotal("EDI2"))
                    { EDI01.Font.Bold = true; Image49.Visible = true; }
                    else Image52.Visible = true;
                }

                else
                {
                    if (passwordBox.Text.ToUpper() == "admin101".ToUpper())
                    {
                        votestatusLabel.Text = "    You are an Administrator";
                        tlabel.Visible = true;
                        Table1.Visible = false;
                        Table2.Visible = true;
                        logUsername.Visible = true;
                        logName.Visible = true;
                        logUsername.Text += usernameBox.Text;
                        logName.Text += "Administrator";
                        logMatric.Visible = false;
                        logFaculty.Visible = false;
                        logDept.Visible = false;

                        //show total votes for each contestant
                        P01.Text += rs.showTotal("P1").ToString();
                        P02.Text += rs.showTotal("P2").ToString();
                        P03.Text += rs.showTotal("P3").ToString();
                        P0N.Text += rs.showTotal("PN").ToString();
                        if (rs.showTotal("P3") > rs.showTotal("P2") && rs.showTotal("P3") > rs.showTotal("P1"))
                        { P03.Font.Bold = true; Image3.Visible = true; }
                        else if (rs.showTotal("P2") > rs.showTotal("P3") && rs.showTotal("P2") > rs.showTotal("P1"))
                        { P02.Font.Bold = true; Image2.Visible = true; }
                        else if (rs.showTotal("P1") > rs.showTotal("P3") && rs.showTotal("P1") > rs.showTotal("P2"))
                        { P01.Font.Bold = true; Image1.Visible = true; }
                        else Image4.Visible = true;
                        VP01.Text += rs.showTotal("VP1").ToString();
                        VP02.Text += rs.showTotal("VP2").ToString();
                        VP03.Text += rs.showTotal("VP3").ToString();
                        VP0N.Text += rs.showTotal("VPN").ToString();
                        if (rs.showTotal("VP3") > rs.showTotal("VP2") && rs.showTotal("VP3") > rs.showTotal("VP1"))
                        { VP03.Font.Bold = true; Image7.Visible = true; }
                        else if (rs.showTotal("VP2") > rs.showTotal("VP3") && rs.showTotal("VP2") > rs.showTotal("VP1"))
                        { VP02.Font.Bold = true; Image6.Visible = true; }
                        else if (rs.showTotal("VP1") > rs.showTotal("VP3") && rs.showTotal("VP1") > rs.showTotal("VP2"))
                        { VP01.Font.Bold = true; Image5.Visible = true; }
                        else Image8.Visible = true;
                        GS01.Text += rs.showTotal("GS1").ToString();
                        GS02.Text += rs.showTotal("GS2").ToString();
                        GS03.Text += rs.showTotal("GS3").ToString();
                        GS0N.Text += rs.showTotal("GSN").ToString();
                        if (rs.showTotal("GS3") > rs.showTotal("GS2") && rs.showTotal("GS3") > rs.showTotal("GS1"))
                        { GS03.Font.Bold = true; Image11.Visible = true; }
                        else if (rs.showTotal("GS2") > rs.showTotal("GS3") && rs.showTotal("GS2") > rs.showTotal("GS1"))
                        { GS02.Font.Bold = true; Image10.Visible = true; }
                        else if (rs.showTotal("GS1") > rs.showTotal("GS3") && rs.showTotal("GS1") > rs.showTotal("GS2"))
                        { GS01.Font.Bold = true; Image9.Visible = true; }
                        else Image12.Visible = true;
                        FS01.Text += rs.showTotal("FS1").ToString();
                        FS02.Text += rs.showTotal("FS2").ToString();
                        FS03.Text += rs.showTotal("FS3").ToString();
                        FS0N.Text += rs.showTotal("FSN").ToString();
                        if (rs.showTotal("FS3") > rs.showTotal("FS2") && rs.showTotal("FS3") > rs.showTotal("FS1"))
                        { FS03.Font.Bold = true; Image15.Visible = true; }
                        else if (rs.showTotal("FS2") > rs.showTotal("FS3") && rs.showTotal("FS2") > rs.showTotal("FS1"))
                        { FS02.Font.Bold = true; Image14.Visible = true; }
                        else if (rs.showTotal("FS1") > rs.showTotal("FS3") && rs.showTotal("FS1") > rs.showTotal("FS2"))
                        { FS01.Font.Bold = true; Image13.Visible = true; }
                        else Image16.Visible = true;
                        PRO01.Text += rs.showTotal("PR1").ToString();
                        PRO02.Text += rs.showTotal("PR2").ToString();
                        PRO03.Text += rs.showTotal("PR3").ToString();
                        PRO0N.Text += rs.showTotal("PRN").ToString();
                        if (rs.showTotal("PR3") > rs.showTotal("PR2") && rs.showTotal("PR3") > rs.showTotal("PR1"))
                        { PRO03.Font.Bold = true; Image19.Visible = true; }
                        else if (rs.showTotal("PR2") > rs.showTotal("PR3") && rs.showTotal("PR2") > rs.showTotal("PR1"))
                        { PRO02.Font.Bold = true; Image18.Visible = true; }
                        else if (rs.showTotal("PR1") > rs.showTotal("PR3") && rs.showTotal("PR1") > rs.showTotal("PR2"))
                        { PRO01.Font.Bold = true; Image17.Visible = true; }
                        else Image20.Visible = true;
                        SOC01.Text += rs.showTotal("SOC1").ToString();
                        SOC02.Text += rs.showTotal("SOC2").ToString();
                        SOC03.Text += rs.showTotal("SOC3").ToString();
                        SOC0N.Text += rs.showTotal("SOCN").ToString();
                        if (rs.showTotal("SOC3") > rs.showTotal("SOC2") && rs.showTotal("SOC3") > rs.showTotal("SOC1"))
                        { SOC03.Font.Bold = true; Image23.Visible = true; }
                        else if (rs.showTotal("SOC2") > rs.showTotal("SOC3") && rs.showTotal("SOC2") > rs.showTotal("SOC1"))
                        { SOC02.Font.Bold = true; Image22.Visible = true; }
                        else if (rs.showTotal("SOC1") > rs.showTotal("SOC3") && rs.showTotal("SOC1") > rs.showTotal("SOC2"))
                        { SOC01.Font.Bold = true; Image21.Visible = true; }
                        else Image24.Visible = true;
                        TRE01.Text += rs.showTotal("TRE1").ToString();
                        TRE02.Text += rs.showTotal("TRE2").ToString();
                        TRE03.Text += rs.showTotal("TRE3").ToString();
                        TRE0N.Text += rs.showTotal("TREN").ToString();
                        if (rs.showTotal("TRE3") > rs.showTotal("TRE2") && rs.showTotal("TRE3") > rs.showTotal("TRE1"))
                        { TRE03.Font.Bold = true; Image27.Visible = true; }
                        else if (rs.showTotal("TRE2") > rs.showTotal("TRE3") && rs.showTotal("TRE2") > rs.showTotal("TRE1"))
                        { TRE02.Font.Bold = true; Image26.Visible = true; }
                        else if (rs.showTotal("TRE1") > rs.showTotal("TRE3") && rs.showTotal("TRE1") > rs.showTotal("TRE2"))
                        { TRE01.Font.Bold = true; Image25.Visible = true; }
                        else Image28.Visible = true;
                        AGS01.Text += rs.showTotal("AGS1").ToString();
                        AGS02.Text += rs.showTotal("AGS2").ToString();
                        AGS03.Text += rs.showTotal("AGS3").ToString();
                        AGS0N.Text += rs.showTotal("AGSN").ToString();
                        if (rs.showTotal("AGS3") > rs.showTotal("AGS2") && rs.showTotal("AGS3") > rs.showTotal("AGS1"))
                        { AGS03.Font.Bold = true; Image31.Visible = true; }
                        else if (rs.showTotal("AGS2") > rs.showTotal("AGS3") && rs.showTotal("AGS2") > rs.showTotal("AGS1"))
                        { AGS02.Font.Bold = true; Image30.Visible = true; }
                        else if (rs.showTotal("AGS1") > rs.showTotal("AGS3") && rs.showTotal("AGS1") > rs.showTotal("AGS2"))
                        { AGS01.Font.Bold = true; Image29.Visible = true; }
                        else Image32.Visible = true;
                        WEL01.Text += rs.showTotal("WEL1").ToString();
                        WEL02.Text += rs.showTotal("WEL2").ToString();
                        WEL03.Text += rs.showTotal("WEL3").ToString();
                        WEL0N.Text += rs.showTotal("WELN").ToString();
                        if (rs.showTotal("WEL3") > rs.showTotal("WEL2") && rs.showTotal("WEL3") > rs.showTotal("WEL1"))
                        { WEL03.Font.Bold = true; Image35.Visible = true; }
                        else if (rs.showTotal("WEL2") > rs.showTotal("WEL3") && rs.showTotal("WEL2") > rs.showTotal("WEL1"))
                        { WEL02.Font.Bold = true; Image34.Visible = true; }
                        else if (rs.showTotal("WEL1") > rs.showTotal("WEL3") && rs.showTotal("WEL1") > rs.showTotal("WEL2"))
                        { WEL01.Font.Bold = true; Image33.Visible = true; }
                        else Image36.Visible = true;
                        SD01.Text += rs.showTotal("SD1").ToString();
                        SD02.Text += rs.showTotal("SD2").ToString();
                        SD03.Text += rs.showTotal("SD3").ToString();
                        SD0N.Text += rs.showTotal("SDN").ToString();
                        if (rs.showTotal("SD3") > rs.showTotal("SD2") && rs.showTotal("SD3") > rs.showTotal("SD1"))
                        { SD03.Font.Bold = true; Image39.Visible = true; }
                        else if (rs.showTotal("SD2") > rs.showTotal("SD3") && rs.showTotal("SD2") > rs.showTotal("SD1"))
                        { SD02.Font.Bold = true; Image38.Visible = true; }
                        else if (rs.showTotal("SD1") > rs.showTotal("SD3") && rs.showTotal("SD1") > rs.showTotal("SD2"))
                        { SD01.Font.Bold = true; Image37.Visible = true; }
                        else Image40.Visible = true;
                        LIB01.Text += rs.showTotal("LIB1").ToString();
                        LIB02.Text += rs.showTotal("LIB2").ToString();
                        LIB03.Text += rs.showTotal("LIB3").ToString();
                        LIB0N.Text += rs.showTotal("LIBN").ToString();
                        if (rs.showTotal("LIB3") > rs.showTotal("LIB2") && rs.showTotal("LIB3") > rs.showTotal("LIB1"))
                        { LIB03.Font.Bold = true; Image43.Visible = true; }
                        else if (rs.showTotal("LIB2") > rs.showTotal("LIB3") && rs.showTotal("LIB2") > rs.showTotal("LIB1"))
                        { LIB02.Font.Bold = true; Image42.Visible = true; }
                        else if (rs.showTotal("LIB1") > rs.showTotal("LIB3") && rs.showTotal("LIB1") > rs.showTotal("LIB2"))
                        { LIB01.Font.Bold = true; Image41.Visible = true; }
                        else Image44.Visible = true;
                        AL01.Text += rs.showTotal("AL1").ToString();
                        AL02.Text += rs.showTotal("AL2").ToString();
                        AL03.Text += rs.showTotal("AL3").ToString();
                        AL0N.Text += rs.showTotal("ALN").ToString();
                        if (rs.showTotal("AL3") > rs.showTotal("AL2") && rs.showTotal("AL3") > rs.showTotal("AL1"))
                        { AL03.Font.Bold = true; Image47.Visible = true; }
                        else if (rs.showTotal("AL2") > rs.showTotal("AL3") && rs.showTotal("AL2") > rs.showTotal("AL1"))
                        { AL02.Font.Bold = true; Image46.Visible = true; }
                        else if (rs.showTotal("AL1") > rs.showTotal("AL3") && rs.showTotal("AL1") > rs.showTotal("AL2"))
                        { AL01.Font.Bold = true; Image45.Visible = true; }
                        else Image48.Visible = true;
                        EDI01.Text += rs.showTotal("EDI1").ToString();
                        EDI02.Text += rs.showTotal("EDI2").ToString();
                        EDI03.Text += rs.showTotal("EDI3").ToString();
                        EDI0N.Text += rs.showTotal("EDIN").ToString();
                        if (rs.showTotal("EDI3") > rs.showTotal("EDI2") && rs.showTotal("EDI3") > rs.showTotal("EDI1"))
                        { EDI03.Font.Bold = true; Image51.Visible = true; }
                        else if (rs.showTotal("EDI2") > rs.showTotal("EDI3") && rs.showTotal("EDI2") > rs.showTotal("EDI1"))
                        { EDI02.Font.Bold = true; Image50.Visible = true; }
                        else if (rs.showTotal("EDI1") > rs.showTotal("EDI3") && rs.showTotal("EDI1") > rs.showTotal("EDI2"))
                        { EDI01.Font.Bold = true; Image49.Visible = true; }
                        else Image52.Visible = true;
                    }
                    else { logLabel.Visible = true; logLabel.Text = "Invalid Username and Password Combination"; tlabel.Visible = false; }
                }
            }
        }

        protected void visClick(object sender, EventArgs e)
        {
            logUsername.Text = "Username: ";
            logName.Text = "Name: ";
            logMatric.Text = "Matric. Number: ";
            logDept.Text = "Department: ";
            logFaculty.Text = "Faculty: ";

            P1.Text = "CHINEKE Tobenna Chinonso: "; P2.Text = "ADEJUWON Omolara Sara: "; P3.Text = "AREO Ayodeji Adewale: "; PN.Text = "Null Vote: ";
            VP1.Text = "ODILI Chigozie Onyinye: "; VP2.Text = "AKINDE Temitayo Similoluwa: "; VP3.Text = "AYOOLA Tomide Timothy: "; VPN.Text = "Null Vote: ";
            GS1.Text = "BUSARI Babajide James: "; GS2.Text = "OLUSOLA Feyisayo Gabriel: "; GS3.Text = "ADEBIYI Ademola Jonathan: "; GSN.Text = "Null Vote: ";
            FS1.Text = "AYOMIDE Bajomo Charles: "; FS2.Text = "EZE Tochukwu Grace: "; FS3.Text = "OKEKE Chimezie Marcel: "; FSN.Text = "Null Vote: ";
            PRO1.Text = "ADAEZE Obed Lawrentia: "; PRO2.Text = "UBONG Amos Adanorisewo: "; PRO3.Text = "OLAPADE Tomide James: "; PRON.Text = "Null Vote: ";
            SOC1.Text = "EZE Chiugo Amaka: "; SOC2.Text = "OLUSEESIN Tomide Daniel: "; SOC3.Text = "MAKINDE Afolabi Micheal: "; SOCN.Text = "Null Vote: ";
            TRE1.Text = "ADEOYE Abiola Ahmed: "; TRE2.Text = "OLAPADE Tolulope Cynthia: "; TRE3.Text = "SANUSI Temitayo Abiwo: "; TREN.Text = "Null Vote: ";
            AGS1.Text = "ADEOYE Adela Matawale: "; AGS2.Text = "AZIKIWE Amaka Joy: "; AGS3.Text = "BAKARE Zainab Tolulope: "; AGSN.Text = "Null Vote: ";
            WEL1.Text = "EZEIRU Chike Philip: "; WEL2.Text = "UBONG Uduak Harny: "; WEL3.Text = "MOHAMMED Kabiru: "; WELN.Text = "Null Vote: ";
            SD1.Text = "MOHAMMED Quadri: "; SD2.Text = "UBONG James Simon: "; SD3.Text = "KUKU Amina aka Amina: "; SDN.Text = "Null Vote: ";
            LIB1.Text = "EZIKEOHA Joy: "; LIB2.Text = "ADEWALE Mayowa Blessing: "; LIB3.Text = "AYO Bukunmi Zachary: "; LIBN.Text = "Null Vote: ";
            AL1.Text = "OGAYI Okechukwu Frank: "; AL2.Text = "ABIOLA Olusola aka Sola: "; AL3.Text = "ADEOYE Adesola: "; ALN.Text = "Null Vote: ";
            EDI1.Text = "FALAYI Esther: "; EDI2.Text = "IDOWU Olubunmi: "; EDI3.Text = "AJAYI Olufemi: "; EDIN.Text = "Null Vote: ";

            P01.Text = "CHINEKE Tobenna Chinonso: "; P02.Text = "ADEJUWON Omolara Sara: "; P03.Text = "AREO Ayodeji Adewale: "; P0N.Text = "Null Vote: ";
            VP01.Text = "ODILI Chigozie Onyinye: "; VP02.Text = "AKINDE Temitayo Similoluwa: "; VP03.Text = "AYOOLA Tomide Timothy: "; VP0N.Text = "Null Vote: ";
            GS01.Text = "BUSARI Babajide James: "; GS02.Text = "OLUSOLA Feyisayo Gabriel: "; GS03.Text = "ADEBIYI Ademola Jonathan: "; GS0N.Text = "Null Vote: ";
            FS01.Text = "AYOMIDE Bajomo Charles: "; FS02.Text = "EZE Tochukwu Grace: "; FS03.Text = "OKEKE Chimezie Marcel: "; FS0N.Text = "Null Vote: ";
            PRO01.Text = "ADAEZE Obed Lawrentia: "; PRO02.Text = "UBONG Amos Adanorisewo: "; PRO03.Text = "OLAPADE Tomide James: "; PRO0N.Text = "Null Vote: ";
            SOC01.Text = "EZE Chiugo Amaka: "; SOC02.Text = "OLUSEESIN Tomide Daniel: "; SOC03.Text = "MAKINDE Afolabi Micheal: "; SOC0N.Text = "Null Vote: ";
            TRE01.Text = "ADEOYE Abiola Ahmed: "; TRE02.Text = "OLAPADE Tolulope Cynthia: "; TRE03.Text = "SANUSI Temitayo Abiwo: "; TRE0N.Text = "Null Vote: ";
            AGS01.Text = "ADEOYE Adela Matawale: "; AGS02.Text = "AZIKIWE Amaka Joy: "; AGS03.Text = "BAKARE Zainab Tolulope: "; AGS0N.Text = "Null Vote: ";
            WEL01.Text = "EZEIRU Chike Philip: "; WEL02.Text = "UBONG Uduak Harny: "; WEL03.Text = "MOHAMMED Kabiru: "; WEL0N.Text = "Null Vote: ";
            SD01.Text = "MOHAMMED Quadri: "; SD02.Text = "UBONG James Simon: "; SD03.Text = "KUKU Amina aka Amina: "; SD0N.Text = "Null Vote: ";
            LIB01.Text = "EZIKEOHA Joy: "; LIB02.Text = "ADEWALE Mayowa Blessing: "; LIB03.Text = "AYO Bukunmi Zachary: "; LIB0N.Text = "Null Vote: ";
            AL01.Text = "OGAYI Okechukwu Frank: "; AL02.Text = "ABIOLA Olusola aka Sola: "; AL03.Text = "ADEOYE Adesola: "; AL0N.Text = "Null Vote: ";
            EDI01.Text = "FALAYI Esther: "; EDI02.Text = "IDOWU Olubunmi: "; EDI03.Text = "AJAYI Olufemi: "; EDI0N.Text = "Null Vote: ";

            votestatusLabel.Text = "    You cannot vote";
            tlabel.Visible = true;
            Table1.Visible = false;
            Table2.Visible = true;
            logName.Font.Bold = true;
            logName.Visible = true;
            logMatric.Visible = true;
            logName.Text += "Visitor";
            logUsername.Visible=false;
            logMatric.Text += "You are a visitor";
            logFaculty.Visible = false;
            logDept.Visible = false;

            //show total votes for each contestant
            P01.Text += rs.showTotal("P1").ToString();
            P02.Text += rs.showTotal("P2").ToString();
            P03.Text += rs.showTotal("P3").ToString();
            P0N.Text += rs.showTotal("PN").ToString();
            if (rs.showTotal("P3") > rs.showTotal("P2") && rs.showTotal("P3") > rs.showTotal("P1"))
            { P03.Font.Bold = true; Image3.Visible = true; }
            else if (rs.showTotal("P2") > rs.showTotal("P3") && rs.showTotal("P2") > rs.showTotal("P1"))
            { P02.Font.Bold = true; Image2.Visible = true; }
            else if (rs.showTotal("P1") > rs.showTotal("P3") && rs.showTotal("P1") > rs.showTotal("P2"))
            { P01.Font.Bold = true; Image1.Visible = true; }
            else Image4.Visible = true;
            VP01.Text += rs.showTotal("VP1").ToString();
            VP02.Text += rs.showTotal("VP2").ToString();
            VP03.Text += rs.showTotal("VP3").ToString();
            VP0N.Text += rs.showTotal("VPN").ToString();
            if (rs.showTotal("VP3") > rs.showTotal("VP2") && rs.showTotal("VP3") > rs.showTotal("VP1"))
            { VP03.Font.Bold = true; Image7.Visible = true; }
            else if (rs.showTotal("VP2") > rs.showTotal("VP3") && rs.showTotal("VP2") > rs.showTotal("VP1"))
            { VP02.Font.Bold = true; Image6.Visible = true; }
            else if (rs.showTotal("VP1") > rs.showTotal("VP3") && rs.showTotal("VP1") > rs.showTotal("VP2"))
            { VP01.Font.Bold = true; Image5.Visible = true; }
            else Image8.Visible = true;
            GS01.Text += rs.showTotal("GS1").ToString();
            GS02.Text += rs.showTotal("GS2").ToString();
            GS03.Text += rs.showTotal("GS3").ToString();
            GS0N.Text += rs.showTotal("GSN").ToString();
            if (rs.showTotal("GS3") > rs.showTotal("GS2") && rs.showTotal("GS3") > rs.showTotal("GS1"))
            { GS03.Font.Bold = true; Image11.Visible = true; }
            else if (rs.showTotal("GS2") > rs.showTotal("GS3") && rs.showTotal("GS2") > rs.showTotal("GS1"))
            { GS02.Font.Bold = true; Image10.Visible = true; }
            else if (rs.showTotal("GS1") > rs.showTotal("GS3") && rs.showTotal("GS1") > rs.showTotal("GS2"))
            { GS01.Font.Bold = true; Image9.Visible = true; }
            else Image12.Visible = true;
            FS01.Text += rs.showTotal("FS1").ToString();
            FS02.Text += rs.showTotal("FS2").ToString();
            FS03.Text += rs.showTotal("FS3").ToString();
            FS0N.Text += rs.showTotal("FSN").ToString();
            if (rs.showTotal("FS3") > rs.showTotal("FS2") && rs.showTotal("FS3") > rs.showTotal("FS1"))
            { FS03.Font.Bold = true; Image15.Visible = true; }
            else if (rs.showTotal("FS2") > rs.showTotal("FS3") && rs.showTotal("FS2") > rs.showTotal("FS1"))
            { FS02.Font.Bold = true; Image14.Visible = true; }
            else if (rs.showTotal("FS1") > rs.showTotal("FS3") && rs.showTotal("FS1") > rs.showTotal("FS2"))
            { FS01.Font.Bold = true; Image13.Visible = true; }
            else Image16.Visible = true;
            PRO01.Text += rs.showTotal("PR1").ToString();
            PRO02.Text += rs.showTotal("PR2").ToString();
            PRO03.Text += rs.showTotal("PR3").ToString();
            PRO0N.Text += rs.showTotal("PRN").ToString();
            if (rs.showTotal("PR3") > rs.showTotal("PR2") && rs.showTotal("PR3") > rs.showTotal("PR1"))
            { PRO03.Font.Bold = true; Image19.Visible = true; }
            else if (rs.showTotal("PR2") > rs.showTotal("PR3") && rs.showTotal("PR2") > rs.showTotal("PR1"))
            { PRO02.Font.Bold = true; Image18.Visible = true; }
            else if (rs.showTotal("PR1") > rs.showTotal("PR3") && rs.showTotal("PR1") > rs.showTotal("PR2"))
            { PRO01.Font.Bold = true; Image17.Visible = true; }
            else Image20.Visible = true;
            SOC01.Text += rs.showTotal("SOC1").ToString();
            SOC02.Text += rs.showTotal("SOC2").ToString();
            SOC03.Text += rs.showTotal("SOC3").ToString();
            SOC0N.Text += rs.showTotal("SOCN").ToString();
            if (rs.showTotal("SOC3") > rs.showTotal("SOC2") && rs.showTotal("SOC3") > rs.showTotal("SOC1"))
            { SOC03.Font.Bold = true; Image23.Visible = true; }
            else if (rs.showTotal("SOC2") > rs.showTotal("SOC3") && rs.showTotal("SOC2") > rs.showTotal("SOC1"))
            { SOC02.Font.Bold = true; Image22.Visible = true; }
            else if (rs.showTotal("SOC1") > rs.showTotal("SOC3") && rs.showTotal("SOC1") > rs.showTotal("SOC2"))
            { SOC01.Font.Bold = true; Image21.Visible = true; }
            else Image24.Visible = true;
            TRE01.Text += rs.showTotal("TRE1").ToString();
            TRE02.Text += rs.showTotal("TRE2").ToString();
            TRE03.Text += rs.showTotal("TRE3").ToString();
            TRE0N.Text += rs.showTotal("TREN").ToString();
            if (rs.showTotal("TRE3") > rs.showTotal("TRE2") && rs.showTotal("TRE3") > rs.showTotal("TRE1"))
            { TRE03.Font.Bold = true; Image27.Visible = true; }
            else if (rs.showTotal("TRE2") > rs.showTotal("TRE3") && rs.showTotal("TRE2") > rs.showTotal("TRE1"))
            { TRE02.Font.Bold = true; Image26.Visible = true; }
            else if (rs.showTotal("TRE1") > rs.showTotal("TRE3") && rs.showTotal("TRE1") > rs.showTotal("TRE2"))
            { TRE01.Font.Bold = true; Image25.Visible = true; }
            else Image28.Visible = true;
            AGS01.Text += rs.showTotal("AGS1").ToString();
            AGS02.Text += rs.showTotal("AGS2").ToString();
            AGS03.Text += rs.showTotal("AGS3").ToString();
            AGS0N.Text += rs.showTotal("AGSN").ToString();
            if (rs.showTotal("AGS3") > rs.showTotal("AGS2") && rs.showTotal("AGS3") > rs.showTotal("AGS1"))
            { AGS03.Font.Bold = true; Image31.Visible = true; }
            else if (rs.showTotal("AGS2") > rs.showTotal("AGS3") && rs.showTotal("AGS2") > rs.showTotal("AGS1"))
            { AGS02.Font.Bold = true; Image30.Visible = true; }
            else if (rs.showTotal("AGS1") > rs.showTotal("AGS3") && rs.showTotal("AGS1") > rs.showTotal("AGS2"))
            { AGS01.Font.Bold = true; Image29.Visible = true; }
            else Image32.Visible = true;
            WEL01.Text += rs.showTotal("WEL1").ToString();
            WEL02.Text += rs.showTotal("WEL2").ToString();
            WEL03.Text += rs.showTotal("WEL3").ToString();
            WEL0N.Text += rs.showTotal("WELN").ToString();
            if (rs.showTotal("WEL3") > rs.showTotal("WEL2") && rs.showTotal("WEL3") > rs.showTotal("WEL1"))
            { WEL03.Font.Bold = true; Image35.Visible = true; }
            else if (rs.showTotal("WEL2") > rs.showTotal("WEL3") && rs.showTotal("WEL2") > rs.showTotal("WEL1"))
            { WEL02.Font.Bold = true; Image34.Visible = true; }
            else if (rs.showTotal("WEL1") > rs.showTotal("WEL3") && rs.showTotal("WEL1") > rs.showTotal("WEL2"))
            { WEL01.Font.Bold = true; Image33.Visible = true; }
            else Image36.Visible = true;
            SD01.Text += rs.showTotal("SD1").ToString();
            SD02.Text += rs.showTotal("SD2").ToString();
            SD03.Text += rs.showTotal("SD3").ToString();
            SD0N.Text += rs.showTotal("SDN").ToString();
            if (rs.showTotal("SD3") > rs.showTotal("SD2") && rs.showTotal("SD3") > rs.showTotal("SD1"))
            { SD03.Font.Bold = true; Image39.Visible = true; }
            else if (rs.showTotal("SD2") > rs.showTotal("SD3") && rs.showTotal("SD2") > rs.showTotal("SD1"))
            { SD02.Font.Bold = true; Image38.Visible = true; }
            else if (rs.showTotal("SD1") > rs.showTotal("SD3") && rs.showTotal("SD1") > rs.showTotal("SD2"))
            { SD01.Font.Bold = true; Image37.Visible = true; }
            else Image40.Visible = true;
            LIB01.Text += rs.showTotal("LIB1").ToString();
            LIB02.Text += rs.showTotal("LIB2").ToString();
            LIB03.Text += rs.showTotal("LIB3").ToString();
            LIB0N.Text += rs.showTotal("LIBN").ToString();
            if (rs.showTotal("LIB3") > rs.showTotal("LIB2") && rs.showTotal("LIB3") > rs.showTotal("LIB1"))
            { LIB03.Font.Bold = true; Image43.Visible = true; }
            else if (rs.showTotal("LIB2") > rs.showTotal("LIB3") && rs.showTotal("LIB2") > rs.showTotal("LIB1"))
            { LIB02.Font.Bold = true; Image42.Visible = true; }
            else if (rs.showTotal("LIB1") > rs.showTotal("LIB3") && rs.showTotal("LIB1") > rs.showTotal("LIB2"))
            { LIB01.Font.Bold = true; Image41.Visible = true; }
            else Image44.Visible = true;
            AL01.Text += rs.showTotal("AL1").ToString();
            AL02.Text += rs.showTotal("AL2").ToString();
            AL03.Text += rs.showTotal("AL3").ToString();
            AL0N.Text += rs.showTotal("ALN").ToString();
            if (rs.showTotal("AL3") > rs.showTotal("AL2") && rs.showTotal("AL3") > rs.showTotal("AL1"))
            { AL03.Font.Bold = true; Image47.Visible = true; }
            else if (rs.showTotal("AL2") > rs.showTotal("AL3") && rs.showTotal("AL2") > rs.showTotal("AL1"))
            { AL02.Font.Bold = true; Image46.Visible = true; }
            else if (rs.showTotal("AL1") > rs.showTotal("AL3") && rs.showTotal("AL1") > rs.showTotal("AL2"))
            { AL01.Font.Bold = true; Image45.Visible = true; }
            else Image48.Visible = true;
            EDI01.Text += rs.showTotal("EDI1").ToString();
            EDI02.Text += rs.showTotal("EDI2").ToString();
            EDI03.Text += rs.showTotal("EDI3").ToString();
            EDI0N.Text += rs.showTotal("EDIN").ToString();
            if (rs.showTotal("EDI3") > rs.showTotal("EDI2") && rs.showTotal("EDI3") > rs.showTotal("EDI1"))
            { EDI03.Font.Bold = true; Image51.Visible = true; }
            else if (rs.showTotal("EDI2") > rs.showTotal("EDI3") && rs.showTotal("EDI2") > rs.showTotal("EDI1"))
            { EDI02.Font.Bold = true; Image50.Visible = true; }
            else if (rs.showTotal("EDI1") > rs.showTotal("EDI3") && rs.showTotal("EDI1") > rs.showTotal("EDI2"))
            { EDI01.Font.Bold = true; Image49.Visible = true; }
            else Image52.Visible = true; 
        }
    }
}