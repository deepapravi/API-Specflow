using System;
using System.Data;
using System.Data.SqlClient;

namespace APTSpecFlowTestAutomationProject.Helpers
{
    public static class DataHelperExtensions
    {




        public static SqlConnection DBConnect(string connectionString)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                return sqlConnection;
            }
            catch (Exception e)
            {
                // LogHelpers.Write("ERROR :: " + e.Message);
            }

            return null;
        }


        //Closing the connection 
        public static void DBClose(this SqlConnection sqlConnection)
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                //LogHelpers.Write("ERROR :: " + e.Message);
            }
        }


        //Execution
        public static DataTable ExecuteQuery(SqlConnection sqlConnection, string queryString)
        {

            DataSet dataset;
            try
            {
                //Checking the state of the connection
                if (sqlConnection == null || ((sqlConnection != null && (sqlConnection.State == ConnectionState.Closed ||
                    sqlConnection.State == ConnectionState.Broken))))
                    sqlConnection.Open();

                SqlDataAdapter dataAdaptor = new SqlDataAdapter();
                dataAdaptor.SelectCommand = new SqlCommand(queryString, sqlConnection);
                dataAdaptor.SelectCommand.CommandType = CommandType.Text;

                dataset = new DataSet();
                dataAdaptor.Fill(dataset, "table");
                //foreach (DataRow row in dataset.Tables[0].Rows)
                //{
                //   float OrgValue = ((float)(row["Org_Value"]));
                //    var OrgValueRounded = Math.Round(OrgValue, 1, MidpointRounding.AwayFromZero);

                //}
                sqlConnection.Close();
              //  return dataset.Tables["table"];

                return dataset.Tables[0];

            }
            catch (Exception e)
            {
                dataset = null;
                sqlConnection.Close();
              //  LogHelpers.Write("ERROR :: " + e.Message);
                return null;
            }
            finally
            {
                sqlConnection.Close();
                dataset = null;
            }


        }



    }
}
