using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaLoginCRUD
{
    public partial class LoginForm: Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Conexao conexao = new Conexao();
            var conn = conexao.ObterConexao();
            conn.Open();

            string query = "SELECT * FROM usuarios WHERE email = @Email AND senha = @Senha";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Senha", txtSenha.Text);

            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                // Login bem-sucedido
                MessageBox.Show("Login realizado com sucesso!");
                // Abrir o formulário principal
                this.Hide();
                UsuariosForm usuariosForm = new UsuariosForm();
                usuariosForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Email ou senha incorretos.");
            }

            conn.Close();
        }

        private void btnCadastrarSe_Click(object sender, EventArgs e)
        {
            CadastroForm cadastroForm = new CadastroForm();
            cadastroForm.ShowDialog();
        }
    }
}
