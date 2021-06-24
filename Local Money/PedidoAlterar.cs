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
                    btn_mesa.Ocupado();
                flp_mesas.Controls.Add(btn_mesa.Criar());

            }

            con.fechar();
        }

       
    }
}
