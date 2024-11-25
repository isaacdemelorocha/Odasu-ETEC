using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

public class ClasseConexao
{
    private SqlConnection conexao;

    public SqlConnection conectar()
    {
        try
        {
            if (conexao == null || conexao.State == ConnectionState.Closed)
            {
                string strConexao = "Password=1234; Persist Security Info=True; User ID=sa; Initial Catalog=odasu; Data Source=" + Environment.MachineName;
                conexao = new SqlConnection(strConexao);
                conexao.Open();
            }
            return conexao;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao conectar: " + ex.Message);
            desconectar();
            return null;
        }
    }

    public void desconectar()
    {
        try
        {
            if (conexao != null && conexao.State == ConnectionState.Open)
            {
                conexao.Close();
                conexao.Dispose();
                conexao = null;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao desconectar: " + ex.Message);
        }
    }

    public DataTable executarSQL(string comando_sql)
    {
        try
        {
            conectar();
            using (SqlDataAdapter adaptador = new SqlDataAdapter(comando_sql, conexao))
            {
                DataSet ds = new DataSet();
                adaptador.Fill(ds);
                return ds.Tables[0];
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao executar SQL: " + ex.Message);
            return null;
        }
        finally
        {
            desconectar();
        }
    }

    public bool manutencaoDB(string comando_sql)
    {
        try
        {
            conectar();
            using (SqlCommand comando = new SqlCommand(comando_sql, conexao))
            {
                comando.ExecuteNonQuery();
                return true;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao manter DB: " + ex.Message);
            return false;
        }
        finally
        {
            desconectar();
        }
    }

    public int manutencaoDB_Parametros(SqlCommand comando)
    {
        int retorno = 0;
        try
        {
            comando.Connection = conectar();  // Adiciona a conexão ao SQLCommand
            retorno = comando.ExecuteNonQuery(); // Devolve o número de linhas afetadas
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao executar comando: " + ex.Message);
        }
        finally
        {
            desconectar();
        }
        return retorno;
    }
}
