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
        Conexao con = new Conexao();
        int x = 1, y = 0;
        TableLayoutPanel tlfp_cartao = new TableLayoutPanel
        {
            Width = 120,
            Height = 150,
            ColumnCount = 1,
            RowCount = 2,
        };

        public CartaoProduto(string nome, int i, Image imagem, Label lbl_mesa, Label lbl_total, Label lbl_subtot, TableLayoutPanel tlp_pedido)
        { 
            
            
            tlfp_cartao.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlfp_cartao.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlfp_cartao.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));

            PictureBox pb_cartao = new PictureBox
            {
                Width = 114,
                Height = 117,
                Image = imagem,
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
            tlfp_cartao.Controls.Add(pb_cartao, 0, 0);

            Button btn_cartao = new Button
            {
                Width = 114,
                Height = 21,
                Text = nome,
                TextAlign = ContentAlignment.BottomCenter,
                
            };
            tlfp_cartao.Controls.Add(btn_cartao, 0, 1);

            int id_produto = i;
            btn_cartao.MouseClick += (s, e) => {

                con.abrir();



                SqlCommand com = new SqlCommand
                {
                    Connection = con.SaberConexao(),
                    CommandText = "SELECT * FROM tb_produto WHERE id_produto = '" + i + "'",
                };
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetString(7) == "indisponível")
                    {
                        MessageBox.Show("Este produto encontra-se indisponível\n Contacte o cozinheiro ou a logistica para mais informações");
                    }
                    else
                    {

                        if (lbl_mesa.Tag.ToString() == "0")
                        {
                            MessageBox.Show("Deu certo");
                        }



                        Label lbl_id = new Label
                        {
                            Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Bottom),
                            Text = reader.GetValue(0).ToString(),
                            Font = new Font("Arial", 9F),
                        };

                        Label lbl_nome = new Label
                        {
                            Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Bottom),
                            Text = reader.GetString(3),
                            Font = new Font("Arial", 9F),
                        };

                        Label lbl_qtd = new Label
                        {
                            Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Bottom),
                            Text = "1",
                            Font = new Font("Arial", 9F),
                        };

                        Label lbl_valor = new Label
                        {
                            Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Bottom),
                            Text = reader.GetValue(4).ToString(),
                            Font = new Font("Arial", 9F),
                        };

                        float conta = float.Parse(lbl_valor.Text) * int.Parse(lbl_qtd.Text);
                        Label lbl_subtotal = new Label
                        {
                            Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Bottom),
                            Text = conta.ToString(),
                            Font = new Font("Arial", 9F),
                        };


                        Label lbl_adicionar = new Label
                        {
                            Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Bottom),
                            Text = "+",
                            Font = new Font("Arial", 9F, (FontStyle)(FontStyle.Bold)),
                            
                        };

                        Label lbl_remover = new Label
                        {
                            Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Bottom),
                            Text = "-",
                            Font = new Font("Arial", 9F, (FontStyle)(FontStyle.Bold)),
                        };


                        string[] tot = lbl_total.Text.Split(' ');
                        lbl_total.Text = (float.Parse(tot[0]) + conta).ToString() + " Kz";
                        string[] subtot = lbl_total.Text.Split(' ');
                        lbl_subtot.Text = (float.Parse(subtot[0]) + (float.Parse(subtot[0])) * 14 / 100).ToString() + " Kz";

                        tlp_pedido.RowCount++;
                        tlp_pedido.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
                        tlp_pedido.Controls.Add(lbl_id, y, x);
                        tlp_pedido.Controls.Add(lbl_nome, y + 1, x);
                        tlp_pedido.Controls.Add(lbl_qtd, y + 2, x);
                        tlp_pedido.Controls.Add(lbl_valor, y + 3, x);
                        tlp_pedido.Controls.Add(lbl_subtotal, y + 4, x);
                        tlp_pedido.Controls.Add(lbl_adicionar, y + 5, x);
                        tlp_pedido.Controls.Add(lbl_remover, y + 6, x);
                        x++;
                        

                    }
                }

                con.fechar();


            };
        }

        public TableLayoutPanel CriarCartao()
        {
            return tlfp_cartao;
        }
    }
}
