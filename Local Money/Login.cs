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
    public partial class Login : Form
    {
        Conexao conn = new Conexao();

        public int Id;
        public string Nome;
        public int Telefone;
        public float Saldo;
        public string Email;

        
        public Login()
        {
            InitializeComponent();
        }


        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUser_Click(object sender, EventArgs e)
        {
            txtUser.Clear();
            txtUser.ForeColor = Color.Black;
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            txtPass.Clear();
            txtUser.ForeColor = Color.Black;
            txtPass.PasswordChar = '*';
        }

        private void btnRegistar_Click(object sender, EventArgs e)
        {
            Registo r = new Registo();
            this.Hide();
            r.ShowDialog();
            
            
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUser.Text == null || txtUser.Text == "Usuário")
                {
                    txtUser.ForeColor = Color.Red;
                }
                if (txtPass.Text == null || txtPass.Text == "Palavra-Passe")
                {
                    txtPass.ForeColor = Color.Red;
                }
                else
                {
                    conn.abrir();

                    SqlCommand com = new SqlCommand();
                    com.Connection = conn.SaberConexao();
                    com.CommandText = "SELECT * FROM tb_user WHERE id_user = '" + int.Parse(txtUser.Text.ToString()) + "' AND password = '" + txtPass.Text.ToString() + "'";

                    SqlDataReader reader = com.ExecuteReader();
                    if(reader.Read() == false)
                    {
                        MessageBox.Show("Não existe nenhum usuário com estas credenciais");
                        txtUser.ForeColor = Color.Red;
                        txtPass.ForeColor = Color.Red;
                    }
                    else
                    {
                        while (reader.Read())
                        {

                            Id = int.Parse(reader.GetValue(0).ToString());
                            Nome = reader.GetString(1);
                            Email = reader.GetString(2);
                            Telefone = int.Parse(reader.GetValue(3).ToString());
                            Saldo = float.Parse(reader.GetValue(4).ToString());
                        }
                        reader.Close();
                        SqlCommand com2 = new SqlCommand();
                        com2.Connection = conn.SaberConexao();
                        com2.CommandText = "UPDATE tb_user SET ultimo_login = '" + DateTime.Now.ToString() + "'";
                        com2.ExecuteNonQuery();

                        /*
                        Home h = new Home();
                        h.Id = Id;
                        h.Nome = Nome;
                        h.Telefone = Telefone;
                        h.Email = Email;
                        this.Hide();
                        h.ShowDialog();
                        */

                        frm_dashboard d = new frm_dashboard();
                        d.Id = Id;
                        d.Nome = Nome;
                        d.Email = Email;
                        d.lbl_user.Text = Nome;
                        this.Hide();
                        d.Show();
                    }
                    

                    conn.fechar();
                }
            }
            catch(Exception er)
            {
                MessageBox.Show("Erro " + er);
            }            
        }
    }
}
