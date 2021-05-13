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

            try
            {
                con.abrir();

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
                con.fechar();
            }
            catch(Exception er)
            {
                MessageBox.Show("Erro!!!!!! " + er);
            }

            
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

        private void panel7_Click(object sender, EventArgs e)
        {

        }

        private void lbl_subtotal_valor_TextChanged(object sender, EventArgs e)
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
            AddQuantidade();
            AddSubtotal();
            AddTotal();
            AddNomes();
            GuardarPedido gp = new GuardarPedido();
            gp.ShowDialog();
        }

        private void btn_pagar_Click(object sender, EventArgs e)
        {
            AddQuantidade();
            AddSubtotal();
            AddTotal();
            AddNomes();
            Pagamento p = new Pagamento();
            
            string[] separa = lbl_subtotal_valor.Text.Split(' ');
            p.Subtotal = double.Parse(separa[1]) ;
            
            separa = lbl_total_valor.Text.Split(' ');
            p.Total = double.Parse(separa[1]);
            
            separa = lbl_promodia_valor.Text.Split(' ');
            p.Descontos = double.Parse(separa[1]);

            separa = lbl_codpromo_valor.Text.Split(' ');
            p.Descontos = p.Descontos + double.Parse(separa[1]);

            
            p.ShowDialog();
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
            /*
            int qtd = 0;
            double preco = 0;
            foreach (Control pl in p_lista_produtos.Controls)
            {
                if(pl is Panel)
                {
                    
                    
                    foreach (Control p in pl.Controls)
                    {
                        if (p is Label && Tag is "1")
                        {
                            string[] separa = p.Text.Split(' ');
                            preco = double.Parse(separa[1]);
                        }
                        if (p is Label && Tag is "0")
                        {
                            qtd = int.Parse(p.Text);
                            totais.Add(qtd * preco);
                        }
                        
                    }
                }
            }
            */
        }

        public void AddNomes()
        {
            nomes.AddRange(from Control pl in p_lista_produtos.Controls
                           where pl is Panel
                           from Control p in pl.Controls
                           where p is Label && p.Tag is "3"
                           select p.Text);
        }
    }
}
