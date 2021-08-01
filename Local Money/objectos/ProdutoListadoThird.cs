using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using System.IO;
using Local_Money.objectos;
namespace Local_Money.objectos
{
    class ProdutoListadoThird
    {
        Conexao con = new Conexao();
        frm_dashboard d = (frm_dashboard)Application.OpenForms[1];
        private int Id;
        private string Disponibilidade;
        private int categoria, subcategoria;
        public ProdutoListadoThird(int id, string nome, string categoria, double preco, string disponibilidade)
        {
            Id = id;

            LabelId.Text = id.ToString();
            LabelNome.Text = nome;
            LabelCategoria.Text = categoria;
            LabelPreco.Text = preco + " Kz";
            LabelDisponibilidade.Text = disponibilidade;

            BotaoVizualizar.Click += (sender2, e2) => Visualizar(sender2, e2);
            BotaoEditar.Click += (sender2, e2) => Editar(sender2, e2);
            BotaoEliminar.Click += (sender2, e2) => Apagar(sender2, e2);

            PainelProduto.Controls.Add(LabelId);
            PainelProduto.Controls.Add(LabelNome);
            PainelProduto.Controls.Add(LabelCategoria);
            PainelProduto.Controls.Add(LabelPreco);
            PainelProduto.Controls.Add(LabelDisponibilidade);
            PainelProduto.Controls.Add(BotaoDisponivel);
            PainelProduto.Controls.Add(BotaoOcupado);
            PainelProduto.Controls.Add(BotaoVizualizar);
            PainelProduto.Controls.Add(BotaoEditar);
            PainelProduto.Controls.Add(BotaoEliminar);


        }

        private Panel PainelProduto = new Panel
        {
            Width = 730,
            Height = 80,
        };

