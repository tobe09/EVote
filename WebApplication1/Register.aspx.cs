using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Configuration;
using System.Data;
using System.Text;
using System.Configuration;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Drawing;

namespace WebApplication1
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //display department according to faculty
            Boolean checkfacdept = (fac.SelectedIndex == 0 && adm.Visible == true) || (fac.SelectedIndex == 1 && agr.Visible == true) || (fac.SelectedIndex == 2 && art.Visible == true) ||
                                 (fac.SelectedIndex == 3 && med.Visible == true) || (fac.SelectedIndex == 4 && cli.Visible == true) || (fac.SelectedIndex == 5 && den.Visible == true) ||
                                 (fac.SelectedIndex == 6 && edu.Visible == true) || (fac.SelectedIndex == 7 && edm.Visible == true) || (fac.SelectedIndex == 8 && law.Visible == true) ||
                                 (fac.SelectedIndex == 9 && phm.Visible == true) || (fac.SelectedIndex == 10 && sci.Visible == true) || (fac.SelectedIndex == 11 && soc.Visible == true) ||
                                 (fac.SelectedIndex == 12 && tech.Visible == true) || (fac.SelectedIndex == 13 && otherd.Visible == true);
            holdLabel1.Text = checkfacdept.ToString();
            if (fac.SelectedIndex == 0) adm.Visible = true; else adm.Visible = false;
            if (fac.SelectedIndex == 1) agr.Visible = true; else agr.Visible = false;
            if (fac.SelectedIndex == 2) art.Visible = true; else art.Visible = false;
            if (fac.SelectedIndex == 3) med.Visible = true; else med.Visible = false;
            if (fac.SelectedIndex == 4) cli.Visible = true; else cli.Visible = false;
            if (fac.SelectedIndex == 5) den.Visible = true; else den.Visible = false;
            if (fac.SelectedIndex == 6) edu.Visible = true; else edu.Visible = false;
            if (fac.SelectedIndex == 7) edm.Visible = true; else edm.Visible = false;
            if (fac.SelectedIndex == 8) law.Visible = true; else law.Visible = false;
            if (fac.SelectedIndex == 9) phm.Visible = true; else phm.Visible = false;
            if (fac.SelectedIndex == 10) sci.Visible = true; else sci.Visible = false;
            if (fac.SelectedIndex == 11) soc.Visible = true; else soc.Visible = false;
            if (fac.SelectedIndex == 12) tech.Visible = true; else tech.Visible = false;
            if (fac.SelectedIndex == 13) { facBox.Visible = true; otherd.Visible = true; fac.Visible = true; }
            else { facBox.Visible = false; otherd.Visible = false; fac.Visible = true; }

            rButton.Visible = false;

            //to generate and check captcha
            Session["holder"] = holdLabel.Text;
            infoLabel.Text = "Enter Your details below";
            Random r = new Random();
            int rn = r.Next(0, 22);
            if (rn > 20 || rn < 1) rn = r.Next(5, 15);
            image.ImageUrl = "~/captcha/" + rn.ToString() + ".jpg";
            holdLabel.Text = rn.ToString();
            holdLabel.Visible = false;
            holdLabel1.Visible = false;
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
            string key = facKCBox.Text;
            string faculty = "", dept = "";

            //assign values for captcha
            int count = Convert.ToInt32(Session["holder"]);
            string hold = "";
            if (count == 1) hold = "9164bf";
            else if (count == 2) hold = "ai6ilt";
            else if (count == 3) hold = "c149eg";
            else if (count == 4) hold = "dd1e4";
            else if (count == 5) hold = "5ci2e3";
            else if (count == 6) hold = "jklm1";
            else if (count == 7) hold = "64ijlc";
            else if (count == 8) hold = "gga68b";
            else if (count == 9) hold = "134bcd";
            else if (count == 10) hold = "efigh3";
            else if (count == 11) hold = "h46ml8";
            else if (count == 12) hold = "ggi23g";
            else if (count == 13) hold = "ac941h";
            else if (count == 14) hold = "lmuiv3";
            else if (count == 15) hold = "ihitu7";
            else if (count == 16) hold = "739h43";
            else if (count == 17) hold = "64umu1";
            else if (count == 18) hold = "lht23";
            else if (count == 19) hold = "d463mi";
            else hold = "prtq49";

            //assign departments and faculties accordingly
                if (fac.SelectedIndex == 0)
                {
                    faculty = "Administration";
                    if (adm.SelectedIndex == 0) dept = "International_Relations";
                    else if (adm.SelectedIndex == 1) dept = "Local_Government_Studies";
                    else if (adm.SelectedIndex == 2) dept = "Management_and_Accounting";
                    else if (adm.SelectedIndex == 3) dept = "Public_Administration";
                    else dept = "Other_Administration";
                }
                else if (fac.SelectedIndex == 1)
                {
                    faculty = "Agricultural_Sciences";
                    if (agr.SelectedIndex == 0) dept = "Agricultural_Economics";
                    else if (agr.SelectedIndex == 1) dept = "Agricultural_Extension";
                    else if (agr.SelectedIndex == 2) dept = "Animal_Science";
                    else if (agr.SelectedIndex == 3) dept = "Crop_Production";
                    else if (agr.SelectedIndex == 4) dept = "Family_Nutrition";
                    else if (agr.SelectedIndex == 5) dept = "Soil_Science";
                    else dept = "Other_Agricultural_Sciences";
                }
                else if (fac.SelectedIndex == 2)
                {
                    faculty = "Arts";
                    if (art.SelectedIndex == 0) dept = "Dramatic_Arts";
                    else if (art.SelectedIndex == 1) dept = "English_Language";
                    else if (art.SelectedIndex == 2) dept = "Foreign_Languages";
                    else if (art.SelectedIndex == 3) dept = "History";
                    else if (art.SelectedIndex == 4) dept = "Linguistics";
                    else if (art.SelectedIndex == 5) dept = "Music";
                    else if (art.SelectedIndex == 6) dept = "Philosophy";
                    else if (art.SelectedIndex == 7) dept = "Religious_Studies";
                    else dept = "Other_Arts";
                }
                else if (fac.SelectedIndex == 3)
                {
                    faculty = "Basic_Medical_Sciences";
                    if (med.SelectedIndex == 0) dept = "Medical_Rehabilitation";
                    else if (med.SelectedIndex == 1) dept = "Nursing";
                    else dept = "Other_Basic_Medical_Sciences";
                }
                else if (fac.SelectedIndex == 4)
                {
                    faculty = "Clinical_Sciences";
                    if (cli.SelectedIndex == 0) dept = "Medicine_and_Surgery";
                    else dept = "Other_Clinical_Sciences";
                }
                else if (fac.SelectedIndex == 5)
                {
                    faculty = "Dentistry";
                    if (den.SelectedIndex == 0) dept = "Dentistry_Department";
                    else dept = "Other_Dentistry";
                }
                else if (fac.SelectedIndex == 6)
                {
                    faculty = "Education";
                    if (edu.SelectedIndex == 0) dept = "Adult_Education";
                    else if (edu.SelectedIndex == 1) dept = "Continuing_Education";
                    else if (edu.SelectedIndex == 2) dept = "Educational_Administration";
                    else if (edu.SelectedIndex == 3) dept = "Educational_Foundation";
                    else if (edu.SelectedIndex == 4) dept = "Educational_Technology";
                    else if (edu.SelectedIndex == 5) dept = "Physical_Education";
                    else if (edu.SelectedIndex == 6) dept = "Special_Education";
                    else dept = "Other_Education";
                }
                else if (fac.SelectedIndex == 7)
                {
                    faculty = "EDM";
                    if (edm.SelectedIndex == 0) dept = "Architecture";
                    else if (edm.SelectedIndex == 1) dept = "Building";
                    else if (edm.SelectedIndex == 2) dept = "Estate_Management";
                    else if (edu.SelectedIndex == 3) dept = "Fine_Arts";
                    else if (edm.SelectedIndex == 4) dept = "Quantity_Surveying";
                    else if (edm.SelectedIndex == 5) dept = "Urban_and_Rural_Planning";
                    else dept = "Other_EDM";
                }
                else if (fac.SelectedIndex == 8)
                {
                    faculty = "Law";
                    if (law.SelectedIndex == 0) dept = "Law_Department";
                    else dept = "Other_Law";
                }
                else if (fac.SelectedIndex == 9)
                {
                    faculty = "Pharmacy";
                    if (phm.SelectedIndex == 0) dept = "Pharmacy_Department";
                    else dept = "Other_Pharmacy";
                }
                else if (fac.SelectedIndex == 10)
                {
                    faculty = "Sciences";
                    if (sci.SelectedIndex == 0) dept = "Biochemistry";
                    else if (sci.SelectedIndex == 1) dept = "Botany";
                    else if (sci.SelectedIndex == 2) dept = "Chemistry";
                    else if (sci.SelectedIndex == 3) dept = "Conservative_Science";
                    else if (sci.SelectedIndex == 4) dept = "Geology";
                    else if (sci.SelectedIndex == 5) dept = "Mathematics";
                    else if (sci.SelectedIndex == 6) dept = "Microbiology";
                    else if (sci.SelectedIndex == 7) dept = "Physics";
                    else if (sci.SelectedIndex == 8) dept = "Zoology";
                    else dept = "Other_Sciences";
                }
                else if (fac.SelectedIndex == 11)
                {
                    faculty = "Social_Sciences";
                    if (soc.SelectedIndex == 0) dept = "Demography";
                    else if (soc.SelectedIndex == 1) dept = "Economics";
                    else if (soc.SelectedIndex == 2) dept = "Geography";
                    else if (soc.SelectedIndex == 3) dept = "Philosophy";
                    else if (soc.SelectedIndex == 4) dept = "Political_Science";
                    else if (soc.SelectedIndex == 5) dept = "Psychology";
                    else if (soc.SelectedIndex == 6) dept = "Sociology";
                    else dept = "Other_Social_Sciences";
                }
                else if (fac.SelectedIndex == 12)
                {
                    faculty = "Technology";
                    if (tech.SelectedIndex == 0) dept = "Agricultural_Engineering";
                    else if (tech.SelectedIndex == 1) dept = "Chemical_Engineering";
                    else if (tech.SelectedIndex == 2) dept = "Civil_Engineering";
                    else if (tech.SelectedIndex == 3) dept = "Computer_Science_and_Engineering";
                    else if (tech.SelectedIndex == 4) dept = "Electrical_Engineering";
                    else if (tech.SelectedIndex == 5) dept = "Food_Science";
                    else if (tech.SelectedIndex == 6) dept = "Material_Science";
                    else if (tech.SelectedIndex == 7) dept = "Mechanical_Engineering";
                    else dept = "Other_Technology";
                }
                else
                {
                    faculty = "Other_Faculty";
                    dept = "Other_Department";
                }

            //validate and update database tables
                using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    con.Open();

                    //validate keycode
                    string mats = matricBox.Text;
                    SqlCommand cmd3 = new SqlCommand("SELECT * FROM KeyCodes WHERE Id = @Id AND Matric_no=@mat", con);
                    cmd3.Parameters.AddWithValue("@Id", key);
                    cmd3.Parameters.AddWithValue("@mat", mats);
                    SqlDataAdapter da = new SqlDataAdapter(cmd3);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    //check usage of keycode
                    SqlCommand cmds = new SqlCommand("SELECT * FROM KeyCodes where UsageInt=@Usage AND Matric_no=@Matric", con);
                    cmds.CommandType = CommandType.Text;
                    cmds.Parameters.AddWithValue("@Usage", "1");
                    cmds.Parameters.AddWithValue("@matric", mats);
                    SqlDataAdapter daa = new SqlDataAdapter(cmds);
                    DataTable dta = new DataTable();
                    daa.Fill(dta);

                    //check keycode provision status
                    SqlCommand cmds1 = new SqlCommand("SELECT * FROM KeyCodes where Matric_no=@Matric", con);
                    cmds1.CommandType = CommandType.Text;
                    cmds1.Parameters.AddWithValue("@matric", mats);
                    SqlDataAdapter daa1 = new SqlDataAdapter(cmds1);
                    DataTable dta1 = new DataTable();
                    daa1.Fill(dta1);

                    //check registration of username
                    SqlCommand cmd1 = new SqlCommand("SELECT *FROM Users WHERE Username=@Username", con);
                    cmd1.Parameters.AddWithValue("@Username", usernameBox.Text);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);

                    //check registration of mail
                    SqlCommand ccmd1 = new SqlCommand("SELECT *FROM Users WHERE email=@email", con);
                    ccmd1.Parameters.AddWithValue("@email", emailBox.Text);
                    SqlDataAdapter cda1 = new SqlDataAdapter(ccmd1);
                    DataTable cdt1 = new DataTable();
                    cda1.Fill(cdt1);

                    //if loop to display error messages according to conditions
                    if (nameBox.Text.Length <= 2 || levelBox.Text.Length < 1 || imageBox.Text.ToUpper() != hold.ToString().ToUpper() ||
                        dt.Rows.Count <= 0 || dta.Rows.Count > 0 || usernameBox.Text.Length < 1 || phoneBox.Text.Length <= 8 || emailBox.Text.Length <= 3 ||
                        dt1.Rows.Count > 0 || cdt1.Rows.Count > 0 || password2Box.Text != passwordBox.Text || passwordBox.Text.Length < 4 || matricBox.Text.Length != 12 ||
                        (yesR.Checked == false && noR.Checked == false) || noR.Checked == true || holdLabel1.Text.ToUpper() == "FALSE" || dta1.Rows.Count <= 0)
                    {
                        if (dta1.Rows.Count <= 0) infoLabel.Text = "Please acquire a keycode from your nearest administrator";
                        else if (dta.Rows.Count > 0) infoLabel.Text = "This Matriculation number is already registered";
                        else if (dt.Rows.Count <= 0) infoLabel.Text = "Wrong Keycode";
                        else if (nameBox.Text.Length <= 2) infoLabel.Text = "Enter Valid Name";
                        else if (matricBox.Text.Length != 12) infoLabel.Text = "Enter a valid matriculation number";
                        else if (holdLabel1.Text.ToUpper() == "FALSE") infoLabel.Text = "Faculty and department do not tally";
                        else if (usernameBox.Text.Length < 1) infoLabel.Text = "Enter Valid Username";
                        else if (levelBox.Text.Length < 1) infoLabel.Text = "Enter Valid Level";
                        else if (phoneBox.Text.Length <= 8) infoLabel.Text = "Enter Valid Phone Number";
                        else if (emailBox.Text.Length <= 3) infoLabel.Text = "Enter Valid E-mail adress";
                        else if (dt1.Rows.Count > 0) infoLabel.Text = "Username already registered, please use another";
                        else if (cdt1.Rows.Count > 0) infoLabel.Text = "E-mail already registered";
                        else if (passwordBox.Text.Length < 4) infoLabel.Text = "Inadmissible Password. (Hint: Your password must contain at least 4 characters)";
                        else if (password2Box.Text != passwordBox.Text) infoLabel.Text = "Mismatched Password";
                        else if (imageBox.Text.ToUpper() != hold.ToString().ToUpper()) infoLabel.Text = "Invalid captcha value entry";
                        else if (noR.Checked == true) { infoLabel.Visible = true; infoLabel.Text = "Adjust your details to your satisfaction"; }
                        else if (yesR.Checked == false && noR.Checked == false) { infoLabel.Visible = true; infoLabel.Text = "Accept details entered to proceed"; }
                        else infoLabel.Text = "Recheck Details Please";
                    }

                    else
                    {
                        //update faculty
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO " + faculty + "(HaveVoted, Username, Password, Phone_no, Email, Name, Matric_no, KeyCode, Department, Level) VALUES(@HaveVoted, @Username, @Password, @Phone_no, @Email, @Name, @Matric_no, @KeyCode, @Department, @Level)", con))
                        {
                            cmd.Parameters.AddWithValue("@Username", usernameBox.Text.Trim());
                            cmd.Parameters.AddWithValue("@Password", Encrypt(passwordBox.Text.Trim()));
                            cmd.Parameters.AddWithValue("@Phone_no", phoneBox.Text.Trim());
                            cmd.Parameters.AddWithValue("@Email", emailBox.Text.Trim());
                            cmd.Parameters.AddWithValue("@Name", nameBox.Text.Trim());
                            cmd.Parameters.AddWithValue("@Matric_no", matricBox.Text.Trim());
                            cmd.Parameters.AddWithValue("@KeyCode", key.Trim());
                            if (fac.SelectedIndex == 13) cmd.Parameters.AddWithValue("@Department", otherd.Text);
                            else cmd.Parameters.AddWithValue("@Department", dept.Trim());
                            cmd.Parameters.AddWithValue("@Level", levelBox.Text.Trim());
                            cmd.Parameters.AddWithValue("@HaveVoted", "No");
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }

                        //update department
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO " + dept + "(HaveVoted, Username, Password, Phone_no, Email, Name, Matric_no, KeyCode, Level) VALUES(@HaveVoted, @Username, @Password, @Phone_no, @Email, @Name, @Matric_no, @KeyCode, @Level)", con))
                        {
                            cmd.Parameters.AddWithValue("@Username", usernameBox.Text.Trim());
                            cmd.Parameters.AddWithValue("@Password", Encrypt(passwordBox.Text.Trim()));
                            cmd.Parameters.AddWithValue("@Phone_no", phoneBox.Text.Trim());
                            cmd.Parameters.AddWithValue("@Email", emailBox.Text.Trim());
                            cmd.Parameters.AddWithValue("@Name", nameBox.Text.Trim());
                            cmd.Parameters.AddWithValue("@Matric_no", matricBox.Text.Trim());
                            cmd.Parameters.AddWithValue("@KeyCode", key.Trim());
                            cmd.Parameters.AddWithValue("@Level", levelBox.Text.Trim());
                            cmd.Parameters.AddWithValue("@HaveVoted", "No");
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }

                        //update users
                        using (SqlCommand cmd4 = new SqlCommand("INSERT INTO Users (HaveVoted, Username, Password, Phone_no, Email, Name, Matric_no, KeyCode, Department, Level, Faculty) VALUES(@HaveVoted, @Username, @Password, @Phone_no, @Email, @Name, @Matric_no, @KeyCode, @Department, @Level, @Faculty)", con))
                        {
                            cmd4.Parameters.AddWithValue("@Username", usernameBox.Text.Trim());
                            cmd4.Parameters.AddWithValue("@Password", Encrypt(passwordBox.Text.Trim()));
                            cmd4.Parameters.AddWithValue("@Phone_no", phoneBox.Text.Trim());
                            cmd4.Parameters.AddWithValue("@Email", emailBox.Text.Trim());
                            cmd4.Parameters.AddWithValue("@Name", nameBox.Text.Trim());
                            cmd4.Parameters.AddWithValue("@Matric_no", matricBox.Text.Trim());
                            cmd4.Parameters.AddWithValue("@KeyCode", key.Trim());
                            if (fac.SelectedIndex == 13) cmd4.Parameters.AddWithValue("@Department", otherd.Text);
                            else cmd4.Parameters.AddWithValue("@Department", dept.Trim());
                            cmd4.Parameters.AddWithValue("@Level", levelBox.Text.Trim());
                            if (fac.SelectedIndex == 13) cmd4.Parameters.AddWithValue("@Faculty", facBox.Text);
                            else cmd4.Parameters.AddWithValue("@Faculty", faculty.Trim());
                            cmd4.Parameters.AddWithValue("@HaveVoted", "No");
                            cmd4.ExecuteNonQuery();
                            cmd4.Dispose();
                        }

                        //adjust components visibility
                        rButton.Visible = true;
                        nameLabel.Visible = false;
                        matricLabel.Visible = false;
                        facLabel.Visible = false;
                        facultyKC.Visible = false;
                        usernameLabel.Visible = false;
                        passwordLabel.Visible = false;
                        password2Label.Visible = false;
                        phoneLabel.Visible = false;
                        emailLabel.Visible = false;
                        nameBox.Visible = false;
                        matricBox.Visible = false;
                        fac.Visible = false;
                        facKCBox.Visible = false;
                        usernameBox.Visible = false;
                        passwordBox.Visible = false;
                        password2Box.Visible = false;
                        phoneBox.Visible = false;
                        emailBox.Visible = false;
                        deptLabel.Visible = false;
                        levelBox.Visible = false;
                        levelLabel.Visible = false;
                        regButton.Visible = false;
                        rButton.Visible = true;
                        image.Visible = false;
                        imgLabel.Visible = false;
                        imageBox.Visible = false;
                        adm.Visible = false;
                        agr.Visible = false;
                        art.Visible = false;
                        den.Visible = false;
                        edm.Visible = false;
                        edu.Visible = false;
                        cli.Visible = false;
                        law.Visible = false;
                        med.Visible = false;
                        phm.Visible = false;
                        sci.Visible = false;
                        soc.Visible = false;
                        tech.Visible = false;
                        sure.Visible = false;
                        facBox.Visible = false;
                        facgen.Visible = false;
                        otherd.Visible = false;
                        yesR.Visible = false;
                        noR.Visible = false;

                        //update keycodes table
                        using (SqlCommand cmx = new SqlCommand("UPDATE KeyCodes SET UsageInt = @usage1 WHERE Matric_no=@Matric_no1", con))
                        {
                            cmx.CommandType = CommandType.Text;
                            cmx.Parameters.AddWithValue("@usage1", "1");
                            cmx.Parameters.AddWithValue("@Matric_no1", mats);
                            cmx.ExecuteNonQuery();
                        }

                        infoLabel.Text = "Registration complete (" + nameBox.Text + ").";
                    }
                    con.Close();
                }
        }

        protected void selectClick(object sender, EventArgs e)
        {
            //adjust visibility of department according to faculty
            if (fac.SelectedIndex == 0) adm.Visible = true; else adm.Visible = false;
            if (fac.SelectedIndex == 1) agr.Visible = true; else agr.Visible = false;
            if (fac.SelectedIndex == 2) art.Visible = true; else art.Visible = false;
            if (fac.SelectedIndex == 3) med.Visible = true; else med.Visible = false;
            if (fac.SelectedIndex == 4) cli.Visible = true; else cli.Visible = false;
            if (fac.SelectedIndex == 5) den.Visible = true; else den.Visible = false;
            if (fac.SelectedIndex == 6) edu.Visible = true; else edu.Visible = false;
            if (fac.SelectedIndex == 7) edm.Visible = true; else edm.Visible = false;
            if (fac.SelectedIndex == 8) law.Visible = true; else law.Visible = false;
            if (fac.SelectedIndex == 9) phm.Visible = true; else phm.Visible = false;
            if (fac.SelectedIndex == 10) sci.Visible = true; else sci.Visible = false;
            if (fac.SelectedIndex == 11) soc.Visible = true; else soc.Visible = false;
            if (fac.SelectedIndex == 12) tech.Visible = true; else tech.Visible = false;
            if (fac.SelectedIndex == 13) { facBox.Visible = true; otherd.Visible = true; fac.Visible = true; }
            else { facBox.Visible = false; otherd.Visible = false; fac.Visible = true; facgen.Visible = true; }
        }

        protected void rButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

    }
}