using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using System.Data.SqlClient;
using System.IO;

namespace Local_Money.objectos
{
    class FuncionarioListado
    {
        Conexao con = new Conexao();
        frm_dashboard d = (frm_dashboard)Application.OpenForms[1];
        private int Id;

        public FuncionarioListado(int id, string nome, string cargo, string ultimoAcesso, string ultimoLogout)
        {
            Id = id;
            BotaoApagar.Click += (sender2, e2) => Apagar(sender2, e2);
            BotaoEditar.Click += (sender2, e2) => Editar(sender2, e2);
            BotaoVisualizar.Click += (sender2, e2) => Visualizar(sender2, e2);

            string[] data1 = ultimoAcesso.Split(' ');
            string[] data2 = ultimoLogout.Split(' ');

            LabelId.Text = id.ToString();
            LabelNome.Text = nome;
            LabelCargo.Text = cargo;
            LabelAcessoDia.Text = data1[0];
            LabelAcessoHora.Text = data1[1];
            LabelSaidaDia.Text = data2[0];
            LabelSaidaHora.Text = data2[1];

            PainelUsuario.Controls.Add(LabelId);
            PainelUsuario.Controls.Add(LabelNome);
            PainelUsuario.Controls.Add(LabelCargo);
            PainelUsuario.Controls.Add(LabelAcessoDia);
            PainelUsuario.Controls.Add(LabelAcessoHora);
            PainelUsuario.Controls.Add(LabelSaidaDia);
            PainelUsuario.Controls.Add(LabelSaidaHora);
            PainelUsuario.Controls.Add(BotaoApagar);
            PainelUsuario.Controls.Add(BotaoEditar);
            PainelUsuario.Controls.Add(BotaoVisualizar);

        }

        private Panel PainelUsuario = new Panel
        {
            Width = 731,
            Height = 80,
        };

        private Label LabelId = new Label
        {
            AutoSize = true,
            Location = new Point(15,35),
            Font = new Font("Roboto", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),

        };

