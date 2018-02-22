using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Data;

namespace WebApplication1
{
    public class ResultCode
    {
        //generate user votes
        public int show(string cand, string user)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cm1 = new SqlCommand("SELECT "+cand+" FROM AllVotes WHERE Username=@Username", con);
            cm1.CommandType = CommandType.Text;
            using (con)
            {
                cm1.Parameters.AddWithValue("@Username", user);
                cm1.ExecuteNonQuery();
                string hold1 = cm1.ExecuteScalar().ToString();
                int hold = int.Parse(hold1);
                return hold;
            }
        }

        //generate totalvotes
        public int showTotal(String cand) 
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cm1 = new SqlCommand("SELECT Number FROM TotalVotes WHERE VoteId=@vote", con);
            cm1.CommandType = CommandType.Text;
            using (con)
            {
                cm1.Parameters.AddWithValue("@vote", cand);
                cm1.ExecuteNonQuery();
                string hold1 = cm1.ExecuteScalar().ToString();
                int hold = int.Parse(hold1);
                return hold;
            }
        }
    }
}