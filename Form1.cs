using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Projeto {
    public partial class FormLogin : Form {

        private MySqlConnection con;
        public FormLogin() {
            InitializeComponent();

            string conexao = "Server=localhost;Database=future_founds;Uid=root;Pwd=55286333;";
            con = new MySqlConnection(conexao);
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void btnEntrar_Click(object sender, EventArgs e) {
            string email = txtEmail.Text;
            string senha = txtSenha.Text;

            try {
                con.Open();

                string sql = "SELECT senha FROM Login WHERE email = @email";

                using (MySqlCommand cmd = new MySqlCommand(sql, con)) {
                    cmd.Parameters.AddWithValue("email", email);

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null) {
                        string senhaBanco = resultado.ToString();

                        if (senha == senhaBanco) {
                            MessageBox.Show("Seja bem-vindo!");
                            TelaMenu telamenu = new TelaMenu();
                            telamenu.Show();
                            this.Hide();
                        }
                        else {
                            MessageBox.Show("Senha incorreta!");
                        }
                    }
                    else {
                        MessageBox.Show("Usuário não encontrado");
                    }

                }
            }
            catch (Exception ex) {
                MessageBox.Show("Erro ao conectar com o banco de dados" + ex.Message);
            }
            finally {
                con.Close();
            }
        }

        private void txtSenha_TextChanged(object sender, EventArgs e) {

        }
    }
}
