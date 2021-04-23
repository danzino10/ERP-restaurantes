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

namespace Local_Money
{
    public partial class PedidoNovo : Form
    {
        Conexao con = new Conexao();
        int id_cat;

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

        private void p_navegador_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con.abrir();

            try
            {
                SqlCommand com = new SqlCommand
                {
                    Connection = con.SaberConexao(),
                    CommandText = "SELECT * FROM tb_produto WHERE nome = '" + textBox1.Text + "'",
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
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Erro!!!!! " + er);
            }

            con.fechar();
        }
    }
}
