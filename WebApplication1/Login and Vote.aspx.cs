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
    public partial class Vote : System.Web.UI.Page
    {
        //using this class
        VotingClass vclass = new VotingClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Hide component visibility
            voteLabel.Visible = false;
            infoLabel.Visible=false;
            infoLabel1.Visible = false;
            resultButton.Visible = false;
            logUsername.Visible = false;
            logUsername.Font.Bold = true;
            holdUsername.Visible = false;
            logName.Visible = false;
            holdName.Visible = false;
            logMatric.Visible = false;
            holdMatric.Visible = false;
            logFaculty.Visible = false;
            holdFaculty.Visible = false;
            logDept.Visible = false;
            holdDept.Visible = false;
            Plabel.Visible = false;
            VPlabel.Visible = false;
            Llabel.Visible = false;
            Elabel.Visible = false;
            Slabel.Visible = false;
            PROlabel.Visible = false;
            SOClabel.Visible = false;
            AGSlabel.Visible = false;
            ALlabel.Visible = false;
            genlabel.Visible = false;
            finlabel.Visible = false;
            trelabel.Visible = false;
            wellabel.Visible = false;
            submitButton.Visible = false;
            Table1.Visible = false;
            Table2.Visible = false;
            Table3.Visible = false;
            Table4.Visible = false;
            Table5.Visible = false;
            Table6.Visible = false;
            Table7.Visible = false;
            Table8.Visible = false;
            Table9.Visible = false;
            Table10.Visible = false;
            Table11.Visible = false;
            Table12.Visible = false;
            Table13.Visible = false;
        }

        //create encryption code
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

        //create decryption code
        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        protected void regButton_Click(object sender, EventArgs e)
        {
            //goto registration page
            Response.Redirect("Register.aspx");
        }

        protected void login_Click(object sender, EventArgs e)
        {
            logLabel.Visible = true;
            if (usernameBox.Text.ToUpper() == "adminregister".ToUpper() && passwordBox.Text.ToUpper() == "admin101".ToUpper())
                Response.Redirect("RegisterKey.aspx");
            if (usernameBox.Text.ToUpper() == "admindatabase".ToUpper() && passwordBox.Text.ToUpper() == "admin101".ToUpper())
                Response.Redirect("Database.aspx");
            String unString = usernameBox.Text;

            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                con.Open();

                //check against username and password
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Username = @Username AND Password=@Password", con);
                cmd.Parameters.AddWithValue("@Username", usernameBox.Text);
                cmd.Parameters.AddWithValue("@password", Encrypt(passwordBox.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                //check against email and password
                SqlCommand cmdd = new SqlCommand("SELECT * FROM Users WHERE Email = @email AND Password=@Password", con);
                cmdd.Parameters.AddWithValue("@email", usernameBox.Text);
                cmdd.Parameters.AddWithValue("@password", Encrypt(passwordBox.Text));
                SqlDataAdapter dad = new SqlDataAdapter(cmdd);
                DataTable dtd = new DataTable();
                dad.Fill(dtd);

                if ((dt.Rows.Count > 0 || dtd.Rows.Count > 0) || (usernameBox.Text.ToUpper() == "adminlogin".ToUpper() && passwordBox.Text.ToUpper() == "adminlogin".ToUpper()))
                {

                    //Make visible and allow access
                    logUsername.Visible = true;
                    logName.Visible = true;
                    logMatric.Visible = true;
                    logFaculty.Visible = true;
                    logDept.Visible = true;
                    Table0.Visible = false;
                    Plabel.Visible = true;
                    VPlabel.Visible = true;
                    Llabel.Visible = true;
                    Elabel.Visible = true;
                    Slabel.Visible = true;
                    PROlabel.Visible = true;
                    SOClabel.Visible = true;
                    AGSlabel.Visible = true;
                    ALlabel.Visible = true;
                    genlabel.Visible = true;
                    finlabel.Visible = true;
                    trelabel.Visible = true;
                    wellabel.Visible = true;
                    Table1.Visible = true;
                    Table2.Visible = true;
                    Table3.Visible = true;
                    Table4.Visible = true;
                    Table5.Visible = true;
                    Table6.Visible = true;
                    Table7.Visible = true;
                    Table8.Visible = true;
                    Table9.Visible = true;
                    Table10.Visible = true;
                    Table11.Visible = true;
                    Table12.Visible = true;
                    Table13.Visible = true;
                    infoLabel.Visible = false;
                    submitButton.Visible = true;

                    //grab from User table; username, name, matric_no, faculty and department
                    SqlCommand cmdu = new SqlCommand("SELECT Username FROM Users WHERE Username=@Username OR Email=@email", con);
                    cmdu.CommandType = CommandType.Text;
                    cmdu.Parameters.AddWithValue("@Username", unString);
                    cmdu.Parameters.AddWithValue("@email", unString);
                    String username = (string)cmdu.ExecuteScalar();
                    logUsername.Text += username;
                    holdUsername.Text = username;
                    unString = holdUsername.Text;

                    SqlCommand cmd1 = new SqlCommand("SELECT name FROM Users WHERE Username=@Username", con);
                    cmd1.CommandType = CommandType.Text;
                    cmd1.Parameters.AddWithValue("@Username", unString);
                    String name = (string)cmd1.ExecuteScalar();
                    logName.Text += name;
                    holdName.Text = name;

                    SqlCommand cmd2 = new SqlCommand("SELECT Matric_no FROM Users WHERE Username=@Username", con);
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Parameters.AddWithValue("@Username", unString);
                    string matric = (String)cmd2.ExecuteScalar();
                    logMatric.Text += matric;
                    holdMatric.Text = matric;

                    SqlCommand cmd3 = new SqlCommand("SELECT Faculty FROM Users WHERE Username=@Username", con);
                    cmd3.CommandType = CommandType.Text;
                    cmd3.Parameters.AddWithValue("@Username", unString);
                    string faculty = (string)cmd3.ExecuteScalar();
                    logFaculty.Text += faculty;
                    holdFaculty.Text = faculty;

                    SqlCommand cmd31 = new SqlCommand("SELECT Department FROM Users WHERE Username=@Username", con);
                    cmd3.CommandType = CommandType.Text;
                    cmd31.Parameters.AddWithValue("@Username", unString);
                    string dept = (string)cmd31.ExecuteScalar();
                    logDept.Text += dept;
                    holdDept.Text = dept;

                    //show voting status
                    SqlCommand cd = new SqlCommand("SELECT * FROM HaveVoted WHERE Username = @Username", con);
                    cd.Parameters.AddWithValue("@Username", holdUsername.Text);
                    cd.ExecuteNonQuery();
                    SqlDataAdapter da1 = new SqlDataAdapter(cd);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0) { infoLabel1.Visible = true; infoLabel1.Text = "Voting Status: Voted"; }
                    else { infoLabel1.Visible = true; infoLabel1.Text = "Voting Status:  Not Voted"; infoLabel.Visible = true; }

                    if (usernameBox.Text.ToUpper() == "adminlogin".ToUpper())
                    {
                        infoLabel1.Text = "Voting Status: Cannot Vote";
                        infoLabel.Text = "You cannot vote with this credential";
                    }

                }
                else
                {
                    logLabel.Text = "Invalid Username and Password combination";
                }
                con.Close();
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (usernameBox.Text.ToUpper() == "adminlogin".ToUpper())
            {
                //for administrator
                logUsername.Visible = true;
                logName.Visible = true;
                logMatric.Visible = true;
                logFaculty.Visible = true;
                Table0.Visible = false;
                Plabel.Visible = true;
                VPlabel.Visible = true;
                Llabel.Visible = true;
                Elabel.Visible = true;
                Slabel.Visible = true;
                PROlabel.Visible = true;
                SOClabel.Visible = true;
                AGSlabel.Visible = true;
                ALlabel.Visible = true;
                genlabel.Visible = true;
                finlabel.Visible = true;
                trelabel.Visible = true;
                wellabel.Visible = true;
                Table1.Visible = true;
                Table2.Visible = true;
                Table3.Visible = true;
                Table4.Visible = true;
                Table5.Visible = true;
                Table6.Visible = true;
                Table7.Visible = true;
                Table8.Visible = true;
                Table9.Visible = true;
                Table10.Visible = true;
                Table11.Visible = true;
                Table12.Visible = true;
                Table13.Visible = true;
                submitButton.Visible = true;
                infoLabel1.Visible = false; 
                voteLabel.Visible = true; voteLabel.Text = "You are not allowed to vote with this credential please";
            }
            else
            {
                voteLabel.Visible = true;
                using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    con.Open();

                    //check voting status
                    SqlCommand cm = new SqlCommand("SELECT *FROM HaveVoted WHERE Username=@UserName", con);
                    cm.CommandType = CommandType.Text;
                    cm.Parameters.AddWithValue("@Username", holdUsername.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        voteLabel.Text = "You have voted already, do not attempt to vote twice.";
                    }
                    else
                    {
                        //ensure completed voting
                        if (((pRadio1.Checked || pRadio2.Checked || pRadio3.Checked || pRadio4.Checked) == true) & ((vpRadio1.Checked || vpRadio2.Checked || vpRadio3.Checked || vpRadio4.Checked) == true) &
                            ((gsRadio1.Checked || gsRadio2.Checked || gsRadio3.Checked || gsRadio4.Checked) == true) & ((fsRadio1.Checked || fsRadio2.Checked || fsRadio3.Checked || fsRadio4.Checked) == true) &
                            ((proRadio1.Checked || proRadio2.Checked || proRadio3.Checked || proRadio4.Checked) == true) & ((agsRadio1.Checked || agsRadio2.Checked || agsRadio3.Checked || agsRadio4.Checked) == true) &
                            ((socRadio1.Checked || socRadio2.Checked || socRadio3.Checked || socRadio4.Checked) == true) & ((spoRadio1.Checked || spoRadio2.Checked || spoRadio3.Checked || spoRadio4.Checked) == true) &
                            ((libRadio1.Checked || libRadio2.Checked || libRadio3.Checked || libRadio4.Checked) == true) & ((alRadio1.Checked || alRadio2.Checked || alRadio3.Checked || alRadio4.Checked) == true) &
                            ((ediRadio1.Checked || ediRadio2.Checked || ediRadio3.Checked || ediRadio4.Checked) == true) & ((welRadio1.Checked || welRadio2.Checked || welRadio3.Checked || welRadio4.Checked) == true) &
                            ((treRadio1.Checked || treRadio2.Checked || treRadio3.Checked || treRadio4.Checked) == true))
                        {
                            //update totalvotes
                            if (pRadio1.Checked == true) vclass.vote("P1");
                            if (pRadio2.Checked == true) vclass.vote("P2");
                            if (pRadio3.Checked == true) vclass.vote("P3");
                            if (pRadio4.Checked == true) vclass.vote("PN");
                            if (vpRadio1.Checked == true) vclass.vote("VP1");
                            if (vpRadio2.Checked == true) vclass.vote("VP2");
                            if (vpRadio3.Checked == true) vclass.vote("VP3");
                            if (vpRadio4.Checked == true) vclass.vote("VPN");
                            if (gsRadio1.Checked == true) vclass.vote("GS1");
                            if (gsRadio2.Checked == true) vclass.vote("GS2");
                            if (gsRadio3.Checked == true) vclass.vote("GS3");
                            if (gsRadio4.Checked == true) vclass.vote("GSN");
                            if (fsRadio1.Checked == true) vclass.vote("FS1");
                            if (fsRadio2.Checked == true) vclass.vote("FS2");
                            if (fsRadio3.Checked == true) vclass.vote("FS3");
                            if (fsRadio4.Checked == true) vclass.vote("FSN");
                            if (proRadio1.Checked == true) vclass.vote("PR1");
                            if (proRadio2.Checked == true) vclass.vote("PR2");
                            if (proRadio3.Checked == true) vclass.vote("PR3");
                            if (proRadio4.Checked == true) vclass.vote("PRN");
                            if (agsRadio1.Checked == true) vclass.vote("AGS1");
                            if (agsRadio2.Checked == true) vclass.vote("AGS2");
                            if (agsRadio3.Checked == true) vclass.vote("AGS3");
                            if (agsRadio4.Checked == true) vclass.vote("AGSN");
                            if (socRadio1.Checked == true) vclass.vote("SOC1");
                            if (socRadio2.Checked == true) vclass.vote("SOC2");
                            if (socRadio3.Checked == true) vclass.vote("SOC3");
                            if (socRadio4.Checked == true) vclass.vote("SOCN");
                            if (spoRadio1.Checked == true) vclass.vote("SD1");
                            if (spoRadio2.Checked == true) vclass.vote("SD2");
                            if (spoRadio3.Checked == true) vclass.vote("SD3");
                            if (spoRadio4.Checked == true) vclass.vote("SDN");
                            if (libRadio1.Checked == true) vclass.vote("LIB1");
                            if (libRadio2.Checked == true) vclass.vote("LIB2");
                            if (libRadio3.Checked == true) vclass.vote("LIB3");
                            if (libRadio4.Checked == true) vclass.vote("LIBN");
                            if (alRadio1.Checked == true) vclass.vote("AL1");
                            if (alRadio2.Checked == true) vclass.vote("AL2");
                            if (alRadio3.Checked == true) vclass.vote("AL3");
                            if (alRadio4.Checked == true) vclass.vote("ALN");
                            if (ediRadio1.Checked == true) vclass.vote("EDI1");
                            if (ediRadio2.Checked == true) vclass.vote("EDI2");
                            if (ediRadio3.Checked == true) vclass.vote("EDI3");
                            if (ediRadio4.Checked == true) vclass.vote("EDIN");
                            if (treRadio1.Checked == true) vclass.vote("TRE1");
                            if (treRadio2.Checked == true) vclass.vote("TRE2");
                            if (treRadio3.Checked == true) vclass.vote("TRE3");
                            if (treRadio4.Checked == true) vclass.vote("TREN");
                            if (welRadio1.Checked == true) vclass.vote("WEL1");
                            if (welRadio2.Checked == true) vclass.vote("WEL2");
                            if (welRadio3.Checked == true) vclass.vote("WEL3");
                            if (welRadio4.Checked == true) vclass.vote("WELN");

                            //update allvotes
                            int P1 = 0, P2 = 0, P3 = 0, PN = 0, VP1 = 0, VP2 = 0, VP3 = 0, VPN = 0, GS1 = 0, GS2 = 0, GS3 = 0, GSN = 0, FS1 = 0, FS2 = 0, FS3 = 0, FSN = 0, PR1 = 0, PR2 = 0, PR3 = 0, PRN = 0, AGS1 = 0, AGS2 = 0, AGS3 = 0, AGSN = 0, SOC1 = 0, SOC2 = 0, SOC3 = 0, SOCN = 0, SD1 = 0, SD2 = 0, SD3 = 0, SDN = 0, LIB1 = 0, LIB2 = 0, LIB3 = 0, LIBN = 0, AL1 = 0, AL2 = 0, AL3 = 0, ALN = 0, EDI1 = 0, EDI2 = 0, EDI3 = 0, EDIN = 0, WEL1 = 0, WEL2 = 0, WEL3 = 0, WELN = 0, TRE1 = 0, TRE2 = 0, TRE3 = 0, TREN = 0;
                            SqlCommand cm2 = new SqlCommand("INSERT INTO AllVotes(Username,Matric_no,P1,P2,VP1,VP2,GS1,GS2,FS1,FS2,PR1,PR2,AGS1,AGS2,SOC1,SOC2,SD1,SD2,LIB1,LIB2,AL1,AL2,EDI1,EDI2,P3,VP3,GS3,FS3,PR3,AGS3,SOC3,SD3,LIB3,AL3,EDI3,WEL1,WEL2,WEL3,TRE1,TRE2,TRE3,PN,VPN,GSN,FSN,PRN,AGSN,SOCN,SDN,LIBN,ALN,EDIN,WELN,TREN) VALUES (@Username,@matric,@P1,@P2,@VP1,@VP2,@GS1,@GS2,@FS1,@FS2,@PR1,@PR2,@AGS1,@AGS2,@SOC1,@SOC2,@SD1,@SD2,@LIB1,@LIB2,@AL1,@AL2,@EDI1,@EDI2,@P3,@VP3,@GS3,@FS3,@PR3,@AGS3,@SOC3,@SD3,@LIB3,@AL3,@EDI3,@WEL1,@WEL2,@WEL3,@TRE1,@TRE2,@TRE3,@PN,@VPN,@GSN,@FSN,@PRN,@AGSN,@SOCN,@SDN,@LIBN,@ALN,@EDIN,@WELN,@TREN)", con);
                            cm2.CommandType = CommandType.Text;
                            if (pRadio1.Checked == true) P1 = 1; else P1 = 0;
                            if (pRadio2.Checked == true) P2 = 1; else P2 = 0;
                            if (pRadio3.Checked == true) P3 = 1; else P3 = 0;
                            if (pRadio4.Checked == true) PN = 1; else PN = 0;
                            if (vpRadio1.Checked == true) VP1 = 1; else VP1 = 0;
                            if (vpRadio2.Checked == true) VP2 = 1; else VP2 = 0;
                            if (vpRadio3.Checked == true) VP3 = 1; else VP3 = 0;
                            if (vpRadio4.Checked == true) VPN = 1; else VPN = 0;
                            if (gsRadio1.Checked == true) GS1 = 1; else GS1 = 0;
                            if (gsRadio2.Checked == true) GS2 = 1; else GS2 = 0;
                            if (gsRadio3.Checked == true) GS3 = 1; else GS3 = 0;
                            if (gsRadio4.Checked == true) GSN = 1; else GSN = 0;
                            if (fsRadio1.Checked == true) FS1 = 1; else FS1 = 0;
                            if (fsRadio2.Checked == true) FS2 = 1; else FS2 = 0;
                            if (fsRadio3.Checked == true) FS3 = 1; else FS3 = 0;
                            if (fsRadio4.Checked == true) FSN = 1; else FSN = 0;
                            if (proRadio1.Checked == true) PR1 = 1; else PR1 = 0;
                            if (proRadio2.Checked == true) PR2 = 1; else PR2 = 0;
                            if (proRadio3.Checked == true) PR3 = 1; else PR3 = 0;
                            if (proRadio4.Checked == true) PRN = 1; else PRN = 0;
                            if (agsRadio1.Checked == true) AGS1 = 1; else AGS1 = 0;
                            if (agsRadio2.Checked == true) AGS2 = 1; else AGS2 = 0;
                            if (agsRadio3.Checked == true) AGS3 = 1; else AGS3 = 0;
                            if (agsRadio4.Checked == true) AGSN = 1; else AGSN = 0;
                            if (socRadio1.Checked == true) SOC1 = 1; else SOC1 = 0;
                            if (socRadio2.Checked == true) SOC2 = 1; else SOC2 = 0;
                            if (socRadio3.Checked == true) SOC3 = 1; else SOC3 = 0;
                            if (socRadio4.Checked == true) SOCN = 1; else SOCN = 0;
                            if (spoRadio1.Checked == true) SD1 = 1; else SD1 = 0;
                            if (spoRadio2.Checked == true) SD2 = 1; else SD2 = 0;
                            if (spoRadio3.Checked == true) SD3 = 1; else SD3 = 0;
                            if (spoRadio4.Checked == true) SDN = 1; else SDN = 0;
                            if (libRadio1.Checked == true) LIB1 = 1; else LIB1 = 0;
                            if (libRadio2.Checked == true) LIB2 = 1; else LIB2 = 0;
                            if (libRadio3.Checked == true) LIB3 = 1; else LIB3 = 0;
                            if (libRadio4.Checked == true) LIBN = 1; else LIBN = 0;
                            if (alRadio1.Checked == true) AL1 = 1; else AL1 = 0;
                            if (alRadio2.Checked == true) AL2 = 1; else AL2 = 0;
                            if (alRadio3.Checked == true) AL3 = 1; else AL3 = 0;
                            if (alRadio4.Checked == true) ALN = 1; else ALN = 0;
                            if (ediRadio1.Checked == true) EDI1 = 1; else EDI1 = 0;
                            if (ediRadio2.Checked == true) EDI2 = 1; else EDI2 = 0;
                            if (ediRadio3.Checked == true) EDI3 = 1; else EDI3 = 0;
                            if (ediRadio4.Checked == true) EDIN = 1; else EDIN = 0;
                            if (welRadio1.Checked == true) WEL1 = 1; else WEL1 = 0;
                            if (welRadio2.Checked == true) WEL2 = 1; else WEL2 = 0;
                            if (welRadio3.Checked == true) WEL3 = 1; else WEL3 = 0;
                            if (welRadio4.Checked == true) WELN = 1; else WELN = 0;
                            if (treRadio1.Checked == true) TRE1 = 1; else TRE1 = 0;
                            if (treRadio2.Checked == true) TRE2 = 1; else TRE2 = 0;
                            if (treRadio3.Checked == true) TRE3 = 1; else TRE3 = 0;
                            if (treRadio4.Checked == true) TREN = 1; else TREN = 0;
                            cm2.Parameters.AddWithValue("@Username", holdUsername.Text);
                            cm2.Parameters.AddWithValue("@matric", holdMatric.Text);
                            cm2.Parameters.AddWithValue("@P1", P1);
                            cm2.Parameters.AddWithValue("@P2", P2);
                            cm2.Parameters.AddWithValue("@P3", P3);
                            cm2.Parameters.AddWithValue("@PN", PN);
                            cm2.Parameters.AddWithValue("@VP1", VP1);
                            cm2.Parameters.AddWithValue("@VP2", VP2);
                            cm2.Parameters.AddWithValue("@VP3", VP3);
                            cm2.Parameters.AddWithValue("@VPN", VPN);
                            cm2.Parameters.AddWithValue("@GS1", GS1);
                            cm2.Parameters.AddWithValue("@GS2", GS2);
                            cm2.Parameters.AddWithValue("@GS3", GS3);
                            cm2.Parameters.AddWithValue("@GSN", GSN);
                            cm2.Parameters.AddWithValue("@FS1", FS1);
                            cm2.Parameters.AddWithValue("@FS2", FS2);
                            cm2.Parameters.AddWithValue("@FS3", FS3);
                            cm2.Parameters.AddWithValue("@FSN", FSN);
                            cm2.Parameters.AddWithValue("@PR1", PR1);
                            cm2.Parameters.AddWithValue("@PR2", PR2);
                            cm2.Parameters.AddWithValue("@PR3", PR3);
                            cm2.Parameters.AddWithValue("@PRN", PRN);
                            cm2.Parameters.AddWithValue("@AGS1", AGS1);
                            cm2.Parameters.AddWithValue("@AGS2", AGS2);
                            cm2.Parameters.AddWithValue("@AGS3", AGS3);
                            cm2.Parameters.AddWithValue("@AGSN", AGSN);
                            cm2.Parameters.AddWithValue("@SOC1", SOC1);
                            cm2.Parameters.AddWithValue("@SOC2", SOC2);
                            cm2.Parameters.AddWithValue("@SOC3", SOC3);
                            cm2.Parameters.AddWithValue("@SOCN", SOCN);
                            cm2.Parameters.AddWithValue("@SD1", SD1);
                            cm2.Parameters.AddWithValue("@SD2", SD2);
                            cm2.Parameters.AddWithValue("@SD3", SD3);
                            cm2.Parameters.AddWithValue("@SDN", SDN);
                            cm2.Parameters.AddWithValue("@LIB1", LIB1);
                            cm2.Parameters.AddWithValue("@LIB2", LIB2);
                            cm2.Parameters.AddWithValue("@LIB3", LIB3);
                            cm2.Parameters.AddWithValue("@LIBN", LIBN);
                            cm2.Parameters.AddWithValue("@AL1", AL1);
                            cm2.Parameters.AddWithValue("@AL2", AL2);
                            cm2.Parameters.AddWithValue("@AL3", AL3);
                            cm2.Parameters.AddWithValue("@ALN", ALN);
                            cm2.Parameters.AddWithValue("@EDI1", EDI1);
                            cm2.Parameters.AddWithValue("@EDI2", EDI2);
                            cm2.Parameters.AddWithValue("@EDI3", EDI3);
                            cm2.Parameters.AddWithValue("@EDIN", EDIN);
                            cm2.Parameters.AddWithValue("@WEL1", WEL1);
                            cm2.Parameters.AddWithValue("@WEL2", WEL2);
                            cm2.Parameters.AddWithValue("@WEL3", WEL3);
                            cm2.Parameters.AddWithValue("@WELN", WELN);
                            cm2.Parameters.AddWithValue("@TRE1", TRE1);
                            cm2.Parameters.AddWithValue("@TRE2", TRE2);
                            cm2.Parameters.AddWithValue("@TRE3", TRE3);
                            cm2.Parameters.AddWithValue("@TREN", TREN);
                            cm2.ExecuteNonQuery();

                            //update faculty
                            string chkfac = holdFaculty.Text;
                            if ((chkfac != "Administration") & (chkfac != "Agricultural_Sciences") & (chkfac != "Arts") & (chkfac != "Basic_Medical_Sciences") & (chkfac != "Clinical_Sciences") & (chkfac != "Dentistry") &
                                (chkfac != "Education") & (chkfac != "EDM") & (chkfac != "Law") & (chkfac != "Pharmacy") & (chkfac != "Sciences") & (chkfac != "Social_Sciences") & (chkfac != "Technology"))
                            { holdFaculty.Text = "Other_Faculty"; }
                            SqlCommand cm3 = new SqlCommand("UPDATE " + holdFaculty.Text + " SET HaveVoted = @HaveVoted1 WHERE Matric_no=@Matric_no1", con);
                            cm3.CommandType = CommandType.Text;
                            cm3.Parameters.AddWithValue("@HaveVoted1", "Yes");
                            cm3.Parameters.AddWithValue("@Matric_no1", holdMatric.Text);
                            cm3.ExecuteNonQuery();

                            //update department
                            string chkdept = holdDept.Text;
                            if ((chkdept != "International_Relations") & (chkdept != "Local_Government_Studies") & (chkdept != "Management_and_Accounting") & (chkdept != "Public_Administration") & (chkdept != "Other_Administration") & (chkdept != "Agricultural_Economics") & (chkdept != "Agricultural_Extension") & (chkdept != "Animal_Science") & (chkdept != "Crop_Production") & (chkdept != "Family_Nutrition") & (chkdept != "Soil_Science") & (chkdept != "Other_Agricultural_Sciences") & (chkdept != "Dramatic_Arts") & (chkdept != "English_Language") &
                                (chkdept != "Foreign_Languages") & (chkdept != "History") & (chkdept != "Linguistics") & (chkdept != "Music") & (chkdept != "Philosophy") & (chkdept != "Religious_Studies") & (chkdept != "Other_Arts") & (chkdept != "Basic_Medical_Sciences") & (chkdept != "Medical_Rehabilitation") & (chkdept != "Nursing") & (chkdept != "Other_Basic_Medical_Sciences") & (chkdept != "Clinical_Sciences") & (chkdept != "Medicine_and_Surgery") & (chkdept != "Other_Clinical_Sciences") &
                                (chkdept != "Dentistry_Department") & (chkdept != "Other_Dentistry") & (chkdept != "Education") & (chkdept != "Adult_Education") & (chkdept != "Continuing_Education") & (chkdept != "Educational_Administration") & (chkdept != "Educational_Foundation") & (chkdept != "Educational_Technology") & (chkdept != "Physical_Education") & (chkdept != "Special_Education") & (chkdept != "Other_Education") & (chkdept != "Architecture") & (chkdept != "Building") & (chkdept != "Estate_Management") &
                                (chkdept != "Fine_Arts") & (chkdept != "Quantity_Surveying") & (chkdept != "Urban_and_Rural_Planning") & (chkdept != "Other_EDM") & (chkdept != "Law_Department") & (chkdept != "Other_Law") & (chkdept != "Pharmacy_Department") & (chkdept != "Other_Pharmacy") & (chkdept != "Biochemistry") & (chkdept != "Botany") & (chkdept != "Chemistry") & (chkdept != "Conservative_Science") & (chkdept != "Geology") & (chkdept != "Mathematics") & (chkdept != "Microbiology") &
                                (chkdept != "Physics") & (chkdept != "Zoology") & (chkdept != "Other_Sciences") & (chkdept != "Demography") & (chkdept != "Economics") & (chkdept != "Geography") & (chkdept != "Philosophy") & (chkdept != "Political_Science") & (chkdept != "Psychology") & (chkdept != "Sociology") & (chkdept != "Other_Social_Sciences") & (chkdept != "Agricultural_Engineering") & (chkdept != "Chemical_Engineering") & (chkdept != "Civil_Engineering") &
                                (chkdept != "Computer_Science_and_Engineering") & (chkdept != "Electrical_Engineering") & (chkdept != "Food_Science") & (chkdept != "Material_Science") & (chkdept != "Mechanical_Engineering") & (chkdept != "Other_Technology"))
                            { holdDept.Text = "Other_Department"; }
                            SqlCommand cmm3 = new SqlCommand("UPDATE " + holdDept.Text + " SET HaveVoted = @HaveVoted3 WHERE Matric_no=@Matric_no3", con);
                            cmm3.CommandType = CommandType.Text;
                            cmm3.Parameters.AddWithValue("@HaveVoted3", "Yes");
                            cmm3.Parameters.AddWithValue("@Matric_no3", holdMatric.Text);
                            cmm3.ExecuteNonQuery();

                            //update users table
                            SqlCommand cm4 = new SqlCommand("UPDATE Users SET HaveVoted = @HaveVoted2 WHERE Matric_no=@Matric_no2", con);
                            cm4.CommandType = CommandType.Text;
                            cm4.Parameters.AddWithValue("@HaveVoted2", "Yes");
                            cm4.Parameters.AddWithValue("@Matric_no2", holdMatric.Text);
                            cm4.ExecuteNonQuery();

                            //update total votes table
                            SqlCommand com = new SqlCommand("UPDATE TotalVotes SET Number = Number + 1 WHERE VoteId=@VoteId", con);
                            com.CommandType = CommandType.Text;
                            com.Parameters.AddWithValue("@VoteId", "TOTAL");
                            com.ExecuteNonQuery();

                            SqlCommand cmd = new SqlCommand("UPDATE TotalVotes SET NumberFaculty = NumberFaculty + 1 WHERE Faculty=@Faculty", con);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@Faculty", holdFaculty.Text);
                            cmd.ExecuteNonQuery();

                            SqlCommand cmd1 = new SqlCommand("UPDATE TotalVotes SET NumberFaculty = NumberFaculty + 1 WHERE Faculty=@Faculty", con);
                            cmd1.CommandType = CommandType.Text;
                            cmd1.Parameters.AddWithValue("@Faculty", "TOTAL");
                            cmd1.ExecuteNonQuery();

                            SqlCommand cmmd = new SqlCommand("UPDATE TotalVotes SET NumberDepartment = NumberDepartment + 1 WHERE Department=@Department", con);
                            cmmd.CommandType = CommandType.Text;
                            cmmd.Parameters.AddWithValue("@Department", holdDept.Text);
                            cmmd.ExecuteNonQuery();

                            SqlCommand cmmd1 = new SqlCommand("UPDATE TotalVotes SET NumberDepartment = NumberDepartment + 1 WHERE Department=@Department", con);
                            cmmd1.CommandType = CommandType.Text;
                            cmmd1.Parameters.AddWithValue("@Department", "TOTAL_" + holdFaculty.Text);
                            cmmd1.ExecuteNonQuery();

                            SqlCommand cmmd2 = new SqlCommand("UPDATE TotalVotes SET NumberDepartment = NumberDepartment + 1 WHERE Department=@Department", con);
                            cmmd2.CommandType = CommandType.Text;
                            cmmd2.Parameters.AddWithValue("@Department", "TOTAL");
                            cmmd2.ExecuteNonQuery();

                            //insert voters details into havevoted table
                            SqlCommand cm1 = new SqlCommand("INSERT INTO HaveVoted(Username, Faculty, Matric_no, Name, Department) VALUES (@Username, @faculty, @Matric_no, @name, @dept)", con);
                            cm1.CommandType = CommandType.Text;
                            cm1.Parameters.AddWithValue("@Username", holdUsername.Text);
                            cm1.Parameters.AddWithValue("@faculty", holdFaculty.Text);
                            cm1.Parameters.AddWithValue("@Matric_no", holdMatric.Text);
                            cm1.Parameters.AddWithValue("@name", holdName.Text);
                            cm1.Parameters.AddWithValue("@dept", holdDept.Text);
                            cm1.ExecuteNonQuery();

                            voteLabel.Text = "Your vote has been recorded, voting completed";
                            resultButton.Visible = true;
                        }
                        else
                        {
                            //upon incomplete votes
                            logUsername.Visible = true;
                            logName.Visible = true;
                            logMatric.Visible = true;
                            logFaculty.Visible = true;
                            Table0.Visible = false;
                            Plabel.Visible = true;
                            VPlabel.Visible = true;
                            Llabel.Visible = true;
                            Elabel.Visible = true;
                            Slabel.Visible = true;
                            PROlabel.Visible = true;
                            SOClabel.Visible = true;
                            AGSlabel.Visible = true;
                            ALlabel.Visible = true;
                            genlabel.Visible = true;
                            finlabel.Visible = true;
                            trelabel.Visible = true;
                            wellabel.Visible = true;
                            Table1.Visible = true;
                            Table2.Visible = true;
                            Table3.Visible = true;
                            Table4.Visible = true;
                            Table5.Visible = true;
                            Table6.Visible = true;
                            Table7.Visible = true;
                            Table8.Visible = true;
                            Table9.Visible = true;
                            Table10.Visible = true;
                            Table11.Visible = true;
                            Table12.Visible = true;
                            Table13.Visible = true;
                            submitButton.Visible = true;
                            voteLabel.Visible = true;
                            voteLabel.Text = "You must vote in all positions";

                            //generate voting status
                            SqlCommand cd = new SqlCommand("SELECT * FROM HaveVoted WHERE Username = @Username", con);
                            cd.Parameters.AddWithValue("@Username", holdUsername.Text);
                            cd.ExecuteNonQuery();
                            SqlDataAdapter da1 = new SqlDataAdapter(cd);
                            DataTable dt1 = new DataTable();
                            da1.Fill(dt1);
                            if (dt1.Rows.Count > 0) { infoLabel1.Visible = true; infoLabel1.Text = "Voting Status: Voted"; }
                            else { infoLabel1.Visible = true; infoLabel1.Text = "Voting Status:  Not Voted"; infoLabel.Visible = true; }
                        }

                    }
                }
            }
        }

        protected void forgot_click(object sender, EventArgs e)
        {
            //go to forgot password page
            Response.Redirect("ForgotPassword.aspx");
        }

        protected void resultButton_Click(object sender, EventArgs e)
        {
            //go to result page
            Response.Redirect("Result.aspx");
        }

    }
}