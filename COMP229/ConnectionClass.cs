using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace COMP229
{
    public class ConnectionClass
    {

        private static SqlConnection cntString;
        private static SqlCommand cmdString;

            static ConnectionClass()
            {
                cntString = new SqlConnection(ConfigurationManager.ConnectionStrings["DODAMDB"].ConnectionString);
            }

        public static void AvoidDuplicateEmail(SignUpInfo info)
        {
            string aQuery = string.Format(@"select * from userlist where email=('{0}')", info.eMailAddress);
            cmdString = new SqlCommand(aQuery, cntString);

            try
            {
                cntString.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmdString);

                DataTable dt = new DataTable();

                DataSet ds = new DataSet();
                da.Fill(dt);
                ds.Tables.Add(dt);

                if (dt.Rows.Count > 0)
                { info.eMailAddress = "EE"; }
            }

            finally
            {
                cntString.Close();
            }
        }


        public static void SignUp(SignUpInfo info)
        {
            string bQuery = string.Format(@"insert into userlist(username,email,password) values('{0}', '{1}', '{2}')", info.userName, info.eMailAddress, info.passWord);
            cmdString = new SqlCommand(bQuery, cntString);

            try
            {
                cntString.Open();
                cmdString.ExecuteNonQuery();
            }

            finally
            {
                cntString.Close();
            }
        }

        /*public static void SignIn(SignUpInfo info)
        {
            string cQuery = string.Format(@"select * from userlist where email= ('{0}') and password=('{1}')", info.eMailAddress, info.passWord);
            cmdString = new SqlCommand(cQuery, cntString);

            try
            {
                cntString.Open();
                // cmdString.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmdString);

                DataTable dt = new DataTable();

                DataSet ds = new DataSet();

                da.Fill(dt);

                ds.Tables.Add(dt);

                if (dt.Rows.Count > 0)
                {
                    info.eMailAddress = "EM"; //Email Matching
                    info.userName = dt.Rows[0]["username"].ToString();
                }

                else
                {
                    info.eMailAddress = "EMN"; //Email Not Matching
                }
            }

            finally
            {

                cntString.Close();
            }
        } */

        public static bool SignIn(SignUpInfo info)
        {
            string cQuery = string.Format(@"select count(email) from userlist where email= ('{0}') and password=('{1}')", info.eMailAddress, info.passWord);
            cmdString = new SqlCommand(cQuery, cntString);

            cntString.Open();
            int count = (int)cmdString.ExecuteScalar();
            cntString.Close();

            return count > 0;
        }
  }
}
