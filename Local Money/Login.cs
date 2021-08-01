﻿using System;
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

        private int Id;
        private string Nome;
        private int Telefone;
        private float Saldo;
        private string Email;
        private int NivelAcesso;

        private int flag = 0;
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
            conn.abrir();
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
                    

                    SqlCommand com = new SqlCommand();
                    com.Connection = conn.SaberConexao();
                    com.CommandText = "SELECT * FROM tb_user WHERE id_user = '" + int.Parse(txtUser.Text.ToString()) + "' AND password = '" + txtPass.Text.ToString() + "'";
                    SqlDataReader reader = com.ExecuteReader();
                    if (reader.HasRows)
                    {
                        frm_dashboard d = new frm_dashboard();
                        while (reader.Read())
                        {

                            Id = int.Parse(reader.GetValue(0).ToString());
                            Nome = reader.GetValue(1).ToString();
                            Email = reader.GetValue(2).ToString();
                            Telefone = int.Parse(reader.GetValue(3).ToString());
                            NivelAcesso = reader.GetInt32(5);
                        }
                        reader.Close();
                        SqlCommand com2 = new SqlCommand();
                        com2.Connection = conn.SaberConexao();
                        com2.CommandText = "UPDATE tb_user SET ultimo_login = '" + DateTime.Now.ToString() + "' WHERE id_user = '" + Id + "'";
                        com2.ExecuteNonQuery();

                        string[] s = DateTime.Today.ToString().Split('/');
                        int dia = int.Parse(s[0]);
                        SqlCommand com3 = new SqlCommand();
                        com3.Connection = conn.SaberConexao();
                        com3.CommandText = "SELECT * FROM tb_dia";
                        SqlDataReader reader3 = com3.ExecuteReader();
                        while(reader3.Read())
                        {
                            if(reader3.GetInt32(0) == dia)
                            {
                                d.clientes = reader3.GetInt32(2);
                                d.dinheiro = double.Parse(reader3.GetValue(1).ToString());
                            }
                            else
                            {
                                flag = 1;
                            }
                        }
                        reader3.Close();

                        SqlCommand com5 = new SqlCommand();
                        com5.Connection = conn.SaberConexao();
                        com5.CommandText = "SELECT * FROM tb_mes WHERE dia = '" + dia + "'";
                        SqlDataReader reader5 = com5.ExecuteReader();
                        while(reader5.Read())
                        {
                            d.metaClientes = reader5.GetInt32(4);
                            d.metaDinheiro = double.Parse(reader5.GetValue(3).ToString());
                        }
                        reader5.Close();

                        if(flag == 1)
                        {
                            SqlCommand com4 = new SqlCommand();
                            com4.Connection = conn.SaberConexao();
                            com4.CommandText = "UPDATE tb_dia SET dia = '" + dia + "', receita = 0, clientes = 0";
                            com4.ExecuteNonQuery();
                            d.clientes = 0;
                            d.dinheiro = 0;
                        }
                        else
                        {

                        }

                        d.Id = Id;
                        d.Nome = Nome;
                        d.Email = Email;
                        d.NivelAcesso = NivelAcesso;
                        d.lbl_usuario.Text = Nome;

                        conn.fechar();
                        this.Hide();
                        d.ShowDialog();
                    }

                    else
                    {



                        MessageBox.Show("Não existe nenhum usuário com estas credenciais");
                        txtUser.ForeColor = Color.Red;
                        txtPass.ForeColor = Color.Red;
                    }
                }
            }
            catch(Exception er)
            {
                MessageBox.Show("Erro " + er);
            }
            conn.fechar();
        }
    }
}