        private Label LabelId = new Label
        {
            AutoSize = true,
            Location = new Point(15, 35),
            Font = new Font("Roboto", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)))
        };

        private Label LabelNome = new Label
        {
            AutoSize = true,
            Location = new Point(65, 20),
            Font = new Font("Roboto", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
            MaximumSize = new Size(150, 50)
        };

        private Label LabelCategoria = new Label
        {
            AutoSize = true,
            Location = new Point(225, 35),
            Font = new Font("Roboto", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)))
        };

        private Label LabelPreco = new Label
        {
            AutoSize = true,
            Location = new Point(315, 35),
            Font = new Font("Roboto", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)))
        };

        private Label LabelDisponibilidade = new Label
        {
            AutoSize = true,
            Location = new Point(435, 15),
            Font = new Font("Roboto", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)))
        };

        private Button BotaoDisponivel = new Button
        {
            Location = new Point(425, 35),
            Padding = new Padding(5, 5, 0, 0),
            AutoSize = true,
            BackgroundImageLayout = ImageLayout.Zoom,
            BackgroundImage = Properties.Resources.check_mark,
            BackColor = Color.DarkSlateGray,
            Width = 35,
            Height = 35,
            FlatStyle = FlatStyle.Flat,

        };

        private Button BotaoOcupado = new Button
        {
            Location = new Point(480, 35),
            Padding = new Padding(5, 5, 0, 0),
            AutoSize = true,
            BackgroundImageLayout = ImageLayout.Zoom,
            BackgroundImage = Properties.Resources.cancel_button,
            BackColor = Color.Brown,
            Width = 35,
            Height = 35,
            FlatStyle = FlatStyle.Flat,
        };

        private Button BotaoVizualizar = new Button
        {
            AutoSize = true,
            Location = new Point(555, 35),
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.DarkSlateGray,
            Height = 35,
            Width = 35,
            BackgroundImage = Properties.Resources.user,
            BackgroundImageLayout = ImageLayout.Zoom,
        };

        private Button BotaoEditar = new Button
        {
            AutoSize = true,
            Location = new Point(610, 35),
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.Gold,
            Height = 35,
            Width = 35,
            BackgroundImage = Properties.Resources.editar_arquivo,
            BackgroundImageLayout = ImageLayout.Zoom,
        };

        private Button BotaoEliminar = new Button
        {
            AutoSize = true,
            Location = new Point(665, 35),
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.Brown,
            Height = 35,
            Width = 35,
            BackgroundImage = Properties.Resources.delete,
            BackgroundImageLayout = ImageLayout.Zoom,
        };

        private void Visualizar(Object sender, EventArgs e)
        {
            con.abrir();
            FormularioMenu fu = new FormularioMenu();
            fu.flag = 1;
            fu.p_ra.Visible = false;
            fu.p_id.Visible = true;
            fu.txt_registo.Enabled = false;
            fu.txt_id.Enabled = false;
            fu.txt_nome.Enabled = false;
            fu.txt_descricao.Enabled = false;
            fu.txt_preco.Enabled = false;
            fu.cb_categoria.Enabled = false;
            fu.cb_estoque.Enabled = false;
            fu.cb_subcategoria.Enabled = false;
            fu.btn_upload.Visible = false;
            fu.btn_concluir.Visible = false;
            fu.btn_cancelar.Visible = false;

            SqlCommand com = new SqlCommand
            {
                CommandText = "SELECT * FROM tb_produto WHERE id_produto ='" + Id + "'",
                Connection = con.SaberConexao(),
            };
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                fu.txt_id.Text = reader.GetInt32(0).ToString();
                fu.txt_nome.Text = reader.GetString(3);
                fu.txt_descricao.Text = reader.GetString(6);
                fu.cb_estoque.Text = reader.GetValue(7).ToString();
                fu.txt_registo.Text = reader.GetString(8);
                categoria = reader.GetInt32(1);
                subcategoria = reader.GetInt32(2);
                fu.pb_imagem.Image = null;
            }
            reader.Close();

            SqlCommand com2 = new SqlCommand
            {
                CommandText = "SELECT * FROM tb_menu WHERE id_menu ='" + categoria + "'",
                Connection = con.SaberConexao(),
            };
            SqlDataReader reader2 = com2.ExecuteReader();
            while (reader2.Read())
            {
                fu.cb_categoria.Text = reader2.GetString(1);
            }
            reader2.Close();

            SqlCommand com3 = new SqlCommand
            {
                CommandText = "SELECT * FROM tb_categoria WHERE id_categoria ='" + subcategoria + "'",
                Connection = con.SaberConexao(),
            };
            SqlDataReader reader3 = com3.ExecuteReader();
            while (reader2.Read())
            {
                fu.cb_subcategoria.Text = reader3.GetString(1);
            }

            con.fechar();
            d.AbrirJanela(fu);
        }
        private void Editar(Object sender, EventArgs e)
        {
            con.abrir();
            FormularioMenu fu = new FormularioMenu();
            fu.flag = 1;
            fu.p_ra.Visible = true;
            fu.p_id.Visible = true;
            fu.txt_registo.Enabled = false;
            fu.txt_id.Enabled = false;
            fu.txt_nome.Enabled = true;
            fu.txt_descricao.Enabled = true;
            fu.txt_preco.Enabled = true;
            fu.cb_categoria.Enabled = true;
            fu.cb_estoque.Enabled = true;
            fu.cb_subcategoria.Enabled = false;
            fu.btn_upload.Visible = true;
            fu.btn_concluir.Visible = true;
            fu.btn_cancelar.Visible = true;

            SqlCommand com = new SqlCommand
            {
                CommandText = "SELECT * FROM tb_produto WHERE id_produto ='" + Id + "'",
                Connection = con.SaberConexao(),
            };
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                fu.txt_id.Text = reader.GetInt32(0).ToString();
                fu.txt_nome.Text = reader.GetString(3);
                fu.txt_descricao.Text = reader.GetString(6);
                fu.cb_estoque.Text = reader.GetValue(7).ToString();
                fu.txt_registo.Text = reader.GetString(8);
                categoria = reader.GetInt32(1);
                subcategoria = reader.GetInt32(2);
                fu.pb_imagem.Image = null;
            }
            reader.Close();

            SqlCommand com2 = new SqlCommand
            {
                CommandText = "SELECT * FROM tb_menu WHERE id_menu ='" + categoria + "'",
                Connection = con.SaberConexao(),
            };
            SqlDataReader reader2 = com2.ExecuteReader();
            while(reader2.Read())
            {
                fu.cb_categoria.Text = reader2.GetString(1);
            }
            reader2.Close();

            SqlCommand com3 = new SqlCommand
            {
                CommandText = "SELECT * FROM tb_categoria WHERE id_categoria ='" + subcategoria + "'",
                Connection = con.SaberConexao(),
            };
            SqlDataReader reader3 = com3.ExecuteReader();
            while (reader2.Read())
            {
                fu.cb_subcategoria.Text = reader3.GetString(1);
            }
            
            con.fechar();
            d.AbrirJanela(fu);
        }
        private void Apagar(Object sender, EventArgs e)
        {
            con.abrir();
            SqlCommand com = new SqlCommand
            {
                CommandText = "DELETE FROM tb_produto WHERE id_produto = '" + Id + "'",
                Connection = con.SaberConexao(),
            };
            com.ExecuteNonQuery();
            con.fechar();
            MessageBox.Show("Produto removido!!");

            d.AbrirJanela(new RestauranteIngredientes());
        }

        public Panel Criar()
        {
            return PainelProduto;
        }
    }
}
