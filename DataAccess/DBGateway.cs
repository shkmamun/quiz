using Entity;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DBGateway
    {
        private SqlConnection GetConnection()
        {
            string connStr = ConfigurationManager.ConnectionStrings["QuizDBConn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connStr);
            connection.Open();
            return connection;
        }
        public int InsertParticipant(Participant obj)
        {
            SqlConnection connection = null;

            try
            {
                SqlParameter[] arParms = new SqlParameter[14];

                arParms[0] = new SqlParameter("@RefCode", SqlDbType.VarChar, 64);
                arParms[0].Value = obj.RefCode;

                arParms[1] = new SqlParameter("@FirstName", SqlDbType.VarChar, 50);
                arParms[1].Value = obj.FirstName;

                arParms[2] = new SqlParameter("@LastName", SqlDbType.Char, 50);
                arParms[2].Value = obj.LastName;

                arParms[3] = new SqlParameter("@Gender", SqlDbType.VarChar, 1);
                arParms[3].Value = obj.Gender;

                arParms[4] = new SqlParameter("@Address", SqlDbType.VarChar, 200);
                arParms[4].Value = obj.Address;

                arParms[5] = new SqlParameter("@City", SqlDbType.VarChar, 50);
                arParms[5].Value = obj.City;

                arParms[6] = new SqlParameter("@Phone", SqlDbType.VarChar, 50);
                arParms[6].Value = obj.Phone;

                arParms[7] = new SqlParameter("@Email", SqlDbType.VarChar, 50);
                arParms[7].Value = obj.Email;

                arParms[8] = new SqlParameter("@DateOfBirth", SqlDbType.DateTime);
                arParms[8].Value = obj.DateOfBirth;

                arParms[9] = new SqlParameter("@Age", SqlDbType.Int);
                arParms[9].Value = obj.Age;

                arParms[10] = new SqlParameter("@Profession", SqlDbType.VarChar, 50);
                arParms[10].Value = obj.Profession;

                arParms[11] = new SqlParameter("@Organization", SqlDbType.VarChar, 50);
                arParms[11].Value = obj.Organization;

                arParms[12] = new SqlParameter("@IPAddress", SqlDbType.VarChar, 50);
                arParms[12].Value = obj.IPAddress;


                arParms[13] = new SqlParameter("@Device", SqlDbType.VarChar, 50);
                arParms[13].Value = obj.Device;

                connection = GetConnection();

                int id = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "Participant_Insert", arParms);

                return id;

            }

            catch (Exception ex)
            {
                throw new Exception("Cannot Add", ex);
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }

            return 0;
        }

        public Contest GetContestValidation(string RefCode)
        {
            SqlConnection connection = null;
            DataSet Result;
            Contest obj = new Contest();
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@RefCode", SqlDbType.VarChar, 50);
                arParms[0].Value = RefCode;

                connection = GetConnection();

                Result = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "GetContestValidation", arParms);

            }
            catch (Exception ex)
            {

                throw new Exception("Cannot get information.", ex);
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }

            if (Result.Tables.Count > 0)
            {
                DataTable dt = Result.Tables[0];
                obj.Status = Convert.ToInt32(dt.Rows[0]["Status"].ToString());
                obj.StartDate = Convert.ToDateTime(dt.Rows[0]["StartDate"].ToString());
                obj.EndDate = Convert.ToDateTime(dt.Rows[0]["EndDate"].ToString());
                obj.NumOfQuestion = Convert.ToInt32(dt.Rows[0]["NumOfQuestion"].ToString());
            }

            return obj;
        }

    }
}
