using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace WebApplication1
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label.Visible = false;
            Label1.Visible = false;
        }

        //create decryption key
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

        protected void emailButton_click(object sender, EventArgs e)
        {
            Label.Visible = true;

            // test validity of email adress
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.Timeout = 10000;
                mail.To.Add(emailBox.Text);
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("goldenboi039@gmail.com", "248163264128");
                SmtpServer.EnableSsl = true;

                using (SqlConnection con1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    con1.Open();

                    //check availabilty of email adress
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE email=@email", con1);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@email", emailBox.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        //generate password
                        SqlCommand cmd1 = new SqlCommand("SELECT Password FROM Users WHERE email=@email", con1);
                        cmd1.CommandType = CommandType.Text;
                        cmd1.Parameters.AddWithValue("@email", emailBox.Text);
                        String pass = Decrypt((string)cmd1.ExecuteScalar());

                        //generate username
                        SqlCommand cmd2 = new SqlCommand("SELECT Username FROM Users WHERE email=@email", con1);
                        cmd2.CommandType = CommandType.Text;
                        cmd2.Parameters.AddWithValue("@email", emailBox.Text);
                        String name = (string)cmd2.ExecuteScalar();

                        //enter mail details
                        mail.From = new MailAddress("goldenboi039@gmail.com");
                        mail.Subject = "Your correct OAU E-VOTE Password";
                        mail.Body = "Your details are: \r\n\r\nUsername: " + name + "\r\nPassword: " + pass;

                        //store offline
                        using (StreamWriter stw = File.AppendText(@"C:\Users\user\Desktop\New folder\WebApplication1\WebApplication1\getPassword.txt"))
                        { stw.WriteLine(name + "\t\t" + pass); }
                        try
                        {
                            //send mail
                            SmtpServer.Send(mail);
                            Label.Text = "Message sent";
                            using (StreamWriter stw = File.AppendText(@"C:\Users\user\Desktop\New folder\WebApplication1\WebApplication1\getSentPassword.txt"))
                            { stw.WriteLine(name + "\t\t" + pass); }
                        }
                        catch (Exception ex)
                        {
                            Label.Text = "Could not send message. Error= " + ex.Message;
                            Label1.Visible = true;
                            Label1.Text = "Details stored offline. Retrieve at voting centre";
                        }
                    }
                    else Label.Text = "E-mail adress has not been registered.";
                }
            }

            catch
            {
                Label.Text = "The adress entered is invalid.";
            }
        }
    }
}