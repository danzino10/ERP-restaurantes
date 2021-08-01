using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Local_Money.objectos
{
    class BotaoTarefa
    {
        private int IdTarefa, IdUser, Estado;
        private string Mensagem, Assunto;

        Conexao con = new Conexao();
        PessoalTarefas pt = (PessoalTarefas)Application.OpenForms[2];
        frm_dashboard d = (frm_dashboard)Application.OpenForms[1];

        public BotaoTarefa(string mensagem, string assunto, int estado, int idTarefa, int idUser)
        {
            Mensagem = mensagem;
            Assunto = assunto;
            IdTarefa = idTarefa;
            IdUser = idUser;
            Estado = estado;

            Botao.Text = assunto;
            if(Estado == 1)
            {
                Botao.BackColor = Color.DarkSlateGray;
            }
            else
            {
                Botao.BackColor = Color.Brown;
            }

            Botao.Click += (sender2, e2) => Botao_Click(sender2, e2);
            PainelBotao.Controls.Add(Botao);
        }

        private Panel PainelBotao = new Panel
        {
            Width = 270,
            Height = 90,
            Dock = DockStyle.Top,
        };

        private Button Botao = new Button
        {
            Location = new Point(10, 15),
            Width = 240,
            Height = 60,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Roboto Medium", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
        };

        private void Botao_Click(Object sender, EventArgs e)
        {
            pt.cb_funcionario.Enabled = false;
            pt.txt_assunto.Enabled = false;
            pt.txt_mensagem.Enabled = false;
            pt.btn_publicar.Enabled = false;
            pt.lbl_count1.Visible = false;
            pt.lbl_count2.Visible = false;
            pt.IdTarefa = IdTarefa;

            con.abrir();
            SqlCommand com = new SqlCommand
            {
                CommandText = "SELECT * FROM tb_tarefa WHERE id_tarefa ='" + IdTarefa + "'",
                Connection = con.SaberConexao(),
            };
            SqlDataReader reader = com.ExecuteReader();
            while(reader.Read())
            {
                pt.cb_funcionario.Text = reader.GetInt32(3).ToString() + " - " + reader.GetString(4);
                pt.txt_assunto.Text = reader.GetString(5);
                pt.txt_mensagem.Text = "Por: " + reader.GetString(2) + Environment.NewLine;
                pt.txt_mensagem.Text += "Data: " + reader.GetString(8) + Environment.NewLine;
                if(reader.GetInt32(7) == 0)
                {
                    pt.txt_mensagem.Text += "Estado: A decorrer " + Environment.NewLine;
                    pt.btn_concluir.Visible = true;
                }
                else
                {
                    pt.txt_mensagem.Text += "Estado: Conluído " + Environment.NewLine;
                    pt.btn_cancelar.Visible = true;
                }
                pt.txt_mensagem.Text += reader.GetString(6);
            }

            con.fechar();
        }

        public Panel Criar()
        {
            return PainelBotao;
        }
    }
}
