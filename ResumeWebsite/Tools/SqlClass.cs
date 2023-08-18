using System.Collections.Specialized;
using System.Data;
using System.Collections.Specialized;
using System.Data.SqlClient;

using Dapper;
using ResumeWebsite.Models;

namespace ResumeWebsite.Tools
{
    public class SqlClass
    {
        private SqlConnection GetConnection()
        {
            const string dataSource = "BLACKSTAR";
            const string initialCatalog = "PersonalDb";
            //const bool integratedSecurity = true;
            string conString = $"Data Source={dataSource};initial catalog={initialCatalog};integrated Security=true;";
            return new SqlConnection(conString);
        }




        public IEnumerable<SkillsModel> SelectDb_Dapper_Skills(string query)
        {
            var conn = GetConnection();
            IEnumerable<SkillsModel> obj;
            try
            {
                conn.Open();

                obj = conn.Query<SkillsModel>(query);

                conn.Close();
            }
            catch
            {
                try
                {
                    conn.Close();
                }
                catch (Exception)
                {
                    throw;
                }
                throw;
            }
            return obj;
        }





        public IEnumerable<T> SelectDb<T>(string queryStr)
        {
            var conn = GetConnection();
            IEnumerable<T> obj_;
            try
            {
                conn.Open();

                obj_ = conn.Query<T>(queryStr);

                conn.Close();
            }
            catch
            {
                try
                {
                    conn.Close();
                }
                catch (Exception)
                {

                }
                throw;
            }
            return obj_;
        }





        public DataTable SelectDb(string query)
        {
            var conn = GetConnection();
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
                conn.Close();
            }
            catch
            {
                try
                {
                    conn.Close();
                }
                catch (Exception)
                {
                    throw;
                }
                throw;
            }
            return dt;
        }





        public DataTable SelectDb_Param(string select_Query, NameValueCollection param)
        {

            var conn = GetConnection();
            string query = select_Query;
            DataTable dt = new DataTable();
            ///////////
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            foreach (string s in param.AllKeys)
            {
                cmd.Parameters.Add(new SqlParameter(s, param[s]));
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            da.Dispose();
            return dt;
        }




        public int Insert_Dynamic_Query(string tblName, NameValueCollection param)
        {
            var conn = GetConnection();
            conn.Open();
            string str = "";
            string comma = "";
            foreach (var item in param.AllKeys)
            {
                str += comma + item;
                comma = ",";
            }
            string Query = $"insert into {tblName} ({str.Replace("@", "")}) values ({str}) ";
            SqlCommand cmd = new SqlCommand(Query, conn);
            foreach (string s in param.AllKeys)
            {
                cmd.Parameters.Add(new SqlParameter(s, param[s]));
            }
            int r = cmd.ExecuteNonQuery();
            conn.Close();
            return r;
        }






        public int Batch_Insert_Dynamic_Query(string tblName, List<NameValueCollection> param)
        {
            var conn = GetConnection();
            string str = "";
            string comma = "";
            foreach (var item in param[0].AllKeys)
            {
                str += comma + item;
                comma = ",";
            }
            string Query = $"insert into {tblName} ({str.Replace("@", "")}) values ({str}) ";
            conn.Open();
            SqlCommand cmd = new SqlCommand(Query, conn);
            int r = 0;
            foreach (var item in param)
            {
                cmd.Parameters.Clear();
                foreach (string s in item.AllKeys)
                {
                    cmd.Parameters.Add(new SqlParameter(s, item[s]));
                }
                r = cmd.ExecuteNonQuery();
            }

            conn.Close();
            return r;
        }
    }
}
