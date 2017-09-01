
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SocialCampaignMVC.App_Code
{
    class AppDatabase
    {
        public AppDatabase()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        internal string getConnectionString(string serverName)
        {

            string connectionString = "";
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[serverName];

            if (settings != null)
            {
                connectionString = settings.ConnectionString;
            }

            return connectionString;
        }

        internal string postDBCampaignTransaction(Models.DownloadInfo Newinfo, string ConnString)
        {

            string retVal = "";
            string connString = getConnectionString(ConnString);
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmnd = new SqlCommand();

            cmnd.Connection = conn;
            cmnd.CommandType = CommandType.StoredProcedure;
            cmnd.CommandText = "zsp_insert_campaign_transaction";

            cmnd.Parameters.Add("@Customer_FacebookID", SqlDbType.VarChar).Value = Newinfo.Customer_FacebookID;
            cmnd.Parameters.Add("@Customer_Name", SqlDbType.VarChar).Value = Newinfo.Customer_Name;
            cmnd.Parameters.Add("@Customer_Email", SqlDbType.VarChar).Value = Newinfo.Customer_Email;
            cmnd.Parameters.Add("@Referrer_ID", SqlDbType.VarChar).Value = Newinfo.Referrer_ID;
            cmnd.Parameters.Add("@Campaign_ID", SqlDbType.VarChar).Value = Newinfo.Campaign_ID;
            cmnd.Parameters.Add("@Product_ID", SqlDbType.VarChar).Value = Newinfo.Product_ID;
            cmnd.Parameters.Add("@rErrorMsg", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
            cmnd.Parameters.Add("@rErrorCode", SqlDbType.Int, 2).Direction = ParameterDirection.Output;

            SqlDataReader dr;

            try
            {
                // Open the data connection
                cmnd.Connection = conn;
                conn.Open();

                // Execute the command
                dr = cmnd.ExecuteReader();
                /*while (dr.Read()) {
                    string rr      = dr["rr"].ToString();
                    i++;
                }*/

                /* Get the out parameters*/

                int retCode = int.Parse(cmnd.Parameters["@rErrorCode"].Value.ToString());
                if (retCode != 0)
                {
                    retVal = retCode + "|" + cmnd.Parameters["@rErrorMsg"].Value.ToString();
                }

            }
            catch (SqlException ex)
            {

                if (ex.Number != 0)
                {
                    retVal = ex.Number + "|" + ex.Message;
                }

            }

            return retVal;
        }

        internal string postDBCampaign(Models.Campaign Newcampaign, string ConnString)
        {

            string retVal = "";
            string connString = getConnectionString(ConnString);

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmnd = new SqlCommand();

            cmnd.Connection = conn;
            cmnd.CommandType = CommandType.StoredProcedure;
            cmnd.CommandText = "zsp_insert_campaign";

            cmnd.Parameters.Add("@Campaign_ID", SqlDbType.VarChar).Value = Newcampaign.Campaign_ID;
            cmnd.Parameters.Add("@Product_ID", SqlDbType.VarChar).Value = Newcampaign.Product_ID;
            cmnd.Parameters.Add("@Campaign_Title", SqlDbType.VarChar).Value = Newcampaign.Campaign_Title;
            cmnd.Parameters.Add("@Campaign_Type", SqlDbType.VarChar).Value = Newcampaign.Campaign_Type;
            cmnd.Parameters.Add("@Campaign_Link", SqlDbType.VarChar).Value = Newcampaign.Campaign_Link;
            cmnd.Parameters.Add("@Created_By", SqlDbType.VarChar).Value = Newcampaign.Created_By;
            cmnd.Parameters.Add("@Campaign_Status", SqlDbType.VarChar).Value = Newcampaign.Campaign_Status;
            cmnd.Parameters.Add("@Start_Date", SqlDbType.DateTime).Value = Newcampaign.Start_Date;
            cmnd.Parameters.Add("@End_Date", SqlDbType.DateTime).Value = Newcampaign.End_Date;

            cmnd.Parameters.Add("@rErrorMsg", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
            cmnd.Parameters.Add("@rErrorCode", SqlDbType.Int, 2).Direction = ParameterDirection.Output;

            SqlDataReader dr;

            try
            {
                // Open the data connection
                cmnd.Connection = conn;
                conn.Open();

                // Execute the command
                dr = cmnd.ExecuteReader();
                /*while (dr.Read()) {
                    string rr      = dr["rr"].ToString();
                    i++;
                }*/

                /* Get the out parameters*/

                int retCode = int.Parse(cmnd.Parameters["@rErrorCode"].Value.ToString());
                if (retCode != 0)
                {
                    retVal = retCode + "|" + cmnd.Parameters["@rErrorMsg"].Value.ToString();
                }

            }
            catch (SqlException ex)
            {

                if (ex.Number != 0)
                {
                    retVal = ex.Number + "|" + ex.Message;
                }

            }

            return retVal;
        }

        internal string postDBStaffList(DataTable dt, string cid, string ConnString)
        {

            string retVal = "";
            string connString = getConnectionString(ConnString);

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmnd = new SqlCommand();

            cmnd.Connection = conn;
            cmnd.CommandType = CommandType.StoredProcedure;
            cmnd.CommandText = "zsp_insert_campaign_stafflist";

            SqlParameter parameter = cmnd.CreateParameter();
            parameter.ParameterName = "@tvpNewStaff";
            parameter.Value = dt;
            parameter.SqlDbType = SqlDbType.Structured;
            parameter.TypeName = "dbo.StaffTableType";
            cmnd.Parameters.Add(parameter);

            cmnd.Parameters.Add("@campaign_id", SqlDbType.VarChar).Value = cid;
            cmnd.Parameters.Add("@rErrorMsg", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
            cmnd.Parameters.Add("@rErrorCode", SqlDbType.Int, 2).Direction = ParameterDirection.Output;

            SqlDataReader dr;

            try
            {
                // Open the data connection
                cmnd.Connection = conn;
                conn.Open();

                // Execute the command
                dr = cmnd.ExecuteReader();

                int retCode = int.Parse(cmnd.Parameters["@rErrorCode"].Value.ToString());
                if (retCode != 0)
                {
                    retVal = retCode + "|" + cmnd.Parameters["@rErrorMsg"].Value.ToString();
                }

            }
            catch (SqlException ex)
            {

                if (ex.Number != 0)
                {
                    retVal = ex.Number + "|" + ex.Message;
                }

            }

            return retVal;
        }
    }
}

