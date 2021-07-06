using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Local_Money.modelos
{
    class CartaoCategoriaCardapio
    {
        int id_cat;

        Conexao con = new Conexao();

        Panel PainelCartao = new Panel
        {
            Width = 205,
            Height = 170,
            Cursor = Cursors.Hand,
        };

        Panel PainelCima = new Panel
        {
            Height = 2,
            BackColor = System.Drawing.Color.DarkSlateGray,
            Dock = DockStyle.Top,
        };

        Panel PainelBaixo = new Panel
        {
            Height = 2,
            BackColor = System.Drawing.Color.DarkSlateGray,
            Dock = DockStyle.Bottom,
        };

        Panel PainelDireita = new Panel
        {
            Width = 2,
            BackColor = System.Drawing.Color.DarkSlateGray,
            Dock = DockStyle.Right,
        };

        Panel PainelEsquerda = new Panel
        {
            Width = 2,
            BackColor = System.Drawing.Color.DarkSlateGray,
            Dock = DockStyle.Left,
        };

        Panel PainelBack = new Panel
        {
            Width = 150,
            Height = 125,
            Location = new System.Drawing.Point(25, 30),
            BackColor = System.Drawing.Color.DarkSlateGray,
        };

        Panel PainelFront = new Panel
        {
            Width = 110,
            Height = 110,
            Location = new System.Drawing.Point(45, 13),
            BackColor = System.Drawing.SystemColors.MenuHighlight,
        };

        PictureBox IconeCategoria = new PictureBox
        {
            Width = 64,
            Height = 64,
            Location = new System.Drawing.Point(22,20),
            Image = global::Local_Money.Properties.Resources._004_chef,
        };

        Label NomeCategoria = new Label
        {
            ForeColor = System.Drawing.SystemColors.Control,
            Dock = DockStyle.Bottom,
            Padding = new System.Windows.Forms.Padding(10, 0, 0, 5),
            Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
            
        };

        public CartaoCategoriaCardapio (string n, int i, FlowLayoutPanel flp_cardapio)
        {

            id_cat = i;

            PainelBack.Click += (sender2, e2) => Categoria_Click(sender2, e2, flp_cardapio);
            PainelBaixo.Click += (sender2, e2) => Categoria_Click(sender2, e2, flp_cardapio);
            PainelCartao.Click += (sender2, e2) => Categoria_Click(sender2, e2, flp_cardapio);
            PainelCima.Click += (sender2, e2) => Categoria_Click(sender2, e2, flp_cardapio);
            PainelDireita.Click += (sender2, e2) => Categoria_Click(sender2, e2, flp_cardapio);
            PainelEsquerda.Click += (sender2, e2) => Categoria_Click(sender2, e2, flp_cardapio);
            PainelFront.Click += (sender2, e2) => Categoria_Click(sender2, e2, flp_cardapio);
            IconeCategoria.Click += (sender2, e2) => Categoria_Click(sender2, e2, flp_cardapio);
            NomeCategoria.Click += (sender2, e2) => Categoria_Click(sender2, e2, flp_cardapio);

            PainelFront.Controls.Add(IconeCategoria);
            PainelBack.Controls.Add(NomeCategoria);
            PainelCartao.Controls.Add(PainelEsquerda);
            PainelCartao.Controls.Add(PainelCima);
            PainelCartao.Controls.Add(PainelBaixo);
            PainelCartao.Controls.Add(PainelDireita);
           
            PainelCartao.Controls.Add(PainelFront);
            PainelCartao.Controls.Add(PainelBack);

            NomeCategoria.Text = n;

            
        }

        public Panel Criar ()
        {
            return PainelCartao;
        }

        

        private void Categoria_Click(object sender, EventArgs e, FlowLayoutPanel flp_cardapio)
        {
            

            con.abrir();

            try
            {
                SqlCommand com = new SqlCommand
                {
                    Connection = con.SaberConexao(),
                    CommandText = "SELECT * FROM tb_categoria WHERE id_menu = '" + id_cat + "'",
                };
                SqlDataReader reader = com.ExecuteReader();

                flp_cardapio.Controls.Clear();
                while (reader.Read())
                {
                    CartaoSubCategoriaCardapio cartao = new CartaoSubCategoriaCardapio(reader.GetString(1), reader.GetInt32(0), flp_cardapio);
                    flp_cardapio.Controls.Add(cartao.Criar());
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Erro!!!!! " + er);
            }

            con.fechar();
        }
    }
}
