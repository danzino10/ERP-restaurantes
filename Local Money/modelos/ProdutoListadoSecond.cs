using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Local_Money.modelos
{
    class ProdutoListadoSecond
    {
        public ProdutoListadoSecond(string nome, int quantidade, string estado)
        {

            NomeProduto.Text = nome;
            QuantidadeProduto.Text = quantidade.ToString();
            EstadoProduto.Text = estado;

            PainelProduto.Controls.Add(QuantidadeProduto);
            PainelProduto.Controls.Add(NomeProduto);
            PainelProduto.Controls.Add(EstadoProduto);

        }

        private Panel PainelProduto = new Panel
        {
            Height = 60,
            Dock = DockStyle.Top,
        };

        private Label NomeProduto = new Label
        {
            Location = new Point(135, 20),
            Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
            Padding = new Padding(5, 5, 0, 0),
            Size = new Size(72, 24),
            TextAlign = ContentAlignment.MiddleCenter,
            AutoSize = true,        };

        private Label QuantidadeProduto = new Label
        {
            Location = new Point(45, 20),
            Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
            Padding = new Padding(5, 5, 0, 0),
            TextAlign = ContentAlignment.MiddleCenter,
            AutoSize = true,
        };

        private Label EstadoProduto = new Label
        {
            Location = new Point(350, 20),
            Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
            Padding = new Padding(5, 5, 0, 0),
            TextAlign = ContentAlignment.MiddleCenter,
            AutoSize = true,
        };

        public Panel CriarPainel()
        {
            return PainelProduto;
        }
    }
}
