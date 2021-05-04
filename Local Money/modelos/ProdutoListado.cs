using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Local_Money.modelos
{
    class ProdutoListado
    {
        PedidoNovo pn = (PedidoNovo)Application.OpenForms[2];
        private string[] ss;
        private float valor_produto, total_produto, subtotal_geral;
        private int Id;
        public int Mesa;

        Panel PainelProduto = new Panel
        {
            Width = 320,
            Height = 75,
            Dock = DockStyle.Top,
        };

        public ProdutoListado(string nome, string preco, int IdProduto)
        {
            NomeProduto.Text = nome;
            ValorProduto.Text = preco;
            TotalProduto.Text = preco;
            Id = IdProduto;
            

            ss = pn.lbl_subtotal_valor.Text.Split(' ');
            string[]pp = preco.Split(' ');
            valor_produto = float.Parse(pp[1]);
            pn.lbl_subtotal_valor.Text = "Kz " + (float.Parse(ss[1]) + valor_produto).ToString();

            Adicionar.Click += new System.EventHandler(this.AdicinarQuantidade);
            Retirar.Click += new System.EventHandler(this.SubtrairQuantidade);
            Apagar.Click += new System.EventHandler(this.RetirarProduto);

            PainelProduto.Controls.Add(PainelBaixo);
            PainelProduto.Controls.Add(PainelCima);
            PainelProduto.Controls.Add(PainelDireita);
            PainelProduto.Controls.Add(PainelEsquerda);
            PainelProduto.Controls.Add(NomeProduto);
            PainelProduto.Controls.Add(QuantidadeProduto);
            PainelProduto.Controls.Add(TotalProduto);
            PainelProduto.Controls.Add(ValorProduto);
            PainelProduto.Controls.Add(Adicionar);
            PainelProduto.Controls.Add(Apagar);
            PainelProduto.Controls.Add(Retirar);

        }

        Panel PainelCima = new Panel
        {
            BackColor = System.Drawing.Color.DarkSlateGray,
            Location = new System.Drawing.Point(16, 34),
            Size = new System.Drawing.Size(67, 2),
        };

        Panel PainelBaixo = new Panel
        {
            BackColor = System.Drawing.Color.DarkSlateGray,
            Location = new System.Drawing.Point(16, 66),
            Size = new System.Drawing.Size(67, 2),
        };

        Panel PainelEsquerda = new Panel
        {
            BackColor = System.Drawing.Color.DarkSlateGray,
            Location = new System.Drawing.Point(16, 36),
            Size = new System.Drawing.Size(2, 30),
        };

        Panel PainelDireita = new Panel
        {
            BackColor = System.Drawing.Color.DarkSlateGray,
            Location = new System.Drawing.Point(81, 36),
            Size = new System.Drawing.Size(2, 30),
        };

        Label NomeProduto = new Label
        {
            Location = new System.Drawing.Point(6, 7),
            Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
            Padding = new System.Windows.Forms.Padding(5, 5, 0, 0),
            Size = new System.Drawing.Size(72, 24),
            TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
            AutoSize = true,
        };

        Label ValorProduto = new Label
        {
            Location = new System.Drawing.Point(103, 52),
            Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
            Size = new System.Drawing.Size(51, 15),
            TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
            AutoSize = true,
        };

        Label TotalProduto = new Label
        {
            Location = new System.Drawing.Point(217, 47),
            Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
            Size = new System.Drawing.Size(89, 20),
            TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
            Padding = new System.Windows.Forms.Padding(5, 5, 0, 0),
            AutoSize = true,
            Text = "Kz 0",
        };

        Label QuantidadeProduto = new Label
        {
            Location = new System.Drawing.Point(19, 44),
            Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
            Size = new System.Drawing.Size(14, 15),
            TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
            AutoSize = true,
            Text = "1",
            Tag = "0",
        };

        Button Retirar = new Button
        {
            BackColor = System.Drawing.Color.DarkSlateGray,
            FlatStyle = System.Windows.Forms.FlatStyle.Flat,
            Image = global::Local_Money.Properties.Resources.down_arrow2,
            Location = new System.Drawing.Point(60, 51),
            Size = new System.Drawing.Size(23, 15),
            UseVisualStyleBackColor = false,
            Cursor = Cursors.Hand,
            Enabled = false,
        };

        Button Adicionar = new Button
        {
            BackColor = System.Drawing.Color.DarkSlateGray,
            FlatStyle = System.Windows.Forms.FlatStyle.Flat,
            Image = global::Local_Money.Properties.Resources.up_arrow2,
            Location = new System.Drawing.Point(60, 36),
            Size = new System.Drawing.Size(23, 15),
            UseVisualStyleBackColor = false,
            Cursor = Cursors.Hand,
        };

        PictureBox Apagar = new PictureBox
        {
            Image = global::Local_Money.Properties.Resources.delete__1_,
            Location = new System.Drawing.Point(276, 6),
            Size = new System.Drawing.Size(32, 32),
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize,
            TabStop = false,
            Cursor = Cursors.Hand,
        };

        public Panel Criar()
        {
            return PainelProduto;
        }

        private void AdicinarQuantidade(object sender, EventArgs e)
        {
            QuantidadeProduto.Text = (int.Parse(QuantidadeProduto.Text) + 1).ToString();
            if (int.Parse(QuantidadeProduto.Text) > 1)
                Retirar.Enabled = true;
            else
                Retirar.Enabled = false;

            string[] vv = ValorProduto.Text.Split(' ');
            total_produto = int.Parse(QuantidadeProduto.Text) * float.Parse(vv[1]);
            TotalProduto.Text = "Kz " + total_produto.ToString();


            ss = pn.lbl_subtotal_valor.Text.Split(' ');
            subtotal_geral = float.Parse(ss[1]) + valor_produto;
            pn.lbl_subtotal_valor.Text = "Kz " + subtotal_geral.ToString();

        }

        private void SubtrairQuantidade(object sender, EventArgs e)
        {
            QuantidadeProduto.Text = (int.Parse(QuantidadeProduto.Text) - 1).ToString();
            if(QuantidadeProduto.Text == "1")
            {
                Retirar.Enabled = false;
            }

            string[] vv = ValorProduto.Text.Split(' ');
            total_produto = int.Parse(QuantidadeProduto.Text) * float.Parse(vv[1]);
            TotalProduto.Text = "Kz " + total_produto.ToString();

            ss = pn.lbl_subtotal_valor.Text.Split(' ');
            subtotal_geral = float.Parse(ss[1]) - valor_produto;
            pn.lbl_subtotal_valor.Text = "Kz " + subtotal_geral.ToString();

        }

        private void RetirarProduto(object sender, EventArgs e)
        {
            string[] vv = ValorProduto.Text.Split(' ');
            total_produto = int.Parse(QuantidadeProduto.Text) * float.Parse(vv[1]);
            ss = pn.lbl_subtotal_valor.Text.Split(' ');
            subtotal_geral = float.Parse(ss[1]) - total_produto;
            pn.lbl_subtotal_valor.Text = "Kz " + subtotal_geral.ToString();
            if (pn.produtos.Contains(Id))
                pn.produtos.Remove(Id);
            
            
            pn.p_lista_produtos.Controls.Remove(this.PainelProduto);
            /*
            PainelCima.BackColor = SystemColors.MenuHighlight;
            PainelBaixo.BackColor = SystemColors.MenuHighlight;
            PainelDireita.BackColor = SystemColors.MenuHighlight;
            PainelEsquerda.BackColor = SystemColors.MenuHighlight;
            PainelConfirma.BackColor = SystemColors.MenuHighlight;
            PainelConfirma.BackgroundImage = global::Local_Money.Properties.Resources.check_mark;
            PainelCartao.Cursor = Cursors.Default;
            PainelCartao.Enabled = false;
            */
        }
    }
}
