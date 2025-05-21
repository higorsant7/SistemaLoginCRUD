using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
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
    public partial class UsuariosForm: Form
    {
        public UsuariosForm()
        {
            InitializeComponent();
        }

        private void btnInserir_Click(object sender, EventArgs e)
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
            MessageBox.Show("Usuário inserido com sucesso!");

            conn.Close();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["id"].Value);

                Conexao conexao = new Conexao();
                var conn = conexao.ObterConexao();
                conn.Open();

                string query = "UPDATE usuarios SET nome = @Nome, email = @Email, senha = @Senha, nivel_acesso = @NivelAcesso WHERE id = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Senha", txtSenha.Text);
                cmd.Parameters.AddWithValue("@NivelAcesso", cmbNivelAcesso.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Usuário atualizado com sucesso!");



                conn.Close();
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["id"].Value);

                Conexao conexao = new Conexao();
                var conn = conexao.ObterConexao();
                conn.Open();

                string query = "DELETE FROM usuarios WHERE id = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Usuário deletado com sucesso!");

                conn.Close();
            }
        }

        

        private void cmbNivelAcesso_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbNivelAcesso.Items.Add("Admin");
            cmbNivelAcesso.Items.Add("usuario");
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            Conexao conexao = new Conexao();
            var conn = conexao.ObterConexao();
            conn.Open();

            string query = "SELECT * FROM usuarios";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dgvUsuarios.DataSource = table;

            conn.Close();
        }
    }
}
