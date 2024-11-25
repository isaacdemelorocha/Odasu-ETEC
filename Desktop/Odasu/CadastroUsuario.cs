using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Odasu_MySQL
{
    internal class CadastroUsuario
    {
        private string cod_usuario;
        private string nome_usuario;
        private string sobrenome_usuario;
        private string cpf_usuario;
        private DateTime nasc_usuario;
        private string cel_usuario;
        private string email_usuario;
        private string senha_usuario;

        public string id
        {
            get { return cod_usuario; }
            set { cod_usuario = value; }
        }
        public string nome
        {
            get { return nome_usuario; }
            set { nome_usuario = value; }
        }

        public string sobrenome
        {
            get { return sobrenome_usuario; }
            set { sobrenome_usuario = value; }
        }

        public string cpf
        {
            get { return cpf_usuario; }
            set { cpf_usuario = value; }
        }

        public DateTime nascimento
        {
            get { return nasc_usuario; }
            set { nasc_usuario = value; }
        }

        public string celular
        {
            get { return cel_usuario; }
            set { cel_usuario = value; }
        }

        public string email
        {
            get { return email_usuario; }
            set { email_usuario = value; }
        }

        public string senha
        {
            get { return senha_usuario; }
            set { senha_usuario = value; }
        }

        public bool cadastrarUsuario()
        {
            ClasseConexao conexao = new ClasseConexao();
            string insert = "INSERT INTO tb_usuario (nome_usuario, sobrenome_usuario, cpf_usuario, nasc_usuario, cel_usuario, email_usuario, senha_usuario, status_usuario, tipo_conta) " +
                            "VALUES (@nome, @sobrenome, @cpf, @nascimento, @celular, @email, @senha, 'OFFLINE', 'ADM')";

            using (SqlCommand comandoSql = new SqlCommand(insert))
            {
                comandoSql.Parameters.AddWithValue("@nome", nome);
                comandoSql.Parameters.AddWithValue("@sobrenome", sobrenome);
                comandoSql.Parameters.AddWithValue("@cpf", cpf);
                comandoSql.Parameters.AddWithValue("@nascimento", nascimento);
                comandoSql.Parameters.AddWithValue("@celular", celular);
                comandoSql.Parameters.AddWithValue("@email", email);
                comandoSql.Parameters.AddWithValue("@senha", senha);

                return conexao.manutencaoDB_Parametros(comandoSql) > 0;
            }
        }

        public CadastroUsuario buscarUsuario(string cpf)
        {
            ClasseConexao conexao = new ClasseConexao();
            string select = "SELECT  cod_usuario, nome_usuario, sobrenome_usuario, cpf_usuario, nasc_usuario, cel_usuario, email_usuario " +
                            "FROM tb_usuario WHERE cpf_usuario = @cpf";

            using (SqlCommand comandoSql = new SqlCommand(select))
            {
                comandoSql.Parameters.AddWithValue("@cpf", cpf);

                try
                {
                    using (SqlConnection conn = conexao.conectar())
                    {
                        comandoSql.Connection = conn;
                        using (SqlDataReader reader = comandoSql.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new CadastroUsuario
                                {
                                    id = reader["cod_usuario"].ToString(),
                                    nome = reader["nome_usuario"].ToString(),
                                    sobrenome = reader["sobrenome_usuario"].ToString(),
                                    cpf = reader["cpf_usuario"].ToString(),
                                    nascimento = Convert.ToDateTime(reader["nasc_usuario"]),
                                    celular = reader["cel_usuario"].ToString(),
                                    email = reader["email_usuario"].ToString()
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível realizar a busca do usuário: " + ex.Message);
                }
            }
            return null;
        }

        public bool atualizarUsuario(string cpf)
        {
            ClasseConexao conexao = new ClasseConexao();
            string update = "UPDATE tb_usuario SET nome_usuario = @nome, sobrenome_usuario = @sobrenome, " +
                            "nasc_usuario = @nascimento, cel_usuario = @celular, " +
                            "email_usuario = @email, senha_usuario = @senha WHERE cpf_usuario = @cpf";

            using (SqlCommand comandoSql = new SqlCommand(update))
            {
                comandoSql.Parameters.AddWithValue("@nome", this.nome);
                comandoSql.Parameters.AddWithValue("@sobrenome", this.sobrenome);
                comandoSql.Parameters.AddWithValue("@nascimento", this.nascimento);
                comandoSql.Parameters.AddWithValue("@celular", this.celular);
                comandoSql.Parameters.AddWithValue("@email", this.email);
                comandoSql.Parameters.AddWithValue("@senha", this.senha);
                comandoSql.Parameters.AddWithValue("@cpf", cpf);

                return conexao.manutencaoDB_Parametros(comandoSql) > 0;
            }
        }

        public bool inativarUsuario(string cpf)
        {
            ClasseConexao conexao = new ClasseConexao();
            string update = "UPDATE tb_usuario SET status_usuario = 'INATIVO' WHERE cpf_usuario = @cpf";

            using (SqlCommand comandoSql = new SqlCommand(update))
            {
                comandoSql.Parameters.AddWithValue("@cpf", cpf);
                return conexao.manutencaoDB_Parametros(comandoSql) > 0;
            }
        }
    }
}