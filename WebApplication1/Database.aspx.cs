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
    public partial class Database : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //visibility of departments according to faculty
            if (fac2.SelectedIndex == 0) admd.Visible = true; else admd.Visible = false;
            if (fac2.SelectedIndex == 1) agrd.Visible = true; else agrd.Visible = false;
            if (fac2.SelectedIndex == 2) artd.Visible = true; else artd.Visible = false;
            if (fac2.SelectedIndex == 3) medd.Visible = true; else medd.Visible = false;
            if (fac2.SelectedIndex == 4) clid.Visible = true; else clid.Visible = false;
            if (fac2.SelectedIndex == 5) dend.Visible = true; else dend.Visible = false;
            if (fac2.SelectedIndex == 6) edud.Visible = true; else edud.Visible = false;
            if (fac2.SelectedIndex == 7) edmd.Visible = true; else edmd.Visible = false;
            if (fac2.SelectedIndex == 8) lawd.Visible = true; else lawd.Visible = false;
            if (fac2.SelectedIndex == 9) phmd.Visible = true; else phmd.Visible = false;
            if (fac2.SelectedIndex == 10) scid.Visible = true; else scid.Visible = false;
            if (fac2.SelectedIndex == 11) socd.Visible = true; else socd.Visible = false;
            if (fac2.SelectedIndex == 12) techd.Visible = true; else techd.Visible = false;
            if (fac2.SelectedIndex == 13) otherd.Visible = true; else otherd.Visible = false;
            if (fac2.SelectedIndex == 14) alld.Visible = true; else alld.Visible = false;

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
            if (fac.SelectedIndex == 13) other.Visible = true; else other.Visible = false;
            if (fac.SelectedIndex == 14) all.Visible = true; else all.Visible = false;
        }

        //confirm adminnistrative credentials
        protected void adminClick(object sender, EventArgs e)
        {
            if (nameBox.Text.ToUpper() == "admindatabase".ToUpper() && adminBox.Text.ToUpper() == "admin101".ToUpper())
            { adminButton.Text = "Accepted"; holdLabel.Text = "Administrative credentials accepted"; nameBox.Text = ""; }
            else
            { adminButton.Text = "Submit"; holdLabel.Text = "Wrong Administrative credentials."; }
        }

        protected void userdClick(object sender, EventArgs e)
        {
            if (adminButton.Text == "Accepted")
            {
                using (SqlConnection cons = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    cons.Open();

                    //display users table
                    SqlCommand cd = new SqlCommand("SELECT * FROM Users", cons);
                    cd.ExecuteNonQuery();
                    SqlDataAdapter da1 = new SqlDataAdapter(cd);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    StringBuilder html = new StringBuilder();
                    SqlDataReader dr = cd.ExecuteReader();
                    html.Append("<table border='1'>");
                    html.Append("<tr> <b>USERS<b></tr><br/>");
                    html.Append("<tr>");
                    foreach (DataColumn column in dt1.Columns)
                    {
                        html.Append("<th>");
                        html.Append(column.ColumnName);
                        html.Append("</th>");
                    }
                    html.Append("</tr>");
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            html.Append("<tr>");
                            html.Append("<td>" + dr["Serial_no"] + "</td>");
                            html.Append("<td>" + dr["Username"] + "</td>");
                            html.Append("<td>" + dr["Password"] + "</td>");
                            html.Append("<td>" + dr["Name"] + "</td>");
                            html.Append("<td>" + dr["Matric_no"] + "</td>");
                            html.Append("<td>" + dr["Faculty"] + "</td>");
                            html.Append("<td>" + dr["Department"] + "</td>");
                            html.Append("<td>" + dr["Level"] + "</td>");
                            html.Append("<td>" + dr["Phone_no"] + "</td>");
                            html.Append("<td>" + dr["Email"] + "</td>");
                            html.Append("<td>" + dr["KeyCode"] + "</td>");
                            html.Append("<td>" + dr["HaveVoted"] + "</td>");
                            html.Append("</tr>");
                        }
                    }
                    html.Append("</table>");
                    ph.Controls.Add(new Literal { Text = html.ToString() });
                    dr.Close();
                    dr.Dispose();
                    contentLabel.Text = "Table content has been displayed";
                    cons.Dispose();
                }
            }
            else holdLabel.Text = "Please enter administrative credentials to view or delete table content!";
        }

        //display faculty table
        protected void facdClick(object sender, EventArgs e)
        {
            if (adminButton.Text == "Accepted")
            {
                string facs = "";
                if (fac2.SelectedIndex == 0) facs = "Administration";
                else if (fac2.SelectedIndex == 1) facs = "Agricultural_Sciences";
                else if (fac2.SelectedIndex == 2) facs = "Arts";
                else if (fac2.SelectedIndex == 3) facs = "Basic_Medical_Sciences";
                else if (fac2.SelectedIndex == 4) facs = "Clinical_Sciences";
                else if (fac2.SelectedIndex == 5) facs = "Dentistry";
                else if (fac2.SelectedIndex == 6) facs = "Education";
                else if (fac2.SelectedIndex == 7) facs = "EDM";
                else if (fac2.SelectedIndex == 8) facs = "Law";
                else if (fac2.SelectedIndex == 9) facs = "Pharmacy";
                else if (fac2.SelectedIndex == 10) facs = "Sciences";
                else if (fac2.SelectedIndex == 11) facs = "Social_Sciences";
                else if (fac2.SelectedIndex == 12) facs = "Technology";
                else if (fac2.SelectedIndex == 13) facs = "Other_Faculty";
                else facs = "Administration";
                using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cd1 = new SqlCommand("SELECT * FROM " + facs, con);
                    cd1.ExecuteNonQuery();
                    SqlDataAdapter da1 = new SqlDataAdapter(cd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    StringBuilder html = new StringBuilder();
                    SqlDataReader dr = cd1.ExecuteReader();
                    html.Append("<table border='1'>");
                    html.Append("<tr>" + "<b>" + facs.ToUpper() + "</b>" + "</tr>");
                    html.Append("<tr>");
                    foreach (DataColumn column in dt1.Columns)
                    {
                        html.Append("<th>");
                        html.Append(column.ColumnName);
                        html.Append("</th>");
                    }
                    html.Append("</tr>");
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            html.Append("<tr>");
                            html.Append("<td>" + dr["Serial_no"] + "</td>");
                            html.Append("<td>" + dr["Username"] + "</td>");
                            html.Append("<td>" + dr["Password"] + "</td>");
                            html.Append("<td>" + dr["Name"] + "</td>");
                            html.Append("<td>" + dr["Matric_no"] + "</td>");
                            html.Append("<td>" + dr["Department"] + "</td>");
                            html.Append("<td>" + dr["Level"] + "</td>");
                            html.Append("<td>" + dr["Phone_no"] + "</td>");
                            html.Append("<td>" + dr["Email"] + "</td>");
                            html.Append("<td>" + dr["KeyCode"] + "</td>");
                            html.Append("<td>" + dr["HaveVoted"] + "</td>");
                            html.Append("</tr>");
                        }
                    }
                    html.Append("</table>");
                    ph.Controls.Add(new Literal { Text = html.ToString() });
                    dr.Close();
                    dr.Dispose();

                    //display all faculties table
                    if (fac2.SelectedIndex == 14)
                    {
                        String[] facs2 = { "Agricultural_Sciences", "Arts", "Basic_Medical_Sciences", "Clinical_Sciences", "Dentistry", "Education", "EDM", "Law", "Pharmacy", "Sciences", "Social_Sciences", "Technology", "Other_Faculty" };
                        for (int i = 0; i < 12; i++)
                        {
                            SqlCommand cd = new SqlCommand("SELECT * FROM " + facs2[i], con);
                            cd.ExecuteNonQuery();
                            SqlDataAdapter da = new SqlDataAdapter(cd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            StringBuilder html1 = new StringBuilder();
                            SqlDataReader dr1 = cd.ExecuteReader();
                            html1.Append("<table border='1'>");
                            html1.Append("<br/><tr><b>" + facs2[i].ToUpper() + "</b></tr>");
                            html1.Append("<tr>");
                            foreach (DataColumn column in dt.Columns)
                            {
                                html1.Append("<th>");
                                html1.Append(column.ColumnName);
                                html1.Append("</th>");
                            }
                            html1.Append("</tr>");
                            if (dr1.HasRows)
                            {
                                while (dr1.Read())
                                {
                                    html1.Append("<tr>");
                                    html1.Append("<td>" + dr1["Serial_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Username"] + "</td>");
                                    html1.Append("<td>" + dr1["Password"] + "</td>");
                                    html1.Append("<td>" + dr1["Name"] + "</td>");
                                    html1.Append("<td>" + dr1["Matric_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Department"] + "</td>");
                                    html1.Append("<td>" + dr1["Level"] + "</td>");
                                    html1.Append("<td>" + dr1["Phone_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Email"] + "</td>");
                                    html1.Append("<td>" + dr1["KeyCode"] + "</td>");
                                    html1.Append("<td>" + dr1["HaveVoted"] + "</td>");
                                    html1.Append("</tr>");
                                }
                            }
                            html1.Append("</table>");
                            ph.Controls.Add(new Literal { Text = html1.ToString() });
                            dr1.Close();
                            dr1.Dispose();
                        }
                    }
                    contentLabel.Text = "Table(s) content has been displayed";
                }
            }

            else holdLabel.Text = "Please enter administrative credentials to view or delete table content!";
        }

        //display departmental table
        protected void deptdClick(object sender, EventArgs e)
        {
            String dept = "";
            if (adminButton.Text == "Accepted")
            {
                if (admd.Visible == true)
                {
                    if (admd.SelectedIndex == 0) dept = "International_Relations";
                    else if (admd.SelectedIndex == 1) dept = "Local_Government_Studies";
                    else if (admd.SelectedIndex == 2) dept = "Management_and_Accounting";
                    else if (admd.SelectedIndex == 3) dept = "Public_Administration";
                    else if (admd.SelectedIndex == 4) dept = "Other_Administration";
                    else dept = "International_Relations";
                }
                if (agrd.Visible == true)
                {
                    if (agrd.SelectedIndex == 0) dept = "Agricultural_Economics";
                    else if (agrd.SelectedIndex == 1) dept = "Agricultural_Extension";
                    else if (agrd.SelectedIndex == 2) dept = "Animal_Science";
                    else if (agrd.SelectedIndex == 3) dept = "Crop_Production";
                    else if (agrd.SelectedIndex == 4) dept = "Family_Nutrition";
                    else if (agrd.SelectedIndex == 5) dept = "Soil_Science";
                    else if (agrd.SelectedIndex == 6) dept = "Other_Agricultural_Sciences";
                    else dept = "Agricultural_Economics";
                }
                if (artd.Visible == true)
                {
                    if (artd.SelectedIndex == 0) dept = "Dramatic_Arts";
                    else if (artd.SelectedIndex == 1) dept = "English_Language";
                    else if (artd.SelectedIndex == 2) dept = "Foreign_Languages";
                    else if (artd.SelectedIndex == 3) dept = "History";
                    else if (artd.SelectedIndex == 4) dept = "Linguistics";
                    else if (artd.SelectedIndex == 5) dept = "Music";
                    else if (artd.SelectedIndex == 6) dept = "Philosophy";
                    else if (artd.SelectedIndex == 7) dept = "Religious_Studies";
                    else if (artd.SelectedIndex == 8) dept = "Other_Arts";
                    else dept = "Dramatic_Arts";
                }
                if (medd.Visible == true)
                {
                    if (medd.SelectedIndex == 0) dept = "Medical_Rehabilitation";
                    else if (medd.SelectedIndex == 1) dept = "Nursing";
                    else if (medd.SelectedIndex == 2) dept = "Other_Basic_Medical_Sciences";
                    else dept = "Medical_Rehabilitation";
                }
                if (clid.Visible == true)
                {
                    if (clid.SelectedIndex == 0) dept = "Medicine_and_Surgery";
                    else if (clid.SelectedIndex == 1) dept = "Other_Clinical_Sciences";
                    else dept = "Medicine_and_Surgery";
                }
                if (dend.Visible == true)
                {
                    if (dend.SelectedIndex == 0) dept = "Dentistry_Department";
                    else if (dend.SelectedIndex == 1) dept = "Other_Dentistry";
                    else dept = "Dentistry_Departent";
                }
                if (edud.Visible == true)
                {
                    if (edud.SelectedIndex == 0) dept = "Adult_Education";
                    else if (edud.SelectedIndex == 1) dept = "Continuing_Education";
                    else if (edud.SelectedIndex == 2) dept = "Educational_Administration";
                    else if (edud.SelectedIndex == 3) dept = "Educational_Foundation";
                    else if (edud.SelectedIndex == 4) dept = "Educational_Technology";
                    else if (edud.SelectedIndex == 5) dept = "Physical_Education";
                    else if (edud.SelectedIndex == 6) dept = "Special_Education";
                    else if (edud.SelectedIndex == 7) dept = "Other_Education";
                    else dept = "Adult_Education";
                }
                if (edmd.Visible == true)
                {
                    if (edmd.SelectedIndex == 0) dept = "Architecture";
                    else if (edmd.SelectedIndex == 1) dept = "Building";
                    else if (edmd.SelectedIndex == 2) dept = "Estate_Management";
                    else if (edud.SelectedIndex == 3) dept = "Fine_Arts";
                    else if (edmd.SelectedIndex == 4) dept = "Quantity_Surveying";
                    else if (edmd.SelectedIndex == 5) dept = "Urban_and_Rural_Planning";
                    else if (edmd.SelectedIndex == 6) dept = "Other_EDM";
                    else dept = "Architecture";
                }
                if (lawd.Visible == true)
                {
                    if (lawd.SelectedIndex == 0) dept = "Law_Department";
                    else if (lawd.SelectedIndex == 1) dept = "Other_Law";
                    else dept = "Law_Department";
                }
                if (phmd.Visible == true)
                {
                    if (phmd.SelectedIndex == 0) dept = "Pharmacy_Department";
                    else if (phmd.SelectedIndex == 1) dept = "Other_Pharmacy";
                    else dept = "Pharmacy_Department";
                }
                if (scid.Visible == true)
                {
                    if (scid.SelectedIndex == 0) dept = "Biochemistry";
                    else if (scid.SelectedIndex == 1) dept = "Botany";
                    else if (scid.SelectedIndex == 2) dept = "Chemistry";
                    else if (scid.SelectedIndex == 3) dept = "Conservative_Science";
                    else if (scid.SelectedIndex == 4) dept = "Geology";
                    else if (scid.SelectedIndex == 5) dept = "Mathematics";
                    else if (scid.SelectedIndex == 6) dept = "Microbiology";
                    else if (scid.SelectedIndex == 7) dept = "Physics";
                    else if (scid.SelectedIndex == 8) dept = "Zoology";
                    else if (scid.SelectedIndex == 9) dept = "Other_Sciences";
                    else dept = "Biochemistry";
                }
                if (socd.Visible == true)
                {
                    if (socd.SelectedIndex == 0) dept = "Demography";
                    else if (socd.SelectedIndex == 1) dept = "Economics";
                    else if (socd.SelectedIndex == 2) dept = "Geography";
                    else if (socd.SelectedIndex == 3) dept = "Philosophy";
                    else if (socd.SelectedIndex == 4) dept = "Political_Science";
                    else if (socd.SelectedIndex == 5) dept = "Psychology";
                    else if (socd.SelectedIndex == 6) dept = "Sociology";
                    else if (socd.SelectedIndex == 7) dept = "Other_Social_Sciences";
                    else dept = "Demography";
                }
                if (techd.Visible == true)
                {
                    if (techd.SelectedIndex == 0) dept = "Agricultural_Engineering";
                    else if (techd.SelectedIndex == 1) dept = "Chemical_Engineering";
                    else if (techd.SelectedIndex == 2) dept = "Civil_Engineering";
                    else if (techd.SelectedIndex == 3) dept = "Computer_Science_and_Engineering";
                    else if (techd.SelectedIndex == 4) dept = "Electrical_Engineering";
                    else if (techd.SelectedIndex == 5) dept = "Food_Science";
                    else if (techd.SelectedIndex == 6) dept = "Material_Science";
                    else if (techd.SelectedIndex == 7) dept = "Mechanical_Engineering";
                    else if (techd.SelectedIndex == 8) dept = "Other_Technology";
                    else dept = "Agricultural_Engineering";
                }

                if (otherd.Visible == true && otherd.SelectedIndex == 0)
                { dept = "Other_Department"; }

                if (alld.SelectedIndex == 0 && alld.Visible == true)
                { dept = "International_Relations"; }

                using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cd1 = new SqlCommand("SELECT * FROM " + dept, con);
                    cd1.ExecuteNonQuery();
                    SqlDataAdapter da1 = new SqlDataAdapter(cd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    StringBuilder html = new StringBuilder();
                    SqlDataReader dr = cd1.ExecuteReader();
                    html.Append("<table border='1'>");
                    html.Append("<tr>" + "<b>" + dept.ToUpper() + "</b>" + "</tr>");
                    html.Append("<tr>");
                    foreach (DataColumn column in dt1.Columns)
                    {
                        html.Append("<th>");
                        html.Append(column.ColumnName);
                        html.Append("</th>");
                    }
                    html.Append("</tr>");
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            html.Append("<tr>");
                            html.Append("<td>" + dr["Serial_no"] + "</td>");
                            html.Append("<td>" + dr["Username"] + "</td>");
                            html.Append("<td>" + dr["Password"] + "</td>");
                            html.Append("<td>" + dr["Name"] + "</td>");
                            html.Append("<td>" + dr["Matric_no"] + "</td>");
                            html.Append("<td>" + dr["Level"] + "</td>");
                            html.Append("<td>" + dr["Phone_no"] + "</td>");
                            html.Append("<td>" + dr["Email"] + "</td>");
                            html.Append("<td>" + dr["KeyCode"] + "</td>");
                            html.Append("<td>" + dr["HaveVoted"] + "</td>");
                            html.Append("</tr>");
                        }
                    }
                    html.Append("</table>");
                    ph.Controls.Add(new Literal { Text = html.ToString() });
                    dr.Close();
                    dr.Dispose();

                    //display all departments table in a faculty
                    if (admd.SelectedIndex == 5 && admd.Visible == true)
                    {
                        String[] dept2 = { "Local_Government_Studies", "Management_and_Accounting", "Public_Administration", "Other_Administration" };
                        for (int i = 0; i < 4; i++)
                        {
                            SqlCommand cd = new SqlCommand("SELECT * FROM " + dept2[i], con);
                            cd.ExecuteNonQuery();
                            SqlDataAdapter da = new SqlDataAdapter(cd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            StringBuilder html1 = new StringBuilder();
                            SqlDataReader dr1 = cd.ExecuteReader();
                            html1.Append("<table border='1'>");
                            html1.Append("<br/><tr><b>" + dept2[i].ToUpper() + "</b></tr>");
                            html1.Append("<tr>");
                            foreach (DataColumn column in dt.Columns)
                            {
                                html1.Append("<th>");
                                html1.Append(column.ColumnName);
                                html1.Append("</th>");
                            }
                            html1.Append("</tr>");
                            if (dr1.HasRows)
                            {
                                while (dr1.Read())
                                {
                                    html1.Append("<tr>");
                                    html1.Append("<td>" + dr1["Serial_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Username"] + "</td>");
                                    html1.Append("<td>" + dr1["Password"] + "</td>");
                                    html1.Append("<td>" + dr1["Name"] + "</td>");
                                    html1.Append("<td>" + dr1["Matric_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Level"] + "</td>");
                                    html1.Append("<td>" + dr1["Phone_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Email"] + "</td>");
                                    html1.Append("<td>" + dr1["KeyCode"] + "</td>");
                                    html1.Append("<td>" + dr1["HaveVoted"] + "</td>");
                                    html1.Append("</tr>");
                                }
                            }
                            html1.Append("</table>");
                            ph.Controls.Add(new Literal { Text = html1.ToString() });
                            dr1.Close();
                            dr1.Dispose();
                        }
                    }

                    if (agrd.SelectedIndex == 7 && agrd.Visible == true)
                    {
                        String[] dept2 = { "Agricultural_Extension", "Animal_Science", "Crop_Production", "Family_Nutrition", "Soil_Science", "Other_Agricultural_Sciences" };
                        for (int i = 0; i < 6; i++)
                        {
                            SqlCommand cd = new SqlCommand("SELECT * FROM " + dept2[i], con);
                            cd.ExecuteNonQuery();
                            SqlDataAdapter da = new SqlDataAdapter(cd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            StringBuilder html1 = new StringBuilder();
                            SqlDataReader dr1 = cd.ExecuteReader();
                            html1.Append("<table border='1'>");
                            html1.Append("<br/><tr><b>" + dept2[i].ToUpper() + "</b></tr>");
                            html1.Append("<tr>");
                            foreach (DataColumn column in dt.Columns)
                            {
                                html1.Append("<th>");
                                html1.Append(column.ColumnName);
                                html1.Append("</th>");
                            }
                            html1.Append("</tr>");
                            if (dr1.HasRows)
                            {
                                while (dr1.Read())
                                {
                                    html1.Append("<tr>");
                                    html1.Append("<td>" + dr1["Serial_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Username"] + "</td>");
                                    html1.Append("<td>" + dr1["Password"] + "</td>");
                                    html1.Append("<td>" + dr1["Name"] + "</td>");
                                    html1.Append("<td>" + dr1["Matric_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Level"] + "</td>");
                                    html1.Append("<td>" + dr1["Phone_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Email"] + "</td>");
                                    html1.Append("<td>" + dr1["KeyCode"] + "</td>");
                                    html1.Append("<td>" + dr1["HaveVoted"] + "</td>");
                                    html1.Append("</tr>");
                                }
                            }
                            html1.Append("</table>");
                            ph.Controls.Add(new Literal { Text = html1.ToString() });
                            dr1.Close();
                            dr1.Dispose();
                        }
                    }

                    if (artd.SelectedIndex == 9 && artd.Visible == true)
                    {
                        String[] dept2 = { "English_Language", "Foreign_Languages", "History", "Linguistics", "Music", "Philosophy", "Religious_Studies", "Other_Arts" };
                        for (int i = 0; i < 8; i++)
                        {
                            SqlCommand cd = new SqlCommand("SELECT * FROM " + dept2[i], con);
                            cd.ExecuteNonQuery();
                            SqlDataAdapter da = new SqlDataAdapter(cd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            StringBuilder html1 = new StringBuilder();
                            SqlDataReader dr1 = cd.ExecuteReader();
                            html1.Append("<table border='1'>");
                            html1.Append("<br/><tr><b>" + dept2[i].ToUpper() + "</b></tr>");
                            html1.Append("<tr>");
                            foreach (DataColumn column in dt.Columns)
                            {
                                html1.Append("<th>");
                                html1.Append(column.ColumnName);
                                html1.Append("</th>");
                            }
                            html1.Append("</tr>");
                            if (dr1.HasRows)
                            {
                                while (dr1.Read())
                                {
                                    html1.Append("<tr>");
                                    html1.Append("<td>" + dr1["Serial_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Username"] + "</td>");
                                    html1.Append("<td>" + dr1["Password"] + "</td>");
                                    html1.Append("<td>" + dr1["Name"] + "</td>");
                                    html1.Append("<td>" + dr1["Matric_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Level"] + "</td>");
                                    html1.Append("<td>" + dr1["Phone_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Email"] + "</td>");
                                    html1.Append("<td>" + dr1["KeyCode"] + "</td>");
                                    html1.Append("<td>" + dr1["HaveVoted"] + "</td>");
                                    html1.Append("</tr>");
                                }
                            }
                            html1.Append("</table>");
                            ph.Controls.Add(new Literal { Text = html1.ToString() });
                            dr1.Close();
                            dr1.Dispose();
                        }
                    }

                    if (medd.SelectedIndex == 3 && medd.Visible == true)
                    {
                        String[] dept2 = { "Nursing", "Other_Basic_Medical_Sciences" };
                        for (int i = 0; i < 2; i++)
                        {
                            SqlCommand cd = new SqlCommand("SELECT * FROM " + dept2[i], con);
                            cd.ExecuteNonQuery();
                            SqlDataAdapter da = new SqlDataAdapter(cd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            StringBuilder html1 = new StringBuilder();
                            SqlDataReader dr1 = cd.ExecuteReader();
                            html1.Append("<table border='1'>");
                            html1.Append("<br/><tr><b>" + dept2[i].ToUpper() + "</b></tr>");
                            html1.Append("<tr>");
                            foreach (DataColumn column in dt.Columns)
                            {
                                html1.Append("<th>");
                                html1.Append(column.ColumnName);
                                html1.Append("</th>");
                            }
                            html1.Append("</tr>");
                            if (dr1.HasRows)
                            {
                                while (dr1.Read())
                                {
                                    html1.Append("<tr>");
                                    html1.Append("<td>" + dr1["Serial_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Username"] + "</td>");
                                    html1.Append("<td>" + dr1["Password"] + "</td>");
                                    html1.Append("<td>" + dr1["Name"] + "</td>");
                                    html1.Append("<td>" + dr1["Matric_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Level"] + "</td>");
                                    html1.Append("<td>" + dr1["Phone_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Email"] + "</td>");
                                    html1.Append("<td>" + dr1["KeyCode"] + "</td>");
                                    html1.Append("<td>" + dr1["HaveVoted"] + "</td>");
                                    html1.Append("</tr>");
                                }
                            }
                            html1.Append("</table>");
                            ph.Controls.Add(new Literal { Text = html1.ToString() });
                            dr1.Close();
                            dr1.Dispose();
                        }
                    }

                    if (clid.SelectedIndex == 2 && clid.Visible == true)
                    {
                        String[] dept2 = { "Other_Clinical_Sciences" };
                        for (int i = 0; i < 1; i++)
                        {
                            SqlCommand cd = new SqlCommand("SELECT * FROM " + dept2[i], con);
                            cd.ExecuteNonQuery();
                            SqlDataAdapter da = new SqlDataAdapter(cd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            StringBuilder html1 = new StringBuilder();
                            SqlDataReader dr1 = cd.ExecuteReader();
                            html1.Append("<table border='1'>");
                            html1.Append("<br/><tr><b>" + dept2[i].ToUpper() + "</b></tr>");
                            html1.Append("<tr>");
                            foreach (DataColumn column in dt.Columns)
                            {
                                html1.Append("<th>");
                                html1.Append(column.ColumnName);
                                html1.Append("</th>");
                            }
                            html1.Append("</tr>");
                            if (dr1.HasRows)
                            {
                                while (dr1.Read())
                                {
                                    html1.Append("<tr>");
                                    html1.Append("<td>" + dr1["Serial_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Username"] + "</td>");
                                    html1.Append("<td>" + dr1["Password"] + "</td>");
                                    html1.Append("<td>" + dr1["Name"] + "</td>");
                                    html1.Append("<td>" + dr1["Matric_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Level"] + "</td>");
                                    html1.Append("<td>" + dr1["Phone_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Email"] + "</td>");
                                    html1.Append("<td>" + dr1["KeyCode"] + "</td>");
                                    html1.Append("<td>" + dr1["HaveVoted"] + "</td>");
                                    html1.Append("</tr>");
                                }
                            }
                            html1.Append("</table>");
                            ph.Controls.Add(new Literal { Text = html1.ToString() });
                            dr1.Close();
                            dr1.Dispose();
                        }
                    }

                    if (dend.SelectedIndex == 2 && dend.Visible == true)
                    {
                        String[] dept2 = { "Other_Dentistry" };
                        for (int i = 0; i < 1; i++)
                        {
                            SqlCommand cd = new SqlCommand("SELECT * FROM " + dept2[i], con);
                            cd.ExecuteNonQuery();
                            SqlDataAdapter da = new SqlDataAdapter(cd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            StringBuilder html1 = new StringBuilder();
                            SqlDataReader dr1 = cd.ExecuteReader();
                            html1.Append("<table border='1'>");
                            html1.Append("<br/><tr><b>" + dept2[i].ToUpper() + "</b></tr>");
                            html1.Append("<tr>");
                            foreach (DataColumn column in dt.Columns)
                            {
                                html1.Append("<th>");
                                html1.Append(column.ColumnName);
                                html1.Append("</th>");
                            }
                            html1.Append("</tr>");
                            if (dr1.HasRows)
                            {
                                while (dr1.Read())
                                {
                                    html1.Append("<tr>");
                                    html1.Append("<td>" + dr1["Serial_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Username"] + "</td>");
                                    html1.Append("<td>" + dr1["Password"] + "</td>");
                                    html1.Append("<td>" + dr1["Name"] + "</td>");
                                    html1.Append("<td>" + dr1["Matric_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Level"] + "</td>");
                                    html1.Append("<td>" + dr1["Phone_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Email"] + "</td>");
                                    html1.Append("<td>" + dr1["KeyCode"] + "</td>");
                                    html1.Append("<td>" + dr1["HaveVoted"] + "</td>");
                                    html1.Append("</tr>");
                                }
                            }
                            html1.Append("</table>");
                            ph.Controls.Add(new Literal { Text = html1.ToString() });
                            dr1.Close();
                            dr1.Dispose();
                        }
                    }

                    if (edud.SelectedIndex == 8 && edud.Visible == true)
                    {
                        String[] dept2 = { "Continuing_Education", "Educational_Administration", "Educational_Foundation", "Educational_Technology", "Physical_Education", "Special_Education", "Other_Education" };
                        for (int i = 0; i < 7; i++)
                        {
                            SqlCommand cd = new SqlCommand("SELECT * FROM " + dept2[i], con);
                            cd.ExecuteNonQuery();
                            SqlDataAdapter da = new SqlDataAdapter(cd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            StringBuilder html1 = new StringBuilder();
                            SqlDataReader dr1 = cd.ExecuteReader();
                            html1.Append("<table border='1'>");
                            html1.Append("<br/><tr><b>" + dept2[i].ToUpper() + "</b></tr>");
                            html1.Append("<tr>");
                            foreach (DataColumn column in dt.Columns)
                            {
                                html1.Append("<th>");
                                html1.Append(column.ColumnName);
                                html1.Append("</th>");
                            }
                            html1.Append("</tr>");
                            if (dr1.HasRows)
                            {
                                while (dr1.Read())
                                {
                                    html1.Append("<tr>");
                                    html1.Append("<td>" + dr1["Serial_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Username"] + "</td>");
                                    html1.Append("<td>" + dr1["Password"] + "</td>");
                                    html1.Append("<td>" + dr1["Name"] + "</td>");
                                    html1.Append("<td>" + dr1["Matric_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Level"] + "</td>");
                                    html1.Append("<td>" + dr1["Phone_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Email"] + "</td>");
                                    html1.Append("<td>" + dr1["KeyCode"] + "</td>");
                                    html1.Append("<td>" + dr1["HaveVoted"] + "</td>");
                                    html1.Append("</tr>");
                                }
                            }
                            html1.Append("</table>");
                            ph.Controls.Add(new Literal { Text = html1.ToString() });
                            dr1.Close();
                            dr1.Dispose();
                        }
                    }

                    if (edmd.SelectedIndex == 7 && edmd.Visible == true)
                    {
                        String[] dept2 = { "Building", "Estate_Management", "Fine_Arts", "Quantity_Surveying", "Urban_and_Rural_Planning", "Other_EDM" };
                        for (int i = 0; i < 6; i++)
                        {
                            SqlCommand cd = new SqlCommand("SELECT * FROM " + dept2[i], con);
                            cd.ExecuteNonQuery();
                            SqlDataAdapter da = new SqlDataAdapter(cd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            StringBuilder html1 = new StringBuilder();
                            SqlDataReader dr1 = cd.ExecuteReader();
                            html1.Append("<table border='1'>");
                            html1.Append("<br/><tr><b>" + dept2[i].ToUpper() + "</b></tr>");
                            html1.Append("<tr>");
                            foreach (DataColumn column in dt.Columns)
                            {
                                html1.Append("<th>");
                                html1.Append(column.ColumnName);
                                html1.Append("</th>");
                            }
                            html1.Append("</tr>");
                            if (dr1.HasRows)
                            {
                                while (dr1.Read())
                                {
                                    html1.Append("<tr>");
                                    html1.Append("<td>" + dr1["Serial_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Username"] + "</td>");
                                    html1.Append("<td>" + dr1["Password"] + "</td>");
                                    html1.Append("<td>" + dr1["Name"] + "</td>");
                                    html1.Append("<td>" + dr1["Matric_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Level"] + "</td>");
                                    html1.Append("<td>" + dr1["Phone_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Email"] + "</td>");
                                    html1.Append("<td>" + dr1["KeyCode"] + "</td>");
                                    html1.Append("<td>" + dr1["HaveVoted"] + "</td>");
                                    html1.Append("</tr>");
                                }
                            }
                            html1.Append("</table>");
                            ph.Controls.Add(new Literal { Text = html1.ToString() });
                            dr1.Close();
                            dr1.Dispose();
                        }
                    }

                    if (lawd.SelectedIndex == 2 && lawd.Visible == true)
                    {
                        String[] dept2 = { "Other_Law" };
                        for (int i = 0; i < 1; i++)
                        {
                            SqlCommand cd = new SqlCommand("SELECT * FROM " + dept2[i], con);
                            cd.ExecuteNonQuery();
                            SqlDataAdapter da = new SqlDataAdapter(cd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            StringBuilder html1 = new StringBuilder();
                            SqlDataReader dr1 = cd.ExecuteReader();
                            html1.Append("<table border='1'>");
                            html1.Append("<br/><tr><b>" + dept2[i].ToUpper() + "</b></tr>");
                            html1.Append("<tr>");
                            foreach (DataColumn column in dt.Columns)
                            {
                                html1.Append("<th>");
                                html1.Append(column.ColumnName);
                                html1.Append("</th>");
                            }
                            html1.Append("</tr>");
                            if (dr1.HasRows)
                            {
                                while (dr1.Read())
                                {
                                    html1.Append("<tr>");
                                    html1.Append("<td>" + dr1["Serial_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Username"] + "</td>");
                                    html1.Append("<td>" + dr1["Password"] + "</td>");
                                    html1.Append("<td>" + dr1["Name"] + "</td>");
                                    html1.Append("<td>" + dr1["Matric_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Level"] + "</td>");
                                    html1.Append("<td>" + dr1["Phone_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Email"] + "</td>");
                                    html1.Append("<td>" + dr1["KeyCode"] + "</td>");
                                    html1.Append("<td>" + dr1["HaveVoted"] + "</td>");
                                    html1.Append("</tr>");
                                }
                            }
                            html1.Append("</table>");
                            ph.Controls.Add(new Literal { Text = html1.ToString() });
                            dr1.Close();
                            dr1.Dispose();
                        }
                    }

                    if (phmd.SelectedIndex == 2 && phmd.Visible == true)
                    {
                        String[] dept2 = { "Other_Pharmacy" };
                        for (int i = 0; i < 1; i++)
                        {
                            SqlCommand cd = new SqlCommand("SELECT * FROM " + dept2[i], con);
                            cd.ExecuteNonQuery();
                            SqlDataAdapter da = new SqlDataAdapter(cd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            StringBuilder html1 = new StringBuilder();
                            SqlDataReader dr1 = cd.ExecuteReader();
                            html1.Append("<table border='1'>");
                            html1.Append("<br/><tr><b>" + dept2[i].ToUpper() + "</b></tr>");
                            html1.Append("<tr>");
                            foreach (DataColumn column in dt.Columns)
                            {
                                html1.Append("<th>");
                                html1.Append(column.ColumnName);
                                html1.Append("</th>");
                            }
                            html1.Append("</tr>");
                            if (dr1.HasRows)
                            {
                                while (dr1.Read())
                                {
                                    html1.Append("<tr>");
                                    html1.Append("<td>" + dr1["Serial_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Username"] + "</td>");
                                    html1.Append("<td>" + dr1["Password"] + "</td>");
                                    html1.Append("<td>" + dr1["Name"] + "</td>");
                                    html1.Append("<td>" + dr1["Matric_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Level"] + "</td>");
                                    html1.Append("<td>" + dr1["Phone_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Email"] + "</td>");
                                    html1.Append("<td>" + dr1["KeyCode"] + "</td>");
                                    html1.Append("<td>" + dr1["HaveVoted"] + "</td>");
                                    html1.Append("</tr>");
                                }
                            }
                            html1.Append("</table>");
                            ph.Controls.Add(new Literal { Text = html1.ToString() });
                            dr1.Close();
                            dr1.Dispose();
                        }
                    }

                    if (scid.SelectedIndex == 9 && scid.Visible == true)
                    {
                        String[] dept2 = { "Botany", "Chemistry", "Conservative_Science", "Geology", "Mathematics", "Microbiology", "Physics", "Zoology", "Other_Sciences" };
                        for (int i = 0; i < 8; i++)
                        {
                            SqlCommand cd = new SqlCommand("SELECT * FROM " + dept2[i], con);
                            cd.ExecuteNonQuery();
                            SqlDataAdapter da = new SqlDataAdapter(cd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            StringBuilder html1 = new StringBuilder();
                            SqlDataReader dr1 = cd.ExecuteReader();
                            html1.Append("<table border='1'>");
                            html1.Append("<br/><tr><b>" + dept2[i].ToUpper() + "</b></tr>");
                            html1.Append("<tr>");
                            foreach (DataColumn column in dt.Columns)
                            {
                                html1.Append("<th>");
                                html1.Append(column.ColumnName);
                                html1.Append("</th>");
                            }
                            html1.Append("</tr>");
                            if (dr1.HasRows)
                            {
                                while (dr1.Read())
                                {
                                    html1.Append("<tr>");
                                    html1.Append("<td>" + dr1["Serial_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Username"] + "</td>");
                                    html1.Append("<td>" + dr1["Password"] + "</td>");
                                    html1.Append("<td>" + dr1["Name"] + "</td>");
                                    html1.Append("<td>" + dr1["Matric_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Level"] + "</td>");
                                    html1.Append("<td>" + dr1["Phone_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Email"] + "</td>");
                                    html1.Append("<td>" + dr1["KeyCode"] + "</td>");
                                    html1.Append("<td>" + dr1["HaveVoted"] + "</td>");
                                    html1.Append("</tr>");
                                }
                            }
                            html1.Append("</table>");
                            ph.Controls.Add(new Literal { Text = html1.ToString() });
                            dr1.Close();
                            dr1.Dispose();
                        }
                    }

                    if (socd.SelectedIndex == 8 && socd.Visible == true)
                    {
                        String[] dept2 = { "Economics", "Geography", "Philosophy", "Political_Science", "Psychology", "Sociology", "Other_Social_Sciences" };
                        for (int i = 0; i < 7; i++)
                        {
                            SqlCommand cd = new SqlCommand("SELECT * FROM " + dept2[i], con);
                            cd.ExecuteNonQuery();
                            SqlDataAdapter da = new SqlDataAdapter(cd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            StringBuilder html1 = new StringBuilder();
                            SqlDataReader dr1 = cd.ExecuteReader();
                            html1.Append("<table border='1'>");
                            html1.Append("<br/><tr><b>" + dept2[i].ToUpper() + "</b></tr>");
                            html1.Append("<tr>");
                            foreach (DataColumn column in dt.Columns)
                            {
                                html1.Append("<th>");
                                html1.Append(column.ColumnName);
                                html1.Append("</th>");
                            }
                            html1.Append("</tr>");
                            if (dr1.HasRows)
                            {
                                while (dr1.Read())
                                {
                                    html1.Append("<tr>");
                                    html1.Append("<td>" + dr1["Serial_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Username"] + "</td>");
                                    html1.Append("<td>" + dr1["Password"] + "</td>");
                                    html1.Append("<td>" + dr1["Name"] + "</td>");
                                    html1.Append("<td>" + dr1["Matric_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Level"] + "</td>");
                                    html1.Append("<td>" + dr1["Phone_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Email"] + "</td>");
                                    html1.Append("<td>" + dr1["KeyCode"] + "</td>");
                                    html1.Append("<td>" + dr1["HaveVoted"] + "</td>");
                                    html1.Append("</tr>");
                                }
                            }
                            html1.Append("</table>");
                            ph.Controls.Add(new Literal { Text = html1.ToString() });
                            dr1.Close();
                            dr1.Dispose();
                        }
                    }

                    if (techd.SelectedIndex == 9 && techd.Visible == true)
                    {
                        String[] dept2 = { "Chemical_Engineering", "Civil_Engineering", "Computer_Science_and_Engineering", "Electrical_Engineering", "Food_Science", "Material_Science", "Mechanical_Engineering", "Other_Technology" };
                        for (int i = 0; i < 8; i++)
                        {
                            SqlCommand cd = new SqlCommand("SELECT * FROM " + dept2[i], con);
                            cd.ExecuteNonQuery();
                            SqlDataAdapter da = new SqlDataAdapter(cd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            StringBuilder html1 = new StringBuilder();
                            SqlDataReader dr1 = cd.ExecuteReader();
                            html1.Append("<table border='1'>");
                            html1.Append("<br/><tr><b>" + dept2[i].ToUpper() + "</b></tr>");
                            html1.Append("<tr>");
                            foreach (DataColumn column in dt.Columns)
                            {
                                html1.Append("<th>");
                                html1.Append(column.ColumnName);
                                html1.Append("</th>");
                            }
                            html1.Append("</tr>");
                            if (dr1.HasRows)
                            {
                                while (dr1.Read())
                                {
                                    html1.Append("<tr>");
                                    html1.Append("<td>" + dr1["Serial_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Username"] + "</td>");
                                    html1.Append("<td>" + dr1["Password"] + "</td>");
                                    html1.Append("<td>" + dr1["Name"] + "</td>");
                                    html1.Append("<td>" + dr1["Matric_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Level"] + "</td>");
                                    html1.Append("<td>" + dr1["Phone_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Email"] + "</td>");
                                    html1.Append("<td>" + dr1["KeyCode"] + "</td>");
                                    html1.Append("<td>" + dr1["HaveVoted"] + "</td>");
                                    html1.Append("</tr>");
                                }
                            }
                            html1.Append("</table>");
                            ph.Controls.Add(new Literal { Text = html1.ToString() });
                            dr1.Close();
                            dr1.Dispose();
                        }
                    }

                    //display all departments table
                    if (alld.SelectedIndex == 0 && alld.Visible == true)
                    {
                        String[] dept2 = {"Local_Government_Studies","Management_and_Accounting","Public_Administration","Other_Administration", "Agricultural_Economics","Agricultural_Extension","Animal_Science", "Crop_Production","Family_Nutrition","Soil_Science","Other_Agricultural_Sciences",
                                      "Dramatic_Arts","English_Language","Foreign_Languages","History","Linguistics","Music", "Philosophy","Religious_Studies","Other_Arts","Medical_Rehabilitation","Nursing","Other_Basic_Medical_Sciences",
                                      "Medicine_and_Surgery","Other_Clinical_Sciences","Dentistry_Department","Other_Dentistry","Adult_Education","Continuing_Education","Educational_Administration","Educational_Foundation","Educational_Technology","Physical_Education",
                                      "Special_Education","Other_Education","Architecture","Building","Estate_Management","Fine_Arts","Quantity_Surveying","Urban_and_Rural_Planning","Other_EDM","Law_Department",
                                      "Other_Law","Pharmacy_Department","Other_Pharmacy","Biochemistry","Botany","Chemistry","Conservative_Science","Geology","Mathematics",
                                      "Microbiology","Physics", "Zoology","Other_Sciences","Demography","Economics","Geography","Philosophy","Political_Science","Psychology",
                                      "Sociology","Other_Social_Sciences","Agricultural_Engineering","Chemical_Engineering","Civil_Engineering","Computer_Science_and_Engineering","Electrical_Engineering","Food_Science","Material_Science","Mechanical_Engineering","Other_Technology", "Other_Department" };
                        for (int i = 0; i < 74; i++)
                        {
                            SqlCommand cd = new SqlCommand("SELECT * FROM " + dept2[i], con);
                            cd.ExecuteNonQuery();
                            SqlDataAdapter da = new SqlDataAdapter(cd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            StringBuilder html1 = new StringBuilder();
                            SqlDataReader dr1 = cd.ExecuteReader();
                            html1.Append("<table border='1'>");
                            html1.Append("<br/><tr><b>" + dept2[i].ToUpper() + "</b></tr>");
                            html1.Append("<tr>");
                            foreach (DataColumn column in dt.Columns)
                            {
                                html1.Append("<th>");
                                html1.Append(column.ColumnName);
                                html1.Append("</th>");
                            }
                            html1.Append("</tr>");
                            if (dr1.HasRows)
                            {
                                while (dr1.Read())
                                {
                                    html1.Append("<tr>");
                                    html1.Append("<td>" + dr1["Serial_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Username"] + "</td>");
                                    html1.Append("<td>" + dr1["Password"] + "</td>");
                                    html1.Append("<td>" + dr1["Name"] + "</td>");
                                    html1.Append("<td>" + dr1["Matric_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Level"] + "</td>");
                                    html1.Append("<td>" + dr1["Phone_no"] + "</td>");
                                    html1.Append("<td>" + dr1["Email"] + "</td>");
                                    html1.Append("<td>" + dr1["KeyCode"] + "</td>");
                                    html1.Append("<td>" + dr1["HaveVoted"] + "</td>");
                                    html1.Append("</tr>");
                                }
                            }
                            html1.Append("</table>");
                            ph.Controls.Add(new Literal { Text = html1.ToString() });
                            dr1.Close();
                            dr1.Dispose();
                        }
                    }
                    contentLabel.Text = "Table(s) content has been displayed";
                }
            }

            else holdLabel.Text = "Please enter administrative credentials to view or delete table content!";
        }

        //display havevoted table
        protected void hvdClick(object sender, EventArgs e)
        {
            if (adminButton.Text == "Accepted")
            {
                using (SqlConnection cons = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    cons.Open();
                    SqlCommand cd = new SqlCommand("SELECT * FROM HaveVoted", cons);
                    cd.ExecuteNonQuery();
                    SqlDataAdapter da1 = new SqlDataAdapter(cd);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    StringBuilder html = new StringBuilder();
                    SqlDataReader dr = cd.ExecuteReader();
                    html.Append("<table border='1'>");
                    html.Append("<tr> <b>HAVE VOTED<b></tr><br/>");
                    html.Append("<tr>");
                    foreach (DataColumn column in dt1.Columns)
                    {
                        html.Append("<th>");
                        html.Append(column.ColumnName);
                        html.Append("</th>");
                    }
                    html.Append("</tr>");
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            html.Append("<tr>");
                            html.Append("<td>" + dr["Serial_no"] + "</td>");
                            html.Append("<td>" + dr["Username"] + "</td>");
                            html.Append("<td>" + dr["Name"] + "</td>");
                            html.Append("<td>" + dr["Matric_no"] + "</td>");
                            html.Append("<td>" + dr["Faculty"] + "</td>");
                            html.Append("<td>" + dr["Department"] + "</td>");
                            html.Append("</tr>");
                        }
                    }
                    html.Append("</table>");
                    ph.Controls.Add(new Literal { Text = html.ToString() });
                    dr.Close();
                    dr.Dispose();
                    contentLabel.Text = "Table content has been displayed";
                    cons.Dispose();
                }
            }
            else holdLabel.Text = "Please enter administrative credentials to view or delete table content!";
        }

        //display totalvotes table
        protected void tvdClick(object sender, EventArgs e)
        {
            if (adminButton.Text == "Accepted")
            {
                using (SqlConnection cons = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    cons.Open();
                    SqlCommand cd = new SqlCommand("SELECT * FROM TotalVotes", cons);
                    cd.ExecuteNonQuery();
                    SqlDataAdapter da1 = new SqlDataAdapter(cd);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    StringBuilder html = new StringBuilder();
                    SqlDataReader dr = cd.ExecuteReader();
                    html.Append("<table border='1'>");
                    html.Append("<tr> <b>TOTAL VOTES<b></tr><br/>");
                    html.Append("<tr>");
                    foreach (DataColumn column in dt1.Columns)
                    {
                        html.Append("<th>");
                        html.Append(column.ColumnName);
                        html.Append("</th>");
                    }
                    html.Append("</tr>");
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            html.Append("<tr>");
                            html.Append("<td>" + dr["Serial_no"] + "</td>");
                            html.Append("<td>" + dr["VoteId"] + "</td>");
                            html.Append("<td>" + dr["Number"] + "</td>");
                            html.Append("<td>" + dr["Faculty"] + "</td>");
                            html.Append("<td>" + dr["NumberFaculty"] + "</td>");
                            html.Append("<td>" + dr["Department"] + "</td>");
                            html.Append("<td>" + dr["NumberDepartment"] + "</td>");
                            html.Append("</tr>");
                        }
                    }
                    html.Append("</table>");
                    ph.Controls.Add(new Literal { Text = html.ToString() });
                    dr.Close();
                    dr.Dispose();
                    contentLabel.Text = "Table content has been displayed";
                    cons.Dispose();
                }
            }
            else holdLabel.Text = "Please enter administrative credentials to view or delete table content!";
        }

        //display allvotes table
        protected void avdClick(object sender, EventArgs e)
        {
            if (adminButton.Text == "Accepted")
            {
                using (SqlConnection cons = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    cons.Open();
                    SqlCommand cd = new SqlCommand("SELECT * FROM AllVotes", cons);
                    cd.ExecuteNonQuery();
                    SqlDataAdapter da1 = new SqlDataAdapter(cd);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    StringBuilder html = new StringBuilder();
                    SqlDataReader dr = cd.ExecuteReader();
                    html.Append("<table border='1'>");

                    html.Append("<tr> <b>ALL VOTES<b></tr><br/>");
                    html.Append("<tr>");
                    foreach (DataColumn column in dt1.Columns)
                    {
                        html.Append("<th>");
                        html.Append(column.ColumnName);
                        html.Append("</th>");
                    }
                    html.Append("</tr>");
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            html.Append("<tr>");
                            html.Append("<td>" + dr["Serial_no"] + "</td>");
                            html.Append("<td>" + dr["Username"] + "</td>");
                            html.Append("<td>" + dr["Matric_no"] + "</td>");
                            html.Append("<td>" + dr["P1"] + "</td>");
                            html.Append("<td>" + dr["P2"] + "</td>");
                            html.Append("<td>" + dr["P3"] + "</td>");
                            html.Append("<td>" + dr["PN"] + "</td>");
                            html.Append("<td>" + dr["VP1"] + "</td>");
                            html.Append("<td>" + dr["VP2"] + "</td>");
                            html.Append("<td>" + dr["VP3"] + "</td>");
                            html.Append("<td>" + dr["VPN"] + "</td>");
                            html.Append("<td>" + dr["GS1"] + "</td>");
                            html.Append("<td>" + dr["GS2"] + "</td>");
                            html.Append("<td>" + dr["GS3"] + "</td>");
                            html.Append("<td>" + dr["GSN"] + "</td>");
                            html.Append("<td>" + dr["FS1"] + "</td>");
                            html.Append("<td>" + dr["FS2"] + "</td>");
                            html.Append("<td>" + dr["FS3"] + "</td>");
                            html.Append("<td>" + dr["FSN"] + "</td>");
                            html.Append("<td>" + dr["PR1"] + "</td>");
                            html.Append("<td>" + dr["PR2"] + "</td>");
                            html.Append("<td>" + dr["PR3"] + "</td>");
                            html.Append("<td>" + dr["PRN"] + "</td>");
                            html.Append("<td>" + dr["AGS1"] + "</td>");
                            html.Append("<td>" + dr["AGS2"] + "</td>");
                            html.Append("<td>" + dr["AGS3"] + "</td>");
                            html.Append("<td>" + dr["AGSN"] + "</td>");
                            html.Append("<td>" + dr["SOC1"] + "</td>");
                            html.Append("<td>" + dr["SOC2"] + "</td>");
                            html.Append("<td>" + dr["SOC3"] + "</td>");
                            html.Append("<td>" + dr["SOCN"] + "</td>");
                            html.Append("<td>" + dr["SD1"] + "</td>");
                            html.Append("<td>" + dr["SD2"] + "</td>");
                            html.Append("<td>" + dr["SD3"] + "</td>");
                            html.Append("<td>" + dr["SDN"] + "</td>");
                            html.Append("<td>" + dr["LIB1"] + "</td>");
                            html.Append("<td>" + dr["LIB2"] + "</td>");
                            html.Append("<td>" + dr["LIB3"] + "</td>");
                            html.Append("<td>" + dr["LIBN"] + "</td>");
                            html.Append("<td>" + dr["AL1"] + "</td>");
                            html.Append("<td>" + dr["AL2"] + "</td>");
                            html.Append("<td>" + dr["AL3"] + "</td>");
                            html.Append("<td>" + dr["ALN"] + "</td>");
                            html.Append("<td>" + dr["EDI1"] + "</td>");
                            html.Append("<td>" + dr["EDI2"] + "</td>");
                            html.Append("<td>" + dr["EDI3"] + "</td>");
                            html.Append("<td>" + dr["EDIN"] + "</td>");
                            html.Append("<td>" + dr["WEL1"] + "</td>");
                            html.Append("<td>" + dr["WEL2"] + "</td>");
                            html.Append("<td>" + dr["WEL3"] + "</td>");
                            html.Append("<td>" + dr["WELN"] + "</td>");
                            html.Append("<td>" + dr["TRE1"] + "</td>");
                            html.Append("<td>" + dr["TRE2"] + "</td>");
                            html.Append("<td>" + dr["TRE3"] + "</td>");
                            html.Append("<td>" + dr["TREN"] + "</td>");
                            html.Append("</tr>");
                        }
                    }
                    html.Append("</table>");
                    ph.Controls.Add(new Literal { Text = html.ToString() });
                    dr.Close();
                    dr.Dispose();
                    contentLabel.Text = "Table content has been displayed";
                    cons.Dispose();
                }
            }
            else holdLabel.Text = "Please enter administrative credentials to view or delete table content!";
        }

        //display keycode table
        protected void kcdClick(object sender, EventArgs e)
        {
            if (adminButton.Text == "Accepted")
            {
                using (SqlConnection cons = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    cons.Open();
                    SqlCommand cd = new SqlCommand("SELECT * FROM KeyCodes", cons);
                    cd.ExecuteNonQuery();
                    SqlDataAdapter da1 = new SqlDataAdapter(cd);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    StringBuilder html = new StringBuilder();
                    SqlDataReader dr = cd.ExecuteReader();
                    html.Append("<table border='1'>");
                    html.Append("<tr> <b>KEYCODE<b></tr><br/>");
                    html.Append("<tr>");
                    foreach (DataColumn column in dt1.Columns)
                    {
                        html.Append("<th>");
                        html.Append(column.ColumnName);
                        html.Append("</th>");
                    }
                    html.Append("</tr>");
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            html.Append("<tr>");
                            html.Append("<td>" + dr["Serial_no"] + "</td>");
                            html.Append("<td>" + dr["Name"] + "</td>");
                            html.Append("<td>" + dr["Matric_no"] + "</td>");
                            html.Append("<td>" + dr["Id"] + "</td>");
                            html.Append("<td>" + dr["UsageInt"] + "</td>");
                            html.Append("</tr>");
                        }
                    }
                    html.Append("</table>");
                    ph.Controls.Add(new Literal { Text = html.ToString() });
                    dr.Close();
                    dr.Dispose();
                    contentLabel.Text = "Table content has been displayed";
                    cons.Dispose();
                }
            }
            else holdLabel.Text = "Please enter administrative credentials to view or delete table content!";
        }


        //clear user table
        protected void userClick(object sender, EventArgs e)
        {
            if (userRB.Checked == true && adminButton.Text == "Accepted")
            {
                using (SqlConnection cons = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    cons.Open();
                    SqlCommand cmds = new SqlCommand("DELETE FROM Users", cons);
                    cmds.CommandType = CommandType.Text;
                    cmds.ExecuteNonQuery();
                    userButton.Text = "Cleared";
                    titleLabel.Text = "Clear Database Tables (Users Table has been cleared)";
                    cons.Dispose();
                }
            }
            else
            {
                if (adminButton.Text != "Accepted") holdLabel.Text = "Please enter administrative credentials to view or delete table content!";
                else 
                {
                    userButton.Text = "Not Cleared";
                    userLabel.Text+=", Hint: Check radiobutton";
                }
            }
        }

        //clear faculty table
        protected void facClick(object sender, EventArgs e)
        {

            if (facrb.Checked == true && adminButton.Text == "Accepted")
            {
                string facs = "";
                if (fac.SelectedIndex == 0) facs = "Administration";
                else if (fac.SelectedIndex == 1) facs = "Agricultural_Sciences";
                else if (fac.SelectedIndex == 2) facs = "Arts";
                else if (fac.SelectedIndex == 3) facs = "Basic_Medical_Sciences";
                else if (fac.SelectedIndex == 4) facs = "Clinical_Sciences";
                else if (fac.SelectedIndex == 5) facs = "Dentistry";
                else if (fac.SelectedIndex == 6) facs = "Education";
                else if (fac.SelectedIndex == 7) facs = "EDM";
                else if (fac.SelectedIndex == 8) facs = "Law";
                else if (fac.SelectedIndex == 9) facs = "Pharmacy";
                else if (fac.SelectedIndex == 10) facs = "Sciences";
                else if (fac.SelectedIndex == 11) facs = "Social_Sciences";
                else if (fac.SelectedIndex == 12) facs = "Technology";
                else if (fac.SelectedIndex == 13) facs = "Other_Faculty";
                else facs = "Administration";
                using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmds = new SqlCommand("DELETE FROM " + facs, con);
                    cmds.CommandType = CommandType.Text;
                    cmds.ExecuteNonQuery();

                    //c;ear all faculty tables
                    if (fac.SelectedIndex == 14)
                    {
                        String[] facs2 = { "Agricultural_Sciences", "Arts", "Basic_Medical_Sciences", "Clinical_Sciences", "Dentistry", "Education", "EDM", "Law", "Pharmacy", "Sciences", "Social_Sciences", "Technology", "Other_Faculty" };
                        for (int i = 0; i < 13; i++)
                        {
                            SqlCommand cmd = new SqlCommand("DELETE FROM " + facs2[i], con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                            titleLabel.Text = "Clear Database Tables (All faculty Tables have been cleared)";
                        }
                    }
                    if (fac.SelectedIndex != 13) titleLabel.Text = "Clear Database Tables (" + facs.ToUpper() + " Table has been cleared)";
                    facButton.Text = "Cleared";
                }
            }
            else
            {

                if (adminButton.Text != "Accepted") holdLabel.Text = "Please enter administrative credentials to view or delete table content!";
                else
                {
                    facButton.Text = "Not Cleared";
                    facLabel.Text += ", Hint: Check radiobutton";
                }
            }
        }

        //clear department table
        protected void deptClick(object sender, EventArgs e)
        {
            if (deptrb.Checked == true && adminButton.Text == "Accepted")
            {
                string facs = "", dept = "";
                if (fac.SelectedIndex == 0) facs = "Administration";
                else if (fac.SelectedIndex == 1) facs = "Agricultural_Sciences";
                else if (fac.SelectedIndex == 2) facs = "Arts";
                else if (fac.SelectedIndex == 3) facs = "Basic_Medical_Sciences";
                else if (fac.SelectedIndex == 4) facs = "Clinical_Sciences";
                else if (fac.SelectedIndex == 5) facs = "Dentistry";
                else if (fac.SelectedIndex == 6) facs = "Education";
                else if (fac.SelectedIndex == 7) facs = "EDM";
                else if (fac.SelectedIndex == 8) facs = "Law";
                else if (fac.SelectedIndex == 9) facs = "Pharmacy";
                else if (fac.SelectedIndex == 10) facs = "Sciences";
                else if (fac.SelectedIndex == 11) facs = "Social_Sciences";
                else if (fac.SelectedIndex == 12) facs = "Technology";
                else if (fac.SelectedIndex == 13) facs = "Other_Faculty";
                else facs = "All";

                if (adm.Visible == true)
                {
                    if (adm.SelectedIndex == 0) dept = "International_Relations";
                    else if (adm.SelectedIndex == 1) dept = "Local_Government_Studies";
                    else if (adm.SelectedIndex == 2) dept = "Management_and_Accounting";
                    else if (adm.SelectedIndex == 3) dept = "Public_Administration";
                    else if (adm.SelectedIndex == 4) dept = "Other_Administration";
                    else dept = "International_Relations";
                }
                if (agr.Visible == true)
                {
                    if (agr.SelectedIndex == 0) dept = "Agricultural_Economics";
                    else if (agr.SelectedIndex == 1) dept = "Agricultural_Extension";
                    else if (agr.SelectedIndex == 2) dept = "Animal_Science";
                    else if (agr.SelectedIndex == 3) dept = "Crop_Production";
                    else if (agr.SelectedIndex == 4) dept = "Family_Nutrition";
                    else if (agr.SelectedIndex == 5) dept = "Soil_Science";
                    else if (agr.SelectedIndex == 6) dept = "Other_Agricultural_Sciences";
                    else dept = "Agricultural_Economics";
                }
                if (art.Visible == true)
                {
                    if (art.SelectedIndex == 0) dept = "Dramatic_Arts";
                    else if (art.SelectedIndex == 1) dept = "English_Language";
                    else if (art.SelectedIndex == 2) dept = "Foreign_Languages";
                    else if (art.SelectedIndex == 3) dept = "History";
                    else if (art.SelectedIndex == 4) dept = "Linguistics";
                    else if (art.SelectedIndex == 5) dept = "Music";
                    else if (art.SelectedIndex == 6) dept = "Philosophy";
                    else if (art.SelectedIndex == 7) dept = "Religious_Studies";
                    else if (art.SelectedIndex == 8) dept = "Other_Arts";
                    else dept = "Dramatic_Arts";
                }
                if (med.Visible == true)
                {
                    if (med.SelectedIndex == 0) dept = "Medical_Rehabilitation";
                    else if (med.SelectedIndex == 1) dept = "Nursing";
                    else if (med.SelectedIndex == 2) dept = "Other_Basic_Medical_Sciences";
                    else dept = "Medical_Rehabilitation";
                }
                if (cli.Visible == true)
                {
                    if (cli.SelectedIndex == 0) dept = "Medicine_and_Surgery";
                    else if (cli.SelectedIndex == 1) dept = "Other_Clinical_Sciences";
                    else dept = "Medicine_and_Surgery";
                }
                if (den.Visible == true)
                {
                    if (den.SelectedIndex == 0) dept = "Dentistry_Department";
                    else if (den.SelectedIndex == 1) dept = "Other_Dentistry";
                    else dept = "Dentistry_Departent";
                }
                if (edu.Visible == true)
                {
                    if (edu.SelectedIndex == 0) dept = "Adult_Education";
                    else if (edu.SelectedIndex == 1) dept = "Continuing_Education";
                    else if (edu.SelectedIndex == 2) dept = "Educational_Administration";
                    else if (edu.SelectedIndex == 3) dept = "Educational_Foundation";
                    else if (edu.SelectedIndex == 4) dept = "Educational_Technology";
                    else if (edu.SelectedIndex == 5) dept = "Physical_Education";
                    else if (edu.SelectedIndex == 6) dept = "Special_Education";
                    else if (edu.SelectedIndex == 7) dept = "Other_Education";
                    else dept = "Adult_Education";
                }
                if (edm.Visible == true)
                {
                    if (edm.SelectedIndex == 0) dept = "Architecture";
                    else if (edm.SelectedIndex == 1) dept = "Building";
                    else if (edm.SelectedIndex == 2) dept = "Estate_Management";
                    else if (edu.SelectedIndex == 3) dept = "Fine_Arts";
                    else if (edm.SelectedIndex == 4) dept = "Quantity_Surveying";
                    else if (edm.SelectedIndex == 5) dept = "Urban_and_Rural_Planning";
                    else if (edm.SelectedIndex == 6) dept = "Other_EDM";
                    else dept = "Architecture";
                }
                if (law.Visible == true)
                {
                    if (law.SelectedIndex == 0) dept = "Law_Department";
                    else if (law.SelectedIndex == 1) dept = "Other_Law";
                    else dept = "Law_Department";
                }
                if (phm.Visible == true)
                {
                    if (phm.SelectedIndex == 0) dept = "Pharmacy_Department";
                    else if (phm.SelectedIndex == 1) dept = "Other_Pharmacy";
                    else dept = "Pharmacy_Department";
                }
                if (sci.Visible == true)
                {
                    if (sci.SelectedIndex == 0) dept = "Biochemistry";
                    else if (sci.SelectedIndex == 1) dept = "Botany";
                    else if (sci.SelectedIndex == 2) dept = "Chemistry";
                    else if (sci.SelectedIndex == 3) dept = "Conservative_Science";
                    else if (sci.SelectedIndex == 4) dept = "Geology";
                    else if (sci.SelectedIndex == 5) dept = "Mathematics";
                    else if (sci.SelectedIndex == 6) dept = "Microbiology";
                    else if (sci.SelectedIndex == 7) dept = "Physics";
                    else if (sci.SelectedIndex == 8) dept = "Zoology";
                    else if (sci.SelectedIndex == 9) dept = "Other_Sciences";
                    else dept = "Biochemistry";
                }
                if (soc.Visible == true)
                {
                    if (soc.SelectedIndex == 0) dept = "Demography";
                    else if (soc.SelectedIndex == 1) dept = "Economics";
                    else if (soc.SelectedIndex == 2) dept = "Geography";
                    else if (soc.SelectedIndex == 3) dept = "Philosophy";
                    else if (soc.SelectedIndex == 4) dept = "Political_Science";
                    else if (soc.SelectedIndex == 5) dept = "Psychology";
                    else if (soc.SelectedIndex == 6) dept = "Sociology";
                    else if (soc.SelectedIndex == 7) dept = "Other_Social_Sciences";
                    else dept = "Demography";
                }
                if (tech.Visible == true)
                {
                    if (tech.SelectedIndex == 0) dept = "Agricultural_Engineering";
                    else if (tech.SelectedIndex == 1) dept = "Chemical_Engineering";
                    else if (tech.SelectedIndex == 2) dept = "Civil_Engineering";
                    else if (tech.SelectedIndex == 3) dept = "Computer_Science_and_Engineering";
                    else if (tech.SelectedIndex == 4) dept = "Electrical_Engineering";
                    else if (tech.SelectedIndex == 5) dept = "Food_Science";
                    else if (tech.SelectedIndex == 6) dept = "Material_Science";
                    else if (tech.SelectedIndex == 7) dept = "Mechanical_Engineering";
                    else if (tech.SelectedIndex == 8) dept = "Other_Technology";
                    else dept = "Agricultural_Engineering";
                }

                if (other.Visible == true && other.SelectedIndex == 0)
                { dept = "Other_Department"; }

                if (all.SelectedIndex == 0 && all.Visible == true)
                { dept = "International_Relations"; }

                using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmds = new SqlCommand("DELETE FROM " + dept, con);
                    cmds.CommandType = CommandType.Text;
                    cmds.ExecuteNonQuery();

                    titleLabel.Text = "Clear Database Tables (" + dept.ToUpper() + " Table has been cleared)";
                    deptButton.Text = "Cleared";

                    //delete all departments in a faculty
                    if (adm.SelectedIndex == 5 && adm.Visible == true)
                    {
                        String[] dept2 = { "International_Relations", "Local_Government_Studies", "Management_and_Accounting", "Public_Administration", "Other_Administration" };
                        for (int i = 0; i < 5; i++)
                        {
                            SqlCommand cmd = new SqlCommand("DELETE FROM " + dept2[i], con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                            titleLabel.Text = "Clear Database Tables (All Department's Tables in faculty of " + facs.ToUpper() + " have been cleared)";
                        }
                    }

                    if (agr.SelectedIndex == 7 && agr.Visible == true)
                    {
                        String[] dept2 = { "Agricultural_Economics", "Agricultural_Extension", "Animal_Science", "Crop_Production", "Family_Nutrition", "Soil_Science", "Other_Agricultural_Sciences" };
                        for (int i = 0; i < 7; i++)
                        {
                            SqlCommand cmd = new SqlCommand("DELETE FROM " + dept2[i], con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                            titleLabel.Text = "Clear Database Tables (All Department's Tables in faculty of " + facs.ToUpper() + " have been cleared)";
                        }
                    }

                    if (art.SelectedIndex == 9 && art.Visible == true)
                    {
                        String[] dept2 = { "Dramatic_Arts", "English_Language", "Foreign_Languages", "History", "Linguistics", "Music", "Philosophy", "Religious_Studies", "Other_Arts" };
                        for (int i = 0; i < 9; i++)
                        {
                            SqlCommand cmd = new SqlCommand("DELETE FROM " + dept2[i], con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                            titleLabel.Text = "Clear Database Tables (All Department's Tables in faculty of " + facs.ToUpper() + " have been cleared)";
                        }
                    }

                    if (med.SelectedIndex == 3 && med.Visible == true)
                    {
                        String[] dept2 = { "Medical_Rehabilitation", "Nursing", "Other_Basic_Medical_Sciences" };
                        for (int i = 0; i < 3; i++)
                        {
                            SqlCommand cmd = new SqlCommand("DELETE FROM " + dept2[i], con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                            titleLabel.Text = "Clear Database Tables (All Department's Tables in faculty of " + facs.ToUpper() + " have been cleared)";
                        }
                    }

                    if (cli.SelectedIndex == 2 && cli.Visible == true)
                    {
                        String[] dept2 = { "Medicine_and_Surgery", "Other_Clinical_Sciences" };
                        for (int i = 0; i < 2; i++)
                        {
                            SqlCommand cmd = new SqlCommand("DELETE FROM " + dept2[i], con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                            titleLabel.Text = "Clear Database Tables (All Department's Tables in faculty of " + facs.ToUpper() + " have been cleared)";
                        }
                    }

                    if (den.SelectedIndex == 2 && den.Visible == true)
                    {
                        String[] dept2 = { "Dentistry_Department", "Other_Dentistry" };
                        for (int i = 0; i < 2; i++)
                        {
                            SqlCommand cmd = new SqlCommand("DELETE FROM " + dept2[i], con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                            titleLabel.Text = "Clear Database Tables (All Department's Tables in faculty of " + facs.ToUpper() + " have been cleared)";
                        }
                    }

                    if (edu.SelectedIndex == 8 && edu.Visible == true)
                    {
                        String[] dept2 = { "Adult_Education", "Continuing_Education", "Educational_Administration", "Educational_Foundation", "Educational_Technology", "Physical_Education", "Special_Education", "Other_Education" };
                        for (int i = 0; i < 8; i++)
                        {
                            SqlCommand cmd = new SqlCommand("DELETE FROM " + dept2[i], con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                            titleLabel.Text = "Clear Database Tables (All Department's Tables in faculty of " + facs.ToUpper() + " have been cleared)";
                        }
                    }

                    if (edm.SelectedIndex == 7 && edm.Visible == true)
                    {
                        String[] dept2 = { "Architecture", "Building", "Estate_Management", "Fine_Arts", "Quantity_Surveying", "Urban_and_Rural_Planning", "Other_EDM" };
                        for (int i = 0; i < 7; i++)
                        {
                            SqlCommand cmd = new SqlCommand("DELETE FROM " + dept2[i], con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                            titleLabel.Text = "Clear Database Tables (All Department's Tables in faculty of " + facs.ToUpper() + " have been cleared)";
                        }
                    }

                    if (law.SelectedIndex == 2 && law.Visible == true)
                    {
                        String[] dept2 = { "Law_Department", "Other_Law" };
                        for (int i = 0; i < 2; i++)
                        {
                            SqlCommand cmd = new SqlCommand("DELETE FROM " + dept2[i], con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                            titleLabel.Text = "Clear Database Tables (All Department's Tables in faculty of " + facs.ToUpper() + " have been cleared)";
                        }
                    }

                    if (phm.SelectedIndex == 2 && phm.Visible == true)
                    {
                        String[] dept2 = { "Pharmacy_Department", "Other_Pharmacy" };
                        for (int i = 0; i < 2; i++)
                        {
                            SqlCommand cmd = new SqlCommand("DELETE FROM " + dept2[i], con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                            titleLabel.Text = "Clear Database Tables (All Department's Tables in faculty of " + facs.ToUpper() + " have been cleared)";
                        }
                    }

                    if (sci.SelectedIndex == 9 && sci.Visible == true)
                    {
                        String[] dept2 = { "Biochemistry", "Botany", "Chemistry", "Conservative_Science", "Geology", "Mathematics", "Microbiology", "Physics", "Zoology", "Other_Sciences" };
                        for (int i = 0; i < 9; i++)
                        {
                            SqlCommand cmd = new SqlCommand("DELETE FROM " + dept2[i], con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                            titleLabel.Text = "Clear Database Tables (All Department's Tables in faculty of " + facs.ToUpper() + " have been cleared)";
                        }
                    }

                    if (soc.SelectedIndex == 8 && soc.Visible == true)
                    {
                        String[] dept2 = { "Demography", "Economics", "Geography", "Philosophy", "Political_Science", "Psychology", "Sociology", "Other_Social_Sciences" };
                        for (int i = 0; i < 8; i++)
                        {
                            SqlCommand cmd = new SqlCommand("DELETE FROM " + dept2[i], con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                            titleLabel.Text = "Clear Database Tables (All Department's Tables in faculty of " + facs.ToUpper() + " have been cleared)";
                        }
                    }

                    if (tech.SelectedIndex == 9 && tech.Visible == true)
                    {
                        String[] dept2 = { "Agricultural_Engineering", "Chemical_Engineering", "Civil_Engineering", "Computer_Science_and_Engineering", "Electrical_Engineering", "Food_Science", "Material_Science", "Mechanical_Engineering", "Other_Technology" };
                        for (int i = 0; i < 9; i++)
                        {
                            SqlCommand cmd = new SqlCommand("DELETE FROM " + dept2[i], con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                            titleLabel.Text = "Clear Database Tables (All Department's Tables in faculty of " + facs.ToUpper() + " have been cleared)";
                        }
                    }

                    //clear all departmental tables
                    if (all.SelectedIndex == 0 && all.Visible == true)
                    {
                        String[] dept2 = {"International_Relations","Local_Government_Studies","Management_and_Accounting","Public_Administration","Other_Administration", "Agricultural_Economics","Agricultural_Extension","Animal_Science", "Crop_Production","Family_Nutrition","Soil_Science","Other_Agricultural_Sciences",
                                      "Dramatic_Arts","English_Language","Foreign_Languages","History","Linguistics","Music", "Philosophy","Religious_Studies","Other_Arts","Medical_Rehabilitation","Nursing","Other_Basic_Medical_Sciences",
                                      "Medicine_and_Surgery","Other_Clinical_Sciences","Dentistry_Department","Other_Dentistry","Adult_Education","Continuing_Education","Educational_Administration","Educational_Foundation","Educational_Technology","Physical_Education",
                                      "Special_Education","Other_Education","Architecture","Building","Estate_Management","Fine_Arts","Quantity_Surveying","Urban_and_Rural_Planning","Other_EDM","Law_Department",
                                      "Other_Law","Pharmacy_Department","Other_Pharmacy","Biochemistry","Botany","Chemistry","Conservative_Science","Geology","Mathematics",
                                      "Microbiology","Physics", "Zoology","Other_Sciences","Demography","Economics","Geography","Philosophy","Political_Science","Psychology",
                                      "Sociology","Other_Social_Sciences","Agricultural_Engineering","Chemical_Engineering","Civil_Engineering","Computer_Science_and_Engineering","Electrical_Engineering","Food_Science","Material_Science","Mechanical_Engineering","Other_Technology", "Other_Department"};
                        for (int i = 0; i < 75; i++)
                        {
                            SqlCommand cmd = new SqlCommand("DELETE FROM " + dept2[i], con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                            titleLabel.Text = "Clear Database Tables (All Department's Tables have been cleared)";
                            con.Dispose();
                        }
                    }
                }
            }
            else
            {

                if (adminButton.Text != "Accepted") holdLabel.Text = "Please enter administrative credentials to view or delete table content!";
                else
                {
                    deptButton.Text = "Not Cleared";
                    deptLabel.Text += ", Hint: Check radiobutton";
                }
            }
        }

        //clear havevoted table
        protected void hvClick(object sender, EventArgs e)
        {
            if (hvrb.Checked == true && adminButton.Text == "Accepted")
            {
                using (SqlConnection cons = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    cons.Open();
                    SqlCommand cmds = new SqlCommand("DELETE FROM HaveVoted", cons);
                    cmds.CommandType = CommandType.Text;
                    cmds.ExecuteNonQuery();
                    titleLabel.Text = "Clear Database Tables (HaveVoted Table has been cleared)";
                    hvButton.Text = "Cleared";
                    cons.Dispose();
                }
            }
            else
            {

                if (adminButton.Text != "Accepted") holdLabel.Text = "Please enter administrative credentials to view or delete table content!";
                else
                {
                    hvButton.Text = "Not Cleared";
                    hvLabel.Text += ", Hint: Check radiobutton";
                }
            }
        }

        //clear totalvotes table
        protected void tvClick(object sender, EventArgs e)
        {
            if (tvrb.Checked == true && adminButton.Text == "Accepted")
            {
                using (SqlConnection cons = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    cons.Open();
                    String[] facs1 = { "P1", "P2", "VP1", "VP2", "GS1", "GS2", "FS1", "FS2", "PR1", "PR2", "AGS1", "AGS2", "SOC1", "SOC2", "SD1", "SD2", "LIB1", "LIB2", "AL1", "AL2", "EDI1", "EDI2", "P3", "VP3", "GS3", "FS3", "PR3", "AGS3", "SOC3", "SD3", "LIB3", "AL3", "EDI3", "WEL1", "WEL2", "WEL3", "TRE1", "TRE2", "TRE3", "PN", "VPN", "GSN", "FSN", "PRN", "AGSN", "SOCN", "SDN", "LIBN", "ALN", "EDIN", "WELN", "TREN", "TOTAL" };
                    for (int i = 0; i < 53; i++)
                    {
                        SqlCommand cmds = new SqlCommand("UPDATE TotalVotes SET Number = 0 where VoteId=@vote", cons);
                        cmds.CommandType = CommandType.Text;
                        cmds.Parameters.AddWithValue("@vote", facs1[i]);
                        cmds.ExecuteNonQuery();
                    }
                    //for each faculty
                    String[] facs2 = { "Administration", "Agricultural_Sciences", "Arts", "Basic_Medical_Sciences", "Clinical_Sciences", "Dentistry", "Education", "EDM", "Law", "Pharmacy", "Sciences", "Social_Sciences", "Technology", "Other_Faculty", "Total" };
                    for (int i = 0; i < 15; i++)
                    {
                        SqlCommand cmds1 = new SqlCommand("UPDATE TotalVotes SET NumberFaculty = 0 WHERE Faculty=@faculty", cons);
                        cmds1.CommandType = CommandType.Text;
                        cmds1.Parameters.AddWithValue("@faculty", facs2[i]);
                        cmds1.ExecuteNonQuery();
                    }
                    //for each department
                    String[] dept2 = {"International_Relations","Local_Government_Studies","Management_and_Accounting","Public_Administration","Other_Administration", "Agricultural_Economics","Agricultural_Extension","Animal_Science", "Crop_Production","Family_Nutrition","Soil_Science","Other_Agricultural_Sciences",
                                      "Dramatic_Arts","English_Language","Foreign_Languages","History","Linguistics","Music", "Philosophy","Religious_Studies","Other_Arts","Medical_Rehabilitation","Nursing","Other_Basic_Medical_Sciences",
                                      "Medicine_and_Surgery","Other_Clinical_Sciences","Dentistry_Department","Other_Dentistry","Adult_Education","Continuing_Education","Educational_Administration","Educational_Foundation","Educational_Technology","Physical_Education",
                                      "Special_Education","Other_Education","Architecture","Building","Estate_Management","Fine_Arts","Quantity_Surveying","Urban_and_Rural_Planning","Other_EDM","Law_Department",
                                      "Other_Law","Pharmacy_Department","Other_Pharmacy","Biochemistry","Botany","Chemistry","Conservative_Science","Geology","Mathematics",
                                      "Microbiology","Physics", "Zoology","Other_Sciences","Demography","Economics","Geography","Philosophy","Political_Science","Psychology",
                                      "Sociology","Other_Social_Sciences","Agricultural_Engineering","Chemical_Engineering","Civil_Engineering","Computer_Science_and_Engineering","Electrical_Engineering","Food_Science","Material_Science","Mechanical_Engineering","Other_Technology", "Other_Department",
                                  "TOTAL_Administration","TOTAL_Agricultural_Science","TOTAL_Arts","TOTAL_Basic_Medical_Sciences","TOTAL_Clinical_Sciences","TOTAL_Dentistry","TOTAL_Education","TOTAL_EDM","TOTAL_Law", "TOTAL_Pharmacy","TOTAL_Sciences","TOTAL_Social_Sciences","TOTAL_Technology","TOTAL"};
                    for (int i = 0; i < 89; i++)
                    {
                        SqlCommand cmds1 = new SqlCommand("UPDATE TotalVotes SET NumberDepartment = 0 WHERE Department=@dept", cons);
                        cmds1.CommandType = CommandType.Text;
                        cmds1.Parameters.AddWithValue("@dept", dept2[i]);
                        cmds1.ExecuteNonQuery();
                    }
                    titleLabel.Text = "Clear Database Tables (TotalVotes Table has been cleared)";
                    tvButton.Text = "Cleared";
                    cons.Dispose();
                }
            }
            else
            {

                if (adminButton.Text != "Accepted") holdLabel.Text = "Please enter administrative credentials to view or delete table content!";
                else
                {
                    tvButton.Text = "Not Cleared";
                    tvLabel.Text += ", Hint: Check radiobutton";
                }
            }
        }

        //clear allvotes table
        protected void avClick(object sender, EventArgs e)
        {
            if (avrb.Checked == true && adminButton.Text == "Accepted")
            {
                using (SqlConnection cons = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    cons.Open();
                    SqlCommand cmds = new SqlCommand("DELETE FROM AllVotes", cons);
                    cmds.CommandType = CommandType.Text;
                    cmds.ExecuteNonQuery();
                    titleLabel.Text = "Clear Database Tables (AllVotes Table has been cleared)";
                    avButton.Text = "Cleared";
                    cons.Dispose();
                }
            }
            else
            {

                if (adminButton.Text != "Accepted") holdLabel.Text = "Please enter administrative credentials to view or delete table content!";
                else
                {
                    avButton.Text = "Not Cleared";
                    avLabel.Text += ", Hint: Check radiobutton";
                }
            }
        }

        //clear all keycodes
        protected void kcClick(object sender, EventArgs e)
        {
            if (kcrb.Checked == true && adminButton.Text == "Accepted")
            {
                using (SqlConnection cons = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    cons.Open();
                    SqlCommand cmds = new SqlCommand("DELETE FROM KeyCodes", cons);
                    cmds.CommandType = CommandType.Text;
                    cmds.ExecuteNonQuery();
                    titleLabel.Text = "Clear Database Tables (KeyCodes Table has been cleared)";
                    kcButton.Text = "Cleared";
                    cons.Dispose();
                }
            }
            else
            {

                if (adminButton.Text != "Accepted") holdLabel.Text = "Please enter administrative credentials to view or delete table content!";
                else
                {
                    kcButton.Text = "Not Cleared";
                    kcLabel.Text += ", Hint: Check radiobutton";
                }
            }
        }

        //for display of department when displaying database tables
        protected void selectdClick(object sender, EventArgs e)
        {
            if (fac2.SelectedIndex == 0) admd.Visible = true; else admd.Visible = false;
            if (fac2.SelectedIndex == 1) agrd.Visible = true; else agrd.Visible = false;
            if (fac2.SelectedIndex == 2) artd.Visible = true; else artd.Visible = false;
            if (fac2.SelectedIndex == 3) medd.Visible = true; else medd.Visible = false;
            if (fac2.SelectedIndex == 4) clid.Visible = true; else clid.Visible = false;
            if (fac2.SelectedIndex == 5) dend.Visible = true; else dend.Visible = false;
            if (fac2.SelectedIndex == 6) edud.Visible = true; else edud.Visible = false;
            if (fac2.SelectedIndex == 7) edmd.Visible = true; else edmd.Visible = false;
            if (fac2.SelectedIndex == 8) lawd.Visible = true; else lawd.Visible = false;
            if (fac2.SelectedIndex == 9) phmd.Visible = true; else phmd.Visible = false;
            if (fac2.SelectedIndex == 10) scid.Visible = true; else scid.Visible = false;
            if (fac2.SelectedIndex == 11) socd.Visible = true; else socd.Visible = false;
            if (fac2.SelectedIndex == 12) techd.Visible = true; else techd.Visible = false;
            if (fac2.SelectedIndex == 13) otherd.Visible = true; else otherd.Visible = false;
            if (fac2.SelectedIndex == 14) alld.Visible = true; else alld.Visible = false;
        }

        //for displaying of department when clearing database tables
        protected void selectClick(object sender, EventArgs e)
        {
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
            if (fac.SelectedIndex == 13) other.Visible = true; else other.Visible = false;
            if (fac.SelectedIndex == 14) all.Visible = true; else all.Visible = false;
        }

    }
}