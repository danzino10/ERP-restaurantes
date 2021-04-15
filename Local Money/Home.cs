 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Local_Money
{
    public partial class Home : Form
    {
        public int Id;
        public string Nome;
        public int Telefone;
        public float Saldo;
        public string Email;
        public int categoria;
        Conexao con = new Conexao();
        int x = 1, y = 0;

        public Home()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_bebidas_Click(object sender, EventArgs e)
        {
            if(lbl_mesa.Tag.ToString() == "0")
            {
                MessageBox.Show("Não é possível iniciar um pedido sem registar antes a mesa ou take-away");
            }
            else
            {
                Cardapio carp = new Cardapio { Dock = DockStyle.Fill, TopMost = true, TopLevel = false };
                this.p_view.Controls.Clear();
                this.p_view.Controls.Add(carp);
                carp.catNum = 1;
                carp.Show();

                btn_bebidas.Enabled = false;
                btn_promo.Enabled = true;
                btn_pratos.Enabled = true;
                btn_entradas.Enabled = true;
                btn_pastelaria.Enabled = true;
            }

            

            /*
            con.abrir();
            try
            {
                SqlCommand com = new SqlCommand
                {
                    Connection = con.SaberConexao(),
                    CommandText = "SELECT * FROM tb_categoria WHERE id_menu = '1'"
                };
                SqlDataReader reader = com.ExecuteReader();
                while(reader.Read())
                {
                    //flp_sub.Controls.Add(BotaoMenu(reader.GetInt32(0).ToString() + " - " + reader.GetString(1), reader.GetInt32(0)));
                }
                reader.Close();
            }
            catch(Exception er)
            {
                MessageBox.Show("Erro! " + er);
            }
            con.fechar();
            */

            
        }

        private void btn_pastelaria_Click(object sender, EventArgs e)
        {
            if (lbl_mesa.Tag.ToString() == "0")
            {
                MessageBox.Show("Não é possível iniciar um pedido sem registar antes a mesa ou take-away");
            }
            else
            {
                Cardapio carp = new Cardapio { Dock = DockStyle.Fill, TopMost = true, TopLevel = false };
                this.p_view.Controls.Clear();
                this.p_view.Controls.Add(carp);
                carp.catNum = 3;
                carp.Show();

                btn_bebidas.Enabled = true;
                btn_promo.Enabled = true;
                btn_pratos.Enabled = true;
                btn_entradas.Enabled = true;
                btn_pastelaria.Enabled = false;
            }
            

            /*
            con.abrir();
            try
            {
                SqlCommand com = new SqlCommand
                {
                    Connection = con.SaberConexao(),
                    CommandText = "SELECT * FROM tb_categoria WHERE id_menu = '3'"
                };
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    //flp_sub.Controls.Add(BotaoMenu(reader.GetInt32(0).ToString() + " - " + reader.GetString(1), reader.GetInt32(0)));
                }
                reader.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show("Erro! " + er);
            }
            con.fechar();
            */

            
        }

        private void btn_entradas_Click(object sender, EventArgs e)
        {

            if (lbl_mesa.Tag.ToString() == "0")
            {
                MessageBox.Show("Não é possível iniciar um pedido sem registar antes a mesa ou take-away");
            }
            else
            {
                Cardapio carp = new Cardapio { Dock = DockStyle.Fill, TopMost = true, TopLevel = false };
                this.p_view.Controls.Clear();
                this.p_view.Controls.Add(carp);
                carp.catNum = 5;
                carp.Show();

                lbl_cat.Text = btn_entradas.Text;

                btn_bebidas.Enabled = true;
                btn_promo.Enabled = true;
                btn_pratos.Enabled = true;
                btn_entradas.Enabled = false;
                btn_pastelaria.Enabled = true;
            }
            
        }

        private void btn_promo_Click(object sender, EventArgs e)
        {

            if (lbl_mesa.Tag.ToString() == "0")
            {
                MessageBox.Show("Não é possível iniciar um pedido sem registar antes a mesa ou take-away");
            }
            else
            {
                Cardapio carp = new Cardapio { Dock = DockStyle.Fill, TopMost = true, TopLevel = false };
                this.p_view.Controls.Clear();
                this.p_view.Controls.Add(carp);
                carp.catNum = 2;
                carp.Show();

                lbl_cat.Text = btn_promo.Text;

                btn_bebidas.Enabled = true;
                btn_promo.Enabled = false;
                btn_pratos.Enabled = true;
                btn_entradas.Enabled = true;
                btn_pastelaria.Enabled = true;
            }
            
        }

        private void btn_pratos_Click(object sender, EventArgs e)
        {
            if (lbl_mesa.Tag.ToString() == "0")
            {
                MessageBox.Show("Não é possível iniciar um pedido sem registar antes a mesa ou take-away");
            }
            else
            {
                Cardapio carp = new Cardapio { Dock = DockStyle.Fill, TopMost = true, TopLevel = false };
                this.p_view.Controls.Clear();
                this.p_view.Controls.Add(carp);
                carp.catNum = 4;
                carp.Show();

                btn_bebidas.Enabled = true;
                btn_promo.Enabled = true;
                btn_pratos.Enabled = false;
                btn_entradas.Enabled = true;
                btn_pastelaria.Enabled = true;
            }
            

            

            /*
            con.abrir();
            try
            {
                SqlCommand com = new SqlCommand
                {
                    Connection = con.SaberConexao(),
                    CommandText = "SELECT * FROM tb_categoria WHERE id_menu = '4'",
                };
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    string nome = reader.GetInt32(0) + " - " + reader.GetString(1);
                    int id = reader.GetInt32(0);
                    p_view.Controls.Add(BotaoMenu(nome, id));
                }
                reader.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show("Erro! " + er);
            }
            con.fechar();
            */


            
        }

        public Button BotaoMenu (string nome, int valor)
        {
            string[] nn = nome.Split('-');
            Button btn = new Button
            {
                Width = 105,
                Height = 68,
                Text = nome,
                Tag = valor,
            };
            btn.MouseClick += (s, e) => {
                p_view.Controls.Clear();
                con.abrir();
                lbl_cat.Text = nome;
                SqlCommand com = new SqlCommand
                {
                    Connection = con.SaberConexao(),
                    CommandText = "SELECT * FROM tb_produto WHERE id_categoria = @categoria" ,
                };
                SqlParameter categoria = new SqlParameter("@categoria", SqlDbType.Int);
                categoria.Value = int.Parse(nn[0]);
                com.Parameters.Add(categoria);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    byte[] foto = (byte[])(reader[5]);
                    Image imagem;
                    if (foto == null)
                    {
                        imagem = null;
                    }
                    else
                    {
                        MemoryStream memory = new MemoryStream(foto);
                        imagem = Image.FromStream(memory);
                    }
                    p_view.Controls.Add(Cartao(reader.GetInt32(0).ToString() + " - " +  reader.GetString(3), reader.GetInt32(0), imagem));                   
                }
                reader.Close();
                con.fechar();
            };
            return btn;
        }

        TableLayoutPanel Cartao(string nome, int i, Image imagem)
        {
            string[] nn = nome.Split('-'); 
            TableLayoutPanel tlfp_cartao = new TableLayoutPanel
            {
                Width = 120,
                Height = 150,
                ColumnCount = 1,
                RowCount = 2,
            };
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
                TabIndex = i,
            };


            int id_produto = int.Parse(nn[0].Trim());
            btn_cartao.MouseClick += (s, e) => {

                con.abrir();

                

                SqlCommand com = new SqlCommand
                {
                    Connection = con.SaberConexao(),
                    CommandText = "SELECT * FROM tb_produto WHERE id_produto = '" + nn[0] + "'",
                };
                SqlDataReader reader = com.ExecuteReader();
                while(reader.Read())
                {
                    if(reader.GetString(7) == "indisponível")
                    {
                        MessageBox.Show("Este produto encontra-se indisponível\n Contacte o cozinheiro ou a logistica para mais informações");
                    }
                    else
                    {

                        if(lbl_mesa.Tag.ToString() == "0")
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



                        string[] tot = lbl_total.Text.Split(' ');
                        lbl_total.Text = (float.Parse(tot[0])+conta).ToString() + " Kz";
                        string[] subtot = lbl_total.Text.Split(' ');
                        lbl_subtot.Text = (float.Parse(subtot[0])+(float.Parse(subtot[0]))*14/100).ToString() + " Kz";

                        tlp_pedido.RowCount++;
                        tlp_pedido.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
                        tlp_pedido.Controls.Add(lbl_id, y, x);
                        tlp_pedido.Controls.Add(lbl_nome, y + 1, x);
                        tlp_pedido.Controls.Add(lbl_qtd, y + 2, x);
                        tlp_pedido.Controls.Add(lbl_valor, y + 3, x);
                        tlp_pedido.Controls.Add(lbl_subtotal, y + 4, x);
                        x++;
                        
                    }
                }

                con.fechar();

                

                             

            };

            tlfp_cartao.Controls.Add(btn_cartao, 0, 1);

            return tlfp_cartao;
            
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            Pedidos ped = new Pedidos { Dock = DockStyle.Fill, TopMost = true, TopLevel = false};
            this.p_view.Controls.Clear();
            this.p_view.Controls.Add(ped);
            ped.Show();
        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {

        }

        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            AdicionarProduto ap = new AdicionarProduto();
            ap.ShowDialog();
        }

        
    }
}
