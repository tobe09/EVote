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
    public class VotingClass
    {
        //update totalvotes
        public void vote(string votein)
        {
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE TotalVotes SET Number=Number + 1 WHERE VoteId=@VoteId", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@VoteId", votein);
                cmd.ExecuteNonQuery();
            }
        }

    }
}