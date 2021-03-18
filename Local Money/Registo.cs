using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;

namespace Local_Money
{
    public partial class Registo : Form
    {
        string email;
        int telefone;
        Conexao conn = new Conexao();
        public Registo()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            this.Hide();
            l.ShowDialog();
            
        }

        private void btnRegistar_Click(object sender, EventArgs e)
        {

            if(txtNome.Text == null || txtNome.Text == "Primeiro e último nome" || txtNome.Text == "")
            {
                txtNome.Text = "Primeiro e último nome";
                txtNome.ForeColor = Color.Red;
            }
            if(txtEmail.Text == null || txtEmail.Text == "Email" || txtEmail.Text == "")
            {
                txtEmail.Text = "Email";
                txtEmail.ForeColor = Color.Red;
            }
            if(txtTelefone.Text == null || txtTelefone.Text == "Telefone" || txtTelefone.Text == "")
            {
                txtTelefone.Text = "Telefone";
                txtTelefone.ForeColor = Color.Red;
            }
            if(txtPass.Text == null || txtPass.Text == "Palavra-passe" || txtPass.Text == "")
            {
                txtPass.Text = "Palavra-passe";
                txtPass.ForeColor = Color.Red;
            }
            if(txtConfirmar.Text == null || txtConfirmar.Text == "Confirmar palavra-passe" || txtConfirmar.Text == "")
            {
                txtConfirmar.Text = "Confirmar palavra-passe";
                txtConfirmar.ForeColor = Color.Red;
            }
            else
            {
                if(txtPass.Text == txtConfirmar.Text)
                {
                    conn.abrir();

                    SqlCommand com = new SqlCommand();
                    com.Connection = conn.SaberConexao();
                    com.CommandText = "SELECT * FROM tb_user WHERE email = '" + txtEmail.Text + "' OR telefone = '" + txtTelefone.Text + "'";
                    SqlDataReader reader = com.ExecuteReader();

                    if (reader.Read() == false)
                    {
                        reader.Close();
                        SqlCommand com2 = new SqlCommand();
                        com2.Connection = conn.SaberConexao();
                        com2.CommandText = "INSERT INTO tb_user (nome,email,telefone,saldo,nivel_acesso,password,numero_transacoes,data_hora_registo) VALUES ('" + txtNome.Text + "','" + txtEmail.Text + "','" + txtTelefone.Text + "','0','1','" + txtPass.Text + "','0','" + DateTime.Now.ToString() + "')";
                        com2.ExecuteNonQuery();
                        MessageBox.Show("Usuário registado com sucesso. Pode realizar o login");

                        Login l = new Login();
                        this.Hide();
                        l.ShowDialog();
                        
                    }
                    else
                    {

                        while(reader.Read())
                        {
                            email = reader.GetString(2);
                            telefone = int.Parse(reader.GetValue(3).ToString());
                        }
                        reader.Close();
                        MessageBox.Show("Já existe nenhum usuário com estas credenciais");
                        if(txtEmail.Text == email)
                        {
                            txtEmail.ForeColor = Color.Red;
                        }
                        if (txtTelefone.Text == email)
                        {
                            txtTelefone.ForeColor = Color.Red;
                        }
                    
                    }

                    conn.fechar();
                }
                else
                {
                    MessageBox.Show("As palavras-passes têm de ser iguais");
                    txtConfirmar.ForeColor = Color.Red;
                }
            }
        }

        private void txtNome_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            txtNome.ForeColor = Color.Black;
            
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
            txtEmail.Clear();
            txtEmail.ForeColor = Color.Black;
        }

        private void txtTelefone_Click(object sender, EventArgs e)
        {
            txtTelefone.Clear();
            txtTelefone.ForeColor = Color.Black;
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            txtPass.Clear();
            txtPass.ForeColor = Color.Black;
            txtPass.PasswordChar = '*';
        }

        private void txtConfirmar_Click(object sender, EventArgs e)
        {
            txtConfirmar.Clear();
            txtConfirmar.ForeColor = Color.Black;
            txtPass.PasswordChar = '*';
        }

        
    }
}
