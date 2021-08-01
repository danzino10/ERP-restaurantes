using Local_Money.modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Collections;
using NPOI.SS.Util;

namespace Local_Money
{
    public partial class PedidoNovo : Form
    {
        private Conexao con = new Conexao();
        private int id_cat;
        private double ta = 800.00;
        public int mesa;
        public int numero_pedido;
        public int numero_produtos = 0;
        public List<int> produtos = new List<int>();
        public List<int> quantidades = new List<int>();
        public List<double> subtotais = new List<double>();
        public List<double> totais = new List<double>();
        public List<string> nomes = new List<string>();
        DecimalFormat df = new DecimalFormat("#.##");

        public PedidoNovo()
        {
            InitializeComponent();
        }


        private void btn_add_prod_Click(object sender, EventArgs e)
        {
             
        }

        private void PedidoNovo_Load(object sender, EventArgs e)
        {
            lbl_takeaway_valor.Text = "Kz " + ta;
            con.abrir();
            try
            {
                

                SqlCommand com = new SqlCommand
                {
                    Connection = con.SaberConexao(),
                    CommandText = "SELECT * FROM tb_menu",
                };
                SqlDataReader reader = com.ExecuteReader();

                while(reader.Read())
                {
                    CartaoCategoriaCardapio cartao = new CartaoCategoriaCardapio(reader.GetString(1), reader.GetInt32(0), flp_cardapio);
                    flp_cardapio.Controls.Add(cartao.Criar());
                    
                }
                reader.Close();

                
                SqlCommand com2 = new SqlCommand
                {
                    Connection = con.SaberConexao(),
                    CommandText = "SELECT TOP 1 id_pedido FROM tb_pedido_concluido ORDER BY id_pedido DESC",
                };
                SqlDataReader reader2 = com2.ExecuteReader();

                if(reader2.HasRows)
                {
                    while(reader2.Read())
                    {
                        numero_pedido = reader2.GetInt32(0);
                    }
                }
                reader2.Close();

                SqlCommand com3 = new SqlCommand
                {
                    Connection = con.SaberConexao(),
                    CommandText = "SELECT TOP 1 id_pedido FROM tb_pedido_currente ORDER BY id_pedido DESC",
                };
                SqlDataReader reader3 = com3.ExecuteReader();

                if (reader3.HasRows)
                {
                    while (reader3.Read())
                    {
                        if (reader3.GetInt32(0) > numero_pedido)
                        {
                            numero_pedido = reader2.GetInt32(0);
                        }
                    }
                }

                lbl_num_pedido.Text = (numero_pedido + 1).ToString();
                
            }
            catch(Exception er)
            {
                MessageBox.Show("Erro!!!!!! " + er);
            }
            con.fechar();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            id_cat = 1;
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
                    //CartaoSubCategoriaCardapio cartao = new CartaoSubCategoriaCardapio(reader.GetString(1), reader.GetInt32(2));
                    //flp_cardapio.Controls.Add(cartao.Criar());
                }
            }
            catch(Exception er)
            {
                MessageBox.Show("Erro!!!!! " + er);
            }

