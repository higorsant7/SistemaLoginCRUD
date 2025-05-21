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
    public partial class CadastroForm: Form
    {
        public CadastroForm()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Conexao conexao = new Conexao();
            var conn = conexao.ObterConexao();
            conn.Open();

            string query = "INSERT INTO usuarios (nome, email, senha, nivel_acesso) VALUES (@Nome, @Email, @Senha, @NivelAcesso)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Senha", txtSenha.Text);
            cmd.Parameters.AddWithValue("@NivelAcesso", cmbNivelAcesso.SelectedItem.ToString());

            cmd.ExecuteNonQuery();
            MessageBox.Show("Usuário cadastrado com sucesso!");

            conn.Close();
            this.Hide();
        }

        private void cmbNivelAcesso_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
