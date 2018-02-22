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
    public partial class ReportProblem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            submitLabel.Visible = false;
        }

        protected void submitClick(object sender, EventArgs e)
        {
            submitLabel.Visible = true;

            //validate name and message
            if (nameBox.Text.Length < 1 || messageBox.Text.Length < 1)
            {
                if (nameBox.Text.Length < 1) submitLabel.Text = "Please enter your name";
                else if (messageBox.Text.Length < 1) submitLabel.Text = "Please enter a Message";
            }

            else
            {
                //enter mail datails
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.Timeout = 10000;
                mail.From = new MailAddress("goldenboi039@gmail.com");
                mail.Subject = "Name: " + nameBox.Text + "\t Matric. No.: " + matricBox.Text + "\t Subject: " + subjectBox.Text;
                mail.Body = messageBox.Text;
                mail.To.Add("chineketobenna@yahoo.com");
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("goldenboi039@gmail.com", "248163264128");
                SmtpServer.EnableSsl = true;

                //save offline
                using (StreamWriter stw = File.AppendText(@"C:\Users\user\Desktop\WebApplication1\WebApplication1\getMessage.txt"))
                { stw.WriteLine("Name: " + nameBox.Text + "\t Matric. No.: " + matricBox.Text + "\t Subject: " + subjectBox.Text + "\r\nBody: " + messageBox.Text + "\r\n\r\n"); }
                try
                {
                    //send mail
                    SmtpServer.Send(mail);
                    submitLabel.Text = "Message sent";
                    using (StreamWriter stw = File.AppendText(@"C:\Users\user\Desktop\WebApplication1\WebApplication1\\getSentMessage.txt"))
                    { stw.WriteLine("Name: " + nameBox.Text + "\t Matric. No.: " + matricBox.Text + "\t Subject: " + subjectBox.Text + "\r\nBody: " + messageBox.Text + "\r\n\r\n"); }
                }
                catch (Exception ex)
                {
                    submitLabel.Text = "Could not send message. Error= " + ex.Message+"<br>Message stored offline, go to Computer Centre";
                }
            }
        }
    }
}