        private Label LabelNome = new Label
        {
            AutoSize = true,
            Location = new Point(80, 35),
            Font = new Font("Roboto", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
        };

        private Label LabelCargo = new Label
        {
            AutoSize = true,
            Location = new Point(255, 35),
            Font = new Font("Roboto", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
        };

        private Label LabelAcessoDia = new Label
        {
            AutoSize = true,
            Location = new Point(355, 20),
            Font = new Font("Roboto", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
        };

        private Label LabelAcessoHora = new Label
        {
            AutoSize = true,
            Location = new Point(365, 55),
            Font = new Font("Roboto", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
        };

        private Label LabelSaidaDia = new Label
        {
            AutoSize = true,
            Location = new Point(450, 20),
            Font = new Font("Roboto", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
        };

        private Label LabelSaidaHora = new Label
        {
            AutoSize = true,
            Location = new Point(460, 55),
            Font = new Font("Roboto", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
        };

        private Button BotaoVisualizar = new Button
        {
            AutoSize = true,
            Location = new Point(555, 35),
            Padding = new Padding(5, 5, 0, 0),
            Width = 35,
            Height = 35,
            BackColor = Color.DarkSlateGray,
            BackgroundImage = Properties.Resources.user,
            BackgroundImageLayout = ImageLayout.Zoom,
            FlatStyle = FlatStyle.Flat,
        };

        private Button BotaoEditar = new Button
        {
            AutoSize = true,
            Location = new Point(610, 35),
            Padding = new Padding(5, 5, 0, 0),

            Width = 35,
            Height = 35,
            BackColor = Color.Gold,
            BackgroundImage = Properties.Resources.editar_arquivo,
            BackgroundImageLayout = ImageLayout.Zoom,
            FlatStyle = FlatStyle.Flat,
        };

        private Button BotaoApagar = new Button
        {
            AutoSize = true,
            Location = new Point(665, 35),
            Padding = new Padding(5, 5, 0, 0),
            Width = 35,
            Height = 35,
            BackColor = Color.Brown,
            BackgroundImage = Properties.Resources.delete,
            BackgroundImageLayout = ImageLayout.Zoom,
            FlatStyle = FlatStyle.Flat,
        };

        private void Visualizar(Object sender, EventArgs e)
        {
            con.abrir();
            FormularioUsuario fu = new FormularioUsuario();
            fu.flag = 0;
            fu.p_ra.Visible = true;
            fu.p_id.Visible = true;
            fu.txt_registo.Enabled = false;
            fu.txt_id.Enabled = false;
            fu.txt_nome.Enabled = false;
            fu.txt_telefone.Enabled = false;
            fu.txt_email.Enabled = false;
            fu.txt_pass.Enabled = false;
            fu.txt_pass2.Enabled = false;
            fu.cb_nivel_acesso.Enabled = false;
            fu.btn_upload.Visible = false;
            fu.btn_concluir.Visible = false;
            fu.btn_cancelar.Visible = false;

            SqlCommand com = new SqlCommand
            {
                CommandText = "SELECT * FROM tb_user WHERE id_user ='" + Id + "'",
                Connection = con.SaberConexao(),
            };
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                fu.txt_id.Text = reader.GetInt32(0).ToString();
                fu.txt_nome.Text = reader.GetString(1);
                fu.txt_email.Text = reader.GetString(2);
                fu.txt_telefone.Text = reader.GetValue(3).ToString();
                if(reader.GetInt32(5) == 1)
                {
                    fu.cb_nivel_acesso.Text = "Administrador";
                }
                else
                {
                    fu.cb_nivel_acesso.Text = "Operdadorr";
                }
                fu.txt_pass.Text = reader.GetValue(6).ToString();
                fu.txt_registo.Text = reader.GetString(8);
                fu.pb_imagem.Image = null;
                /*
                if (!DBNull.Value.Equals(reader.GetValue(11)))
                {
                    byte[] img = (byte[])(reader.GetValue(11));
                    fu.pb_imagem.Image = ConverterImagem.GetImage((byte[])reader.GetValue(11));
                    fu.pb_imagem.Image = null;
                }
                else
                {
                    fu.pb_imagem.Image = null;
                }
                */
            }
            con.fechar();
            d.AbrirJanela(fu);
        }
        private void Editar(Object sender, EventArgs e)
        {
            con.abrir();
            FormularioUsuario fu = new FormularioUsuario();
            fu.flag = 1;
            fu.p_ra.Visible = true;
            fu.p_id.Visible = true;
            fu.txt_registo.Enabled = false;
            fu.txt_id.Enabled = false;
            fu.txt_nome.Enabled = true;
            fu.txt_telefone.Enabled = true;
            fu.txt_email.Enabled = true;
            fu.txt_pass.Enabled = true;
            fu.txt_pass2.Enabled = true;
            fu.cb_nivel_acesso.Enabled = true;
            fu.btn_upload.Visible = true;
            fu.btn_concluir.Visible = true;
            fu.btn_cancelar.Visible = true;

            SqlCommand com = new SqlCommand
            {
                CommandText = "SELECT * FROM tb_usuário WHERE id_user ='" + Id + "'",
                Connection = con.SaberConexao(),
            };
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                fu.txt_id.Text = reader.GetInt32(0).ToString();
                fu.txt_nome.Text = reader.GetString(1);
                fu.txt_email.Text = reader.GetString(2);
                fu.txt_telefone.Text = reader.GetValue(3).ToString();
                if (reader.GetInt32(5) == 1)
                {
                    fu.cb_nivel_acesso.Text = "Administrador";
                }
                else
                {
                    fu.cb_nivel_acesso.Text = "Operdadorr";
                }
                fu.txt_pass.Text = reader.GetValue(6).ToString();
                fu.txt_registo.Text = reader.GetString(8);
                fu.pb_imagem.Image = null;
            }
            con.fechar();
            d.AbrirJanela(fu);
        }
        private void Apagar(Object sender, EventArgs e)
        {
            con.abrir();
            SqlCommand com = new SqlCommand
            {
                CommandText = "DELETE FROM tb_user WHERE id_user = '" + Id + "'",
                Connection = con.SaberConexao(),
            };
            com.ExecuteNonQuery();
            con.fechar();
            MessageBox.Show("Usuário removido!!");

            d.AbrirJanela(new RestauranteIngredientes());
        }

        public Panel Criar()
        {
            return PainelUsuario;
        }
    }
}
