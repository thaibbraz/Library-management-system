using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CamadaDados
{
    public class Livro
    {
        #region Metodos

        public static bool Gravar(int id, String titulo, String autor, bool aberto, ref string sErro)
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
                cmd.CommandText = "GravarLivro";

                SqlParameter param = new SqlParameter("Id", SqlDbType.Int);
                param.Value = id;
                cmd.Parameters.Add(param);

                SqlParameter param2 = new SqlParameter("Titulo", SqlDbType.NVarChar, 50);
                param2.Value = titulo;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("Autor", SqlDbType.NVarChar, 50);
                param3.Value = autor;
                cmd.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter("Aberto", SqlDbType.Bit);
                param4.Value = aberto;
                cmd.Parameters.Add(param4);

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
                sqlCommand.CommandText = "ListarLivros";

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
                cmd.CommandText = "EliminarLivro";

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

        public static DataTable ObterLivrosAbertos(Boolean aberto)
        {
            DataTable dataTable = null;
            try
            {
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = Properties.Settings.Default.BD;
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.Text;

                string comando = "SELECT * FROM [Livro] WHERE [Aberto] LIKE '%" + 1 + "%'";

                sqlCommand.CommandText = comando;

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
