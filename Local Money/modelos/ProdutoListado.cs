using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using NPOI.SS.Util;

namespace Local_Money.modelos
{
    class ProdutoListado
    {
        PedidoNovo pn = (PedidoNovo)Application.OpenForms[2];
        private string[] ss;
        private double valor_produto, total_produto, subtotal_geral;
        private int Id;
        //public int Mesa;
        DecimalFormat df = new DecimalFormat("#.##");

        public Panel PainelProduto = new Panel
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
            pn.lbl_subtotal_valor.Text = "Kz " + df.Format((float.Parse(ss[1]) + valor_produto));

            Adicionar.Click += new EventHandler(this.AdicinarQuantidade);
            Retirar.Click += new EventHandler(this.SubtrairQuantidade);
            Apagar.Click += new EventHandler(this.RetirarProduto);

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
            BackColor = Color.DarkSlateGray,
            Location = new Point(16, 34),
            Size = new Size(67, 2),
        };

        Panel PainelBaixo = new Panel
        {
            BackColor = Color.DarkSlateGray,
            Location = new Point(16, 66),
            Size = new Size(67, 2),
        };

        Panel PainelEsquerda = new Panel
        {
            BackColor = System.Drawing.Color.DarkSlateGray,
            Location = new Point(16, 36),
            Size = new Size(2, 30),
        };

        Panel PainelDireita = new Panel
        {
            BackColor = Color.DarkSlateGray,
            Location = new Point(81, 36),
            Size = new Size(2, 30),
        };

        public Label NomeProduto = new Label
        {
            Location = new Point(6, 7),
            Font = new Font("Roboto", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
            Padding = new Padding(5, 5, 0, 0),
            Size = new Size(72, 24),
            TextAlign = ContentAlignment.MiddleCenter,
            AutoSize = true,
            Tag = "3",
        };

        public Label ValorProduto = new Label
        {
            Location = new Point(103, 52),
            Font = new Font("Roboto", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
            Size = new Size(51, 15),
            TextAlign = ContentAlignment.MiddleCenter,
            AutoSize = true,
            Tag = "1",
        };

        public Label TotalProduto = new Label
        {
            Location = new Point(217, 47),
            Font = new Font("Roboto", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
            Size = new Size(89, 20),
            TextAlign = ContentAlignment.MiddleCenter,
            Padding = new Padding(5, 5, 0, 0),
            AutoSize = true,
            Text = "Kz 0",
            Tag = "2",
        };

        public Label QuantidadeProduto = new Label
        {
            Location = new Point(19, 44),
            Font = new Font("Roboto", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
            Size = new Size(14, 15),
            TextAlign = ContentAlignment.MiddleCenter,
            AutoSize = true,
            Text = "1",
            Tag = "0",
        };

        Button Retirar = new Button
        {
            BackColor = Color.DarkSlateGray,
            FlatStyle = FlatStyle.Flat,
            Image = Properties.Resources.down_arrow2,
            Location = new Point(60, 51),
            Size = new Size(23, 15),
            UseVisualStyleBackColor = false,
            Cursor = Cursors.Hand,
            Enabled = false,
        };

        Button Adicionar = new Button
        {
            BackColor = Color.DarkSlateGray,
            FlatStyle = FlatStyle.Flat,
            Image = Properties.Resources.up_arrow2,
            Location = new Point(60, 36),
            Size = new Size(23, 15),
            UseVisualStyleBackColor = false,
            Cursor = Cursors.Hand,
        };

        PictureBox Apagar = new PictureBox
        {
            Image = Properties.Resources.delete__1_,
            Location = new Point(276, 6),
            Size = new Size(32, 32),
            SizeMode = PictureBoxSizeMode.AutoSize,
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
            TotalProduto.Text = "Kz " + df.Format(total_produto);


            ss = pn.lbl_subtotal_valor.Text.Split(' ');
            subtotal_geral = float.Parse(ss[1]) + valor_produto;
            pn.lbl_subtotal_valor.Text = "Kz " + df.Format(subtotal_geral);

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
            TotalProduto.Text = "Kz " + df.Format(total_produto);

            ss = pn.lbl_subtotal_valor.Text.Split(' ');
            subtotal_geral = float.Parse(ss[1]) - valor_produto;
            pn.lbl_subtotal_valor.Text = "Kz " + df.Format(subtotal_geral);

        }

        private void RetirarProduto(object sender, EventArgs e)
        {

            string[] vv = ValorProduto.Text.Split(' ');
            total_produto = int.Parse(QuantidadeProduto.Text) * float.Parse(vv[1]);
            ss = pn.lbl_subtotal_valor.Text.Split(' ');
            subtotal_geral = float.Parse(ss[1]) - total_produto;
            pn.lbl_subtotal_valor.Text = "Kz " + df.Format(subtotal_geral);
            int index;

            if (pn.produtos.Contains(Id))
            {
                index = pn.produtos.IndexOf(Id);
                pn.produtos.Remove(Id);
                
                if(pn.totais.Count > 0)
                {
                    pn.totais.RemoveAt(index);
                    pn.subtotais.RemoveAt(index);
                    pn.nomes.RemoveAt(index);
                    pn.quantidades.RemoveAt(index);
                }
                
            }
                

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
