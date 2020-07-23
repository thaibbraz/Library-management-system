using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados
{
    public class Requisitor
    {
        #region Metodos

        public static bool Gravar(int id, String nome, int telemovel, String curso, ref string sErro)
        {
            bool bOk = true;
            sErro = "";
            try
            {
                SqlParameter param = null;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = Properties.Settings.Default.BD;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GravarRequisitor";

                param = new SqlParameter("Id", SqlDbType.Int);
                param.Value = id;
                cmd.Parameters.Add(param);

                param = new SqlParameter("Nome", SqlDbType.NVarChar, 50);
                param.Value = nome;
                cmd.Parameters.Add(param);

                param = new SqlParameter("Telemovel", SqlDbType.Int);
                param.Value = telemovel;
                cmd.Parameters.Add(param);

                param = new SqlParameter("Curso", SqlDbType.NVarChar, 50);
                param.Value = curso;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception e)
            {
                sErro = e.Message;
                bOk = false;
            }
            return bOk;

        }

        public static DataTable ObterLista()

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
                sqlCommand.CommandText = "ListarRequisitores";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult);

                dataTable = new DataTable();
                dataTable.Load(sqlDataReader);
                sqlConnection.Close();

            }

            catch (Exception e)

            {
                throw new Exception("Erro:" + e);
            }
            return dataTable;

        }

        public static bool Eliminar(int id, ref string sErro)
        {
            bool bOk = true;
            sErro = "";
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Properties.Settings.Default.BD;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EliminarRequisitor";

                SqlParameter param = new SqlParameter("Id", SqlDbType.Int);
                param.Value = id;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception e)
            {
                sErro = e.Message;
                bOk = false;
            }
            return bOk;

        }

        #endregion

    }
}
