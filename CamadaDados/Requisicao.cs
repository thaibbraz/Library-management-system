using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados
{
    public class Requisicao
    {

        #region Metodos

        public static bool Gravar(int id, DateTime dataInicio, DateTime dataFim, bool devolvido ,int idRequisitor, int idLivro, ref string sErro)
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
                cmd.CommandText = "GravarRequisicao";

                SqlParameter param = new SqlParameter("Id", SqlDbType.Int);
                param.Value = id;
                cmd.Parameters.Add(param);

                param = new SqlParameter("DataInicio", SqlDbType.DateTime);
                param.Value = dataInicio;
                cmd.Parameters.Add(param);

                param = new SqlParameter("DataFim", SqlDbType.DateTime);
                param.Value = dataFim;
                cmd.Parameters.Add(param);

                param = new SqlParameter("Devolvido", SqlDbType.Bit);
                param.Value = devolvido;
                cmd.Parameters.Add(param);

                param = new SqlParameter("IdRequisitor", SqlDbType.Int);
                param.Value = idRequisitor;
                cmd.Parameters.Add(param);

                param = new SqlParameter("IdLivro", SqlDbType.Int);
                param.Value = idLivro;
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
                sqlCommand.CommandText = "ListarRequisicoes";

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
                cmd.CommandText = "EliminarRequisicao";

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

        public static DataTable ObterEstatistica()
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
                sqlCommand.CommandText = "ListarEstatistica";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult);

                dataTable = new DataTable();
                dataTable.Load(sqlDataReader);

                sqlConnection.Close();
            }
            catch (Exception e)
            {

            }
            return dataTable;

        }

        public static DataTable ObterEstatistica(DateTime dataInicio, DateTime dataFim)
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
                sqlCommand.CommandText = "ListarEstatisticaEntreDatas";

                SqlParameter param = new SqlParameter("DataInicio", SqlDbType.DateTime);
                param.Value = dataInicio;
                sqlCommand.Parameters.Add(param);

                param = new SqlParameter("DataFim", SqlDbType.DateTime);
                param.Value = dataFim;
                sqlCommand.Parameters.Add(param);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult);

                dataTable = new DataTable();
                dataTable.Load(sqlDataReader);

                sqlConnection.Close();
            }
            catch (Exception e)
            {

            }
            return dataTable;

        }

        #endregion
    }


}
