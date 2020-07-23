using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados
{
    public class User
    {
        #region Metodos

        public static DataTable GetList(ref string error)
        {
            DataTable dataTable = null;

            try
            {
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = Properties.Settings.Default.BD;
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "ListarUser";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult);

                dataTable = new DataTable();
                dataTable.Load(sqlDataReader);

                sqlConnection.Close();
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return dataTable;

        }

        
        public static bool Save(int id, string name, string password, ref string error)
        {

            bool bOk = true;
            error = "";
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Properties.Settings.Default.BD;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GuardarUser";

                SqlParameter param = new SqlParameter("Id", SqlDbType.Int);
                param.Value = id;
                cmd.Parameters.Add(param);

                param = new SqlParameter("Name", SqlDbType.NVarChar, 100);
                param.Value = name;
                cmd.Parameters.Add(param);

                param = new SqlParameter("Password", SqlDbType.NVarChar, 25);
                param.Value = password;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception e)
            {
                error = e.Message;
                bOk = false;
            }
            return bOk;

        }

        
        public static bool Delete(int id, ref string error)
        {

            bool bOk = true;
            error = "";
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Properties.Settings.Default.BD;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApagarUser";

                SqlParameter param = new SqlParameter("Id", SqlDbType.Int);
                param.Value = id;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception e)
            {
                error = e.Message;
                bOk = false;
            }
            return bOk;

        }

        #endregion

    }
}
