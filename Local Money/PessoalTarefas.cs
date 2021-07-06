using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Local_Money.objectos;

namespace Local_Money
{
    public partial class PessoalTarefas : Form
    {

        Conexao con = new Conexao();
        frm_dashboard d = (frm_dashboard)Application.OpenForms[1];

        public PessoalTarefas()
        {
            InitializeComponent();
        }

        private void PessoalTarefas_Load(object sender, EventArgs e)
        {
            con.abrir();
            SqlCommand com = new SqlCommand
            {
                CommandText = "SELECT * FROM tb_user",
                Connection = con.SaberConexao(),
            };
            SqlDataReader reader = com.ExecuteReader();
            while(reader.Read())
            {
                cb_funcionario.Items.Add(reader.GetValue(0).ToString() + " - " + reader.GetString(1));
            }
            reader.Close();

            SqlCommand com2 = new SqlCommand
            {
                CommandText = "SELECT * FROM tb_tarefa WHERE id_receptor = '" + d.Id + "' ORDER BY estado ASC",
                Connection = con.SaberConexao(),
            };
            SqlDataReader reader2 = com2.ExecuteReader();
            while (reader2.Read())
            {
                BotaoTarefa bt = new BotaoTarefa(reader2.GetString(6), reader2.GetString(5), reader2.GetInt32(7), reader2.GetInt32(0), d.Id);
                flp_tarefas.Controls.Add(bt.Criar());
            }
            con.fechar();
        }

        private void btn_publicar_Click(object sender, EventArgs e)
        {
            if (txt_assunto.Text == "")
            {
                lbl_erro_ass.Visible = true;
            }
            if (txt_mensagem.Text == "")
            {
                lbl_erro_mens.Visible = true;
            }
            if (cb_funcionario.Text == "" || cb_funcionario.Text == "Selecione um funcionário")
            {
                lbl_erro_func.Visible = true;
            }
            if(txt_assunto.Text != "" && txt_mensagem.Text != "" && cb_funcionario.Text != "" && cb_funcionario.Text != "Selecione um funcionário")
            {
                string[] receptor = cb_funcionario.Text.Split(' ');
                con.abrir();
                SqlCommand com = new SqlCommand
                {
                    CommandText = "INSERT INTO tb_tarefa VALUES('" + d.Id + "','" + d.Nome + "','" + receptor[0] + "','" + receptor[2] + "','" + txt_assunto.Text + "','" + txt_mensagem.Text + "','0','" + DateTime.Now.ToString() + "',' ')",
                    Connection = con.SaberConexao(),
                };
                com.ExecuteNonQuery();
                con.fechar();
                
                MessageBox.Show("Tarefa remetida com sucesso");
                cb_funcionario.Text = "Selecione um funcionário";
                txt_assunto.Text = "";
                txt_mensagem.Text = "";
            }
        }

        private void btn_nova_Click(object sender, EventArgs e)
        {
            cb_funcionario.Text = "Selecione um funcionário";
            cb_funcionario.Enabled = true;
            txt_assunto.Text = "";
            txt_assunto.Enabled = true;
            txt_mensagem.Text = "";
            txt_mensagem.Enabled = true;
            btn_concluir.Visible = false;
            btn_publicar.Enabled = true;
        }

        private void btn_concluir_Click(object sender, EventArgs e)
        {

        }

        private void txt_mensagem_TextChanged(object sender, EventArgs e)
        {
            string[] s = lbl_count1.Text.Split('/');
            lbl_count1.Text = txt_mensagem.Text.Length + "/300";
        }

        private void txt_assunto_TextChanged(object sender, EventArgs e)
        {
            string[] s = lbl_count2.Text.Split('/');
            lbl_count2.Text = txt_assunto.Text.Length + "/50";
        }
    }
}