            con.fechar();
        }
        public void lbl_subtotal_valor_TextChanged(object sender, EventArgs e)
        {
            string[] st = lbl_subtotal_valor.Text.Split(' ');
            float subtotal = float.Parse(st[1]);
            
            string[] tt = lbl_total_valor.Text.Split(' ');
            float total = float.Parse(st[1]);

            total = subtotal + subtotal * 14/100;
            lbl_total_valor.Text = "Kz " + total;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con.abrir();

            try
            {
                SqlCommand com = new SqlCommand
                {
                    Connection = con.SaberConexao(),
                    CommandText = "SELECT * FROM tb_produto WHERE nome LIKE '" + txt_pesquisar.Text + "%'",
                };
                SqlDataReader reader = com.ExecuteReader();

                flp_cardapio.Controls.Clear();
                while (reader.Read())
                {
                    byte[] dados = (byte[])(reader.GetValue(5));
                    MemoryStream mem = new MemoryStream(dados);
                    bool disp;
                    if (reader.GetString(7) == "disponível")
                        disp = true;
                    else
                        disp = false;

                    CartaoProduto cartao = new CartaoProduto(reader.GetString(3), disp, float.Parse(reader.GetValue(4).ToString()), reader.GetInt32(0), Image.FromStream(mem));
                    flp_cardapio.Controls.Add(cartao.Criar());
                    if (numero_produtos > 0)
                    {
                        if(produtos.Contains(reader.GetInt32(0)))
                        {
                            cartao.selecionado();
                        }
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Erro!!!!! " + er);
            }

            con.fechar();
        }

        private void txt_pesquisar_Click(object sender, EventArgs e)
        {
            txt_pesquisar.Text = "";
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if (p_lista_produtos.Controls.Count == 0)
            {
                MessageBox.Show("Nenhum produto foi selecionado");
            }
            else
            {
                if(mesa == 0)
                {
                    GuardarPedido gp = new GuardarPedido();
                    gp.ShowDialog();
                }
                else
                {
                    con.abrir();

                    SqlCommand com3 = new SqlCommand
                    {
                        CommandText = "DELETE FROM tb_pedido_currente WHERE id_mesa = '" + mesa + "'",
                        Connection = con.SaberConexao(),
                    };
                    com3.ExecuteNonQuery();

                    AddNomes();
                    AddQuantidade();                    
                    
                    int i = 0;
                    foreach (Control pl in p_lista_produtos.Controls)
                    {
                        SqlCommand com2 = new SqlCommand
                        {
                            CommandText = "INSERT INTO tb_pedido_currente (id_mesa,id_produto,estado,quantidade,id_pedido,nome) VALUES ('" + mesa + "', '" + pl.Tag + "', 'Em preparo', '" + quantidades[i] + "', '" + numero_pedido + "','" + nomes[i] + "')",
                            Connection = con.SaberConexao(),
                        };
                        com2.ExecuteNonQuery();
                        i++;
                    }
                    con.fechar();
                    MessageBox.Show("Pedido Salvo com sucesso! \n\nEm preparação");
                    this.Close();
                } 
            }
        }

        private void btn_pagar_Click(object sender, EventArgs e)
        {
            if(p_lista_produtos.Controls.Count == 0)
            {
                MessageBox.Show("Nenhum produto foi selecionado");
            }
            else
            {              
                Pagamento p = new Pagamento();

                string[] separa = lbl_subtotal_valor.Text.Split(' ');
                p.Subtotal = double.Parse(separa[1]);

                separa = lbl_total_valor.Text.Split(' ');
                p.Total = double.Parse(separa[1]);

                separa = lbl_promodia_valor.Text.Split(' ');
                p.Descontos = double.Parse(separa[1]);

                p.Impostos = p.Total - p.Subtotal;
                p.mesa = mesa;
                p.ShowDialog();
            }
        }

        public void AddQuantidade()
        {
            quantidades.AddRange(from Control pl in p_lista_produtos.Controls
                                 where pl is Panel
                                 from Control p in pl.Controls
                                 where p is Label
                                 where p.Tag is "0"
                                 select int.Parse(p.Text));
        }

        public void AddSubtotal()
        {
            subtotais.AddRange(from Control pl in p_lista_produtos.Controls
                            where pl is Panel
                            from Control p in pl.Controls
                            where p is Label && p.Tag is "1"
                            let s = p.Text.Split(' ')
                            select double.Parse(s[1]));
        }

        public void AddTotal()
        {
            totais.AddRange(from Control pl in p_lista_produtos.Controls
                               where pl is Panel
                               from Control p in pl.Controls
                               where p is Label && p.Tag is "2"
                               let s = p.Text.Split(' ')
                               select double.Parse(s[1]));
        }

        public void AddNomes()
        {
            nomes.AddRange(from Control pl in p_lista_produtos.Controls
                           where pl is Panel
                           from Control p in pl.Controls
                           where p is Label && p.Tag is "3"
                           select p.Text);
        }

        int aux = 0;
        private void cb_takeaway_CheckedChanged(object sender, EventArgs e)
        {
            aux ++;
            if(aux%2 == 0)
            {
                string[] total = lbl_subtotal_valor.Text.Split(' ');
                double tot = double.Parse(total[1]);
                lbl_subtotal_valor.Text = "Kz " + (tot - ta);
            }
            else
            {
                string[] total = lbl_subtotal_valor.Text.Split(' ');
                double tot = double.Parse(total[1]);
                lbl_subtotal_valor.Text = "Kz " + (tot + ta);
            }

        }
    }
}
