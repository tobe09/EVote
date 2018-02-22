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
    public partial class RegisterKey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void adminClick(object sender, EventArgs e)
        {
            //confirm administrative status
            if (admNameBox.Text.ToUpper() == "adminregister".ToUpper() && adminBox.Text.ToUpper() == "admin101".ToUpper())
            { adminButton.Text = "Accepted"; holdLabel.Text = "Administrative credential accepted"; admNameBox.Text = ""; }
            else
            { adminButton.Text = "Submit"; holdLabel.Text = "Wrong Administrative credentials."; }
        }

        protected void keygenButton_Click(object sender, EventArgs e)
        {
            if (adminButton.Text == "Accepted")
            {
                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();

                //generate random number for student
                Random r = new Random();

                //check student information entered
                if (matricBox.Text.Length == 12 && nameBox.Text.Length >= 3)
                {
                    //check for previous registration
                    using (SqlCommand cm = new SqlCommand("SELECT * FROM KeyCodes WHERE Matric_no = @mat", con))
                    {
                        cm.Parameters.AddWithValue("@mat", matricBox.Text);
                        SqlDataAdapter da = new SqlDataAdapter(cm);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        //insert values
                        if (dt.Rows.Count == 0)
                        {
                            SqlCommand cmd = new SqlCommand("INSERT INTO KeyCodes(Name, Matric_no, Id, UsageInt) VALUES (@name, @Matric, @Keycode, @usage)", con);
                            cmd.CommandType = CommandType.Text;
                            int zero = 0;
                            int key = r.Next(11111111, 99999999);
                            keycodeBox.Text = key.ToString();
                            cmd.Parameters.AddWithValue("@name", nameBox.Text);
                            cmd.Parameters.AddWithValue("@Matric", matricBox.Text);
                            cmd.Parameters.AddWithValue("@Keycode", key.ToString());
                            cmd.Parameters.AddWithValue("@usage", zero);
                            cmd.ExecuteNonQuery();
                            headLabel.Text = "Keycode Generated";
                            infoLabel.Text = "This keycode is unique to you, and must as such be protected";
                        }
                        
                        //if user has been given a keycode
                        else
                        {
                            SqlCommand cmds = new SqlCommand("SELECT Id FROM KeyCodes WHERE Matric_no=@Matric", con);
                            cmds.Parameters.AddWithValue("@Matric", matricBox.Text);
                            String id = cmds.ExecuteScalar().ToString();
                            cmds.ExecuteNonQuery();
                            keycodeBox.Text = id;
                            headLabel.Text = "Keycode Generated";
                            infoLabel.Text = "You have been given a Keycode";
                        }
                    }
                }
                else
                {
                    if (matricBox.Text.Length != 12) infoLabel.Text = "Wrong matriculation number entered";
                    else infoLabel.Text = "Invalid name entered";
                }
            }
            else
            {
                holdLabel.Text = "Please enter administrative credentials to generate key!";
                infoLabel.Text = "";
                keycodeBox.Text = "";
            }
        }

    }
}