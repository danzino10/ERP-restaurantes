using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Local_Money.modelos
{
    class ProdutoListadoSecond
    {
        private string Nome, Estado;
        private int Quantidade, Id;
        Conexao con = new Conexao();

        public ProdutoListadoSecond(string nome, int quantidade, string estado, int id, int mesa)
        {
            Nome = nome;
            Quantidade = quantidade;
            Estado = estado;
            Id = id;

            NomeProduto.Text = nome;
            QuantidadeProduto.Text = quantidade.ToString();
            EstadoProduto.Text = estado;

            EstadoCozinha.Click += (sender2, e2) => MudarCozinha(sender2, e2, mesa);
            EstadoMesa.Click += (sender2, e2) => MudarMesa(sender2, e2, mesa);

            PainelProduto.Controls.Add(QuantidadeProduto);
            PainelProduto.Controls.Add(NomeProduto);
            PainelProduto.Controls.Add(EstadoProduto);
            PainelProduto.Controls.Add(EstadoCozinha);
            PainelProduto.Controls.Add(EstadoMesa);
            PainelProduto.Controls.Add(Separador);
            PainelProduto.Tag = id;
        }

        private Panel PainelProduto = new Panel
        {
            Height = 60,
            Width = 527,
            Dock = DockStyle.Top,
        };

        private Panel Separador = new Panel
        {
            Height = 2,
            Dock = DockStyle.Bottom,
            BackColor = Color.DarkSlateGray,
        };

        private Label NomeProduto = new Label
        {
            Location = new Point(120, 15),
            Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
            Padding = new Padding(5, 5, 0, 0),
            Size = new Size(72, 24),
            TextAlign = ContentAlignment.MiddleCenter,
            AutoSize = true,        
        };

        private Label QuantidadeProduto = new Label
        {
            Location = new Point(35, 20),
            Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
            Padding = new Padding(5, 5, 0, 0),
            TextAlign = ContentAlignment.MiddleCenter,
            AutoSize = true,
            Tag = "1",
        };

        private Label EstadoProduto = new Label
        {
            Location = new Point(320, 20),
            Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
            Padding = new Padding(5, 5, 0, 0),
            TextAlign = ContentAlignment.MiddleCenter,
            AutoSize = true,
        };

        private Button EstadoCozinha = new Button
        {
            Location = new Point(440, 13),
            Padding = new Padding(5, 5, 0, 0),
            AutoSize = true,
            BackgroundImageLayout = ImageLayout.Zoom,
            BackgroundImage = Properties.Resources.check_mark,
            BackColor = Color.DarkSlateGray,
            Width = 35,
            Height = 35,
            FlatStyle = FlatStyle.Flat,

        };

        private Button EstadoMesa = new Button
        {
            Location = new Point(480, 13),
            Padding = new Padding(5, 5, 0, 0),
            AutoSize = true,
            BackgroundImageLayout = ImageLayout.Zoom,
            BackgroundImage = Properties.Resources.cancel_button,
            BackColor = Color.Brown,
            Width = 35,
            Height = 35,
            FlatStyle = FlatStyle.Flat,
        };

        private void MudarCozinha(object sender, EventArgs e, int mesa)
        {
            EstadoProduto.Text = "Pronto";
            con.abrir();
            SqlCommand com = new SqlCommand
            {
                CommandText = "UPDATE tb_pedido_currente SET estado = 'Pronto' WHERE id_mesa = '" + mesa + "' AND id_produto = '" + Id + "'",
                Connection = con.SaberConexao(),
            };
            com.ExecuteNonQuery();
            con.fechar();
        }

        private void MudarMesa(object sender, EventArgs e, int mesa)
        {
            EstadoProduto.Text = "Em preparo";
            con.abrir();
            SqlCommand com = new SqlCommand
            {
                CommandText = "UPDATE tb_pedido_currente SET estado = 'Em preparo' WHERE id_mesa = '" + mesa + "' AND id_produto = '" + Id + "'",
                Connection = con.SaberConexao(),
            };
            com.ExecuteNonQuery();
            con.fechar();
        }

        public Panel CriarPainel()
        {
            return PainelProduto;
        }
    }
}
