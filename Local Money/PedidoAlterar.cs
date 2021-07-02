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
                CommandText = "SELECT * FROM tb_mesa",
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
                CommandText = "SELECT id_produto FROM tb_pedido_currente WHERE id_mesa = '" + mesa,
                Connection = con.SaberConexao(),
            };
            SqlDataReader reader = com.ExecuteReader();

            if(reader.HasRows)
            {
                List<int> id = new List<int>();
                string[] nomes;
                int i = 0;
                while(reader.Read())
                {
                    id.Add(reader.GetInt32(0));
                    i++;
                }
                nomes = new string[i];

                reader.Close();

                i = 0;
                foreach(int item in id)
                {
                    SqlCommand com2 = new SqlCommand
                    {
                        CommandText = "SELECT nome FROM tb_produto WHERE id_produto = '" + id.ElementAt(i),
                        Connection = con.SaberConexao(),
                    };
                    SqlDataReader reader2 = com2.ExecuteReader();
                    while(reader2.Read())
                    {
                        nomes[i] = reader2.GetString(0);
                    }
                    reader2.Close();
                    i++;
                }

                i = 0;
                SqlCommand com3 = new SqlCommand
                {
                    CommandText = "SELECT * FROM tb_pedido_currente WHERE id_mesa = '" + mesa,
                    Connection = con.SaberConexao(),
                };
                SqlDataReader reader3 = com.ExecuteReader();
                while(reader3.Read())
                {
                    ProdutoListadoSecond pls = new ProdutoListadoSecond(nomes[i], reader3.GetInt32(3), reader3.GetString(4));
                    flp_produto_listado.Controls.Add(pls.CriarPainel());
                    i++;
                }
            }
            


            con.fechar();
        }
       
    }
}
