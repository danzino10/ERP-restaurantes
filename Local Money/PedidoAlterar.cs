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
using Local_Money.modelos;

namespace Local_Money
{
    public partial class PedidoAlterar : Form
    {
        Conexao con = new Conexao();
        public int Selec = 0;
        public int Mesa;
        public PedidoAlterar()
        {
            InitializeComponent();
        }

        private void PedidoAlterar_Load(object sender, EventArgs e)
        {
            con.abrir();

            SqlCommand com = new SqlCommand
            {
                CommandText = "SELECT * FROM tb_mesa WHERE estado = 'ocupado'",
                Connection = con.SaberConexao(),
            };

            SqlDataReader reader2 = com.ExecuteReader();
            while (reader2.Read())
            {

                BotaoMesa btn_mesa = new BotaoMesa(reader2.GetInt32(0));
                if (reader2.GetString(1) == "ocupado")
                {
                    btn_mesa.OcupadoAlterar();
                    flp_mesas.Controls.Add(btn_mesa.Criar());
                }
                    

            }

            con.fechar();
        }

        public void MostrarMesa(int mesa)
        {
            con.abrir();

            SqlCommand com = new SqlCommand
            {
                CommandText = "SELECT * FROM tb_pedido_currente WHERE id_mesa = '" + mesa + "'",
                Connection = con.SaberConexao(),
            };
            SqlDataReader reader = com.ExecuteReader();

            if (reader.HasRows)
            {
                flp_produto_listado.Controls.Clear();
                while (reader.Read())
                {
                    ProdutoListadoSecond pls = new ProdutoListadoSecond(reader.GetString(6), reader.GetInt32(3), reader.GetString(4), reader.GetInt32(2), mesa);
                    flp_produto_listado.Controls.Add(pls.CriarPainel());
                }
            }

            con.fechar();
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            PedidoNovo pn = new PedidoNovo();
            pn.mesa = Mesa;
            frm_dashboard d = (frm_dashboard)Application.OpenForms[1];
            double total = 0;
            foreach (Control pls in flp_produto_listado.Controls)
            {
                con.abrir();

                SqlCommand com = new SqlCommand
                {
                    CommandText = "SELECT * FROM tb_produto WHERE id_produto = '" + pls.Tag + "'",
                    Connection = con.SaberConexao(),
                };
                SqlDataReader reader = com.ExecuteReader();
                
                if (reader.HasRows)
                {
                    int quantidade = 1;
                    foreach(Control qtd in pls.Controls)
                    {
                        if(qtd is Label && qtd.Tag == "1")
                        {
                            quantidade = int.Parse(qtd.Text);
                        }
                    }
                    
                    while(reader.Read())
                    {
                        ProdutoListado pl = new ProdutoListado(reader.GetString(3), "Kz " + reader.GetValue(4).ToString(), reader.GetInt32(0), quantidade, quantidade, new PedidoNovo());
                        pl.Apagar.Enabled = false;
                        pn.p_lista_produtos.Controls.Add(pl.Criar());

                        total += quantidade * float.Parse(reader.GetValue(4).ToString());
                    }

                    
                }
                
                con.fechar();
            }
            pn.lbl_subtotal_valor.Text = "Kz " + total;
            d.AbrirJanela(pn);
        }
    }
}
