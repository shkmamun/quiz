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
                SqlParameter[] arParms = new SqlParameter[16];

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

                arParms[14] = new SqlParameter("@Password", SqlDbType.VarChar, 50);
                arParms[14].Value = obj.Password;

                arParms[15] = new SqlParameter("@Platform", SqlDbType.VarChar, 100);
                arParms[15].Value = obj.Platform;

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
        public int ActivateParticipant(string RefCode)
        {
            SqlConnection connection = null;
            int Result = 0;

            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@RefCode", SqlDbType.VarChar, 50);
                arParms[0].Value = RefCode;

                connection = GetConnection();

                Result = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "ActivateParticipant", arParms);

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


            return Result;
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
                if (dt.Rows.Count > 0)
                {
                    obj.Status = Convert.ToInt32(dt.Rows[0]["Status"].ToString());
                    obj.StartDate = Convert.ToDateTime(dt.Rows[0]["StartDate"].ToString());
                    obj.EndDate = Convert.ToDateTime(dt.Rows[0]["EndDate"].ToString());
                    obj.NumOfQuestion = Convert.ToInt32(dt.Rows[0]["NumOfQuestion"].ToString());
                }
            }

            return obj;
        }

        public Question GetNextQuestion(string RefCode)
        {
            SqlConnection connection = null;
            DataSet Result;
            Question obj = new Question();
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@RefCode", SqlDbType.VarChar, 50);
                arParms[0].Value = RefCode;

                connection = GetConnection();

                Result = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "GetNextQuestion", arParms);

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
                if (dt.Rows.Count > 0)
                {
                    obj.QuestionId = Convert.ToInt32(dt.Rows[0]["QuestionId"].ToString());
                    obj.CategoryId = Convert.ToInt32(dt.Rows[0]["CategoryId"].ToString());
                    obj.Priority = Convert.ToInt32(dt.Rows[0]["Priority"].ToString());
                    obj.DifficultyLevel = Convert.ToInt32(dt.Rows[0]["DifficultyLevel"].ToString());
                    obj.QuestionText = dt.Rows[0]["QuestionText"].ToString();
                    obj.OptionA = dt.Rows[0]["OptionA"].ToString();
                    obj.OptionB = dt.Rows[0]["OptionB"].ToString();
                    obj.OptionC = dt.Rows[0]["OptionC"].ToString();
                    obj.OptionD = dt.Rows[0]["OptionD"].ToString();
                    obj.AnswerText = dt.Rows[0]["AnswerText"].ToString();
                    obj.TimeLimit = Convert.ToInt32(dt.Rows[0]["TimeLimit"].ToString());
                    obj.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"].ToString());
                    //obj.CategoryName = dt.Rows[0]["CategoryName"].ToString();
                    obj.CurrAnsNo = Convert.ToInt32(dt.Rows[0]["CurrAnsNo"].ToString());
                    obj.NumOfQuestion = Convert.ToInt32(dt.Rows[0]["NumOfQuestion"].ToString());
                    obj.ContestId = Convert.ToInt32(dt.Rows[0]["ContestId"].ToString());

                }
            }

            return obj;
        }

        public int InsertAnswer(Answer obj)
        {
            SqlConnection connection = null;

            try
            {
                SqlParameter[] arParms = new SqlParameter[5];

                arParms[0] = new SqlParameter("@RefCode", SqlDbType.VarChar, 64);
                arParms[0].Value = obj.RefCode;

                arParms[1] = new SqlParameter("@QuestionId", SqlDbType.Int);
                arParms[1].Value = obj.QuestionId;

                arParms[2] = new SqlParameter("@AnswerText", SqlDbType.Char, 100);
                arParms[2].Value = obj.AnswerText;

                arParms[3] = new SqlParameter("@TimeTaken", SqlDbType.Int);
                arParms[3].Value = obj.TimeTaken;

                arParms[4] = new SqlParameter("@ProgrammeId", SqlDbType.Int);
                arParms[4].Value = obj.ProgrammeId;


                connection = GetConnection();

                int id = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "Answer_Insert", arParms);

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

        public Contest GetActiveContest()
        {
            SqlConnection connection = null;
            DataSet Result;
            Contest obj = new Contest();
            try
            {
                connection = GetConnection();

                Result = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "GetActiveContest");

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
                obj.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"].ToString());
                obj.StartDate = Convert.ToDateTime(dt.Rows[0]["StartDate"].ToString());
                obj.EndDate = Convert.ToDateTime(dt.Rows[0]["EndDate"].ToString());
                obj.NumOfQuestion = Convert.ToInt32(dt.Rows[0]["NumOfQuestion"].ToString());
            }

            return obj;
        }

        public List<Question> GetAllQuestions()
        {
            SqlConnection connection = null;
            DataSet Result;
            List<Question> questions = new List<Question>();

            try
            {
                connection = GetConnection();

                Result = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "GetAllQuestions");

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
                foreach (DataRow row in dt.Rows)
                {
                    Question question = new Question();
                    question.AnswerText = row["AnswerText"].ToString();
                    question.CategoryId = Convert.ToInt32(row["CategoryId"].ToString());
                    question.CategoryName = row["CategoryName"].ToString();
                    question.DifficultyLevel = Convert.ToInt32(row["DifficultyLevel"].ToString());
                    question.IsActive = Convert.ToBoolean(row["IsActive"].ToString());
                    question.OptionA = row["OptionA"].ToString();
                    question.OptionB = row["OptionB"].ToString();
                    question.OptionC = row["OptionC"].ToString();
                    question.OptionD = row["OptionD"].ToString();
                    question.Priority = Convert.ToInt32(row["Priority"].ToString());
                    question.QuestionId = Convert.ToInt32(row["QuestionId"].ToString());
                    question.QuestionText = row["QuestionText"].ToString();
                    question.TimeLimit = Convert.ToInt32(row["TimeLimit"].ToString());
                    questions.Add(question);
                }

            }

            return questions;
        }

        public bool DeleteQuestion(int questionID)
        {
            SqlConnection connection = null;
            int result = 0;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@questionID", SqlDbType.Int, 50);
                arParms[0].Value = questionID;

                connection = GetConnection();

                result = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "DeleteQuestion", arParms);

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


            return result == 1;
        }

        public List<Category> GetAllCategories()
        {
            SqlConnection connection = null;
            DataSet Result;
            List<Category> categories = new List<Category>();

            try
            {
                connection = GetConnection();

                Result = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "GetAllCategories");

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
                foreach (DataRow row in dt.Rows)
                {
                    Category category = new Category();
                    category.CategoryId = Convert.ToInt32(row["CategoryId"].ToString());
                    category.CategoryName = row["CategoryName"].ToString();
                    categories.Add(category);
                }

            }

            return categories;
        }

        public int InsertQuestion(Question obj)
        {
            SqlConnection connection = null;

            try
            {
                SqlParameter[] arParms = new SqlParameter[11];

                arParms[0] = new SqlParameter("@AnswerText", SqlDbType.VarChar, 50);
                arParms[0].Value = obj.AnswerText;

                arParms[1] = new SqlParameter("@CategoryId", SqlDbType.Int);
                arParms[1].Value = obj.CategoryId;

                arParms[2] = new SqlParameter("@DifficultyLevel", SqlDbType.Int);
                arParms[2].Value = obj.DifficultyLevel;

                arParms[3] = new SqlParameter("@IsActive", SqlDbType.Bit);
                arParms[3].Value = obj.IsActive;

                arParms[4] = new SqlParameter("@OptionA", SqlDbType.VarChar, 50);
                arParms[4].Value = obj.OptionA;

                arParms[5] = new SqlParameter("@OptionB", SqlDbType.VarChar, 50);
                arParms[5].Value = obj.OptionB;

                arParms[6] = new SqlParameter("@OptionC", SqlDbType.VarChar, 50);
                arParms[6].Value = obj.OptionC;

                arParms[7] = new SqlParameter("@OptionD", SqlDbType.VarChar, 50);
                arParms[7].Value = obj.OptionD;

                arParms[8] = new SqlParameter("@Priority", SqlDbType.Int);
                arParms[8].Value = obj.Priority;

                arParms[9] = new SqlParameter("@QuestionText", SqlDbType.VarChar, 500);
                arParms[9].Value = obj.QuestionText;

                arParms[10] = new SqlParameter("@TimeLimit", SqlDbType.Int);
                arParms[10].Value = obj.TimeLimit;

                connection = GetConnection();

                int id = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "InsertQuestion", arParms);

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
        }

        public int UpdateQuestion(Question obj)
        {
            SqlConnection connection = null;

            try
            {
                SqlParameter[] arParms = new SqlParameter[12];

                arParms[0] = new SqlParameter("@AnswerText", SqlDbType.VarChar, 50);
                arParms[0].Value = obj.AnswerText;

                arParms[1] = new SqlParameter("@CategoryId", SqlDbType.Int);
                arParms[1].Value = obj.CategoryId;

                arParms[2] = new SqlParameter("@DifficultyLevel", SqlDbType.Int);
                arParms[2].Value = obj.DifficultyLevel;

                arParms[3] = new SqlParameter("@IsActive", SqlDbType.Bit);
                arParms[3].Value = obj.IsActive;

                arParms[4] = new SqlParameter("@OptionA", SqlDbType.VarChar, 50);
                arParms[4].Value = obj.OptionA;

                arParms[5] = new SqlParameter("@OptionB", SqlDbType.VarChar, 50);
                arParms[5].Value = obj.OptionB;

                arParms[6] = new SqlParameter("@OptionC", SqlDbType.VarChar, 50);
                arParms[6].Value = obj.OptionC;

                arParms[7] = new SqlParameter("@OptionD", SqlDbType.VarChar, 50);
                arParms[7].Value = obj.OptionD;

                arParms[8] = new SqlParameter("@Priority", SqlDbType.Int);
                arParms[8].Value = obj.Priority;

                arParms[9] = new SqlParameter("@QuestionText", SqlDbType.VarChar, 500);
                arParms[9].Value = obj.QuestionText;

                arParms[10] = new SqlParameter("@TimeLimit", SqlDbType.Int);
                arParms[10].Value = obj.TimeLimit;

                arParms[11] = new SqlParameter("@QuestionId", SqlDbType.Int);
                arParms[11].Value = obj.QuestionId;

                connection = GetConnection();

                int id = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "UpdateQuestion", arParms);

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
        }

        public Question GetQuestionByID(int questionID)
        {
            SqlConnection connection = null;
            DataSet Result;
            Question obj = new Question();
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@questionId", SqlDbType.Int);
                arParms[0].Value = questionID;

                connection = GetConnection();

                Result = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "GetQuestionByID", arParms);

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
                obj.QuestionId = Convert.ToInt32(dt.Rows[0]["QuestionId"].ToString());
                obj.CategoryId = Convert.ToInt32(dt.Rows[0]["CategoryId"].ToString());
                obj.AnswerText = dt.Rows[0]["AnswerText"].ToString();
                obj.DifficultyLevel = Convert.ToInt32(dt.Rows[0]["DifficultyLevel"].ToString());
                obj.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"].ToString());
                obj.OptionA = dt.Rows[0]["OptionA"].ToString();
                obj.OptionB = dt.Rows[0]["OptionB"].ToString();
                obj.OptionC = dt.Rows[0]["OptionC"].ToString();
                obj.OptionD = dt.Rows[0]["OptionD"].ToString();
                obj.Priority = Convert.ToInt32(dt.Rows[0]["Priority"].ToString());
                obj.QuestionText = dt.Rows[0]["QuestionText"].ToString();
                obj.TimeLimit = Convert.ToInt32(dt.Rows[0]["TimeLimit"].ToString());
            }

            return obj;
        }

        public List<Question> GetQuestionsBySearch(int categoryID, int priority, int difficultyLevel, string questionText, string active)
        {
            SqlConnection connection = null;
            DataSet Result;
            List<Question> questions = new List<Question>();

            try
            {
                SqlParameter[] arParms = new SqlParameter[5];

                arParms[0] = new SqlParameter("@categoryID", SqlDbType.Int);
                arParms[0].Value = categoryID;

                arParms[1] = new SqlParameter("@priority", SqlDbType.Int);
                arParms[1].Value = priority;

                arParms[2] = new SqlParameter("@difficultyLevel", SqlDbType.Int);
                arParms[2].Value = difficultyLevel;

                arParms[3] = new SqlParameter("@questionText", SqlDbType.VarChar, 500);
                arParms[3].Value = questionText;

                arParms[4] = new SqlParameter("@isActive", SqlDbType.VarChar);
                arParms[4].Value = active;

                connection = GetConnection();

                Result = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "GetQuestionsBySearch", arParms);

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
                foreach (DataRow row in dt.Rows)
                {
                    Question question = new Question();
                    question.AnswerText = row["AnswerText"].ToString();
                    question.CategoryId = Convert.ToInt32(row["CategoryId"].ToString());
                    question.CategoryName = row["CategoryName"].ToString();
                    question.DifficultyLevel = Convert.ToInt32(row["DifficultyLevel"].ToString());
                    question.IsActive = Convert.ToBoolean(row["IsActive"].ToString());
                    question.OptionA = row["OptionA"].ToString();
                    question.OptionB = row["OptionB"].ToString();
                    question.OptionC = row["OptionC"].ToString();
                    question.OptionD = row["OptionD"].ToString();
                    question.Priority = Convert.ToInt32(row["Priority"].ToString());
                    question.QuestionId = Convert.ToInt32(row["QuestionId"].ToString());
                    question.QuestionText = row["QuestionText"].ToString();
                    question.TimeLimit = Convert.ToInt32(row["TimeLimit"].ToString());
                    questions.Add(question);
                }

            }

            return questions;
        }

        public bool CheckDuplicateEmail(string userName)
        {
            bool isExist = false;
            SqlConnection connection = null;
            DataSet Result;

            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@Email", SqlDbType.VarChar, 100);
                arParms[0].Value = userName;

                connection = GetConnection();

                Result = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "CheckDuplicateEmail", arParms);

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
                if (dt.Rows.Count > 0)
                {
                    isExist = true;
                }


            }

            return isExist;

        }

        public Participant GetParticipant(string userName)
        {
            SqlConnection connection = null;
            DataSet Result;
            Participant obj = null;

            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@userName", SqlDbType.VarChar, 100);
                arParms[0].Value = userName;


                connection = GetConnection();

                Result = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "GetParticipant", arParms);

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
                if (dt.Rows.Count > 0)
                {
                    obj = new Participant();
                    obj.Email = dt.Rows[0]["Email"].ToString();
                    obj.Password = dt.Rows[0]["Password"].ToString();
                    obj.FirstName = dt.Rows[0]["FirstName"].ToString();
                    obj.LastName = dt.Rows[0]["LastName"].ToString();
                }
            }

            return obj;
        }
        public UserInfo GetLoginInfo(string userName)
        {
            SqlConnection connection = null;
            DataSet Result;
            UserInfo obj = null;

            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@userName", SqlDbType.VarChar, 100);
                arParms[0].Value = userName;

                connection = GetConnection();

                Result = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "GetLoginInfo", arParms);

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
                if (dt.Rows.Count > 0)
                {
                    obj = new UserInfo();

                    obj.LoginName = dt.Rows[0]["LoginName"].ToString();
                    obj.Password = dt.Rows[0]["Password"].ToString();
                    obj.UserName = dt.Rows[0]["UserName"].ToString();
                    obj.Email = dt.Rows[0]["Email"].ToString();
                    obj.RoleId = Convert.ToInt32(dt.Rows[0]["RoleId"].ToString());

                }
            }

            return obj;
        }

        public List<Programme> GetAllProgramme(int id = 0)
        {
            SqlConnection connection = null;
            DataSet Result;
            List<Programme> list = new List<Programme>();

            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@id", SqlDbType.VarChar, 100);
                arParms[0].Value = id;

                connection = GetConnection();

                Result = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "GetAllProgramme", arParms);

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

                foreach (DataRow row in dt.Rows)
                {
                    Programme obj = new Programme();

                    obj.ProgrammeId = Convert.ToInt32(row["ProgrammeId"].ToString());
                    obj.ProgrammeName = row["ProgrammeName"].ToString();
                    obj.StartDate = Convert.ToDateTime(row["StartDate"].ToString());
                    obj.EndDate = Convert.ToDateTime(row["EndDate"].ToString());
                    obj.NumOfQuestion = Convert.ToInt32(row["NumOfQuestion"].ToString());
                    obj.TimeLimit = Convert.ToInt32(row["TimeLimit"].ToString());
                    obj.IsHourly = Convert.ToBoolean(row["IsHourly"].ToString());
                    obj.IsActive = Convert.ToBoolean(row["IsActive"].ToString());

                    list.Add(obj);
                }
            }

            return list;
        }

        public int InsertProgramme(Programme obj)
        {
            SqlConnection connection = null;

            try
            {
                SqlParameter[] arParms = new SqlParameter[8];

                arParms[0] = new SqlParameter("@ProgrammeName", SqlDbType.VarChar, 100);
                arParms[0].Value = obj.ProgrammeName;

                arParms[1] = new SqlParameter("@StartDate", SqlDbType.DateTime);
                arParms[1].Value = obj.StartDate;

                arParms[2] = new SqlParameter("@EndDate", SqlDbType.DateTime);
                arParms[2].Value = obj.EndDate;

                arParms[3] = new SqlParameter("@NumOfQuestion", SqlDbType.Int);
                arParms[3].Value = obj.NumOfQuestion;

                arParms[4] = new SqlParameter("@TimeLimit", SqlDbType.Int);
                arParms[4].Value = obj.TimeLimit;

                arParms[5] = new SqlParameter("@IsHourly", SqlDbType.Bit);
                arParms[5].Value = obj.IsHourly;

                arParms[6] = new SqlParameter("@IsActive", SqlDbType.Bit);
                arParms[6].Value = obj.IsActive;

                arParms[7] = new SqlParameter("@ProgrammeId", SqlDbType.Int);
                arParms[7].Value = obj.ProgrammeId;

                connection = GetConnection();

                int id = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "InsertUpdateProgramme", arParms);

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
        public int UpdateProgramme(Programme obj)
        {
            SqlConnection connection = null;

            try
            {
                //SqlParameter[] arParms = new SqlParameter[8];

                //arParms[0] = new SqlParameter("@ProgrammeName", SqlDbType.VarChar, 100);
                //arParms[0].Value = obj.ProgrammeName;

                //arParms[1] = new SqlParameter("@StartDate", SqlDbType.DateTime);
                //arParms[1].Value = obj.StartDate;

                //arParms[2] = new SqlParameter("@EndDate", SqlDbType.DateTime);
                //arParms[2].Value = obj.EndDate;

                //arParms[3] = new SqlParameter("@NumOfQuestion", SqlDbType.Int);
                //arParms[3].Value = obj.NumOfQuestion;

                //arParms[4] = new SqlParameter("@TimeLimit", SqlDbType.Int);
                //arParms[4].Value = obj.TimeLimit;

                //arParms[5] = new SqlParameter("@IsHourly", SqlDbType.Bit);
                //arParms[5].Value = obj.IsHourly;

                //arParms[6] = new SqlParameter("@IsActive", SqlDbType.Bit);
                //arParms[6].Value = obj.IsActive;

                //arParms[7] = new SqlParameter("@ProgrammeId", SqlDbType.Int);
                //arParms[7].Value = obj.ProgrammeId;

                //connection = GetConnection();

                //int id = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "InsertUpdateProgramme", arParms);

                //return id;
                connection = GetConnection();
                var sql = "UPDATE [dbo].[Programme]"
                          + " SET [ProgrammeName] ='" + obj.ProgrammeName+"'"
                          + ", [StartDate] = '" + obj.StartDate.ToShortDateString() + "'"
                          + ", [EndDate] = '" + obj.EndDate.ToShortDateString() + "'"
                          + ", [NumOfQuestion] = " + obj.NumOfQuestion
                          + ", [TimeLimit] =" + obj.TimeLimit
                          + ", [IsHourly] =" + (obj.IsHourly?1:0)
                          + ", [IsActive] =" + (obj.IsActive ? 1 : 0)
                          + " WHERE [ProgrammeId]  =" + obj.ProgrammeId;

                int id = SqlHelper.ExecuteNonQuery(connection, CommandType.Text, sql);

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
    }
}
