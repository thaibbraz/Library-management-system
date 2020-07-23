using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados
{
    class Estatistica
    {
        #region Metodos

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
