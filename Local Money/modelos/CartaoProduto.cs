using Local_Money.modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Local_Money
{
    class CartaoProduto
    {
        private Conexao con = new Conexao();
        public int IdProduto;
        PedidoNovo pn = (PedidoNovo)Application.OpenForms[2];

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

        Panel PainelProduto = new Panel
        {
            Width = 185,
            Height = 150,
            Location = new System.Drawing.Point(10, 10),
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom,
        };

        Panel PainelPreco = new Panel
        {
            Width = 100,
            Height = 20,
            Location = new System.Drawing.Point(0, 30),
            BackColor = System.Drawing.SystemColors.MenuHighlight,
        };

        Panel PainelNome = new Panel
        {
            Width = 145,
            Height = 20,
            Location = new System.Drawing.Point(41,102),
            BackColor = System.Drawing.SystemColors.MenuHighlight,
        };

        Panel PainelConfirma = new Panel
        {
            Width = 40,
            Height = 40,
            Location = new System.Drawing.Point(0, 0),
            BackColor = Color.Transparent,
            BackgroundImageLayout = ImageLayout.Zoom,
        };

        Label Preco = new Label
        {
            Font = new System.Drawing.Font("Roboto Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
            ForeColor = Color.Black,

        };

        Label Nome = new Label
        {
            Font = new System.Drawing.Font("Roboto Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
            ForeColor = Color.Black,
            Dock = DockStyle.Fill,
        };

        public CartaoProduto(string nome, bool disp, float preco, int id, Image imagem)
        {
            IdProduto = id;

            PainelBaixo.Click += (sender2, e2) => Produto_Click(sender2, e2);
            PainelCartao.Click += (sender2, e2) => Produto_Click(sender2, e2);
            PainelCima.Click += (sender2, e2) => Produto_Click(sender2, e2);
            PainelConfirma.Click += (sender2, e2) => Produto_Click(sender2, e2);
            PainelDireita.Click += (sender2, e2) => Produto_Click(sender2, e2);
            PainelEsquerda.Click += (sender2, e2) => Produto_Click(sender2, e2);
            PainelNome.Click += (sender2, e2) => Produto_Click(sender2, e2);
            PainelPreco.Click += (sender2, e2) => Produto_Click(sender2, e2);
            PainelProduto.Click += (sender2, e2) => Produto_Click(sender2, e2);
            Preco.Click += (sender2, e2) => Produto_Click(sender2, e2);
            Nome.Click += (sender2, e2) => Produto_Click(sender2, e2);

            if(disp == false)
            {
                indisponivel();
            }

            Nome.Text = nome;
            Preco.Text = "Kz " + preco;
            PainelProduto.BackgroundImage = imagem;

            PainelCartao.Controls.Add(PainelCima);
            PainelCartao.Controls.Add(PainelBaixo);
            PainelCartao.Controls.Add(PainelDireita);
            PainelCartao.Controls.Add(PainelEsquerda);

            PainelPreco.Controls.Add(Preco);
            PainelNome.Controls.Add(Nome);

            PainelProduto.Controls.Add(PainelPreco);
            PainelProduto.Controls.Add(PainelNome);
            PainelProduto.Controls.Add(PainelConfirma);

            PainelCartao.Controls.Add(PainelProduto);

        }

        public Panel Criar()
        {
            return PainelCartao;
        }

        
        private void Produto_Click(object sender, EventArgs e)
        {
            con.abrir();

            try
            {
                ProdutoListado pl = new ProdutoListado(Nome.Text, Preco.Text, IdProduto);
                pn.p_lista_produtos.Controls.Add(pl.Criar());
                pn.produtos.Add(IdProduto);
                pn.numero_produtos++;
                foreach(var item in pn.prod_selec)
                {
                    pn.label_teste.Text = pn.label_teste.Text + item + ", ";
                }
                selecionado();
                
            }
            catch (Exception er)
            {
                MessageBox.Show("Erro!!!!! " + er);
            }

            con.fechar();
        }

        

        private void indisponivel ()
        {
            PainelCima.BackColor = Color.Brown;
            PainelBaixo.BackColor = Color.Brown;
            PainelDireita.BackColor = Color.Brown;
            PainelEsquerda.BackColor = Color.Brown;
            PainelConfirma.BackColor = Color.Brown;
            PainelNome.BackColor = Color.Brown;
            PainelPreco.BackColor = Color.Brown;
            PainelConfirma.BackgroundImage = global::Local_Money.Properties.Resources.cancel_button;
            PainelCartao.Cursor = Cursors.Default;
            PainelCartao.Enabled = false;
        }

        public void selecionado()
        {
            PainelCima.BackColor = SystemColors.MenuHighlight;
            PainelBaixo.BackColor = SystemColors.MenuHighlight;
            PainelDireita.BackColor = SystemColors.MenuHighlight;
            PainelEsquerda.BackColor = SystemColors.MenuHighlight;
            PainelConfirma.BackColor = SystemColors.MenuHighlight;
            PainelConfirma.BackgroundImage = global::Local_Money.Properties.Resources.check_mark;
            PainelCartao.Cursor = Cursors.Default;
            PainelCartao.Enabled = false;
        }

        public void Removido()
        {
            PainelCima.BackColor = Color.DarkSlateGray;
            PainelBaixo.BackColor = Color.DarkSlateGray;
            PainelDireita.BackColor = Color.DarkSlateGray;
            PainelEsquerda.BackColor = Color.DarkSlateGray;
            PainelConfirma.BackColor = Color.DarkSlateGray;
            PainelConfirma.BackgroundImage = null;
            PainelCartao.Cursor = Cursors.Hand;
            PainelCartao.Enabled = false;
        }
    }
}
