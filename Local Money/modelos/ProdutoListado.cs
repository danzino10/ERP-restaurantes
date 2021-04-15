using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Local_Money.modelos
{
    class ProdutoListado
    {

        Panel PainelProduto = new Panel
        {
            Width = 320,
            Height = 75,
            Dock = DockStyle.Top,
        };

        public ProdutoListado()
        {
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
            Text = "Picanha",
        };

        Label ValorProduto = new Label
        {
            Location = new System.Drawing.Point(103, 52),
            Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
            Size = new System.Drawing.Size(51, 15),
            TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
            AutoSize = true,
            Text = "Kz 7500,00",
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
        };

        Button Adicionar = new Button
        {
            BackColor = System.Drawing.Color.DarkSlateGray,
            FlatStyle = System.Windows.Forms.FlatStyle.Flat,
            Image = global::Local_Money.Properties.Resources.down_arrow2,
            Location = new System.Drawing.Point(60, 51),
            Size = new System.Drawing.Size(23, 15),
            UseVisualStyleBackColor = false,
        };

        Button Retirar = new Button
        {
            BackColor = System.Drawing.Color.DarkSlateGray,
            FlatStyle = System.Windows.Forms.FlatStyle.Flat,
            Image = global::Local_Money.Properties.Resources.up_arrow2,
            Location = new System.Drawing.Point(60, 36),
            Size = new System.Drawing.Size(23, 15),
            UseVisualStyleBackColor = false,
        };

        PictureBox Apagar = new PictureBox
        {
            Image = global::Local_Money.Properties.Resources.delete__1_,
            Location = new System.Drawing.Point(276, 6),
            Size = new System.Drawing.Size(32, 32),
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize,
            TabStop = false,
        };

        public Panel CriarProdutoListado()
        {
            return PainelProduto;
        }
    }
}
